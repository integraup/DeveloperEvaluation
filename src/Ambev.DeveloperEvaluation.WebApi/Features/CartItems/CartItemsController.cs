using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;
using Ambev.DeveloperEvaluation.Application.CartItems.GetCartItems;
using Ambev.DeveloperEvaluation.Application.CartItems.DeleteCartItems;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItem.CreateCartItems;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItem.GetCartItems;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItem.DeleteCartItems;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.GetCartItems;
using Microsoft.AspNetCore.Authorization;

namespace Ambev.DeveloperEvaluation.WebApi.Features.GetCartItems;

/// <summary>
/// Controller for managing Cart item operations
/// </summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CartItemsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CartItemsController
    /// </summary>
    public CartItemsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new Cart item
    /// </summary>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCartItemResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCartItem([FromBody] CreateCartItemRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCartItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateCartItemCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateCartItemResponse>
        {
            Success = true,
            Message = "Cart item created successfully",
            Data = _mapper.Map<CreateCartItemResponse>(result)
        });
    }

    /// <summary>
    /// Retrieves an Cart item by its ID
    /// </summary>
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponseWithData<GetCartItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCartItem([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetCartItemRequest { Id = id };
        var validator = new GetCartItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetCartItemCommand>(request.Id);
        var result = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetCartItemResponse>
        {
            Success = true,
            Message = "Cart item retrieved successfully",
            Data = _mapper.Map<GetCartItemResponse>(result)
        });
    }

    /// <summary>
    /// Deletes an Cart item by its ID
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCartItem([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteCartItemRequest { Id = id };
        var validator = new DeleteCartItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteCartItemCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Cart item deleted successfully"
        });
    }


}

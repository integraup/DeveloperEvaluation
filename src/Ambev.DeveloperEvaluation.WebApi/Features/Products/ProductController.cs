using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Microsoft.AspNetCore.Authorization;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

/// <summary>
/// Controller for managing product operations.
/// </summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IMediator mediator, IMapper mapper, ILogger<ProductsController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando criação de produto {@Produto}", request);

        var validator = new CreateProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validação falhou: {@Erros}", validationResult.Errors);
            return BadRequest(validationResult.Errors);
        }

        var command = _mapper.Map<CreateProductCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);

        _logger.LogInformation("Produto criado com sucesso: {@Resultado}", result);

        return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
        {
            Success = true,
            Message = "Product created successfully",
            Data = _mapper.Map<CreateProductResponse>(result)
        });
    }

    /// <summary>
    /// Retrieves a product by ID.
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Recebida requisição para buscar produto com ID: {ProductId}", id);

        

        var request = new GetProductRequest { Id = id };
        var validator = new GetProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validação falhou ao buscar produto {ProductId}: {@Erros}", id, validationResult.Errors);
            return BadRequest(validationResult.Errors);
        }

        var command = new GetProductCommand(id);
        var response = await _mediator.Send(command, cancellationToken);

        if (response == null)
        {
            _logger.LogWarning("Produto com ID {ProductId} não encontrado", id);
            return NotFound(new ApiResponse
            {
                Success = false,
                Message = "Produto não encontrado"
            });
        }

        _logger.LogInformation("Produto {ProductId} recuperado com sucesso", id);

        return Ok(new ApiResponseWithData<GetProductResponse>
        {
            Success = true,
            Message = "Product retrieved successfully",
            Data = _mapper.Map<GetProductResponse>(response)
        });
    }

    /// <summary>
    /// Retrieves a paginated list of products with optional filtering and ordering.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<IEnumerable<GetProductResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductListRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando listagem de produtos com os filtros: {@Filtros}", request);

        var command = new GetProductListCommand(
            Title: request.Title,
            MinPrice: request.MinPrice,
            MaxPrice: request.MaxPrice,
            Page: request.Page,
            Size: request.Size,
            OrderBy: request.Order
        );

        var result = await _mediator.Send(command, cancellationToken);

        _logger.LogInformation("{Total} produtos retornados na listagem", result.Count());

        return Ok(new ApiResponseWithData<IEnumerable<GetProductResponse>>
        {
            Success = true,
            Message = "Products retrieved successfully",
            Data = _mapper.Map<IEnumerable<GetProductResponse>>(result)
        });
    }

    /// <summary>
    /// Deletes a product by ID.
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
     
        _logger.LogInformation("Recebida requisição para deletar produto com ID: {ProductId}", id);
        var request = new DeleteProductRequest { Id = id };
        var validator = new DeleteProductRequestValidator();
        
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validação falhou ao tentar deletar produto {ProductId}: {@Erros}", id, validationResult.Errors);
            return BadRequest(validationResult.Errors);
        }

        var command = _mapper.Map<DeleteProductCommand>(request.Id);
        
        await _mediator.Send(command, cancellationToken);

        _logger.LogInformation("Produto com ID {ProductId} deletado com sucesso", id);
        
        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Product deleted successfully"
        });
    }
}

using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.CartItems.GetCartItems;

/// <summary>
/// Handler for processing GetCartItemCommand requests.
/// </summary>
public class GetCartItemHandler : IRequestHandler<GetCartItemCommand, GetCartItemResult>
{
    private readonly ICartItemRepository _CartItemRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetCartItemHandler.
    /// </summary>
    /// <param name="CartItemRepository">The Cart item repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public GetCartItemHandler(
        ICartItemRepository CartItemRepository,
        IMapper mapper)
    {
        _CartItemRepository = CartItemRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetCartItemCommand request.
    /// </summary>
    /// <param name="request">The GetCartItem command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The Cart item details if found.</returns>
    public async Task<GetCartItemResult> Handle(GetCartItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetCartItemValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var CartItem = await _CartItemRepository.GetByIdAsync(request.Id, cancellationToken);
        if (CartItem == null)
            throw new KeyNotFoundException($"Cart item with ID {request.Id} not found");

        return _mapper.Map<GetCartItemResult>(CartItem);
    }
}

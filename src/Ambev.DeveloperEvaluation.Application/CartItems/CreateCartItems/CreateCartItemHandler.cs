using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;

/// <summary>
/// Handler for processing CreateCartItemCommand requests.
/// </summary>
public class CreateCartItemHandler : IRequestHandler<CreateCartItemCommand, CreateCartItemResult>
{
    private readonly ICartItemRepository _CartItemRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateCartItemHandler.
    /// </summary>
    /// <param name="CartItemRepository">The Cart item repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public CreateCartItemHandler(
        ICartItemRepository CartItemRepository,
        IMapper mapper)
    {
        _CartItemRepository = CartItemRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateCartItemCommand request.
    /// </summary>
    /// <param name="command">The CreateCartItem command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created Cart item result.</returns>
    public async Task<CreateCartItemResult> Handle(CreateCartItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCartItemCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var CartItem = _mapper.Map<CartItem>(command);
        var createdItem = await _CartItemRepository.CreateAsync(CartItem, cancellationToken);
        return _mapper.Map<CreateCartItemResult>(createdItem);
    }
}

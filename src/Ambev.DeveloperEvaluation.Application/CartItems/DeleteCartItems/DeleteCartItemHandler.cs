using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.CartItems.DeleteCartItems;

/// <summary>
/// Handler for processing DeleteCartItemCommand requests.
/// </summary>
public class DeleteCartItemHandler : IRequestHandler<DeleteCartItemCommand, DeleteCartItemResponse>
{
    private readonly ICartItemRepository _CartItemRepository;

    /// <summary>
    /// Initializes a new instance of DeleteCartItemHandler.
    /// </summary>
    /// <param name="CartItemRepository">The Cart item repository.</param>
    public DeleteCartItemHandler(ICartItemRepository CartItemRepository)
    {
        _CartItemRepository = CartItemRepository;
    }

    /// <summary>
    /// Handles the DeleteCartItemCommand request.
    /// </summary>
    /// <param name="request">The DeleteCartItem command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The result of the delete operation.</returns>
    public async Task<DeleteCartItemResponse> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteCartItemValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _CartItemRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Cart item with ID {request.Id} not found");

        return new DeleteCartItemResponse { Success = true };
    }
}

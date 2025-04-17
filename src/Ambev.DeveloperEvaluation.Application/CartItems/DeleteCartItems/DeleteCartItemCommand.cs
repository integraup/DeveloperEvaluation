using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartItems.DeleteCartItems;

/// <summary>
/// Command for deleting an Cart item.
/// </summary>
public record DeleteCartItemCommand : IRequest<DeleteCartItemResponse>
{
    /// <summary>
    /// The unique identifier of the Cart item to delete.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteCartItemCommand.
    /// </summary>
    /// <param name="id">The ID of the Cart item to delete.</param>
    public DeleteCartItemCommand(Guid id)
    {
        Id = id;
    }
}

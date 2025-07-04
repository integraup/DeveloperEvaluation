using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

/// <summary>
/// Command for deleting an Cart.
/// </summary>
public record DeleteCartCommand : IRequest<DeleteCartResult>
{
    /// <summary>
    /// The unique identifier of the Cart to delete.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteCartCommand.
    /// </summary>
    /// <param name="id">The ID of the Cart to delete.</param>
    public DeleteCartCommand(Guid id)
    {
        Id = id;
    }
}

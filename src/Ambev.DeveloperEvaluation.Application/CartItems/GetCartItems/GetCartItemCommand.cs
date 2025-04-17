using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartItems.GetCartItems;

/// <summary>
/// Command for retrieving an Cart item by its ID.
/// </summary>
public record GetCartItemCommand : IRequest<GetCartItemResult>
{
    /// <summary>
    /// The unique identifier of the Cart item to retrieve.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetCartItemCommand.
    /// </summary>
    /// <param name="id">The ID of the Cart item to retrieve.</param>
    public GetCartItemCommand(Guid id)
    {
        Id = id;
    }
}

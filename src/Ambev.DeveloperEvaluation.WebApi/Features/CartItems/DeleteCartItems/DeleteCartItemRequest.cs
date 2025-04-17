namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItem.DeleteCartItems;

/// <summary>
/// Request model for deleting an Cart item
/// </summary>
public class DeleteCartItemRequest
{
    /// <summary>
    /// The unique identifier of the Cart item to delete
    /// </summary>
    public Guid Id { get; set; }
}

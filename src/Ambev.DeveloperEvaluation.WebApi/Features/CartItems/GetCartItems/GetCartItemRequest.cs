namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItem.GetCartItems;

/// <summary>
/// Request model for getting an Cart item by ID
/// </summary>
public class GetCartItemRequest
{
    /// <summary>
    /// The unique identifier of the Cart item to retrieve
    /// </summary>
    public Guid Id { get; set; }
}

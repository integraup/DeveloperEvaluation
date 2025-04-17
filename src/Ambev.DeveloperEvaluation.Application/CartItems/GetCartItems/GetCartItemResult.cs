namespace Ambev.DeveloperEvaluation.Application.CartItems.GetCartItems;

/// <summary>
/// Response model for retrieving a cart item.
/// </summary>
public class GetCartItemResult
{
    /// <summary>
    /// The ID of the product in this cart item.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// The quantity of the product in the cart.
    /// </summary>
    public int Quantity { get; set; }
}

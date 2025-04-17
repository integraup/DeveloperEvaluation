namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.GetCartItems;

/// <summary>
/// API response model for GetCartItem operation
/// </summary>
public class GetCartItemResponse
{
    /// <summary>
    /// The unique identifier of the Cart item
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The product identifier associated with the Cart item
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// The Cart identifier this item is linked to
    /// </summary>
    public Guid CartId { get; set; }

    /// <summary>
    /// The quantity Carted for this item
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The price per unit of the item
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// The total price for the item (Quantity * UnitPrice)
    /// </summary>
    public decimal TotalPrice => Quantity * UnitPrice;
}

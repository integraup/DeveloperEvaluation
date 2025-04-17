namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItem.CreateCartItems;

/// <summary>
/// Represents a request to create a new Cart item in the system.
/// </summary>
public class CreateCartItemRequest
{
    /// <summary>
    /// The ID of the product being Carted.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// The ID of the Cart this item belongs to.
    /// </summary>
    public Guid CartId { get; set; }

    /// <summary>
    /// The quantity of the product Carted.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The price per unit of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }
}

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItem.CreateCartItems;

/// <summary>
/// API response model for CreateCartItem operation
/// </summary>
public class CreateCartItemResponse
{
    /// <summary>
    /// The unique identifier of the created Cart item
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The ID of the product associated with the Cart item
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// The ID of the Cart this item belongs to
    /// </summary>
    public Guid CartId { get; set; }

    /// <summary>
    /// The quantity of product in the Cart item
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The unit price of the product
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// The total calculated price for the item
    /// </summary>
    public decimal TotalPrice => Quantity * UnitPrice;
}

namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;

/// <summary>
/// Response model for creating a cart item
/// </summary>
public class CreateCartItemResult
{
    /// <summary>
    /// ID of the item created.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The ID of the cart this item belongs to.
    /// </summary>
    public Guid CartId { get; set; }

    /// <summary>
    /// The ID of the product added to the cart.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Quantity of the product added.
    /// </summary>
    public int Quantity { get; set; }
}

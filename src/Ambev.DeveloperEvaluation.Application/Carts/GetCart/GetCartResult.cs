using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Response model for GetCart operation
/// </summary>
public class GetCartResult
{
    /// <summary>
    /// The unique identifier of the Cart
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The identifier of the user who placed the Cart
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// The subtotal amount of the Cart (before discount)
    /// </summary>
    public decimal SubTotal { get; set; }

    /// <summary>
    /// The discount percentage applied to the Cart
    /// </summary>
    public decimal DiscountPercent { get; set; }

    /// <summary>
    /// The total amount after applying discount
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// The current status of the Cart
    /// </summary>
    public CartStatus Status { get; set; }

    /// <summary>
    /// The date when the Cart was created
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The date when the Cart was last updated
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// The list of items included in the Cart
    /// </summary>
    //public List<GetCartItemResult> Items { get; set; } = new();
}

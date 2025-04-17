namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

/// <summary>
/// API response model for GetCart operation
/// </summary>
public class GetCartResponse
{
    /// <summary>
    /// The unique identifier of the Cart
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The email of the customer who placed the Cart
    /// </summary>
    public string CustomerEmail { get; set; } = string.Empty;

    /// <summary>
    /// The date the Cart was created
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The total value of the Cart
    /// </summary>
    public decimal TotalValue { get; set; }
}

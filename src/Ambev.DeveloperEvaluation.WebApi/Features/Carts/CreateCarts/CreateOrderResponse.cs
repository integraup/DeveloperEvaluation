namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// API response model for CreateCart operation
/// </summary>
public class CreateCartResponse
{
    /// <summary>
    /// The unique identifier of the created Cart
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

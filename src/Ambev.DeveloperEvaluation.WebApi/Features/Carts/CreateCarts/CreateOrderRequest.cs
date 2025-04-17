namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Represents a request to create a new Cart
/// </summary>
public class CreateCartRequest
{
    /// <summary>
    /// The email of the customer placing the Cart
    /// </summary>
    public string CustomerEmail { get; set; } = string.Empty;

    /// <summary>
    /// The Cart creation date
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The total value of the Cart
    /// </summary>
    public decimal TotalValue { get; set; }
}

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

/// <summary>
/// Response model for DeleteCart operation.
/// </summary>
public class DeleteCartResult
{
    /// <summary>
    /// Indicates whether the deletion was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Optional message providing additional context about the result.
    /// </summary>
    public string? Message { get; set; }
}

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

/// <summary>
/// Response model for DeleteProduct operation.
/// </summary>
public class DeleteProductResponse
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

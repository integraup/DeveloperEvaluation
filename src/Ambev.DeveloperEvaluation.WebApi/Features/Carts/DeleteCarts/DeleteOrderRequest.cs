namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;

/// <summary>
/// Request model for deleting an Cart
/// </summary>
public class DeleteCartRequest
{
    /// <summary>
    /// The unique identifier of the Cart to delete
    /// </summary>
    public Guid Id { get; set; }
}

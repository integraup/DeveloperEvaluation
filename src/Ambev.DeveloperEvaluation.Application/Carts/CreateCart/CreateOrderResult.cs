namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Represents the response returned after successfully creating a new Cart.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created Cart,
/// which can be used for confirmation or future queries.
/// </remarks>
public class CreateCartResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created Cart.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created Cart in the system.</value>
    public Guid Id { get; set; }
}

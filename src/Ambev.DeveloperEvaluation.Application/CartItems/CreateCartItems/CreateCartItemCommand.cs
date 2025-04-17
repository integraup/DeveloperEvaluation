using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;

/// <summary>
/// Command for creating a new Cart item.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating an item within an Cart, 
/// including product ID, quantity, unit price, and discount percent. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateCartItemResult"/>.
/// 
/// The data is validated using the <see cref="CreateCartItemCommandValidator"/>.
/// </remarks>
public class CreateCartItemCommand : IRequest<CreateCartItemResult>
{
    /// <summary>
    /// Gets or sets the ID of the parent Cart.
    /// </summary>
    public Guid CartId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the product.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount percentage to be applied.
    /// </summary>
    public decimal DiscountPercent { get; set; }

    /// <summary>
    /// Validates this command using <see cref="CreateCartItemCommandValidator"/>.
    /// </summary>
    /// <returns>A detailed validation result.</returns>
    public ValidationResultDetail Validate()
    {
        var validator = new CreateCartItemCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}

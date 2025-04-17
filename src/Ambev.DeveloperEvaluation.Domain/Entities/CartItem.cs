using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents an item inside a shopping cart.
/// </summary>
public class CartItem : BaseEntity
{
    /// <summary>
    /// Gets or sets the cart ID this item belongs to.
    /// </summary>
    public Guid CartId { get; set; }

    /// <summary>
    /// Navigation property to the cart.
    /// </summary>
    public Cart Cart { get; set; }

    /// <summary>
    /// Gets or sets the product ID of the item.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Navigation property to the product (optional).
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Gets or sets the quantity of this product in the cart.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product at the time it was added to the cart.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount percentage applied to this item (0–100).
    /// </summary>
    public int DiscountPercent { get; set; }  // 👈 Adicione esta propriedade

    public ValidationResultDetail Validate()
    {
        var result = new CartItemValidator().Validate(this);

        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
        };
    }
}

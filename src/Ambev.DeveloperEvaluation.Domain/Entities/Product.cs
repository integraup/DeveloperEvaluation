using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a product available for purchase.
/// </summary>
public class Product : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price of the product.
    /// Must be greater than zero.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the discount eligibility for 10%.
    /// </summary>
    public bool Has10PercentDiscount { get; set; }

    /// <summary>
    /// Gets or sets the discount eligibility for 20%.
    /// </summary>
    public bool Has20PercentDiscount { get; set; }

    /// <summary>
    /// Gets or sets the current status of the product (Active, Inactive, OutOfStock).
    /// </summary>
    public ProductStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the date the product was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
    

    /// <summary>
    /// Gets or sets the last update date of the product.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public int DiscountPercent { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class.
    /// </summary>
    public Product()
    {
        CreatedAt = DateTime.UtcNow;
        Status = ProductStatus.Active;
    }

    /// <summary>
    /// Validates business rules for product using <see cref="ProductValidator"/>.
    /// </summary>
    public ValidationResultDetail Validate()
    {
        var result = new ProductValidator().Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
        };
    }

    /// <summary>
    /// Marks the product as inactive (hidden from catalog).
    /// </summary>
    public void Deactivate()
    {
        Status = ProductStatus.Inactive;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Marks the product as active (available for sale).
    /// </summary>
    public void Activate()
    {
        Status = ProductStatus.Active;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Marks the product as out of stock.
    /// </summary>
    public void MarkAsOutOfStock()
    {
        Status = ProductStatus.OutOfStock;
        UpdatedAt = DateTime.UtcNow;
    }
}

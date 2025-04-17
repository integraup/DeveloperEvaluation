using System.ComponentModel.DataAnnotations.Schema;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a shopping cart created by a user, with products and creation date.
/// </summary>
public class Cart : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public DateTime Date { get; set; }
    public ICollection<CartItem> Products { get; set; } = new List<CartItem>();
    
    public decimal SubTotal { get; set; }
    public int DiscountPercent { get; set; }
    
    public CartStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public decimal Total {get;set;}

    public Cart()
    {
        Date = DateTime.UtcNow;
    }

    public Cart(Guid userId)
    {
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
        Date = DateTime.UtcNow;
        Status = CartStatus.Active;
        Products = new List<CartItem>();
    }

    public ValidationResultDetail Validate()
    {
        var result = new CartValidator().Validate(this);

        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
        };
    }

    public void AddItem(Product product, int quantity)
    {
        var existingItem = Products.FirstOrDefault(i => i.ProductId == product.Id);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            Products.Add(new CartItem
            {
                ProductId = product.Id,
                Product = product,
                Quantity = quantity,
                UnitPrice = product.Price,
                DiscountPercent = product.DiscountPercent
            });
        }

        UpdateTotal();
    }

    public void UpdateTotal()
    {
        SubTotal = Products.Sum(item => item.UnitPrice * item.Quantity);
        var discountAmount = SubTotal * DiscountPercent / 100m;

        Total = SubTotal - discountAmount;
    }

}

using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

/// <summary>
/// Contains validation rules for the <see cref="Cart"/> entity.
/// </summary>
public class CartValidator : AbstractValidator<Cart>
{
    public CartValidator()
    {
        RuleFor(o => o.UserId)
            .NotEmpty()
            .WithMessage("O usuário associado ao pedido é obrigatório.");

        RuleFor(o => o.Products)
            .NotEmpty()
            .WithMessage("O pedido deve conter pelo menos um item.");

        RuleForEach(o => o.Products).ChildRules(items =>
        {
            items.RuleFor(i => i.Quantity)
                .GreaterThan(0)
                .WithMessage("A quantidade do item deve ser maior que zero.");

            items.RuleFor(i => i.Quantity)
                .LessThanOrEqualTo(20)
                .WithMessage("Não é permitido mais de 20 unidades do mesmo item.");

            items.RuleFor(i => i.ProductId)
                .NotEmpty()
                .WithMessage("O produto do item é obrigatório.");
        });

        RuleFor(o => o.SubTotal)
            .GreaterThan(0)
            .WithMessage("O subtotal deve ser maior que zero.");

        RuleFor(o => o.Total)
            .GreaterThan(0)
            .WithMessage("O valor total do pedido deve ser maior que zero.");

        RuleFor(o => o.DiscountPercent)
            .Must((cart, discount) => IsValidDiscount(cart))
            .WithMessage("Desconto inválido: mínimo de itens não atingido ou critério não atendido.");
    }

    private bool IsValidDiscount(Cart cart)
    {
        int totalQuantity = cart.Products.Sum(i => i.Quantity);

        if (cart.DiscountPercent == 0)
            return true;

        if (cart.DiscountPercent == 10 || cart.DiscountPercent == 20)
            return totalQuantity >= 5;

        return false;
    }
}

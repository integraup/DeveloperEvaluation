using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

/// <summary>
/// Contains validation rules for the <see cref="CartItem"/> entity.
/// </summary>
public class CartItemValidator : AbstractValidator<CartItem>
{
    public CartItemValidator()
    {
        RuleFor(item => item.CartId)
            .NotEmpty()
            .WithMessage("O pedido associado ao item é obrigatório.");

        RuleFor(item => item.ProductId)
            .NotEmpty()
            .WithMessage("O produto associado ao item é obrigatório.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0)
            .WithMessage("A quantidade deve ser maior que zero.")
            .LessThanOrEqualTo(20)
            .WithMessage("A quantidade não pode exceder 20 unidades.");

        RuleFor(item => item.UnitPrice)
            .GreaterThan(0)
            .WithMessage("O preço unitário deve ser maior que zero.");

        RuleFor(item => item.DiscountPercent)
            .InclusiveBetween(0, 100)
            .WithMessage("O desconto deve estar entre 0% e 100%.");

        // Regra adicional: se houver desconto, o preço precisa ser > 0
        RuleFor(item => item)
            .Must(item => item.DiscountPercent == 0 || item.UnitPrice > 0)
            .WithMessage("Não é possível aplicar desconto em um item com preço unitário zero.");
    }
}

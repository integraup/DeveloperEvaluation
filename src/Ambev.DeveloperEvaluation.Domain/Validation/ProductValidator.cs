using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

/// <summary>
/// Contains validation rules for the <see cref="Product"/> entity.
/// </summary>
public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .MaximumLength(100).WithMessage("O nome do produto deve ter no máximo 100 caracteres.");

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("A descrição do produto deve ter no máximo 500 caracteres.");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");

        RuleFor(p => p.Status)
            .IsInEnum().WithMessage("Status do produto inválido.");

        RuleFor(p => new { p.Has10PercentDiscount, p.Has20PercentDiscount })
            .Must(d => !(d.Has10PercentDiscount && d.Has20PercentDiscount))
            .WithMessage("O produto não pode ter descontos de 10% e 20% ao mesmo tempo.");
    }
}

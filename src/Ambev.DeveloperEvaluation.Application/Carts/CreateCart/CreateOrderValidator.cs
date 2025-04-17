using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Validator for CreateCartCommand that defines validation rules for Cart creation.
/// </summary>
public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateCartCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserId: Required
    /// - Items: At least one item required
    /// - Each item: ProductId, Quantity (1–20), UnitPrice > 0, DiscountPercent 0–100
    /// </remarks>
    public CreateCartCommandValidator()
    {
        RuleFor(o => o.UserId)
            .NotEmpty()
            .WithMessage("UserId is required.");

        RuleFor(o => o.Items)
            .NotEmpty()
            .WithMessage("The Cart must contain at least one item.");

        RuleForEach(o => o.Items).SetValidator(new CartItemValidator());
    }
}

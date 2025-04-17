using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;

/// <summary>
/// Validator for CreateCartItemCommand that defines validation rules for Cart item creation.
/// </summary>
public class CreateCartItemCommandValidator : AbstractValidator<CreateCartItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateCartItemCommandValidator with defined validation rules.
    /// </summary>
    public CreateCartItemCommandValidator()
    {
        RuleFor(x => x.CartId)
            .NotEmpty()
            .WithMessage("CartId is required.");

        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("ProductId is required.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0.")
            .LessThanOrEqualTo(20)
            .WithMessage("Quantity cannot exceed 20 units.");
    }
}

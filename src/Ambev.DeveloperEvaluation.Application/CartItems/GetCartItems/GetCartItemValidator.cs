using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartItems.GetCartItems;

/// <summary>
/// Validator for GetCartItemCommand.
/// </summary>
public class GetCartItemValidator : AbstractValidator<GetCartItemCommand>
{
    /// <summary>
    /// Initializes validation rules for GetCartItemCommand.
    /// </summary>
    public GetCartItemValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart item ID is required.");
    }
}

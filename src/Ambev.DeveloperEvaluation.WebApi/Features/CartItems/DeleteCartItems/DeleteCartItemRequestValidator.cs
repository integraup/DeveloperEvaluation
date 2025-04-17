using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItem.DeleteCartItems;

/// <summary>
/// Validator for DeleteCartItemRequest
/// </summary>
public class DeleteCartItemRequestValidator : AbstractValidator<DeleteCartItemRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteCartItemRequest
    /// </summary>
    public DeleteCartItemRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart item ID is required");
    }
}

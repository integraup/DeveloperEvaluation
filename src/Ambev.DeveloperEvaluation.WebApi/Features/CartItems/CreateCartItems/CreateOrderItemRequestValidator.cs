using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItem.CreateCartItems;

/// <summary>
/// Validator for CreateCartItemRequest that defines validation rules for creating an Cart item.
/// </summary>
public class CreateCartItemRequestValidator : AbstractValidator<CreateCartItemRequest>
{
    public CreateCartItemRequestValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.CartId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.UnitPrice).GreaterThan(0);
    }
}

using FluentValidation;
using Ambev.DeveloperEvaluation.Application.Carts.AddItemToCart;

public class AddItemToCartValidator : AbstractValidator<AddItemToCartCommand>
{
    public AddItemToCartValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}

using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.RemoveItemFromCart
{
    public class RemoveItemFromCartValidator : AbstractValidator<RemoveItemFromCartCommand>
    {
        public RemoveItemFromCartValidator()
        {
            RuleFor(x => x.CartItemId)
                .NotEmpty().WithMessage("CartItemId é obrigatório.");
        }
    }
}

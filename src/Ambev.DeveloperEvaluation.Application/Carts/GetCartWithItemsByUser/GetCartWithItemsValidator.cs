// GetCartWithItemsValidator.cs
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartWithItemsByUser
{
    /// <summary>
    /// Validador para a consulta de carrinho com itens por usuário.
    /// </summary>
    public class GetCartWithItemsValidator : AbstractValidator<GetCartWithItemsByUserQuery>
    {
        public GetCartWithItemsValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("O ID do usuário é obrigatório.");
        }
    }
}

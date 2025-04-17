// GetCartWithItemsByUserValidator.cs
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartWithItemsByUser
{
    public class GetCartWithItemsByUserValidator : AbstractValidator<GetCartWithItemsByUserRequest>
    {
        public GetCartWithItemsByUserValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("O ID do usuário é obrigatório.");
        }
    }
}

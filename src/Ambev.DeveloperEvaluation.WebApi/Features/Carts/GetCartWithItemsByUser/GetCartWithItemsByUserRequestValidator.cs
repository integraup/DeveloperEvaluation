// GetCartWithItemsByUserRequestValidator.cs
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartWithItemsByUser
{
    public class GetCartWithItemsByUserRequestValidator : AbstractValidator<GetCartWithItemsByUserRequest>
    {
        public GetCartWithItemsByUserRequestValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("O ID do usuário é obrigatório.");
        }
    }
}

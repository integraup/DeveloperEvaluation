using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Carts.RemoveItemFromCart
{
    public class RemoveItemFromCartHandler : IRequestHandler<RemoveItemFromCartCommand, RemoveItemFromCartResult>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public RemoveItemFromCartHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<RemoveItemFromCartResult> Handle(RemoveItemFromCartCommand request, CancellationToken cancellationToken)
        {
            var success = await _cartItemRepository.DeleteAsync(request.CartItemId, cancellationToken);
            return new RemoveItemFromCartResult { Success = success };
        }
    }
}

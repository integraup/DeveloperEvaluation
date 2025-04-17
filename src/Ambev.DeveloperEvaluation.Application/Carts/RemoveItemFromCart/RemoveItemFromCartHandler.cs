using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Carts.RemoveItemFromCart
{
    public class RemoveItemFromCartHandler : IRequestHandler<RemoveItemFromCartCommand, bool>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public RemoveItemFromCartHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<bool> Handle(RemoveItemFromCartCommand request, CancellationToken cancellationToken)
        {
            return await _cartItemRepository.DeleteAsync(request.CartItemId, cancellationToken);
        }
    }
}

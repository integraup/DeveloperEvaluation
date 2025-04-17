using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ambev.DeveloperEvaluation.Application.Carts.GetCartWithItemsByUser; // Para CartWithItemsResponse
using Ambev.DeveloperEvaluation.Domain.Repositories; // Para ICartRepository, IProductRepository
using Ambev.DeveloperEvaluation.Domain.Entities; // Para Product, Cart etc;

namespace Ambev.DeveloperEvaluation.Application.Carts.AddItemToCart
{
    public class AddItemToCartCommandHandler : IRequestHandler<AddItemToCartCommand, CartWithItemsResponse>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public AddItemToCartCommandHandler(
            ICartRepository cartRepository,
            IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<CartWithItemsResponse> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetActiveCartWithItemsByUserIdAsync(request.UserId, cancellationToken);

            if (cart == null)
            {
                cart = new Cart(request.UserId);
                await _cartRepository.CreateAsync(cart, cancellationToken);
            }

            var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);
            if (product == null)
                throw new Exception("Produto não encontrado");

            cart.AddItem(product, request.Quantity);

            return CartWithItemsResponse.FromEntity(cart);
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ambev.DeveloperEvaluation.Application.Carts.AddItemToCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCartWithItemsByUser;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.AddItemToCart
{
    public class AddItemToCartHandler : IRequestHandler<AddItemToCartCommand, CartWithItemsResponse>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        private readonly ICartItemRepository _cartItemRepository;

        public AddItemToCartHandler(ICartRepository cartRepo, IProductRepository productRepo, ICartItemRepository cartItemRepository)
        {
            _cartRepository = cartRepo;
            _productRepository = productRepo;
            _cartItemRepository = cartItemRepository;
        }

        public async Task<CartWithItemsResponse> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetActiveCartWithItemsByUserIdAsync(request.UserId, cancellationToken);

            if (cart == null)
            {
                cart = new Cart(request.UserId);
                await _cartRepository.CreateAsync(cart, cancellationToken);
            }

            var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken)
                        ?? throw new Exception("Produto não encontrado");

            var cartItem = new CartItem
            {
                CartId = cart.Id,
                ProductId = product.Id,
                Product = product,
                Quantity = request.Quantity,
                UnitPrice = product.Price,
                DiscountPercent = product.DiscountPercent
            };

            await _cartItemRepository.CreateAsync(cartItem, cancellationToken);

            // Opcional: recarrega carrinho com itens atualizados
            var updatedCart = await _cartRepository.GetActiveCartWithItemsByUserIdAsync(request.UserId, cancellationToken);

            return CartWithItemsResponse.FromEntity(updatedCart!);
        }

    }
}

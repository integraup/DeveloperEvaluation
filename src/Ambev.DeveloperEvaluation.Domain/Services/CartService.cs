using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Services
{
    public class CartService : ICartService
    {

        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;

        public CartService(ICartRepository cartRepository, ICartItemRepository cartItemRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
        }

        public void CalcularTotais(Cart cart)
        {
            if (cart.Products == null || !cart.Products.Any())
            {
                cart.SubTotal = 0;
                cart.Total = 0;
                return;
            }

            cart.SubTotal = cart.Products.Sum(item => item.UnitPrice * item.Quantity);

            var desconto = cart.DiscountPercent / 100m;
            cart.Total = cart.SubTotal * (1 - desconto);
        }
    }
}

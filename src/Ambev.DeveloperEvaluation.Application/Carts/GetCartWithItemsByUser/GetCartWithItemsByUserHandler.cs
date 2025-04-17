// GetCartWithItemsByUserHandler.cs
using Ambev.DeveloperEvaluation.Application.Carts.GetCartWithItemsByUser;
using Ambev.DeveloperEvaluation.Application.Services;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartWithItemsByUser
{
    /// <summary>
    /// Manipulador para obter um carrinho com itens pelo ID do usuário.
    /// </summary>
    public class GetCartWithItemsByUserHandler : IRequestHandler<GetCartWithItemsByUserQuery, CartWithItemsResponse>
    {
        private readonly ICartRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;

        public GetCartWithItemsByUserHandler(ICartRepository repository, ICartService  cartService, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _cartService = cartService;
        }

        public async Task<CartWithItemsResponse> Handle(GetCartWithItemsByUserQuery request, CancellationToken cancellationToken)
        {
            var cart = await _repository.GetActiveCartWithItemsByUserIdAsync(request.UserId, cancellationToken);

            if (cart == null)
                return null!; 

             _cartService.CalcularTotais(cart);

            return _mapper.Map<CartWithItemsResponse>(cart);
        }
    }
}

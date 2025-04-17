// GetCartWithItemsByUserQuery.cs
using Ambev.DeveloperEvaluation.Application.Carts.GetCartWithItemsByUser;
using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartWithItemsByUser
{
    /// <summary>
    /// Representa a consulta para obter o carrinho com itens de um usuário.
    /// </summary>
    public class GetCartWithItemsByUserQuery : IRequest<CartWithItemsResponse>
    {
        public Guid UserId { get; set; }

        public GetCartWithItemsByUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}


using System;
using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartWithItemsByUser
{
    /// <summary>
    /// Representa a resposta de um carrinho completo com os itens e dados dos produtos.
    /// </summary>
    public class CartWithItemsResponse
    {
        /// <summary>
        /// ID do carrinho.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// ID do usuário dono do carrinho.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Data do carrinho.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Valor subtotal (sem desconto).
        /// </summary>
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Porcentagem total de desconto aplicado.
        /// </summary>
        public decimal DiscountPercent { get; set; }

        /// <summary>
        /// Valor total com desconto aplicado.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Status do carrinho (ex: Aberto, Pago).
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Data de criação do carrinho.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Lista de itens do carrinho.
        /// </summary>
        public List<CartItemResponse> Products { get; set; } = new();

        public static CartWithItemsResponse FromEntity(Cart cart)
        {
            return new CartWithItemsResponse
            {
                Id = cart.Id,
                UserId = cart.UserId,
                SubTotal = cart.SubTotal,
                DiscountPercent = cart.DiscountPercent,
                Total = cart.Total,
                Products = cart.Products.Select(item => new CartItemResponse
                {
                    ProductId = item.ProductId,
                    ProductName = item.Product?.Name ?? string.Empty,
                    Description = item.Product?.Description ?? string.Empty,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    DiscountPercent = item.DiscountPercent
                }).ToList()
            };
        }
    }
}

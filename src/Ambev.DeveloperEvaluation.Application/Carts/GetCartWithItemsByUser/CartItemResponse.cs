// CartItemResponse.cs
using System;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartWithItemsByUser
{
    /// <summary>
    /// Representa um item do carrinho com dados do produto.
    /// </summary>
    public class CartItemResponse
    {
        /// <summary>
        /// ID do item do carrinho.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// ID do produto.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Descrição do produto.
        /// </summary>
        public string ProductDescription { get; set; } = string.Empty;

        /// <summary>
        /// Preço atual do produto (pode ser diferente do unitário registrado no carrinho).
        /// </summary>
        public decimal ProductPrice { get; set; }

        public string Description { get; set; } = string.Empty; 

        /// <summary>
        /// Quantidade do item no carrinho.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Preço unitário registrado no momento da adição ao carrinho.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Desconto aplicado no item (em %).
        /// </summary>
        public decimal DiscountPercent { get; set; }
    }
}

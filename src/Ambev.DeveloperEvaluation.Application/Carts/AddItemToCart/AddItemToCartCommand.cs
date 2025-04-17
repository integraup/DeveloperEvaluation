using MediatR;
using Ambev.DeveloperEvaluation.Application.Carts.GetCartWithItemsByUser; // Para CartWithItemsResponse
using Ambev.DeveloperEvaluation.Domain.Repositories; // Para ICartRepository, IProductRepository
using Ambev.DeveloperEvaluation.Domain.Entities; // Para Product, Cart etc.


public class AddItemToCartCommand : IRequest<CartWithItemsResponse>
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
 
    public int Quantity { get; set; }
}
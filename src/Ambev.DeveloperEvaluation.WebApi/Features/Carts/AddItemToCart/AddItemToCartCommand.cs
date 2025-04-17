using MediatR;
using Ambev.DeveloperEvaluation.Application.Carts.GetCartWithItemsByUser;

public class AddItemToCartCommand : IRequest<CartWithItemsResponse>
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}

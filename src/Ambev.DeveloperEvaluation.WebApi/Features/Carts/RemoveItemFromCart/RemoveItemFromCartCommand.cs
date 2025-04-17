using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.RemoveItemFromCart
{
    public class RemoveItemFromCartCommand : IRequest<RemoveItemFromCartResult>
    {
        public Guid CartItemId { get; set; }
    }
}

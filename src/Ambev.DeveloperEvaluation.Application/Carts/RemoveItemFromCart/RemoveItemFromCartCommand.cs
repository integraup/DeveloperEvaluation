using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Carts.RemoveItemFromCart
{
    public class RemoveItemFromCartCommand : IRequest<bool>
    {
        public Guid CartItemId { get; set; }
    }
}

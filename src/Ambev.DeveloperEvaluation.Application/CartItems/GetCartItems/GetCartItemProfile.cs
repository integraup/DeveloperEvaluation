using AutoMapper;
using Ambev.DeveloperEvaluation.Application.CartItems.GetCartItems;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems;

/// <summary>
/// Profile for GetCartItem mappings
/// </summary>
public class GetCartItemProfile : Profile
{
    public GetCartItemProfile()
    {
        CreateMap<CartItem, GetCartItemResult>();
    }
}

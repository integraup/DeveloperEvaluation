using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;

/// <summary>
/// Profile for mapping between CartItem entity and CreateCartItem models.
/// </summary>
public class CreateCartItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateCartItem operation.
    /// </summary>
    public CreateCartItemProfile()
    {
        CreateMap<CreateCartItemCommand, CartItem>();
        CreateMap<CartItem, CreateCartItemResult>();
    }
}

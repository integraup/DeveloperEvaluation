using AutoMapper;
using Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItem.CreateCartItems;

/// <summary>
/// Profile for mapping between Application and API CreateCartItem responses
/// </summary>
public class CreateCartItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateCartItem feature
    /// </summary>
    public CreateCartItemProfile()
    {
        CreateMap<CreateCartItemRequest, CreateCartItemCommand>();
        CreateMap<CreateCartItemResult, CreateCartItemResponse>();
    }
}

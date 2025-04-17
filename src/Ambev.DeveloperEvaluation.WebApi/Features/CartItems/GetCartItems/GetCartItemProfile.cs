using Ambev.DeveloperEvaluation.Application.CartItems.GetCartItems;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.GetCartItems;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.GetCartItems;

/// <summary>
/// Profile for mapping GetCartItem feature requests to commands and responses
/// </summary>
public class GetCartItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCartItem feature
    /// </summary>
    public GetCartItemProfile()
    {
        // Mapeia o ID para o comando de busca
        CreateMap<Guid, GetCartItemCommand>()
            .ConstructUsing(id => new GetCartItemCommand(id));

        // Mapeia o resultado da aplicação para o response da API
        CreateMap<GetCartItemResult, GetCartItemResponse>();
    }
}

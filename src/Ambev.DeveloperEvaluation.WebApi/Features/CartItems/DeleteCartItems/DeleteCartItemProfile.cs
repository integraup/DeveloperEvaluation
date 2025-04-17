using Ambev.DeveloperEvaluation.Application.CartItems.DeleteCartItems;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItem.DeleteCartItems;

/// <summary>
/// Profile for mapping DeleteCartItem feature requests to commands
/// </summary>
public class DeleteCartItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteCartItem feature
    /// </summary>
    public DeleteCartItemProfile()
    {
        CreateMap<Guid, DeleteCartItemCommand>()
            .ConstructUsing(id => new DeleteCartItemCommand(id));
    }
}

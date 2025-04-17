using Ambev.DeveloperEvaluation.Application.Carts.GetCartWithItemsByUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartWithItemsByUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartWithItemsByUser
{
    public class GetCartWithItemsByUserProfile : Profile
    {
        public GetCartWithItemsByUserProfile()
        {
            CreateMap<Cart, CartWithItemsResponse>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<CartItem, CartItemResponse>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<GetCartWithItemsByUserRequest, GetCartWithItemsByUserQuery>();

            CreateMap<CartWithItemsResponse, GetCartWithItemsByUserResponse>();
            CreateMap<
                Ambev.DeveloperEvaluation.Application.Carts.GetCartWithItemsByUser.CartItemResponse,
                Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartWithItemsByUser.CartItemResponse>();
        }
    }
}

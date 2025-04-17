using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

public class GetUserWebApiProfile : Profile
{
    public GetUserWebApiProfile()
    {
        CreateMap<GetUserResult, GetUserResponse>();
    }
}

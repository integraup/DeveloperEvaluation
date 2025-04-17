using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Profile for mapping GetProduct feature requests and results.
/// </summary>
public class GetProductProfile : Profile
{
    public GetProductProfile()
    {
        // Requisição
        CreateMap<Guid, GetProductCommand>()
            .ConstructUsing(id => new GetProductCommand(id));

        // Resposta
        CreateMap<Product, GetProductResult>();
    }
}

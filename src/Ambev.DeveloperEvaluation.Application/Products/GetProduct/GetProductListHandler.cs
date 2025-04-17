using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetProductListHandler : IRequestHandler<GetProductListCommand, IEnumerable<GetProductResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductListHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetProductResult>> Handle(GetProductListCommand request, CancellationToken cancellationToken)
    {
        var query =  _productRepository.Query(); // IQueryable<Product>

        if (!string.IsNullOrEmpty(request.Title))
            query = query.Where(p => p.Name.Contains(request.Title));

        if (request.MinPrice.HasValue)
            query = query.Where(p => p.Price >= request.MinPrice);

        if (request.MaxPrice.HasValue)
            query = query.Where(p => p.Price <= request.MaxPrice);

        if (!string.IsNullOrEmpty(request.OrderBy))
        {
            query = query.OrderBy(request.OrderBy); // Requer pacote: System.Linq.Dynamic.Core
        }
        else
        {
            query = query.OrderBy(p => p.Name);
        }

        var skip = (request.Page - 1) * request.Size;
        var paged = query.Skip(skip).Take(request.Size).ToList();

        return _mapper.Map<IEnumerable<GetProductResult>>(paged);
    }
}

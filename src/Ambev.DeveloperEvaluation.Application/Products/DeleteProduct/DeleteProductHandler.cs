using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

/// <summary>
/// Handler for processing DeleteProductCommand requests.
/// </summary>
public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of DeleteProductHandler.
    /// </summary>
    /// <param name="productRepository">The product repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public DeleteProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the DeleteProductCommand request.
    /// </summary>
    /// <param name="command">The DeleteProduct command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A DeleteProductResponse indicating success or failure.</returns>
    public async Task<DeleteProductResponse> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var deleted = await _productRepository.DeleteAsync(command.Id, cancellationToken);

        return new DeleteProductResponse
        {
            Success = deleted,
            Message = deleted ? "Product deleted successfully." : "Product not found."
        };
    }
}

using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Command for retrieving a product by its ID.
/// </summary>
public record GetProductCommand : IRequest<GetProductResult>
{
    /// <summary>
    /// The unique identifier of the product to retrieve.
    /// </summary>
    public Guid Id { get; }

    public GetProductCommand(Guid id)
    {
        Id = id;
    }
}

/// <summary>
/// Command for retrieving a list of products with filters, pagination and ordering.
/// </summary>
public record GetProductListCommand(
    string? Title = null,
    decimal? MinPrice = null,
    decimal? MaxPrice = null,
    int Page = 1,
    int Size = 10,
    string? OrderBy = null
) : IRequest<IEnumerable<GetProductResult>>;

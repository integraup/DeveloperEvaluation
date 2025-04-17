namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetProductListRequest
{
    public string? Title { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }

    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;

    public string? Order { get; set; } // Ex: "price desc, title asc"
}

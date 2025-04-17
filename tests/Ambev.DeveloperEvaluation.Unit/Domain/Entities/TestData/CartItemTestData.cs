using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

public static class CartItemTestData
{
    private static readonly Faker<CartItem> CartItemFaker = new Faker<CartItem>()
        .RuleFor(i => i.CartId, f => Guid.NewGuid())
        .RuleFor(i => i.ProductId, f => Guid.NewGuid())
        .RuleFor(i => i.Quantity, f => f.Random.Int(1, 20))
        .RuleFor(i => i.UnitPrice, f => f.Random.Decimal(1m, 100m))
        .RuleFor(i => i.DiscountPercent, f => f.Random.Int(0, 100));

    public static CartItem GenerateValidCartItem()
    {
        return CartItemFaker.Generate();
    }

    public static CartItem GenerateInvalidQuantityCartItem()
    {
        var item = CartItemFaker.Generate();
        item.Quantity = 0;
        return item;
    }

    public static CartItem GenerateInvalidUnitPriceCartItem()
    {
        var item = CartItemFaker.Generate();
        item.UnitPrice = 0m;
        return item;
    }

    public static CartItem GenerateInvalidDiscountCartItem()
    {
        var item = CartItemFaker.Generate();
        item.DiscountPercent = 150;
        return item;
    }

    public static CartItem GenerateCartItemWithDiscountOnZeroUnitPrice()
    {
        var item = CartItemFaker.Generate();
        item.UnitPrice = 0m;
        item.DiscountPercent = 10;
        return item;
    }
}  

// CartTestData.cs
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

public static class CartTestData
{
    private static readonly Faker<Cart> CartFaker = new Faker<Cart>()
        .RuleFor(c => c.UserId, f => Guid.NewGuid())
        .RuleFor(c => c.Date, f => DateTime.UtcNow)
        .RuleFor(c => c.DiscountPercent, f => f.PickRandom(new[] { 0, 10, 20 }))
        .RuleFor(c => c.Products, f => new List<CartItem>());

    public static Cart GenerateValidCart()
{
    var cart = new Cart
    {
        Id = Guid.NewGuid(),
        UserId = Guid.NewGuid(),
        Date = DateTime.UtcNow,
        CreatedAt = DateTime.UtcNow,
        DiscountPercent = 10,
        Products = new List<CartItem>()
    };

    var item1 = new CartItem
    {
        Id = Guid.NewGuid(),
        CartId = cart.Id,
        ProductId = Guid.NewGuid(),
        Quantity = 2, // ✅ total 2
        UnitPrice = 100m,
        DiscountPercent = 0
    };

    var item2 = new CartItem
    {
        Id = Guid.NewGuid(),
        CartId = cart.Id,
        ProductId = Guid.NewGuid(),
        Quantity = 2, // ✅ total 2
        UnitPrice = 70m,
        DiscountPercent = 0
    };

    var item3 = new CartItem
    {
        Id = Guid.NewGuid(),
        CartId = cart.Id,
        ProductId = Guid.NewGuid(),
        Quantity = 1, // ✅ total 1
        UnitPrice = 50m,
        DiscountPercent = 0
    };

    cart.Products.Add(item1);
    cart.Products.Add(item2);
    cart.Products.Add(item3);

    // Soma total de itens: 2 + 2 + 1 = 5 ✅
    cart.SubTotal = cart.Products.Sum(p => p.Quantity * p.UnitPrice);

    // Calcula o total com desconto
    cart.Total = cart.SubTotal * (1 - (cart.DiscountPercent / 100m));

    return cart;
}



    public static Cart GenerateInvalidCartWithoutItems()
    {
        var cart = CartFaker.Generate();
        cart.Products.Clear();
        return cart;
    }

    public static Cart GenerateInvalidCartWithTooMuchDiscount()
    {
        var cart = GenerateValidCart();
        cart.DiscountPercent = 50; // acima do permitido
        return cart;
    }
}
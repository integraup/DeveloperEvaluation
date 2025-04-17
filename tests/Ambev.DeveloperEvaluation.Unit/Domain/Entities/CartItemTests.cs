using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the <see cref="CartItem"/> entity using xUnit and FluentAssertions.
/// </summary>
public class CartItemTests
{
    [Fact(DisplayName = "Should create valid CartItem when data is correct")]
    public void Should_Create_Valid_CartItem_When_Data_Is_Correct()
    {
        // Arrange
        var cartItem = CartItemTestData.GenerateValidCartItem();

        // Act
        var validation = cartItem.Validate();

        // Assert
        validation.IsValid.Should().BeTrue();
        validation.Errors.Should().BeEmpty();
    }

    [Fact(DisplayName = "Should fail validation when quantity is zero")]
    public void Should_Fail_Validation_When_Quantity_Is_Zero()
    {
        // Arrange
        var cartItem = CartItemTestData.GenerateInvalidQuantityCartItem();

        // Act
        var validation = cartItem.Validate();

        // Assert
        validation.IsValid.Should().BeFalse();
        validation.Errors.Should().ContainSingle(e => e.Detail.Contains("quantidade"));
    }

    [Fact(DisplayName = "Should fail validation when discount is invalid")]
    public void Should_Fail_Validation_When_Discount_Is_Invalid()
    {
        // Arrange
        var cartItem = CartItemTestData.GenerateInvalidDiscountCartItem();

        // Act
        var validation = cartItem.Validate();

        // Assert
        validation.IsValid.Should().BeFalse();
        validation.Errors.Should().Contain(e => e.Detail.Contains("desconto"));
    }

    [Fact(DisplayName = "Should fail validation when unit price is zero")]
    public void Should_Fail_Validation_When_UnitPrice_Is_Zero()
    {
        // Arrange
        var cartItem = CartItemTestData.GenerateInvalidUnitPriceCartItem();

        // Act
        var validation = cartItem.Validate();

        // Assert
        validation.IsValid.Should().BeFalse();
        validation.Errors.Should().Contain(e => e.Detail.Contains("preço unitário"));
    }

    [Fact(DisplayName = "Should fail validation when discount is applied to zero price")]
    public void Should_Fail_Validation_When_Discount_On_Zero_UnitPrice()
    {
        // Arrange
        var cartItem = CartItemTestData.GenerateCartItemWithDiscountOnZeroUnitPrice();

        // Act
        var validation = cartItem.Validate();

        // Assert
        validation.IsValid.Should().BeFalse();
        validation.Errors.Should().Contain(e => e.Detail.Contains("desconto"));
    }
}

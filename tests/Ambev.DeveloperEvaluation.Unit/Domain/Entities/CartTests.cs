using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class CartTests
{
    [Fact]
    public void Cart_WithValidData_ShouldBeValid()
    {
        var cart = CartTestData.GenerateValidCart();

        var result = cart.Validate();

        if (!result.IsValid)
        {
            var msg = string.Join("\n", result.Errors.Select(e => $"Erro: {e.Detail} | Tipo: {e.Error}"));
            throw new Exception("Cart inválido, erros encontrados:\n" + msg);
        }

        result.IsValid.Should().BeTrue("esperado que o carrinho seja válido");
    }



    [Fact(DisplayName = "Cart without items should be invalid")]
    public void Cart_WithoutItems_ShouldBeInvalid()
    {
        // Arrange
        var cart = CartTestData.GenerateInvalidCartWithoutItems();

        // Act
        var result = cart.Validate();

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.Detail.Contains("pelo menos um item"));
    }

    [Fact]
    public void Cart_WithTooMuchDiscount_ShouldBeInvalid()
    {
        var cart = CartTestData.GenerateInvalidCartWithTooMuchDiscount();

        var result = cart.Validate();

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.Detail.Contains("Desconto inválido"));
    }

}

using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for product creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Name: Required, length between 3 and 100 characters
    /// - Description: Optional, max 500 characters
    /// - Price: Must be greater than zero
    /// </remarks>
    public CreateProductRequestValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty()
            .Length(3, 100);

        RuleFor(product => product.Description)
            .MaximumLength(500);

        RuleFor(product => product.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");
    }
}

using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Command for creating a new Cart.
/// </summary>
/// <remarks>
/// This command captures the necessary data to create a new Cart, including
/// the user ID and a list of Cart items. It implements <see cref="IRequest{TResponse}"/>
/// to initiate a request that returns a <see cref="CreateCartResult"/>.
///
/// Validation is enforced using <see cref="CreateCartCommandValidator"/> via FluentValidation.
/// </remarks>
public class CreateCartCommand : IRequest<CreateCartResult>
{
    /// <summary>
    /// Gets or sets the ID of the user placing the Cart.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the list of items included in the Cart.
    /// </summary>
    public List<Ambev.DeveloperEvaluation.Domain.Entities.CartItem> Items { get; set; } = new List<Ambev.DeveloperEvaluation.Domain.Entities.CartItem>();


    /// <summary>
    /// Validates the command using CreateCartCommandValidator.
    /// </summary>
    /// <returns>A detailed validation result.</returns>
    public ValidationResultDetail Validate()
    {
        var validator = new CreateCartCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}

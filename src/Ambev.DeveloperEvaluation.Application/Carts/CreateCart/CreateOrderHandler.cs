using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Handler for processing CreateCartCommand requests.
/// </summary>
public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
{
    private readonly ICartRepository _CartRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateCartHandler.
    /// </summary>
    /// <param name="CartRepository">The Cart repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public CreateCartHandler(ICartRepository CartRepository, IMapper mapper)
    {
        _CartRepository = CartRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateCartCommand request.
    /// </summary>
    /// <param name="command">The CreateCart command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created Cart result.</returns>
    public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCartCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var Cart = _mapper.Map<Cart>(command);
        var createdCart = await _CartRepository.CreateAsync(Cart, cancellationToken);
        var result = _mapper.Map<CreateCartResult>(createdCart);

        return result;
    }
}

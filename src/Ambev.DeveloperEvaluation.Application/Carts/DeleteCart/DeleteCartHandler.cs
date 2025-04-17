using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

/// <summary>
/// Handler for processing DeleteCartCommand requests.
/// </summary>
public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResult>
{
    private readonly ICartRepository _CartRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of DeleteCartHandler.
    /// </summary>
    /// <param name="CartRepository">The Cart repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public DeleteCartHandler(ICartRepository CartRepository, IMapper mapper)
    {
        _CartRepository = CartRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the DeleteCartCommand request.
    /// </summary>
    /// <param name="command">The DeleteCart command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A DeleteCartResponse indicating success or failure.</returns>
    public async Task<DeleteCartResult> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
    {
        var deleted = await _CartRepository.DeleteAsync(command.Id, cancellationToken);

        return new DeleteCartResult
        {
            Success = deleted,
            Message = deleted ? "Cart deleted successfully." : "Cart not found."
        };
    }
}

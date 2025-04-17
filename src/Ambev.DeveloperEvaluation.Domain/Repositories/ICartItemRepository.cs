using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for CartItem entity operations.
/// </summary>
public interface ICartItemRepository
{
    /// <summary>
    /// Creates a new Cart item in the repository.
    /// </summary>
    /// <param name="item">The Cart item to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created Cart item.</returns>
    Task<CartItem> CreateAsync(CartItem item, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an Cart item by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the Cart item.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The Cart item if found, null otherwise.</returns>
    Task<CartItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an Cart item from the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the Cart item to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the item was deleted, false if not found.</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    
}

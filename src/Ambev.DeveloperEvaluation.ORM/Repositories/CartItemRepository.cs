using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ICartItemRepository using Entity Framework Core.
/// </summary>
public class CartItemRepository : ICartItemRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of CartItemRepository.
    /// </summary>
    /// <param name="context">The database context.</param>
    public CartItemRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new Cart item in the database.
    /// </summary>
    /// <param name="item">The Cart item to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created Cart item.</returns>
    public async Task<CartItem> CreateAsync(CartItem item, CancellationToken cancellationToken = default)
    {
        await _context.CartItems.AddAsync(item, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return item;
    }

    /// <summary>
    /// Retrieves an Cart item by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the Cart item.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The Cart item if found, null otherwise.</returns>
    public async Task<CartItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.CartItems.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }


    /// <summary>
    /// Deletes an Cart item from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the Cart item to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the item was deleted, false if not found.</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await GetByIdAsync(id, cancellationToken);
        if (item == null)
            return false;

        _context.CartItems.Remove(item);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

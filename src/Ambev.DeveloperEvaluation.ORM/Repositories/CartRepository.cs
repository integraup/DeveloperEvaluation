using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ICartRepository using Entity Framework Core.
/// </summary>
public class CartRepository : ICartRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of CartRepository.
    /// </summary>
    /// <param name="context">The database context.</param>
    public CartRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new Cart in the database.
    /// </summary>
    /// <param name="Cart">The Cart to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created Cart.</returns>
    public async Task<Cart> CreateAsync(Cart Cart, CancellationToken cancellationToken = default)
    {
        await _context.Carts.AddAsync(Cart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Cart;
    }

    /// <summary>
    /// Retrieves an Cart by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the Cart.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The Cart if found, null otherwise.</returns>
    public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Carts
            .Include(o => o.Products)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<Cart?> GetActiveCartWithItemsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _context.Carts
            .Include(c => c.Products)
                .ThenInclude(ci => ci.Product)
            .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);
    }

    public async Task UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        _context.Carts.Update(cart);
        await _context.SaveChangesAsync(cancellationToken);
    }



    /// <summary>
    /// Retrieves all Carts from the database.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of Carts.</returns>
    public async Task<List<Cart>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Carts
            .Include(o => o.Products)
            .ThenInclude(i => i.Product)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Deletes an Cart from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the Cart to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the Cart was deleted, false if not found.</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var Cart = await GetByIdAsync(id, cancellationToken);
        if (Cart == null)
            return false;

        _context.Carts.Remove(Cart);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

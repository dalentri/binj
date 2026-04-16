using Binj.Application.Interfaces;
using Binj.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Binj.Infrastructure.Persistence.Repositories;

//TODO: Add Documentation
public class MediaRepository<T> : IMediaRepository<T>
    where T : Media
{
    protected readonly BinjDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public MediaRepository(BinjDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    // Get item by id
    public async Task<T?> GetByIdAsync(Guid id) => await _context.Set<T>().FindAsync(id);

    public async Task<T?> GetByTitleAsync(string title) => await _context.Set<T>().FindAsync(title);

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}

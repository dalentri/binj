namespace Binj.Application.Interfaces;

using Binj.Domain.Entities;

// TODO: Hook up to db
public interface IMediaRepository<T>
    where T : Media
{
    // Nullable types to allow for null values (if they don't exist)
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> GetByTitleAsync(string title);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
}

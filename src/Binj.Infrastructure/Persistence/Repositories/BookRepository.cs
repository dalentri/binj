using Binj.Application.Interfaces;
using Binj.Domain.Entities;

namespace Binj.Infrastructure.Persistence.Repositories;

// Inherit from Base repository and interface in application layer
public class BookRepository : MediaRepository<Book>, IBookRepository
{
    public BookRepository(BinjDbContext context)
        : base(context) { }
}

using Binj.Application.Interfaces;
using Binj.Domain.Entities;

namespace Binj.Infrastructure.Persistence.Repositories;

// Inherit from Base repository and interface in application layer
public class ComicRepository : MediaRepository<Book>, IBookRepository
{
    public ComicRepository(BinjDbContext context)
        : base(context) { }
}

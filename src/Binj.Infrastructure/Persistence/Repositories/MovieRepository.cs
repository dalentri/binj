using Binj.Application.Interfaces;
using Binj.Domain.Entities;

namespace Binj.Infrastructure.Persistence.Repositories;

// Inherit from Base repository and interface in application layer
public class MovieRepository : MediaRepository<Book>, IBookRepository
{
    public MovieRepository(BinjDbContext context)
        : base(context) { }
}

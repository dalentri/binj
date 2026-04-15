using Binj.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Binj.Infrastructure.Data;

public class BinjDbContext : DbContext
{
    public BinjDbContext(DbContextOptions<BinjDbContext> options)
        : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Comic> Comics { get; set; }
}

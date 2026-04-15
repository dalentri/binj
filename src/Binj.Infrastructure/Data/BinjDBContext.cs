using Binj.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Binj.Infrastructure.Data;

// Inherit from DbContext
public class BinjDbContext : DbContext
{
    // Constructor
    // DbContextOptions contains the config (what db provider to use)
    public BinjDbContext(DbContextOptions<BinjDbContext> options)
        // Pass settings up to the parent DbContext class so it knows how to connect
        : base(options) { }

    // Create tables of all of the entities
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Comic> Comics => Set<Comic>();

    // The blueprint thats called by EfCore the first time the context is initialized
    // Configures db columns, keys, etc.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Call the base method to ensure EF core's internal defaults are loaded
        base.OnModelCreating(modelBuilder);

        // "Look through this entire project (Assembly) and find every calss that
        // implements IEntityTypeConfiguration and apply it automatically."
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BinjDbContext).Assembly);
    }
}

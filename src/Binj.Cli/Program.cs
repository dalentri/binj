using Binj.Application.Interfaces;
using Binj.Domain.Entities;
using Binj.Infrastructure.Persistence;
using Binj.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console.Cli;

// Create the builder (Handles args, config, and logging)
var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<BinjDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped(typeof(IMediaRepository<>), typeof(MediaRepository<>));

// Build the Host
using IHost host = builder.Build();

var registrar = new TypeRegistrar(host.Services);
var app = new CommandApp(registrar);

// Commands
app.Configure(config =>
{
    // Add Commands
    config.AddCommand<AddMediaCommand<Comic, AddComicSettings>>("add-comic");
    config.AddCommand<AddMediaCommand<Movie, AddMovieSettings>>("add-movie");
    config.AddCommand<AddBookCommand>("add-book");

    // Edit Commands
    config.AddCommand<EditMediaCommand<Comic, EditComicSettings>>("edit-comic");
    config.AddCommand<EditMediaCommand<Movie, EditMovieSettings>>("edit-movie");
    config.AddCommand<EditMediaCommand<Book, EditBookSettings>>("edit-book");
});
return app.Run(args);

public sealed class TypeRegistrar : ITypeRegistrar
{
    private readonly IServiceProvider _provider;

    // Update constructor to take IServiceProvider
    public TypeRegistrar(IServiceProvider provider) => _provider = provider;

    public ITypeResolver Build() => new TypeResolver(_provider);

    // These can stay empty because the host already registered everything
    public void Register(Type service, Type implementation) { }

    public void RegisterInstance(Type service, object implementation) { }

    public void RegisterLazy(Type service, Func<object> factory) { }
}

public sealed class TypeResolver : ITypeResolver
{
    private readonly IServiceProvider _provider;

    public TypeResolver(IServiceProvider provider) => _provider = provider;

    public object? Resolve(Type? type)
    {
        if (type == null)
            return null;

        // Try to get it from the DI container first
        // If it's not there, manually instantiate it and inject dependencies
        return _provider.GetService(type) ?? ActivatorUtilities.CreateInstance(_provider, type);
    }
}

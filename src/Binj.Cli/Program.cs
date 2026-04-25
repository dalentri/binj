using Binj.Application.Features;
using Binj.Application.Interfaces;
using Binj.Cli.Commands;
using Binj.Cli.Commands.Comics.Add;
using Binj.Cli.Support;
using Binj.Domain.Entities;
using Binj.Infrastructure.Persistence;
using Binj.Infrastructure.Persistence.Repositories;
using MediatR;
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

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(Binj.Infrastructure.Handlers.GetAllMediaHandler).Assembly,
        typeof(Binj.Application.Queries.GetMediaByIdQuery).Assembly
    );
});

builder.Services.AddTransient<ViewMediaCommand>();
builder.Services.AddTransient<AddComicCommand>();
builder.Services.AddTransient<AddMovieCommand>();
builder.Services.AddTransient<AddBookCommand>();
builder.Services.AddTransient(typeof(UpdateMediaCommandHandler<>));
builder.Services.AddTransient(
    typeof(IRequestHandler<UpdateMediaCommand<Book>, Unit>),
    typeof(UpdateMediaCommandHandler<Book>)
);
builder.Services.AddTransient(
    typeof(IRequestHandler<UpdateMediaCommand<Comic>, Unit>),
    typeof(UpdateMediaCommandHandler<Comic>)
);
builder.Services.AddTransient(
    typeof(IRequestHandler<UpdateMediaCommand<Movie>, Unit>),
    typeof(UpdateMediaCommandHandler<Movie>)
);
builder.Services.AddScoped(typeof(IMediaRepository<>), typeof(MediaRepository<>));

// Build the Host
using IHost host = builder.Build();

var registrar = new TypeRegistrar(host.Services);
var app = new CommandApp(registrar);

// Build db if missing
using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var ctx = services.GetRequiredService<BinjDbContext>();

    var dbPath = Path.GetFullPath("binj.db");
    Console.WriteLine($"[DEBUG] Database path: {dbPath}");

    if (!File.Exists("binj.db"))
    {
        Console.WriteLine("Database not found. Creating a new Database...");
        ctx.Database.EnsureCreated();
    }
}

// Commands
// TODO: Make custom commands for all media types similar to AddBookCommand
app.Configure(config =>
{
    // Add Commands
    config.AddCommand<AddComicCommand>("add-comic");
    config.AddCommand<AddMovieCommand>("add-movie");
    config.AddCommand<AddBookCommand>("add-book");

    // Edit Commands
    config.AddCommand<EditMediaCommand<Comic>>("edit-comic");
    config.AddCommand<EditMediaCommand<Movie>>("edit-movie");
    config.AddCommand<EditMediaCommand<Book>>("edit-book");

    // View Command
    config.AddCommand<ViewMediaCommand>("view");
});

return await app.RunAsync(args);

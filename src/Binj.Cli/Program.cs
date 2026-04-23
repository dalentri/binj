using Binj.Application.Interfaces;
using Binj.Cli.Commands.Comics.Add;
using Binj.Cli.Support;
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
// TODO: Make custom commands for all media types similar to AddBookCommand
app.Configure(config =>
{
    // Add Commands
    config.AddCommand<AddComicCommand>("add-comic");
    config.AddCommand<AddMediaCommand<Movie, AddMovieSettings>>("add-movie");
    config.AddCommand<AddBookCommand>("add-book");

    // Edit Commands
    config.AddCommand<EditMediaCommand<Comic, EditComicSettings>>("edit-comic");
    config.AddCommand<EditMediaCommand<Movie, EditMovieSettings>>("edit-movie");
    config.AddCommand<EditMediaCommand<Book, EditBookSettings>>("edit-book");
});
return app.Run(args);

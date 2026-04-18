using Binj.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console.Cli;

// Create the builder (Handles args, config, and logging)
var builder = Host.CreateApplicationBuilder(args);
var app = new CommandApp();

// Commands
app.Configure(config =>
{
    // Add Commands
    config.AddCommand<AddMediaCommand<Comic, AddComicSettings>>("add-comic");
    config.AddCommand<AddMediaCommand<Movie, AddMovieSettings>>("add-movie");
    config.AddCommand<AddMediaCommand<Book, AddBookSettings>>("add-book");

    // Edit Commands
    config.AddCommand<EditMediaCommand<Comic, EditComicSettings>>("edit-comic");
    config.AddCommand<EditMediaCommand<Movie, EditMovieSettings>>("edit-movie");
    config.AddCommand<EditMediaCommand<Book, EditBookSettings>>("edit-book");
});

// Build the Host
using IHost host = builder.Build();

return app.Run(args);

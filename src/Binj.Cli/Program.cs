using Binj.Cli;
using Binj.Cli.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console.Cli;

// Create the builder (Handles args, config, and logging)
var builder = Host.CreateApplicationBuilder(args);
var app = new CommandApp();

// Commands
app.Configure(config =>
{
    config.AddCommand<AddMediaCommand<Book, AddBookSettings>>("add-book");
});

// Build the Host
using IHost host = builder.Build();

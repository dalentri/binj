using Binj.Cli;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console.Cli;

// Create the builder (Handles args, config, and logging)
var builder = Host.CreateApplicationBuilder(args);
var app = new CommandApp();

// Commands
app.Configure(config => { });

// Build the Host
using IHost host = builder.Build();

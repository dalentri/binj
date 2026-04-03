using Binj.Application;
using Binj.Application.Features.Media;
using Binj.Cli;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Create the builder (Handles args, config, and logging)
var builder = Host.CreateApplicationBuilder(args);

// Register Services (Map the Interface to the Implementation)
builder.Services.AddSingleton<IMediaService, MediaService>();

// Register the parser so the Host can build it for us
builder.Services.AddSingleton<ArgumentParser>();

// Build the Host
using IHost host = builder.Build();

// Resolve the parser and run it
var parser = host.Services.GetRequiredService<ArgumentParser>();
parser.Parse(args);

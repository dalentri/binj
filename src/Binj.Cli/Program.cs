using Binj.Cli;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Create the builder (Handles args, config, and logging)
var builder = Host.CreateApplicationBuilder(args);

//FIX:
builder.Services.AddDbContext<BinjDbContext>(options => );


// Build the Host
using IHost host = builder.Build();


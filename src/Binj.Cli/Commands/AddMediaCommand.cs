using Binj.Application.Interfaces;
using Binj.Domain.Entities;
using Spectre.Console;
using Spectre.Console.Cli;

public class AddMediaCommand<TEntity, TSettings> : AsyncCommand<TSettings>
    where TEntity : Media, new()
    where TSettings : CommandSettings
{
    // Bridge to the db layer
    private readonly IMediaRepository<TEntity> _repository;

    // Constructor that injects the repository so the data can be saved
    public AddMediaCommand(IMediaRepository<TEntity> repository)
    {
        _repository = repository;
    }

    // Runs when the user hits enter
    protected override async Task<int> ExecuteAsync(
        CommandContext context,
        TSettings settings,
        CancellationToken cancellationToken
    )
    {
        // Confirmation to console
        AnsiConsole.MarkupLine($"[green]Adding {typeof(TEntity).Name}...[/]");
        // Await the addition to repository
        await _repository.AddAsync(new TEntity());
        return 0;
    }
}

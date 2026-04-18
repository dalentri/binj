using Binj.Application.Interfaces;
using Binj.Domain.Entities;
using Spectre.Console;
using Spectre.Console.Cli;

public class EditMediaCommand<TEntity, TSettings> : AsyncCommand<TSettings>
    where TEntity : Media, new()
    where TSettings : CommandSettings
{
    private readonly IMediaRepository<TEntity> _repository;

    public EditMediaCommand(IMediaRepository<TEntity> repository)
    {
        _repository = repository;
    }

    protected override async Task<int> ExecuteAsync(
        CommandContext context,
        TSettings settings,
        CancellationToken cancellationToken
    )
    {
        AnsiConsole.MarkupLine($"[green]Adding {typeof(TEntity).Name}...[/]");
        await _repository.AddAsync(new TEntity());
        return 0;
    }
}

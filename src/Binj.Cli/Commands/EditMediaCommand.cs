using Binj.Application.Interfaces;
using Binj.Domain.Entities;
using MediatR;
using Spectre.Console;
using Spectre.Console.Cli;

public class EditMediaCommand<TEntity, TSettings> : AsyncCommand<TSettings>
    where TEntity : Media, new()
    where TSettings : CommandSettings
{
    private readonly IMediator _mediator;

    public EditMediaCommand(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected override async Task<int> ExecuteAsync(
        CommandContext context,
        TSettings settings,
        CancellationToken cancellationToken
    )
    {
        AnsiConsole.MarkupLine($"[green]Adding {typeof(TEntity).Name}...[/]");
        return 0;
        //TODO: Add edit impplementation
    }
}

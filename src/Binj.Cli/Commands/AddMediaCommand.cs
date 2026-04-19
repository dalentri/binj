using Binj.Application.Interfaces;
using Binj.Domain.Entities;
using MediatR;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Binj.Cli.Commands;

public abstract class AddMediaCommand<TEntity, TSettings> : AsyncCommand<TSettings>
    where TEntity : Media, new()
    where TSettings : CommandSettings
{
    // Bridge to the db layer
    private readonly IMediator _mediator;

    // Constructor that injects the repository so the data can be saved
    public AddMediaCommand(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected abstract IRequest<int> CreateMediatorRequest(TEntity entity);

    // Runs when the user hits enter
    protected override async Task<int> ExecuteAsync(
        CommandContext context,
        TSettings settings,
        CancellationToken cancellationToken
    )
    {
        // Confirmation to console
        AnsiConsole.MarkupLine($"[green]Adding {typeof(TEntity).Name}...[/]");

        var entity = new TEntity();

        var mediatorRequest = CreateMediatorRequest(entity);

        return await _mediator.Send(mediatorRequest, cancellationToken);
    }
}

using Binj.Application.Interfaces;
using Binj.Domain.Entities;
using MediatR;
using Spectre.Console;
using Spectre.Console.Cli;

public class ViewMediaCommand : Command<ViewMediaSettings>
{
    private readonly IMediator _mediator;

    public ViewMediaCommand(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task<int> ExecuteAsync(CommandContext context, ViewMediaSettings settings)
    {
        // Settings -> Application Query
        var query = new GetAllMediaQuery(settings.TypeFilter);

        // Call the application layer
        var results = await _mediator.Send(query);

        if (results == null || !results.Any())
        {
            AnsiConsole.MarkupLine("[red]No media found matching those filters.[/]");
            return 0;
        }
        // 3. Use Spectre's Table to display data beautifully
        var table = new Table();
        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Author[/]");
        table.AddColumn("[yellow]Type[/]");

        foreach (var item in results)
        {
            table.AddRow(item.Id.ToString(), item.Title, item.Author, item.MediaType);
        }
        AnsiConsole.Write(table);
        return 0;
    }
}

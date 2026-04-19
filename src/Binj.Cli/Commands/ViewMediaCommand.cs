using Binj.Application.DTOs;
using Binj.Application.Queries;
using MediatR;
using Spectre.Console;
using Spectre.Console.Cli;

public class ViewMediaCommand : AsyncCommand<ViewMediaSettings>
{
    private readonly IMediator _mediator;

    public ViewMediaCommand(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task<int> ExecuteAsync(CommandContext context, ViewMediaSettings settings)
    {
        // Call the application layer
        var results = await _mediator.Send(new GetAllMediaQuery());

        if (results == null || results.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No media found matching those filters.[/]");
            return 0;
        }
        // Use Spectre's Table to display data
        var table = new Table();
        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Author[/]");
        table.AddColumn("[yellow]Type[/]");

        // Add each row using the attributes of the media
        foreach (var item in results)
        {
            table.AddRow(item.Id.ToString(), item.Title, item.Author, item.MediaType);
        }
        AnsiConsole.Write(table);
        return 0;
    }
}

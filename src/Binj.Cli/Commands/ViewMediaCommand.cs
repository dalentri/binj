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

    protected override async Task<int> ExecuteAsync(
        CommandContext context,
        ViewMediaSettings settings,
        CancellationToken cancellationToken
    )
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
        table.AddColumn("[yellow]Creator[/]");
        table.AddColumn("[yellow]Type[/]");

        // Add each row using the attributes of the media
        foreach (var item in results)
        {
            var color = item.MediaType switch
            {
                "Book" => "blue",
                "Comic" => "green",
                "Movie" => "purple",
            };

            table.AddRow(
                item.Id.ToString(),
                item.Title,
                item.Author,
                $"[{color}]{item.MediaType}[/]"
            );
        }
        AnsiConsole.Write(table);
        return 0;
    }
}

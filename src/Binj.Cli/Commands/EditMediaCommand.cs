using Binj.Application.DTOs;
using Binj.Application.Features;
using Binj.Application.Queries;
using Binj.Domain.Entities;
using MediatR;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Binj.Cli.Commands;

public class EditMediaCommand<TEntity> : AsyncCommand<EditMediaSettings>
    where TEntity : Media, new()
{
    private readonly IMediator _mediator;

    public EditMediaCommand(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected override async Task<int> ExecuteAsync(
        CommandContext context,
        EditMediaSettings settings,
        CancellationToken cancellationToken
    )
    {
        // send a request for all media in the db
        var allMedia = await _mediator.Send(new GetAllMediaQuery(), cancellationToken);

        if (Guid.TryParse(settings.Id, out Guid mediaId))
        {
            var existingMedia = await _mediator.Send(
                new GetMediaByIdQuery(mediaId),
                cancellationToken
            );
        }
        else
        {
            AnsiConsole.MarkupLine("[red] Invalid Id, please try again. [/]");
            return 1;
        }

        // Create a list of the specific media they want to edit
        var filteredMedia = allMedia.Where(m => m.MediaType == typeof(TEntity).Name).ToList();

        var selectedDto = AnsiConsole.Prompt(
            new SelectionPrompt<MediaDto>()
                .Title($"Select the [yellow]{typeof(TEntity).Name}[/] to edit:")
                .UseConverter(m => m.Title)
                .AddChoices(filteredMedia)
        );

        var mediaToEdit = await _mediator.Send(
            new GetMediaByIdQuery(selectedDto.Id),
            cancellationToken
        );

        var newTitle = AnsiConsole.Ask<string>("Title:", selectedDto.Title);
        var newAuthor = AnsiConsole.Ask<string>("Author", selectedDto.Author);
        var newMediaType = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select the media type:")
                .AddChoices("Movie", "Book", "Comic")
        );

        await _mediator.Send(
            new UpdateMediaCommand<TEntity>(
                selectedDto.Id,
                entity =>
                {
                    entity.Title = newTitle;
                    entity.Author = newAuthor;
                    entity.Type = newMediaType;
                }
            ),
            cancellationToken
        );

        AnsiConsole.MarkupLine($"[green]Edited {typeof(TEntity).Name}...[/]");
        return 0;
    }
}

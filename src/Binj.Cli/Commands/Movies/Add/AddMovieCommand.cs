using Binj.Application.Interfaces;
using Binj.Domain.Entities;

namespace Binj.Cli.Commands.Comics.Add;

public class AddMovieCommand : AddMediaCommand<Movie, AddMovieSettings>
{
    public AddMovieCommand(IMediaRepository<Movie> repository)
        : base(repository) { }

    protected override void MapToEntity(Movie entity, AddMovieSettings settings)
    {
        entity.Title = settings.Title;
        entity.Status = settings.Status;
        entity.Genre = settings.Genre;
        entity.Rating = settings.Rating;
    }
}

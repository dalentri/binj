namespace Binj.Application.Features.Movies.Add;

using Binj.Application.Interfaces;
using Binj.Domain.Entities;

public class AddMovieCommandHandler
{
    private readonly IMovieRepository _repostory;

    public AddMovieCommandHandler(IMovieRepository repository)
    {
        _repostory = repository;
    }

    public async Task Handle(AddMovie request)
    {
        var movie = new Movie(
            request.Title,
            request.Genre,
            request.Status,
            request.Rating,
            request.DateAdded
        );

        await _repostory.AddAsync(movie);
    }
}

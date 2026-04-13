using Binj.Application.Interfaces;
using Binj.Domain.Entities;

namespace Binj.Application.Features.Comics;

public class AddComicHandler
{
    private readonly IComicRepository _repository;

    public AddComicHandler(IComicRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(AddComic request)
    {
        var comic = new Comic(
            request.Title,
            int.Parse(request.Volume),
            request.Issue,
            request.Status,
            request.Rating
        );

        await _repository.AddAsync(comic);
    }
}

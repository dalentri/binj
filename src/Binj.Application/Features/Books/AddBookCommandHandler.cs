using Binj.Application.Interfaces;
using Binj.Domain.Entities;

namespace Binj.Application.Features.Books;

public class AddBookCommandHandler
{
    // Dependency Injection
    // We use readonly to ensure it doesnt change after init
    // "Privately init an immutable repository var"
    private readonly IBookRepository _repository;

    // Constructor that takes in the passed in repository and assigns to prev init var
    public AddBookCommandHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    // asynchronously handles the request by
    public async Task Handle(AddBook request)
    {
        var book = new Book(request.Title, int.Parse(request.Page), request.Status);

        await _repository.AddAsync(book);
    }
}

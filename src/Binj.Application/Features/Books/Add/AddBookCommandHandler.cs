using Binj.Application.Interfaces;
using Binj.Domain.Entities;

namespace Binj.Application.Features.Books.Add;

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

    // asynchronously handles the request to write to the database
    public async Task Handle(AddBook request)
    {
        // Collect the vars from the request into their columns
        var book = new Book(
            request.Title,
            int.Parse(request.Page),
            request.Status,
            request.DateAdded
        );

        // Send the book object to the db
        await _repository.AddAsync(book);
    }
}

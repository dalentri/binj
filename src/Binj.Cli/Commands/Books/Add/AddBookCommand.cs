using Binj.Application.Interfaces;
using Binj.Domain.Entities;

public class AddBookCommand : AddMediaCommand<Book, AddBookSettings>
{
    public AddBookCommand(IMediaRepository<Book> repository)
        : base(repository) { }

    protected override void MapToEntity(Book entity, AddBookSettings settings)
    {
        entity.Title = settings.Title;
        entity.Page = settings.Page;
        entity.Author = settings.Author;
        entity.DateAdded = DateTime.Now;
    }
}

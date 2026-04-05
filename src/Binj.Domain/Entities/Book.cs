namespace Binj.Domain.Entities;

public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public int Page { get; private set; }

    public Book(string title, string page) { }
}

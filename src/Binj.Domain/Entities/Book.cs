namespace Binj.Domain.Entities;

public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public int Page { get; private set; }

    //TODO: Possible values: not_started, up_next, reading, finished, dropped
    public string Status { get; private set; }

    // Constructor
    public Book(string title, int page, string status)
    {
        // Check for invalid titles
        ArgumentException.ThrowIfNullOrWhiteSpace(title);

        Id = Guid.NewGuid();
        Title = title;
        Page = page;
        Status = status;
    }
}

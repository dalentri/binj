namespace Binj.Domain.Entities;

public class Book : Media
{
    public Book()
        : base() { }

    public int Page { get; set; }

    // Constructor
    public Book(string title, int page, string status, DateTime dateAdded)
        : base(title, status, dateAdded)
    {
        Page = page;
    }
}

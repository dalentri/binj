namespace Binj.Domain.Entities;

public abstract class Media
{
    protected Media() { }

    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Status { get; set; } = "Planned";
    public string Type => GetType().Name;
    public DateTime DateAdded { get; set; } = DateTime.Now;

    protected Media(string title, string status, DateTime dateAdded)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);

        Id = Guid.NewGuid();
        Title = title;
        Status = status;
        DateAdded = dateAdded;
    }
}

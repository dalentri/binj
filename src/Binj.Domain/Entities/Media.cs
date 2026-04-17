namespace Binj.Domain.Entities;

public abstract class Media
{
    protected Media() { }

    public Guid Id { get; protected set; }
    public string Title { get; protected set; }
    public string Status { get; protected set; }

    // TODO: should I add date?
    // public DateTime DateAdded { get; protected set; }

    protected Media(string title, string status)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);

        Id = Guid.NewGuid();
        Title = title;
        Status = status;
    }
}

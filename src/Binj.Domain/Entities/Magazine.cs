namespace Binj.Domain.Entities;

public class Magazine
{
    // Attributes
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public int Volume { get; private set; }
    public int Issue { get; private set; }
    public string Status { get; private set; }
    public int Rating { get; private set; }

    public Magazine(string title, int volume, int issue, string status, int rating)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);

        Id = Guid.NewGuid();
        Title = title;
        Volume = volume;
        Issue = issue;
        Status = status;
        Rating = rating;
    }
}

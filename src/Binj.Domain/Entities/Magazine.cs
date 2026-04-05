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
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Invalid title, please provide the name of the magazine.");
        }

        Id = Guid.NewGuid();
        Title = title;
        Volume = volume;
        Issue = issue;
        Status = status;
        Rating = rating;
    }
}

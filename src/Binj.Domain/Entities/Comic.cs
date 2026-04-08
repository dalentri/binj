namespace Binj.Domain.Entities;

public class Comic : Media
{
    // Attributes
    public int Volume { get; private set; }
    public int Issue { get; private set; }
    public int Rating { get; private set; }

    // Constructor
    public Comic(string title, int volume, int issue, string status, int rating)
        // Pass shared data
        : base(title, status)
    {
        Volume = volume;
        Issue = issue;
        Rating = rating;
    }
}

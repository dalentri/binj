namespace Binj.Domain.Entities;

public class Comic : Media
{
    public Comic()
        : base() { }

    // Attributes
    public int Volume { get; set; }
    public int Issue { get; set; }
    public int Rating { get; set; }

    // Constructor
    public Comic(string title, int volume, int issue, string status, int rating, DateTime dateAdded)
        // Pass shared data
        : base(title, status, dateAdded)
    {
        Volume = volume;
        Issue = issue;
        Rating = rating;
    }
}

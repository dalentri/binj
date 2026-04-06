namespace Binj.Domain.Entities;

public class Movie
{
    // getters setters
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Genre { get; private set; }
    public string Status { get; private set; }
    public int Rating { get; private set; }

    // Constructor
    public Movie(string title, string genre, string status, int rating)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(genre);
        ArgumentException.ThrowIfNullOrWhiteSpace(status);

        // Rating must be 0-10
        if (rating < 0 || rating > 10)
        {
            throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be 0-10");
        }

        // Assignment
        Id = Guid.NewGuid();
        Title = title;
        Genre = genre;
        Status = status;
        Rating = rating;
    }
}

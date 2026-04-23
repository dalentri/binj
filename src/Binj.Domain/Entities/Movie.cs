namespace Binj.Domain.Entities;

public class Movie : Media
{
    public Movie()
        : base() { }

    // getters setters
    public string Genre { get; set; }
    public int Rating { get; set; }

    // Constructor
    // TODO: Move genre & rating to the base set?
    public Movie(string title, string genre, string status, int rating, DateTime dateAdded)
        : base(title, status, dateAdded)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(genre);

        // Rating must be 0-10
        if (rating < 0 || rating > 10)
        {
            throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be 0-10");
        }

        // Assignment
        Genre = genre;
        Rating = rating;
    }
}

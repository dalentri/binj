using Binj.Application.DTOs;
using Binj.Application.Queries;
using Binj.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetMediaByIdQueryHandler : IRequestHandler<GetMediaByIdQuery, MediaDto>
{
    private readonly BinjDbContext _context;

    public GetMediaByIdQueryHandler(BinjDbContext context)
    {
        _context = context;
    }

    public async Task<MediaDto> Handle(GetMediaByIdQuery request, CancellationToken ct)
    {
        // Check if its a book
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == request.Id, ct);
        if (book != null)
        {
            return new MediaDto(book.Id, book.Title, book.Author, "Book", book.DateAdded);
        }

        //Check if its a comic
        var comic = await _context.Comics.FirstOrDefaultAsync(b => b.Id == request.Id, ct);
        if (comic != null)
        {
            return new MediaDto(comic.Id, comic.Title, comic.Author, "Comic", comic.DateAdded);
        }

        //Check if its a movie
        var movie = await _context.Movies.FirstOrDefaultAsync(b => b.Id == request.Id, ct);
        if (movie != null)
        {
            return new MediaDto(movie.Id, movie.Title, movie.Author, "Movie", movie.DateAdded);
        }
        else
        {
            throw new KeyNotFoundException($"Media with Id {request.Id} not found.");
        }
    }
}

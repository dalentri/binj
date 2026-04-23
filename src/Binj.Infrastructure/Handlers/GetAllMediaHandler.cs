using Binj.Application.DTOs;
using Binj.Application.Queries;
using Binj.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Binj.Infrastructure.Handlers;

public class GetAllMediaHandler : IRequestHandler<GetAllMediaQuery, List<MediaDto>>
{
    private readonly BinjDbContext _context;

    public GetAllMediaHandler(BinjDbContext context)
    {
        _context = context;
    }

    public async Task<List<MediaDto>> Handle(GetAllMediaQuery request, CancellationToken ct)
    {
        // Get books and map to dto
        var books = await _context
            .Books.Select(b => new MediaDto(b.Id, b.Title, b.Author, "Book"))
            .ToListAsync(ct);

        // Get comics and map to dto
        var comics = await _context
            .Comics.Select(b => new MediaDto(b.Id, b.Title, b.Author, "Comic"))
            .ToListAsync(ct);

        // Get movies and map to dto
        var movies = await _context
            .Movies.Select(b => new MediaDto(b.Id, b.Title, b.Author, "Movie"))
            .ToListAsync(ct);

        // Append all tables to each other
        var allMedia = books.Concat(comics).Concat(movies).ToList();

        return allMedia;
    }
}

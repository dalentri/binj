namespace Binj.Application.Features.Comics;

public record AddComic(
    string Title,
    string Volume,
    int Issue,
    string Status,
    int Rating,
    DateTime DateAdded
);

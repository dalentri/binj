namespace Binj.Application.Features.Books;

// Gets passed to the Handle function in the handler
public record AddBook(string Title, string Page, string Status);

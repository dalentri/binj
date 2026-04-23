namespace Binj.Application.DTOs;

// The safe list of entity info we want to show the user
public record MediaDto(Guid Id, string Title, string Author, string MediaType, DateTime DateAdded);

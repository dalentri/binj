using MediatR;

// "I want a list of media dtos"
public record GetAllMediaQuery() : IRequest<List<MediaDto>>;

using MediatR;

public record GetAllMediaQuery() : IRequest<List<MediaDto>>;

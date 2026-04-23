using Binj.Application.DTOs;
using MediatR;

namespace Binj.Application.Queries;

// "I want a list of media dtos"
public record GetAllMediaQuery(string? FilterType = null) : IRequest<List<MediaDto>>;

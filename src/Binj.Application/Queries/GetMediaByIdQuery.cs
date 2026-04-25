using Binj.Application.DTOs;
using MediatR;

namespace Binj.Application.Queries;

public record GetMediaByIdQuery(Guid Id) : IRequest<MediaDto>;

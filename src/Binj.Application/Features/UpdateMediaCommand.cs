using Binj.Domain.Entities;
using MediatR;

namespace Binj.Application.Features;

public record UpdateMediaCommand<TEntity>(Guid Id, Action<TEntity> UpdateAction) : IRequest<Unit>
    where TEntity : Media;

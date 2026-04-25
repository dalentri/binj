using Binj.Application.Features;
using Binj.Application.Interfaces;
using Binj.Domain.Entities;
using MediatR;

namespace Binj.Application.Features;

public class UpdateMediaCommandHandler<TEntity> : IRequestHandler<UpdateMediaCommand<TEntity>, Unit>
    where TEntity : Media
{
    private readonly IMediaRepository<TEntity> _repository;

    public UpdateMediaCommandHandler(IMediaRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateMediaCommand<TEntity> request, CancellationToken ct)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            throw new KeyNotFoundException(
                $"{typeof(TEntity).Name} with ID {request.Id} not found."
            );
        }
        request.UpdateAction(entity);
        await _repository.UpdateAsync(entity);

        return Unit.Value;
    }
}

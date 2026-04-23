using Binj.Application.Interfaces;
using Binj.Domain.Entities;

namespace Binj.Cli.Commands.Comics.Add;

public class AddComicCommand : AddMediaCommand<Comic, AddComicSettings>
{
    public AddComicCommand(IMediaRepository<Comic> repository)
        : base(repository) { }

    protected override void MapToEntity(Comic entity, AddComicSettings settings)
    {
        entity.Title = settings.Title;
        entity.Issue = settings.Issue;
        entity.Volume = settings.Volume;
        entity.Status = settings.Status;
        entity.Rating = settings.Rating;
    }
}

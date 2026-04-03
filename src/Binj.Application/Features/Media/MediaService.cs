namespace Binj.Application.Features.Media;

public class MediaService : IMediaService
{
    public string AddMedia(string title) => $"[Mock] Added {title} to the list.";

    //TODO: Add to database
    public string ListMedia() => "[Mock] List of current media saved:";
}

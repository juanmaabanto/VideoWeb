using VideoWeb.Models;

namespace VideoWeb.Clients
{
    public interface IYoutubeClient
    {
        Task<VideoApiViewModel> ObtenerVideoInfoAsync(string id);
    }
    
}
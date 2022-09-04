using VideoWeb.Models;

namespace VideoWeb.Repositories
{
    public interface IVideoRepository
    {
        Task<List<Video>> ListarAsync();
        Task<Video> ObtenerAsync(string videoId);
        Task InsertarAsync(Video video);
        Task ActualizarAsync(Video video);
        Task EliminarAsync(string videoId);
    }
    
}
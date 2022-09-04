using Microsoft.EntityFrameworkCore;
using VideoWeb.Models;

namespace VideoWeb.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly MyContext _context;
        public VideoRepository(MyContext context)
        {
            _context = context;
        }

        public async Task ActualizarAsync(Video video)
        {
            _context.Videos!.Update(video);
            await _context.SaveChangesAsync();
        }

        public async Task InsertarAsync(Video video)
        {
            await _context.Videos!.AddAsync(video);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Video>> ListarAsync()
        {
            var query = _context.Videos!.OrderByDescending(v => v.Agregado);

            return await query.ToListAsync();
        }

        public async Task<Video> ObtenerAsync(string? videoId)
        {
            var item = await _context.Videos!.FirstOrDefaultAsync(v => v.VideoId == videoId);

            return item!;
        }

        public async Task EliminarAsync(string videoId)
        {
            var item = await _context.Videos!.FirstOrDefaultAsync(v => v.VideoId == videoId);

            if (item is null)
            {
                return;
            }
            _context.Videos!.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
using System.Net.Http.Headers;
using System.Text.Json;
using VideoWeb.Models;

namespace VideoWeb.Clients
{
    public class YoutubeClient : IYoutubeClient
    {
        protected readonly IConfiguration Configuration;

        public YoutubeClient(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<VideoApiViewModel> ObtenerVideoInfoAsync(string id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    
                    var response = await client.GetAsync($"https://www.googleapis.com/youtube/v3/videos?id={id}&key={Configuration["GoogleApiKey"]}&part=snippet");
                
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var serializeOptions = new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        };

                        return JsonSerializer.Deserialize<VideoApiViewModel>(content, serializeOptions)!;
                    }
                    else
                    {
                        throw new Exception($"No se pudo conectar al servicio: {response.StatusCode}");
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
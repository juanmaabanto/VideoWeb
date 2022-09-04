using System.Diagnostics;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using VideoWeb.Clients;
using VideoWeb.Models;
using VideoWeb.Repositories;

namespace VideoWeb.Controllers;

public class HomeController : Controller
{
    private readonly IYoutubeClient _client;
    private readonly IVideoRepository _repository;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IYoutubeClient client, IVideoRepository repository, ILogger<HomeController> logger)
    {
        _client = client;
        _repository = repository;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var videos = await _repository.ListarAsync();

            return View(videos);
        }
        catch (RetryLimitExceededException)
        {
            ModelState.AddModelError("", "No se puede leer base de datos.");
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(string videoUrl)
    {
        try
        {
            Uri? uri;
            if (!Uri.TryCreate(videoUrl, UriKind.Absolute, out uri))
            {
                return RedirectToAction("Index");
            }

            var query = HttpUtility.ParseQueryString(uri.Query);
            var videoId = query.Get("v");

            if (string.IsNullOrWhiteSpace(videoId))
            {
                return RedirectToAction("Index");
            }

            var videoApi = await _client.ObtenerVideoInfoAsync(videoId);

            if (videoApi is null || videoApi.Items is null || videoApi.Items.Count == 0)
            {
                return RedirectToAction("Index");
            }

            var item = videoApi.Items[0];

            var current = await _repository.ObtenerAsync(videoId);

            if (current is null)
            {
                var video = new Video();
                video.VideoId = videoId;
                video.VideoUrl = videoUrl;
                video.Agregado = DateTime.Now;
                video.Descripcion = item.Snippet!.Description;
                video.ImageUrl = item.Snippet.Thumbnails!.Medium!.Url;
                video.Titulo = item.Snippet!.Title;

                await _repository.InsertarAsync(video);
            }
            else
            {
                current.Agregado = DateTime.Now;
                current.Descripcion = item.Snippet!.Description;
                current.ImageUrl = item.Snippet.Thumbnails!.Medium!.Url;
                current.Titulo = item.Snippet!.Title;

                await _repository.ActualizarAsync(current);
            }

            

            return RedirectToAction("Index");
                
        }
        catch (RetryLimitExceededException)
        {
            ModelState.AddModelError("", "No se pudo registrar.");
        }
        catch (Exception)
        {
            ModelState.AddModelError("", "Error no controlado.");
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(string videoId)
    {
        try
        {
            await _repository.EliminarAsync(videoId);

            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            ModelState.AddModelError("", "Error no controlado.");
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<JsonResult> ObtenerVideo([FromQuery]string videoId)
    {
        var video = await _repository.ObtenerAsync(videoId);

        return Json(video);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


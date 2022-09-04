using System.ComponentModel.DataAnnotations;

namespace VideoWeb.Models;

public class Video
{
    public string? VideoId { get; set; }
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public string? VideoUrl { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? Agregado { get; set; }
}
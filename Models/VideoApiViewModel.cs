namespace VideoWeb.Models;

public class VideoApiViewModel
{
    public List<Item>? Items { get; set; }
}

public class Item
{
    public Snippet? Snippet { get; set; }
}

public class Snippet
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Thumbnail? Thumbnails { get; set; }
}

public class Thumbnail
{
    public Medium? Medium { get; set;}
}

public class Medium
{
    public string? Url { get; set; }
}
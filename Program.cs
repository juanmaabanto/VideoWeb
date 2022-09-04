using VideoWeb;
using VideoWeb.Clients;
using VideoWeb.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IVideoRepository, VideoRepository>();
builder.Services.AddScoped<IYoutubeClient, YoutubeClient>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


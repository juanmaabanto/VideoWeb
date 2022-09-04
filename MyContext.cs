using Microsoft.EntityFrameworkCore;
using VideoWeb.Models;

namespace VideoWeb
{
    public class MyContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public MyContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("Database"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Video>(
                    eb =>
                    {
                        eb.ToTable("Video");
                        eb.HasKey(v => v.VideoId);
                        eb.Property(v => v.Titulo).HasColumnName("Titulo");
                        eb.Property(v => v.Descripcion).HasColumnName("Descripcion");
                        eb.Property(v => v.ImageUrl).HasColumnName("ImageUrl");
                        eb.Property(v => v.VideoUrl).HasColumnName("VideoUrl");
                        eb.Property(v => v.Agregado).HasColumnName("Agregado");
                    });
        }

        public DbSet<Video>? Videos { get; set; }
    }
}


using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeoPlace>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<GeoPlace>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<GeoPlace>()
                .Property(e => e.Name)
                .IsRequired();

            modelBuilder.Entity<WeatherForecast>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<WeatherForecast>()
                .HasOne(e => e.GeoPlace)
                .WithMany()
            .HasForeignKey(e => e.GeoPlaceId);
        }

        public DbSet<GeoPlace> GeoPlaces { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}

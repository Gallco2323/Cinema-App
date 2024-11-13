using CinemaApp.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Configurations
{
    public class CinemaMovieConfiguration : IEntityTypeConfiguration<CinemaMovie>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CinemaMovie> builder)
        {
            builder.HasKey(cm => new { cm.CinemaId, cm.MovieId });

            builder.HasOne(cm => cm.Movie)
                .WithMany(m => m.MovieCinemas)
                .HasForeignKey(cm => cm.MovieId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cm => cm.Cinema)
                .WithMany(c => c.CinemaMovies)
                .HasForeignKey(cm => cm.CinemaId)
                .OnDelete(DeleteBehavior.Restrict);
            //builder.HasData(GenerateCinemaMovies());
        }

        private IEnumerable<CinemaMovie> GenerateCinemaMovies()
        {
            IEnumerable<CinemaMovie> cinemaMovies = new List<CinemaMovie>() 
            { 
            
            new CinemaMovie()
            {
                Cinema = new Cinema()
                {
                    Name = "Cinema City",
                    Location = "Kyustendil"
                },
                Movie = new Movie()
                {
                    Title = "The Matrix",
                    Genre = "Action, Sci-Fi",
                    ReleaseDate = new DateTime(1999, 3, 31),
                    Director = "Lana Wachowski, Lilly Wachowski",

                    Duration = 120,
                    Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers."
                }
            }
            
            };
            return cinemaMovies;
        }
    }
}

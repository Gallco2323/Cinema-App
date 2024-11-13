using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Common.EntityValidationConstants.Movie;

namespace CinemaApp.Data.Configurations
{
    internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
                .HasKey(m => m.Id);
            builder.Property(m => m.Title)
                .HasMaxLength(TitleMaxLength)
                .IsRequired();

            builder
                .Property(m => m.Genre)
                .HasMaxLength(GenreMaxLength)
                .IsRequired();
            builder
                .Property(m => m.Director)
                .HasMaxLength(DirectorMaxLength)
                .IsRequired();
            builder
                .Property(m => m.Description)
                .HasMaxLength(DescriptionMaxLength)
                .IsRequired();
           

            builder.HasData(this.SeedMovies());
        }
        private List<Movie> SeedMovies()
        {
            List<Movie> movies = new List<Movie>()
            {
               new Movie
               {
                   Title = "The Matrix",
                   Genre = "Action",
                   ReleaseDate = new DateTime(1999, 3, 31),
                   Director = "Lana Wachowski",
                   Duration = 136,
                   Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers."
               },
               new Movie
               {
                     Title = "The Shawshank Redemption",
                     Genre = "Drama",
                     ReleaseDate = new DateTime(1994, 10, 14),
                     Director = "Frank Darabont",
                     Duration = 142,
                     Description = "Two imprisoned"
               },
               new Movie
               {
                   Title = "The Godfather",
                   Genre = "Crime",
                   ReleaseDate = new DateTime(1972, 3, 24),
                   Director = "Francis Ford Coppola",
                   Duration = 175,
                   Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
               }
            };
            return movies;
        }
    }
}

using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CinemaApp.Data.Configurations
{
    using static CinemaApp.Common.EntityValidationConstants.Cinema;
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cinema> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(NameMaxLength)
                .IsRequired();

            builder.Property(c => c.Location)
                .HasMaxLength(LocationMaxLength)
                .IsRequired();

            builder.HasData(this.GenerateCinemas());
        }

        private IEnumerable<Cinema> GenerateCinemas()
        {
            IEnumerable<Cinema> cinemas = new List<Cinema>()
            {
                new Cinema
                {
                    Name = "Cinema City",
                    Location = "Sofia"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Plovdiv"
                },
                new Cinema
                {
                    Name = "Cine Max",
                    Location = "Varna"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Burgas"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Ruse"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Stara Zagora"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Pleven"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Sliven"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Dobrich"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Shumen"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Pernik"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Haskovo"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Yambol"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Pazardzhik"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Blagoevgrad"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Veliko Tarnovo"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Vratsa"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Gabrovo"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Asenovgrad"
                },
                new Cinema
                {
                    Name = "Cine Grand",
                    Location = "Kazanlak"
                }

            };
            return cinemas;
        }
    
    }
}

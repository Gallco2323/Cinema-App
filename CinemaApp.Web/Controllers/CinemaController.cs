using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Web.Controllers
{
    public class CinemaController : Controller
    {
        private readonly CinemaDbContext dbContext;
        public CinemaController(CinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<CinemaIndexViewModel> cinemas = await this.dbContext.Cinemas
                .Select(c => new CinemaIndexViewModel
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Location = c.Location
                })
                .OrderBy(c => c.Location)
                .ToArrayAsync();   
            
            return this.View(cinemas);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CinemaCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            Cinema cinema = new Cinema
            {
                Name = model.Name,
                Location = model.Location
            };

           await this.dbContext.Cinemas.AddAsync(cinema);
           await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return this.RedirectToAction("Index");
            }

            bool isGuidValid = Guid.TryParse(id, out Guid cinemaGuid);
            if (!isGuidValid)
            {
                   return this.RedirectToAction("Index");
            }
            Cinema? cinema = await this.dbContext 
                .Cinemas
                .Include(c => c.CinemaMovies)
                .ThenInclude(cm => cm.Movie)
                .FirstOrDefaultAsync(c=>c.Id == cinemaGuid);

            if (cinema == null)
            {
                return this.RedirectToAction("Index");
            }

            CinemaDetailsViewModel viewModel = new CinemaDetailsViewModel
            {
                Name = cinema.Name,
                Location = cinema.Location,
                Movies = cinema.CinemaMovies.Select(cm => new CinemaMovieViewModel
                {
                        
                        Title = cm.Movie.Title,
                        Duration = cm.Movie.Duration,
                       
                    })
                    
                    .ToArray()
            };

            return this.View(viewModel);
        }
    }
}

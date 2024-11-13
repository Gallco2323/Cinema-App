using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static CinemaApp.Common.EntityValidationConstants.Movie;
namespace CinemaApp.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly CinemaDbContext dbContext;

        public MovieController(CinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            IEnumerable<Movie> movies = await this.dbContext.Movies.ToArrayAsync();
            return this.View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddMovieInputModel inputModel)
        {
          //TODO:Add form model + validation
          if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

          bool isDateValid = DateTime.TryParseExact(inputModel.ReleaseDate, ReleaseDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);
            if (!isDateValid)
            {
                this.ModelState.AddModelError(nameof(inputModel.ReleaseDate), "Invalid date format.(dd/MM/yyyy)");
                return this.View(inputModel);
            }

            Movie movie = new Movie
            {
                Title = inputModel.Title,
                Genre = inputModel.Genre,
                ReleaseDate = releaseDate,
                Duration = inputModel.Duration,
                Director = inputModel.Director,
                Description = inputModel.Description
            };
           await this.dbContext.Movies.AddAsync(movie);
           await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);

            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }
            Movie? movie =await this.dbContext.Movies.FirstOrDefaultAsync(m => m.Id == guidId);

            if (movie == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(movie);
        }

        [HttpGet]

        public async Task<IActionResult> AddToProgram(string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);

            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }
            Movie? movie = await this.dbContext.Movies.FirstOrDefaultAsync(m => m.Id == guidId);

            if (movie == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            AddMovieToCinemaViewModel viewModel = new AddMovieToCinemaViewModel
            {
                Id = id!,
                MovieTitle = movie.Title,
                Cinemas = await this.dbContext
                .Cinemas
                .Include(c => c.CinemaMovies)
                .ThenInclude(cm => cm.Movie)
                .Select(c => new CinemaCheckBoxItemInputModel
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Location = c.Location,
                    IsSelected = c.CinemaMovies.Any(cm => cm.MovieId == guidId)
                }).ToListAsync()
            };
            return this.View(viewModel);
           
        }

        [HttpPost]
        public async Task<IActionResult> AddToProgram(AddMovieToCinemaViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }
            Guid movieId = Guid.Parse(inputModel.Id);

            Movie? movie = await this.dbContext.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null)
            {
                   return this.RedirectToAction(nameof(Index));
            }

            ICollection<CinemaMovie> entitiesToAdd = new List<CinemaMovie>();
            ICollection<CinemaMovie> entitiesToRemove = new List<CinemaMovie>();
            foreach (var cinemaInputModel in inputModel.Cinemas)
            {
                Guid cinemaGuid = Guid.Empty;
                bool isCinemaIdValid = Guid.TryParse(cinemaInputModel.Id, out cinemaGuid);
                if (!isCinemaIdValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Invalid cinema selected!");
                    return this.View(inputModel);
                }

                Cinema cinema = await this.dbContext.Cinemas.Include(c => c.CinemaMovies).FirstOrDefaultAsync(c => c.Id == cinemaGuid);

                if (cinema == null)
                {
                    this.ModelState.AddModelError(string.Empty, "Invalid cinema selected!");
                    return this.View(inputModel);
                }
                if (cinemaInputModel.IsSelected)
                {

                 

                    entitiesToAdd.Add(new CinemaMovie
                    {
                        Cinema = cinema,
                        Movie = movie
                    });
                }
                else 
                {
                    if (true)
                    {

                    }

                }


            }
            await this.dbContext.CinemasMovies.AddRangeAsync(entitiesToAdd);
           await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction(nameof(Index),"Cinema" );
        }
    }
}

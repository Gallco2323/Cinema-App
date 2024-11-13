using CinemaApp.Web.ViewModels.Cinema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.ViewModels.Movie
{
    using static CinemaApp.Common.EntityValidationConstants.Movie;
    public class AddMovieToCinemaViewModel
    {

        [Required]
        
       
        public string Id { get; set; } = null!;
        [Required]
        [MaxLength(TitleMaxLength)]
        public string MovieTitle { get; set; } = null!;

        public List<CinemaCheckBoxItemInputModel> Cinemas { get; set; } = new List<CinemaCheckBoxItemInputModel>();
    }
}

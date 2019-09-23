using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.MovieViewModels
{
    public class CreateMovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile Cover { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public DateTime Releas { get; set; }
        public TimeSpan Duration { get; set; }
        public List<MovieGenreTagViewModel> MovieGenreTags { get; set; }
        //public ICollection<MovieGenre> Genre { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.MovieViewModels
{
    public class DetailMovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Cover { get; set; }
        //public string Director { get; set; }
        public DateTime Releas { get; set; }
        public TimeSpan Duration { get; set; }
        public List<MovieGenreTagDetailViewModel> MovieGenreTagDetails { get; set; }
    }
}

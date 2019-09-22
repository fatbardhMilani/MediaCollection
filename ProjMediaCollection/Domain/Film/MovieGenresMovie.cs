using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Film
{
    public class MovieGenresMovie
    {
        public Movie Movie { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public MovieGenre MovieGenre { get; set; }
        [ForeignKey("MovieGenre")]
        public int MovieGenreId { get; set; }
    }
}

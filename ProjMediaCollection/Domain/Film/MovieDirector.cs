using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Film
{
    public class MovieDirector
    {
        public Movie Movie { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Director  Director { get; set; }
        [ForeignKey("Director")]
        public int DirectorId { get; set; }
    }
}

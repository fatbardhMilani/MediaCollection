using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Film
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Cover { get; set; }
        public DateTime Releas { get; set; }
        public TimeSpan Duration { get; set; }
        [NotMapped]
        public ICollection<MovieGenre> Genre { get; set; }


    }
}

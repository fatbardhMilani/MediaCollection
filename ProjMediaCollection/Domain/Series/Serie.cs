using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Series
{
    public class Serie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Cover { get; set; }
        public ICollection<Season> SerieSeasons { get; set; }
        [NotMapped]
        public ICollection<SerieGenresSerie> SerieGenres { get; set; }
    }
}

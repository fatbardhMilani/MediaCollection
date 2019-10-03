using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Series
{
    public class SerieGenresSerie
    {
        public Serie Serie { get; set; }
        [ForeignKey("Serie")]
        public int SerieId { get; set; }

        public SeriesGenre SeriesGenre { get; set; }
        [ForeignKey("SeriesGenre")]
        public int SeriesGenreId { get; set; }
    }
}

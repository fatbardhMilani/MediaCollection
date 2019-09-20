using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Series
{
    public class Season
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Cover { get; set; }
        public ICollection<Episode> SeasonEpisodes { get; set; }
        public Serie Serie { get; set; }
        [ForeignKey("Serie")]
        public int SerieId { get; set; }
    }
}

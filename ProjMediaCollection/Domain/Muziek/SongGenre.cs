using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Muziek
{
    public class SongGenre
    {
        public Song Song { get; set; }
        [ForeignKey("Movie")]
        public int SongId { get; set; }
        public MusicGenre MusicGenre { get; set; }
        [ForeignKey("MusicGenre")]
        public int MusicGenreId { get; set; }
    }
}

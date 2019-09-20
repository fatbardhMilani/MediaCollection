using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Muziek
{
    public class SongArtist
    {
        public Song Song { get; set; }
        [ForeignKey("Song")]
        public int SongId { get; set; }
        public Artist Artist { get; set; }
        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
    }
}

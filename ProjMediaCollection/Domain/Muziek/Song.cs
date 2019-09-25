using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Muziek
{
    public class Song
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        [NotMapped]
        public ICollection<SongGenre> GenresSong { get; set; }
        //public Artist Artist { get; set; }
        //[ForeignKey("Artist")]
        //public int ArtistId { get; set; }
        public Album Album { get; set; }
        [ForeignKey("Album")]
        public int AlbumId { get; set; }
    }
}

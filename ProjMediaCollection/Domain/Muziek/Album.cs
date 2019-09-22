using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Muziek
{
    public class Album
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public byte[] Cover { get; set; }
        [NotMapped]
        public ICollection<Artist> AlbumArtists  { get; set; }
        public ICollection<Song> AlbumSongs { get; set; }
    }
}

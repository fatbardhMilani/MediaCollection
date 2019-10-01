using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Muziek
{
    public class MyMusicPlaylistAlbum
    {
        public int Id { get; set; }

        [ForeignKey("MyMusicPlaylistFK")]
        public MyMusicPlaylist MyMusicPlaylist { get; set; }

        public int MyMusicPlaylistId { get; set; }

        public Album Album { get; set; }
        [ForeignKey("Album")]

        public int AlbumId { get; set; }
    }
}

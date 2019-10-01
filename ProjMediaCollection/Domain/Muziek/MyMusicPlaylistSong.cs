using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Muziek
{
    public class MyMusicPlaylistSong
    {
        public int Id { get; set; }
        [NotMapped]
        [ForeignKey("MyMusicPlaylistFK")]
        public MyMusicPlaylist MyMusicPlaylist { get; set; }

        public int MyMusicPlaylistId { get; set; }

        public Song Song { get; set; }
        [ForeignKey("Album")]

        public int SongId { get; set; }
    }
}

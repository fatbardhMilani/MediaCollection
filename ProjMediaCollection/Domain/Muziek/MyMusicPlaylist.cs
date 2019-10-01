using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Muziek
{
    public class MyMusicPlaylist
    {
        public int Id { get; set; }
        public string PlaylistName { get; set; }
        public IdentityUser User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public ICollection<MyMusicPlaylistAlbum> MyAlbum { get; set; }
        [ForeignKey("MyMusicPlayListAlbum")]
        public int MyMusicPlayListAlbumId { get; set; }

        [NotMapped]
        public ICollection<MyMusicPlaylistSong> MySong { get; set; }
        [ForeignKey("MyMusicPlayListSong")]
        public int MyMusicPlayListSongId { get; set; }
    }
}

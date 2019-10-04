using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Series
{
    public class MySeriePlaylist
    {
        public int Id { get; set; }
        public string PlaylistName { get; set; }
        public IdentityUser User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public ICollection<MySeriePlaylistSerie> MySerie { get; set; }
        [ForeignKey("MySeriePlaylistSerie")]
        public int MySeriePlaylistSerieId { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.UserViewModels
{
    public class AddAlbumViewModel
    {
        public int PlaylistId { get; set; }
        public int AlbumId { get; set; }
        public string UserId { get; set; }

        public string SelectedMusicPlaylist { get; set; }
        public List<SelectListItem> MusicPlaylistToSelect { get; set; }
    }
}

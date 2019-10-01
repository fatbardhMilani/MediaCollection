using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.MusicViewModels
{
    public class AlbumIndexViewModel
    {
        public List<AlbumListViewModel> AlbumList = new List<AlbumListViewModel>();
        public List<SelectListItem> MyMusicPlaylistToSelect { get; set; }
        public string SelectedMyMusicPlaylist { get; set; }
    }
}

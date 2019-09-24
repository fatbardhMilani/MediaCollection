using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.UserViewModels
{
    public class MyMovieIndexViewModel
    {
        public List<MyMovieplaylistViewModel> MyMoviePlayList = new List<MyMovieplaylistViewModel>();
        public string SelectedMoviePlaylist { get; set; }
        public List<SelectListItem> MoviePlaylistToSelect { get; set; }
    }
}

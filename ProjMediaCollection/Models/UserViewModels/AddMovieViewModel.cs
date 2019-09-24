using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.UserViewModels
{
    public class AddMovieViewModel
    {
        public int PlaylistId { get; set; }
        //public string UserId { get; set; }
        public int MovieId { get; set; }
        public string UserId { get; set; }

        public string SelectedMoviePlaylist { get; set; }
        public List<SelectMoviePlaylistViewModel> SelectMoviePlaylistViews { get; set; }
        public List<SelectListItem> MoviePlaylistToSelect { get; set; }

    }
}

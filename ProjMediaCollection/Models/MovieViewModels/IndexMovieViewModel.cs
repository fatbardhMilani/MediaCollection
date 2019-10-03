using Microsoft.AspNetCore.Mvc.Rendering;
using ProjMediaCollection.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.MovieViewModels
{
    public class IndexMovieViewModel
    {
        public List<ListMovieViewModel> MovieList = new List<ListMovieViewModel>();

        public string Search { get; set; }

        public List<MovieGenreTagViewModel> TagSearch { get; set; }


        public string SelectedMoviePlaylist { get; set; }
        public List<SelectListItem> MoviePlaylistToSelect { get; set; }
    }
}

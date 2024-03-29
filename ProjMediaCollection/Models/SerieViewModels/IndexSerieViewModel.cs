﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.SerieViewModels
{
    public class IndexSerieViewModel
    {
        public List<ListSeriesViewModel> SerieList = new List<ListSeriesViewModel>();

        public List<SelectListItem> MySeriePlaylistToSelect { get; set; }
        public string SelectedMySeriePlaylist { get; set; }

        //public string Search { get; set; }

        //public List<MovieGenreTagViewModel> TagSearch { get; set; }


        //public string SelectedMoviePlaylist { get; set; }
        //public List<SelectMoviePlaylistViewModel> SelectMoviePlaylistViews { get; set; }
        //public List<SelectListItem> MoviePlaylistToSelect { get; set; }
    }
}

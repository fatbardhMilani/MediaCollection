﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.MusicViewModels
{
    public class EditAlbumViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile Cover { get; set; }
        //public string Description { get; set; }
        //public string Director { get; set; }
        //public DateTime Releas { get; set; }
        //public TimeSpan Duration { get; set; }
        //public List<MovieGenreTagDetailViewModel> MovieGenreTagDetails { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.MusicViewModels
{
    public class AddSongViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public DateTime Release { get; set; }
        public List<SongGenreTagViewModel> SongGenreTags { get; set; }
        //public ICollection<MusicGenre> GenresSong { get; set; }
        //public Artist Artist { get; set; }
        //[ForeignKey("Artist")]
        //public int ArtistId { get; set; }
        //public Album Album { get; set; }
        //[ForeignKey("Album")]
        //public int AlbumId { get; set; }
    }
}

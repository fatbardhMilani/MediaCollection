using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.MusicViewModels
{
    public class CreateAlbumViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile Cover { get; set; }
        //public ICollection<Artist> AlbumArtists { get; set; }
        //public ICollection<Song> AlbumSongs { get; set; }
    }
}

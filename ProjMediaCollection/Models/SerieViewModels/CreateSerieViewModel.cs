using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.SerieViewModels
{
    public class CreateSerieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Cover { get; set; }
        public List<SerieGenreTagViewModel> SerieGenreTags { get; set; }
        //public ICollection<Season> SerieSeasons { get; set; }
        //[NotMapped]
        //public ICollection<SeriesGenre> SerieGenres { get; set; }
    }
}

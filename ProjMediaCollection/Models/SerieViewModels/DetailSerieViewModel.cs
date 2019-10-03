using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.SerieViewModels
{
    public class DetailSerieViewModel
    {
            public int Id { get; set; }
            public string Title { get; set; }
            public byte[] Cover { get; set; }
            public List<SeasonListViewModel> SeasonsToAddToSerie { get; set; }


            //public string Description { get; set; }
            //public string Director { get; set; }
            //public DateTime Releas { get; set; }
            //public TimeSpan Duration { get; set; }
            public List<SerieGenreTagDetailViewModel> SerieGenreTagDetails { get; set; }
        
    }
}

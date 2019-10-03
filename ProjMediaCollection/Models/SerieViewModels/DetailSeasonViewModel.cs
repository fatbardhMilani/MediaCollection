using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.SerieViewModels
{
    public class DetailSeasonViewModel
    {
        public int Id { get; set; }
        public int SerieId { get; set; }
        public int SeasonId { get; set;}
        public List<EpisodeListViewModel> EpisodesToAddToSeason { get; set; }
    }
}

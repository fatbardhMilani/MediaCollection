﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.SerieViewModels
{
    public class SeasonListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Cover { get; set; }
        public string Description { get; set; }
        public List<EpisodeListViewModel> EpisodesForSeason { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Series
{
    public class SeriesGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SerieGenresSerie> Genre { get; set; }
    }
}

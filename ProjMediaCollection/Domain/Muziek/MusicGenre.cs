﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Muziek
{
    public class MusicGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SongGenre> SongGenres { get; set; }
    }
}

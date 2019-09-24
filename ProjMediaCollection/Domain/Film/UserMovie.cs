using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Film
{
    public class UserMovie
    {
        public int Id { get; set; }
        [NotMapped]
        [ForeignKey("MoviePlaylistFK")]
        public MoviePlaylist MoviePlaylist { get; set; }
        
        public int MoviePlaylistId { get; set; }

        public Movie Movie { get; set; }
        [ForeignKey("MovieIdForeignKey")]

        public int MovieId { get; set; }
    }
}

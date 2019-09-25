using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Film
{
    public class MoviePlaylist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IdentityUser User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public ICollection<UserMovie> UserMovie { get; set; }
        [ForeignKey("UserMovieId")]
        public int UserMovieId { get; set; }
    }
}

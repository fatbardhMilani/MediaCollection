using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Film
{
    public class MovieReview
    {
        public int Id { get; set; }

        public Movie Movie { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public IdentityUser User { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public int Rating { get; set; }

        public string Review { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.MovieViewModels
{
    public class MovieReviewViewModel
    {
        public string UserName { get; set; }
        [Range(0, 10)]
        public int Rating { get; set; }

        public string Review { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.MovieViewModels
{
    public class CreateReviewViewModel
    {
        [Required(ErrorMessage = "score 0-10")]
        public int Rating { get; set; }
        [Required(ErrorMessage = "veld is verplicht")]
        public string Review { get; set; }
    }
}

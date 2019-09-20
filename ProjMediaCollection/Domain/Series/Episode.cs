using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Series
{
    public class Episode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public Season Season { get; set; }
        [ForeignKey("Season")]
        public int SeasonId { get; set; }
    }
}

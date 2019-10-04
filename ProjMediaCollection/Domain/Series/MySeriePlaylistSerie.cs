using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Series
{
    public class MySeriePlaylistSerie
    {
        public int Id { get; set; }

        public MySeriePlaylist MySeriePlaylist { get; set; }
        [NotMapped]
        [ForeignKey("MySeriePlaylist")]
        public int MySeriePlaylistId { get; set; }

        public Serie Serie { get; set; }
        [ForeignKey("Serie")]
        public int SerieId { get; set; }
    }
}

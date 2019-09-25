using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.MusicViewModels
{
    public class AlbumListViewModel
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public byte[] Cover { get; set; }
    }
}

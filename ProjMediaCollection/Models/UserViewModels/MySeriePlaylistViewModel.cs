using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.UserViewModels
{
    public class MySeriePlaylistViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<MySelectedSerieViewModel> MySelectedSerie { get; set; }
    }
}

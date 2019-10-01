using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.UserViewModels
{
    public class MyMusicPlaylistViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<MySelectedMusicViewModel> MySelectedMusic { get; set; }
    }
}

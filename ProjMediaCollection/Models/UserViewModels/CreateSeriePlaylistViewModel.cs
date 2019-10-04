using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.UserViewModels
{
    public class CreateSeriePlaylistViewModel
    {
        public int Id { get; set; }
        public string SeriePlaylistName { get; set; }
        public string UserId { get; set; }
    }
}

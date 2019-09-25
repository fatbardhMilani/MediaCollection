using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Models.UserViewModels
{
    public class MyMovieplaylistViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<MyMoviesListViewModel> MyMoviesLists { get; set; }


        //public int Id { get; set; }
        //public string Title { get; set; }
        //public byte[] Cover { get; set; }
        //public DateTime Releas { get; set; }
        //public byte[] Cover { get; set; }
        //public DateTime Releas { get; set; }
    }
}

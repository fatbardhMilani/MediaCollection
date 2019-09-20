using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Domain.Film
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public DateTime Birthday  { get; set; }
        public byte[] Picture { get; set; }
    }
}

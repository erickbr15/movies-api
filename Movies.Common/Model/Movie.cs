using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.CrossCutting.Model
{
    public class Movie
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IList<string> Genres { get; set; } = new List<string>();
    }
}

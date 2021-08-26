using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinereview.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public int Year { get; set; }
        public String Genre { get; set; }
        public String Sinopsis { get; set; }
        public String CoverImage { get; set; }
    }
}

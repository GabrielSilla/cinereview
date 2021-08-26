using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinereview.Models.DTO
{
    public class MovieDTO
    {
        public Guid? Id { get; set; }
        public String Name { get; set; }
        public int? Year { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public String Genre { get; set; }
        public String Sinopsis { get; set; }
        public String CoverImage { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinereview.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public String name { get; set; }
    }
}

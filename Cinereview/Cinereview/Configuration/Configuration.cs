using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinereview.Configuration
{
    public class Configuration
    {
        private String ConnectionString { get; set; }
        private String DatabaseName { get; set; }

        public Configuration()
        {
            ConnectionString = Environment.GetEnvironmentVariable("CINEREVIEW_CS");
            DatabaseName = Environment.GetEnvironmentVariable("CINEREVIEW_NAME");
        }

        public String GetConnectionString()
        {
            return ConnectionString;
        }

        public String GetDatabaseName()
        {
            return DatabaseName;
        }
    }
}

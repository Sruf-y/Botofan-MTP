using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saptamana8_WPF
{
    public class GlobalVars
    {   
        // fix pentru ca folosesc developmens miscrosoft sql server
        public static String CONNECTION_STRING = "Server=localhost;Database=master;Trusted_Connection=True;" + "TrustServerCertificate=True;";
        public static bool DATABASE_RECREATE_ON_STARTUP = false;
    }
}

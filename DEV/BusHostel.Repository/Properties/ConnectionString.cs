using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusHostel.Repository
{
    public class ConnectionString
    {       
        public static string Connection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["bushostel.database"].ConnectionString;
            }
        }
    }
}
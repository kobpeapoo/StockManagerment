using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerment.Utility {
    public static class ConnectionDb {
       
        public static string connectString { get; set; }
        public static string serverName { get; set; }
        public static string userName { get; set; }
        public static string password { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElibManagementSystem_DataAccessLayer
{
    using System.Configuration;
    static class Configuration
    {
        static string _connectionString, _providerName;
        static Configuration()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ELIB_Management_System"].ConnectionString;
            _providerName = ConfigurationManager.ConnectionStrings["ELIB_Management_System"].ProviderName;
        }
        public static string ConnectionString { get { return _connectionString; } }
        public static string ProviderName { get { return _providerName; } }

    }
}

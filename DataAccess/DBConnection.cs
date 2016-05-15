using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    internal class DBConnection
    {
        const string connString = @"Data Source=localhost;Initial Catalog=popotokitchen;Integrated Security=True";

        public static SqlConnection GetDBConnection()
        {
            return new SqlConnection(connString);
        }
    }
}

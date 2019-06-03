using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    internal static class DBConnection
    {
        private static readonly string connString = @"Data Source=localhost;Initial Catalog=SLPDB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(connString);
            return conn;
        }
    }
}

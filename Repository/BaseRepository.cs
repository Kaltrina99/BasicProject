using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BaseRepository
    {
        private string connectionString;

        public BaseRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public SqlConnection GetConnection()
        {
            try
            {
                var con = new SqlConnection(connectionString);
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Userupdateservice
{
    public class NTService : INTService
    {
        private readonly string? connectionstring;
        public NTService(IConfiguration configuration) {
            this.connectionstring = configuration.GetConnectionString("dbconnection");
        }
        public string updateuser()
        {
            string response = string.Empty;
            try
            {
                using (SqlConnection sql = new SqlConnection(this.connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("sp_updatestatus", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sql.Open();
                    using(var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            response = reader["response"].ToString();
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;

        }
    }
}

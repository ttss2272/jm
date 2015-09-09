using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public   class DLLogin
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        
        public SqlDataReader checklogin(string username, string password)
        {
            SqlConnection con = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand("checklogin",con );
            SqlParameter param = new SqlParameter("@Username", username );
            SqlParameter param1 = new SqlParameter("@Password", password );
           
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            param1.Direction = ParameterDirection.Input;
            param1.DbType = DbType.String ;
            cmd.Parameters.Add(param );
            cmd.Parameters.Add(param1 );
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        
    

   }
}

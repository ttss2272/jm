using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public  class DLSelectProject
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        public SqlDataReader GetProjectByAddInv1(int ClId,DateTime from ,DateTime to)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlParameter param,param1,param2;

           
            SqlCommand cmd = new SqlCommand("GetProjectByAddInv", con);
            param = new SqlParameter("@ClientId", ClId );
            cmd.CommandType = CommandType.StoredProcedure;
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.Int32 ;
            param1 = new SqlParameter("@From", from );
            param2 = new SqlParameter("@To", to);
            cmd.CommandType = CommandType.StoredProcedure;
            param1.Direction = ParameterDirection.Input;
            param1.DbType = DbType.Date ;
            cmd.CommandType = CommandType.StoredProcedure;
            param2.Direction = ParameterDirection.Input;
            param2.DbType = DbType.Date ;
            cmd.Parameters.Add(param);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                //con.Close();
                //con.Dispose();
            }
        }
    }
}

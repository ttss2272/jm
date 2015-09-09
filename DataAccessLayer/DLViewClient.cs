using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public  class DLViewClient
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        public SqlDataReader GetClientByNameType1(string ClNm, int App)
        {
            SqlConnection con = new SqlConnection(connstr );
            SqlCommand cmd = new SqlCommand("GetClientByNameType",con );
            SqlParameter param = new SqlParameter("@ClientName",ClNm );
            SqlParameter param1= new SqlParameter("@Approve", App);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            cmd.Parameters.Add(param);
            param1.Direction = ParameterDirection.Input;
            param1.DbType = DbType.Int32 ;
            cmd.Parameters.Add(param1);
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
        public SqlDataReader GetClientAtLoad1()
        {
            SqlConnection con = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand("GetClientAtLoad", con);
           
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

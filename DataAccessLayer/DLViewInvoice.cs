using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
  public   class DLViewInvoice
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        
        public SqlDataReader  ViewInvoiceDet( string  ClNm,string  InNo,int app)
        {
            SqlConnection con = new SqlConnection(connstr);
            con.Open();
            SqlParameter param, param1, param2;
            param = new SqlParameter("@ClientName", ClNm);
            param1 = new SqlParameter("@InvoiceNo", InNo);
            param2 = new SqlParameter("@Approve", app);

            SqlCommand cmd = new SqlCommand("ViewInvoice", con);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            param1.Direction = ParameterDirection.Input;
            param1.DbType = DbType.String;
            param2.Direction = ParameterDirection.Input;
            param2.DbType = DbType.Int32 ;
            cmd.Parameters.Add(param );
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            
            
            
            cmd.CommandType = CommandType.StoredProcedure;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   
  public   class DLTransferToTally
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        string msg;
        public string  transferTallyInv(string from, string to)
        {
            SqlConnection con = new SqlConnection(constr );
            SqlCommand cmd = new SqlCommand("tallyinvoice",con );
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fmdt",from );
           
            cmd.Parameters.AddWithValue("@todt", to );
            try
            {
                con.Open();
                msg= cmd.ExecuteNonQuery ().ToString();
            }
            catch
            {
            }
            finally
            {
            }
            return msg;
        }
        public string transferTallyRec(string from, string to)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand("tallyreceipts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fmdt", from);

            cmd.Parameters.AddWithValue("@todt", to);
            try
            {
                con.Open();
                msg = cmd.ExecuteNonQuery().ToString();
            }
            catch
            {
            }
            finally
            {
            }
            return msg;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient; 

namespace DataAccessLayer
{
   public class DLServices
    {
       string msg;
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        public string saveServices1(string strServiceName, int intIsDeleted, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("saveServices", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ServiceName", SqlDbType.VarChar);
                param1.Value = strServiceName;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
                param2.Value = intIsDeleted;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param3.Value = intApprove;
                cmd.Parameters.Add(param3);

                msg = cmd.ExecuteNonQuery().ToString();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            return msg;
        }
        public SqlDataReader getServiceName1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getServiceName", con);
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

        public SqlDataAdapter getService1(string strServiceName)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getClerk", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter param1 = new SqlParameter("@ServiceName", SqlDbType.VarChar);
                param1.Value = strServiceName;
                cmd.Parameters.Add(param1);
                return da;
                //cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                //cmd.Dispose();
                //con.Close();
                //con.Dispose();
            }
        }
        public SqlDataReader getServiceGridFill1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getServiceGridFill", con);
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

            }
        }
        public SqlDataReader gridFillApproveService1(int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillApproveService", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param4 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param4.Direction = ParameterDirection.Input;
                param4.Value = intApprove;
                cmd.Parameters.Add(param4);

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
        public SqlDataReader gridFillApproveServiceName1(string strServiceName,int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillApproveServiceName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ServiceName", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strServiceName;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Value = intApprove;
                cmd.Parameters.Add(param2);

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
        public SqlDataReader getServicePrice1(int intClientID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getServicePrice", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param4 = new SqlParameter("@ClientID", SqlDbType.VarChar);
                param4.Direction = ParameterDirection.Input;
                param4.Value = intClientID;
                cmd.Parameters.Add(param4);

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
        public SqlDataReader getClientIDforService1(string strClientName1)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getClientIDforService", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param1.Value = strClientName1;
                cmd.Parameters.Add(param1);

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
        public SqlDataReader getServiceDetailsForUpdate1(int intServiceId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getServiceDetailsForUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ServiceId", SqlDbType.Int);
                param1.Value = intServiceId;
                cmd.Parameters.Add(param1);

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

        public void updateService1(int intServiceId, string strServiceName, int intIsDeleted, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("updateService", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ServiceId", SqlDbType.Int);
                param1.Value = intServiceId;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@ServiceName", SqlDbType.VarChar);
                param2.Value = strServiceName;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@IsDeleted", SqlDbType.Int);
                param3.Value = intIsDeleted;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@Approve", SqlDbType.Int);
                param4.Value = intApprove;
                cmd.Parameters.Add(param4);

                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }
    }
}

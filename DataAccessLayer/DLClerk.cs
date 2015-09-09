using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient; 

namespace DataAccessLayer
{
    public class DLClerk
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        string msg;
        public string saveClerk1(string strClerkName, string strAddress1, string strAddress2, string strAddress3, string strAddress4, string strTelephone, string strMobile, string strPanNo, string strEmailId, decimal decTDSRate, int intIsDeleted, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("saveClerk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClerkName", SqlDbType.VarChar);
                param1.Value = strClerkName;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@Address1", SqlDbType.VarChar);
                param2.Value = strAddress1;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Address2", SqlDbType.VarChar);
                param3.Value = strAddress2;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@Address3", SqlDbType.VarChar);
                param4.Value = strAddress3;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@Address4", SqlDbType.VarChar);
                param5.Value = strAddress4;
                cmd.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@Telephone", SqlDbType.VarChar);
                param6.Value = strTelephone;
                cmd.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@Mobile", SqlDbType.VarChar);
                param7.Value = strMobile;
                cmd.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter("@PanNo", SqlDbType.VarChar);
                param8.Value = strPanNo;
                cmd.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter("@EmailId", SqlDbType.VarChar);
                param9.Value = strEmailId;
                cmd.Parameters.Add(param9);

                SqlParameter param10 = new SqlParameter("@TDSRate", SqlDbType.VarChar);
                param10.Value = decTDSRate;
                cmd.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
                param11.Value = intIsDeleted;
                cmd.Parameters.Add(param11);

                SqlParameter param12 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param12.Value = intApprove;
                cmd.Parameters.Add(param12);

                //cmd.ExecuteNonQuery();
                msg =cmd.ExecuteNonQuery().ToString();
                //cmd.ExecuteNonQuery().ToString();
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

        public SqlDataReader getClerkDetails1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getClerkDetails", con);
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

        public SqlDataAdapter getClerk1(string strClerkName)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getClerk", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter param1 = new SqlParameter("@ClerkName", SqlDbType.VarChar);
                param1.Value = strClerkName;
                cmd.Parameters.Add(param1);
                return da;
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

        public SqlDataReader getClerkName1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getClerkName", con);
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

        public SqlDataReader gridFillApproveClerk1(int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillApproveClerk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
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

            }
        }

        public SqlDataReader gridFillApproveClerkName1(string strClerkName, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillApproveClerkName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClerkName", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strClerkName;
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

            }
        }
        public SqlDataReader getClerkDetailsForUpdate1(int intClerkId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getClerkDetailsForUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClerkId", SqlDbType.Int);
                param1.Value = intClerkId;
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

        public void updateClerk1(int intClerkId, string strAddress1, string strAddress2, string strAddress3, string strAddress4, string strTelephone, string strMobile, string strPanNo, string strEmailId, decimal decTDSRate, int intIsDeleted, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("updateClerk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClerkId", SqlDbType.VarChar);
                param1.Value = intClerkId;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@Address1", SqlDbType.VarChar);
                param2.Value = strAddress1;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Address2", SqlDbType.VarChar);
                param3.Value = strAddress2;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@Address3", SqlDbType.VarChar);
                param4.Value = strAddress3;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@Address4", SqlDbType.VarChar);
                param5.Value = strAddress4;
                cmd.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@Telephone", SqlDbType.VarChar);
                param6.Value = strTelephone;
                cmd.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@Mobile", SqlDbType.VarChar);
                param7.Value = strMobile;
                cmd.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter("@PanNo", SqlDbType.VarChar);
                param8.Value = strPanNo;
                cmd.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter("@EmailId", SqlDbType.VarChar);
                param9.Value = strEmailId;
                cmd.Parameters.Add(param9);

                SqlParameter param10 = new SqlParameter("@TDSRate", SqlDbType.VarChar);
                param10.Value = decTDSRate;
                cmd.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter("@IsDeleted", SqlDbType.Int);
                param11.Value = intIsDeleted;
                cmd.Parameters.Add(param11);

                SqlParameter param12 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param12.Value = intApprove;
                cmd.Parameters.Add(param12);

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

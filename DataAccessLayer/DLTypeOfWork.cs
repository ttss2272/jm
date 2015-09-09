using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient; 

namespace DataAccessLayer
{
   public class DLTypeOfWork
    {
       string msg;
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        public string saveTypeOfWork1(string strWork, int intIsDeleted, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("saveTypeOfWork", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@Work", SqlDbType.VarChar);
                param1.Value = strWork;
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
        public SqlDataReader getTypeOfWork1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getTypeOfWork", con);
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

        public SqlDataAdapter getWorkTypeOfWork1(string strWork)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getWorkTypeOfWork", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter param1 = new SqlParameter("@Work", SqlDbType.VarChar);
                param1.Value = strWork;
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
        public SqlDataReader gridFillApproveTypWrk1(int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillApproveTypWrk", con);
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
        public SqlDataReader gridFillApproveTypWrkName1(string strWork,int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillApproveTypWrkName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@Work", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strWork;
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
        public SqlDataReader isDelProjectChecked1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelProjectChecked", con);
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
        public SqlDataReader isDelTypWrkChecked1(int intIsDeleted)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelTypWrkChecked", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param2 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Value = intIsDeleted;
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

        public SqlDataReader isDelTypWrkCheckedWork1(string strWork,int intIsDeleted)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelTypWrkCheckedWork", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param2 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Value = intIsDeleted;
                cmd.Parameters.Add(param2);
                
                SqlParameter param3 = new SqlParameter("@Work", SqlDbType.VarChar);
                param3.Direction = ParameterDirection.Input;
                param3.Value = strWork;
                cmd.Parameters.Add(param3);

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

        public SqlDataReader isDelTypWrkAppCheckedWork1(string strWork,int intApprove, int intIsDeleted)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelTypWrkAppCheckedWork", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param2 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Value = intIsDeleted;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Work", SqlDbType.VarChar);
                param3.Direction = ParameterDirection.Input;
                param3.Value = strWork;
                cmd.Parameters.Add(param3);

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
        public SqlDataReader getTypeWrkDetailsForUpdate1(int intTypeofWorkID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getTypeWrkDetailsForUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@TypeofWorkID", SqlDbType.Int);
                param1.Value = intTypeofWorkID;
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

        public void updateTypeOfWork1(int intTypeofWorkID, string strWork, int intIsDeleted, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("updateTypeOfWork", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@TypeofWorkID", SqlDbType.Int);
                param1.Value = intTypeofWorkID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@Work", SqlDbType.VarChar);
                param2.Value = strWork;
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

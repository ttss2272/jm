using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient; 

namespace DataAccessLayer
{
   public class DLDocument
    {
       string msg;
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        public string saveDocument1(string strDocument, int intIsDeleted, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("saveDocument", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@Document", SqlDbType.VarChar);
                param1.Value = strDocument;
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

        public SqlDataReader getDocument1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getDocument", con);
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

        public SqlDataAdapter getDocDocument1(string strDocument)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getDocDocument", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter param1 = new SqlParameter("@Document", SqlDbType.VarChar);
                param1.Value = strDocument;
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

        public SqlDataReader gridFillApproveDoc1(int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillApproveDoc", con);
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

        public SqlDataReader gridFillApproveDocName1(string strDocument, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillApproveDocName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@Document", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strDocument;
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

        public SqlDataReader isDelDocChecked1(int intIsDeleted)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelDocChecked", con);
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

        public SqlDataReader isDelDocNameChecked1(string strDocument, int intIsDeleted)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelDocNameChecked", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@Document", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strDocument;
                cmd.Parameters.Add(param1);

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

        public SqlDataReader isDelDocAppChkChecked1(int intApprove, int intIsDeleted)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelDocAppChkChecked", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = intApprove;
                cmd.Parameters.Add(param1);

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

        public SqlDataReader isDelDocNameAppChecked1(string strDocument,int intApprove, int intIsDeleted)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelDocNameAppChecked", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@Document", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strDocument;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Value = intApprove;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
                param3.Direction = ParameterDirection.Input;
                param3.Value = intIsDeleted;
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
        public SqlDataReader getDocDetailsForUpdate1(int intDocumentID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getDocDetailsForUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@DocumentID", SqlDbType.Int);
                param1.Value = intDocumentID;
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

        public void updateDocument1(int intDocumentID, string strDocument, int intIsDeleted, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("updateDocument", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@DocumentID", SqlDbType.Int);
                param1.Value = intDocumentID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@Document", SqlDbType.VarChar);
                param2.Value = strDocument;
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

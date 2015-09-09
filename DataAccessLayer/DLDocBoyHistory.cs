using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient; 


namespace DataAccessLayer
{
   public class DLDocBoyHistory
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        public void saveDocumentBoyHistory1(DateTime dtDate, int intDBID, string strDocumentBoy, string strRemarks, int intProjectID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("saveDocumentBoyHistory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@Date", SqlDbType.VarChar);
                param1.Value = dtDate;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@DBID", SqlDbType.VarChar);
                param2.Value = intDBID;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@DocumentBoy", SqlDbType.VarChar);
                param3.Value = strDocumentBoy;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@Remarks", SqlDbType.VarChar);
                param4.Value = strRemarks;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@ProjectID", SqlDbType.VarChar);
                param5.Value = intProjectID;
                cmd.Parameters.Add(param5);

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

        public void saveDocBoyHistoryDetails1(int intDBHID, int intDID, string strDocument)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("saveDocBoyHistoryDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@DBHID", SqlDbType.VarChar);
                param1.Value = intDBHID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@DID", SqlDbType.VarChar);
                param2.Value = intDID;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Document", SqlDbType.VarChar);
                param3.Value = strDocument;
                cmd.Parameters.Add(param3);

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
        public SqlDataReader getDocBoyIdCode1(string strName)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getDocBoyIdCode", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar);
                param1.Value = strName;
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
                //cmd.Dispose();
                //con.Close();
                //con.Dispose();
            }
        }
        public SqlDataAdapter getDocOnDocBoyHistory1(int intProjectID)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getDocOnDocBoyHistory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectID", SqlDbType.VarChar);
                param1.Value = intProjectID;
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
        public SqlDataReader getDocBoyhistoryId1(string strName,int intProjectId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getDocBoyhistoryId", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar);
                param1.Value = strName;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@ProjectId", SqlDbType.VarChar);
                param2.Value = intProjectId;
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
                //cmd.Dispose();
                //con.Close();
                //con.Dispose();
            }
        }
        public SqlDataAdapter   fillGridDBHistoryDetails1(int intProjectID)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("fillGridDBHistoryDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectID", SqlDbType.VarChar);
                param1.Value = intProjectID;
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

        public DataSet showSelectedDocOfDocBoy1(int intDBHID)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("showSelectedDocOfDocBoy", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet dt = new DataSet();
            try
            {
                SqlParameter param1 = new SqlParameter("@DBHID", SqlDbType.Int );
                param1.Value = intDBHID;
                cmd.Parameters.Add(param1);
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt ;
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
        public DataTable getSelectedUnSelectedDoc1( int intprojectID, int  intDocumentboyId,DateTime dtdate,int intDBHID)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
         
            con.Open();
            SqlCommand cmd = new SqlCommand("getSelectedUnSelectedDoc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@projectID", SqlDbType.Int);
                param1.Value = intprojectID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@DocumentboyId", SqlDbType.Int);
                param2.Value = intDocumentboyId;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@date", SqlDbType.Date);
                param3.Value = dtdate;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@DBHID", SqlDbType.Int);
                param4.Value = intDBHID;
                cmd.Parameters.Add(param4);

                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
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

        public SqlDataReader getDBHistDetails1(int intprojectID, int intDBHID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getDBHistDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@projectID", SqlDbType.Int);
                param1.Value = intprojectID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@DBHID", SqlDbType.Int);
                param2.Value = intDBHID;
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

        public SqlDataReader getSelDocFromDBHDetails1(int intprojectID, int intDocumentboyId, DateTime dtdate,int intDBHID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getSelDocFromDBHDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@projectID", SqlDbType.Int);
                param1.Value = intprojectID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@DocumentboyId", SqlDbType.Int);
                param2.Value = intDocumentboyId;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@date", SqlDbType.Date);
                param3.Value = dtdate;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@DBHID", SqlDbType.Int);
                param4.Value = intDBHID;
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
        public void delUnselectedDocOfDocBoy1(int intDBHID, int intDID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("delUnselectedDocOfDocBoy", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@DBHID", SqlDbType.VarChar);
                param1.Value = intDBHID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@DID", SqlDbType.VarChar);
                param2.Value = intDID;
                cmd.Parameters.Add(param2);

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
        public void updateDocBoyHistory1(int intProjectID, DateTime dtDate, int intDBID, string strDocumentBoy, string strRemarks,int intDBHID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("updateDocBoyHistory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectID", SqlDbType.Int);
                param1.Value = intProjectID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@Date", SqlDbType.Date);
                param2.Value = dtDate;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@DBID", SqlDbType.Int);
                param3.Value = intDBID;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@DocumentBoy", SqlDbType.VarChar);
                param4.Value = strDocumentBoy;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@Remarks", SqlDbType.VarChar);
                param5.Value = strRemarks;
                cmd.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@DBHID", SqlDbType.Int);
                param6.Value = intDBHID;
                cmd.Parameters.Add(param6);

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient; 

namespace DataAccessLayer
{
   public class DLDocumentBoy
   {
       string msg;
       string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
       public string saveDocumentBoy1(string strName, string strMobile, int intIsDeleted, string strCode, int intApprove,string strMailID)
       {
           SqlConnection con = new SqlConnection(connstr);
           con.Open();
           SqlCommand cmd = new SqlCommand("saveDocumentBoy", con);
           cmd.CommandType = CommandType.StoredProcedure;
           try
           {
               SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar);
               param1.Value = strName;
               cmd.Parameters.Add(param1);

               SqlParameter param2 = new SqlParameter("@Mobile", SqlDbType.VarChar);
               param2.Value = strMobile;
               cmd.Parameters.Add(param2);

               SqlParameter param3 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
               param3.Value = intIsDeleted;
               cmd.Parameters.Add(param3);

               SqlParameter param4 = new SqlParameter("@Code", SqlDbType.VarChar);
               param4.Value = strCode;
               cmd.Parameters.Add(param4);

               SqlParameter param5 = new SqlParameter("@Approve", SqlDbType.VarChar);
               param5.Value = intApprove;
               cmd.Parameters.Add(param5);

               SqlParameter param6 = new SqlParameter("@MailID", SqlDbType.NVarChar);
               param6.Value = strMailID;
               cmd.Parameters.Add(param6);

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

       public SqlDataReader getDocumentBoy1()
       {
           SqlConnection con = new SqlConnection(connstr);
           con.Open();
           SqlCommand cmd = new SqlCommand("getDocumentBoy", con);
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
       public SqlDataReader getDocBoyCode1(string strName)
       {
           SqlConnection con = new SqlConnection(connstr);
           con.Open();
           SqlCommand cmd = new SqlCommand("getDocBoyCode", con);
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
               //con.Close();
               //con.Dispose();
           }
       }

       public SqlDataReader gridFillApproveDocumentBoy1(int intApprove)
       {
           SqlConnection con = new SqlConnection(connstr);
           con.Open();
           SqlCommand cmd = new SqlCommand("gridFillApproveDocumentBoy", con);
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

       public SqlDataReader gridFillApproveDocumentBoyName1(string strName, int intApprove)
       {
           SqlConnection con = new SqlConnection(connstr);
           con.Open();
           SqlCommand cmd = new SqlCommand("gridFillApproveDocumentBoyName", con);
           cmd.CommandType = CommandType.StoredProcedure;
           try
           {
               SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar);
               param1.Direction = ParameterDirection.Input;
               param1.Value = strName;
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

       public SqlDataReader isDelDocBoyChecked1(int intIsDeleted)
       {
           SqlConnection con = new SqlConnection(connstr);
           con.Open();
           SqlCommand cmd = new SqlCommand("isDelDocBoyChecked", con);
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

           }
       }

       public SqlDataReader isDelDocBoyNameChecked1(string strName, int intIsDeleted)
       {
           SqlConnection con = new SqlConnection(connstr);
           con.Open();
           SqlCommand cmd = new SqlCommand("isDelDocBoyNameChecked", con);
           cmd.CommandType = CommandType.StoredProcedure;
           try
           {
               SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar);
               param1.Direction = ParameterDirection.Input;
               param1.Value = strName;
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

           }
       }

       public SqlDataReader isDelDocBoyNameAppChecked1(string strName,int intApprove, int intIsDeleted)
       {
           SqlConnection con = new SqlConnection(connstr);
           con.Open();
           SqlCommand cmd = new SqlCommand("isDelDocBoyNameAppChecked", con);
           cmd.CommandType = CommandType.StoredProcedure;
           try
           {
               SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar);
               param1.Direction = ParameterDirection.Input;
               param1.Value = strName;
               cmd.Parameters.Add(param1);

               SqlParameter param2 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
               param2.Direction = ParameterDirection.Input;
               param2.Value = intIsDeleted;
               cmd.Parameters.Add(param2);

               SqlParameter param3 = new SqlParameter("@Approve", SqlDbType.VarChar);
               param3.Direction = ParameterDirection.Input;
               param3.Value = intApprove;
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

           }
       }

       public SqlDataReader getDocBoyMaxCode1()
       {
           SqlConnection con = new SqlConnection(connstr);
           con.Open();
           SqlCommand cmd = new SqlCommand("getDocBoyMaxCode", con);
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
       public SqlDataReader getDocBoyName1()
       {
           SqlConnection con = new SqlConnection(connstr);
           con.Open();
           SqlCommand cmd = new SqlCommand("getDocBoyName", con);
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
       public SqlDataReader getDocBoyDetailsForUpdate1(int intDocumentBoyID)
       {
           SqlConnection con = new SqlConnection(connstr);
           con.Open();
           SqlCommand cmd = new SqlCommand("getDocBoyDetailsForUpdate", con);
           cmd.CommandType = CommandType.StoredProcedure;
           try
           {
               SqlParameter param1 = new SqlParameter("@DocumentBoyID", SqlDbType.Int);
               param1.Value = intDocumentBoyID;
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

       public void updateDocumentBoy1(int intDocumentBoyID, string strMobile, int intIsDeleted, int intApprove,string strMailID)
       {
           SqlConnection con = new SqlConnection(connstr);
           con.Open();
           SqlCommand cmd = new SqlCommand("updateDocumentBoy", con);
           cmd.CommandType = CommandType.StoredProcedure;
           try
           {
               SqlParameter param1 = new SqlParameter("@DocumentBoyID", SqlDbType.Int);
               param1.Value = intDocumentBoyID;
               cmd.Parameters.Add(param1);

               SqlParameter param2 = new SqlParameter("@Mobile", SqlDbType.VarChar);
               param2.Value = strMobile;
               cmd.Parameters.Add(param2);

               SqlParameter param3 = new SqlParameter("@IsDeleted", SqlDbType.Int);
               param3.Value = intIsDeleted;
               cmd.Parameters.Add(param3);

               SqlParameter param4 = new SqlParameter("@Approve", SqlDbType.Int);
               param4.Value = intApprove;
               cmd.Parameters.Add(param4);

               SqlParameter param5 = new SqlParameter("@MailID", SqlDbType.NVarChar);
               param5.Value = strMailID;
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
    }
}

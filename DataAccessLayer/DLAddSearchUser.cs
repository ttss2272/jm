using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
   public  class DLAddSearchUser
   {
       string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
       string result; 
       public string  addSearchUser(string strUsername, string strPassword, string strType,string mailid,int intIsDeleted)
       {
           SqlConnection con = new SqlConnection(constr);
           con.Open();
           SqlCommand cmd = new SqlCommand("AddSearchUser", con);
           cmd.CommandType = CommandType.StoredProcedure;
           try
           {
               SqlParameter param1 = new SqlParameter("@Username", SqlDbType.VarChar);
               param1.Value = strUsername;
               cmd.Parameters.Add(param1);

               SqlParameter param2 = new SqlParameter("@Password", SqlDbType.VarChar);
               param2.Value = strPassword;
               cmd.Parameters.Add(param2);

               SqlParameter param3 = new SqlParameter("@MailID", SqlDbType.VarChar);
               param3.Value = strPassword;
               cmd.Parameters.Add(param3);

               SqlParameter param4 = new SqlParameter("@Type", SqlDbType.VarChar);
               param4.Value = strType;
               cmd.Parameters.Add(param4);


               SqlParameter param5 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
               param5.Value = intIsDeleted;
               cmd.Parameters.Add(param5);

               result= cmd.ExecuteNonQuery().ToString();
           }
           catch(Exception ex)
           {
               result = ex.Message.ToString();
           }
           finally
           {

               cmd.Dispose();
               con.Close();
               con.Dispose();


           }
           return result;
           
       }
       
       public SqlDataReader FillUserAtLoad1()
       {
           SqlConnection con = new SqlConnection(constr);
           SqlCommand cmd = new SqlCommand("FillUserAtLoad", con);
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
       public DataSet getAdminCount()
       {
           DataSet ds = null;
           SqlConnection con = new SqlConnection(constr);
           con.Open();
           try
           {
               SqlCommand cmd = new SqlCommand("getAdminCount", con);
               cmd.CommandType = CommandType.StoredProcedure;
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               ds = new DataSet();
               da.Fill(ds);
           }
           catch (Exception ex)
           {
               ex.Message.ToString();
           }
           finally
           {
               con.Close();
           }
           return ds;
       }

       public SqlDataReader userisdeleted(string Unm,int isdel)
       {
           SqlConnection con = new SqlConnection(constr );
           SqlCommand cmd = new SqlCommand("Userisdeleted",con );
           cmd.CommandType = CommandType.StoredProcedure;
           SqlParameter param = new SqlParameter("@Username",Unm );
           SqlParameter param1 = new SqlParameter("@IsDeleted",isdel );
           param.Direction = ParameterDirection.Input;
           param.DbType = DbType.String;
           param1.Direction = ParameterDirection.Input;
           param1.DbType = DbType.Int32 ;
           cmd.Parameters.Add(param );
           cmd.Parameters.Add(param1);
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
       public SqlDataReader GetUserById(int UserId)
       {
           SqlConnection con = new SqlConnection(constr);
           SqlCommand cmd = new SqlCommand("GetUserById", con);
           cmd.CommandType = CommandType.StoredProcedure;
           SqlParameter param = new SqlParameter("@UserId", UserId );
         
        
           param.Direction = ParameterDirection.Input;
           param.DbType = DbType.Int32;
           cmd.Parameters.Add(param);
     
           try
           {
               con.Open();
               SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection );
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
       public SqlDataReader FillUsrNmType1(string Unm, string  type)
       {
           SqlConnection con = new SqlConnection(constr);
           SqlCommand cmd = new SqlCommand("FillUsrNmType", con);
           cmd.CommandType = CommandType.StoredProcedure;
           SqlParameter param = new SqlParameter("@Username", Unm);
           SqlParameter param1 = new SqlParameter("@Type", type);
           param.Direction = ParameterDirection.Input;
           param.DbType = DbType.String;
           param1.Direction = ParameterDirection.Input;
           param1.DbType = DbType.String;
           cmd.Parameters.Add(param);
           cmd.Parameters.Add(param1);
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
               //con.Close();
           }
       }
       public SqlDataReader FillUsrNmTypeIsDel1(string Unm, string type,int isdel)
       {
           SqlConnection con = new SqlConnection(constr);
           SqlCommand cmd = new SqlCommand("FillUsrNmTypeIsDel", con);
           cmd.CommandType = CommandType.StoredProcedure;
           SqlParameter param = new SqlParameter("@Username", Unm);
           SqlParameter param1 = new SqlParameter("@Type", type);

           SqlParameter param2 = new SqlParameter("@IsDeleted", isdel);
           param.Direction = ParameterDirection.Input;
           param.DbType = DbType.String;
           param1.Direction = ParameterDirection.Input;
           param1.DbType = DbType.String;
           param2.Direction = ParameterDirection.Input;
           param2.DbType = DbType.Int32  ;
           cmd.Parameters.Add(param);
           cmd.Parameters.Add(param1);
           cmd.Parameters.Add(param2);
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
               //con.Close();
           }
       }
       public string  UpdateUser(int userid,string Unm,string pass,string mailid,int isdel)
       {
           SqlConnection con = new SqlConnection(constr);
           SqlCommand cmd = new SqlCommand("UpdateUser", con);
           cmd.CommandType = CommandType.StoredProcedure;
           SqlParameter param = new SqlParameter("@UserId", userid );
           SqlParameter param1 = new SqlParameter("@Username", Unm);
           SqlParameter param2 = new SqlParameter("@Password", pass );
           SqlParameter param3 = new SqlParameter("@MailID", mailid);
           SqlParameter param4 = new SqlParameter("@IsDeleted", isdel);
           
           param.Direction = ParameterDirection.Input;
           param.DbType = DbType.Int32 ;
           
           param1.Direction = ParameterDirection.Input;
           param1.DbType = DbType.String;
           
           param2.Direction = ParameterDirection.Input;
           param2.DbType = DbType.String;
           
           param3.Direction = ParameterDirection.Input;
           param3.DbType = DbType.String;

           param4.Direction = ParameterDirection.Input;
           param4.DbType = DbType.Int32;

           cmd.Parameters.Add(param);
           cmd.Parameters.Add(param1);
           cmd.Parameters.Add(param2);
           cmd.Parameters.Add(param3);
           cmd.Parameters.Add(param4);

           try
           {
               con.Open();
               result = cmd.ExecuteNonQuery().ToString();
              
           }
           catch(Exception ex)
           {
               result = ex.Message.ToString();
           }
           finally
           {
               con.Close(); 
              
           }
           return result;
       }
       public SqlDataReader FillTypeIsDel1(string type, int isdel)
       {
           SqlConnection con = new SqlConnection(constr);
           SqlCommand cmd = new SqlCommand("FillTypeIsDel", con);
           cmd.CommandType = CommandType.StoredProcedure;
         
           SqlParameter param1 = new SqlParameter("@Type", type);

           SqlParameter param2 = new SqlParameter("@IsDeleted", isdel);
           
           param1.Direction = ParameterDirection.Input;
           param1.DbType = DbType.String;
           param2.Direction = ParameterDirection.Input;
           param2.DbType = DbType.Int32;
           
           cmd.Parameters.Add(param1);
           cmd.Parameters.Add(param2);
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
               //con.Close();
           }
       }
    }
}

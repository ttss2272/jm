using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public  class DLViewReceipt
    {
       string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
       public SqlDataReader ViewRecByClNmRecNoApp1(string ClNm, int RecNo, int App,DateTime from ,DateTime to)
       {
           SqlConnection con = new SqlConnection(connstr );
           SqlCommand cmd = new SqlCommand("ViewRecByClNmRecNoApp",con );
           SqlParameter param = new SqlParameter("@ClientName",ClNm );
           SqlParameter param1 = new SqlParameter("@ReceiptNo", RecNo );
           SqlParameter param2 = new SqlParameter("@Approve", App );
           SqlParameter param3 = new SqlParameter("@From", from);
           SqlParameter param4 = new SqlParameter("@To", to);
           param.Direction = ParameterDirection.Input;
           param.DbType = DbType.String;
           cmd.Parameters.Add(param);
           param1.Direction = ParameterDirection.Input;
           param1.DbType = DbType.Int32 ;
           cmd.Parameters.Add(param1);
           param2.Direction = ParameterDirection.Input;
           param2.DbType = DbType.Int32 ;
           cmd.Parameters.Add(param2);
           param3.Direction = ParameterDirection.Input;
           param3.DbType = DbType.Date;
           cmd.Parameters.Add(param3 );
           param4.Direction = ParameterDirection.Input;
           param4.DbType = DbType.Date;
           cmd.Parameters.Add(param4);
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
       public SqlDataReader GetRecByClNmApp1(string ClNm, int App)
       {
           SqlConnection con = new SqlConnection(connstr);
           SqlCommand cmd = new SqlCommand("GetRecByClNmApp", con);
           SqlParameter param = new SqlParameter("@ClientName", ClNm);

           SqlParameter param2 = new SqlParameter("@Approve", App);
           param.Direction = ParameterDirection.Input;
           param.DbType = DbType.String;
           cmd.Parameters.Add(param);

           param2.Direction = ParameterDirection.Input;
           param2.DbType = DbType.Int32;
           cmd.Parameters.Add(param2);

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
       public SqlDataReader GetRecByRecNoApp(int RecNo, int App)
       {
           SqlConnection con = new SqlConnection(connstr);
           SqlCommand cmd = new SqlCommand("GetRecByRecNoApp", con);
           SqlParameter param = new SqlParameter("@ReceiptNo", RecNo);

           SqlParameter param2 = new SqlParameter("@Approve", App);
           param.Direction = ParameterDirection.Input;
           param.DbType = DbType.Int32 ;
           cmd.Parameters.Add(param);

           param2.Direction = ParameterDirection.Input;
           param2.DbType = DbType.Int32;
           cmd.Parameters.Add(param2);

           cmd.CommandType = CommandType.StoredProcedure;
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
            public SqlDataReader GetNoOfTrnsTotAmtRec1(string ClNm,  int App,DateTime from,DateTime to)
       {
           SqlConnection con = new SqlConnection(connstr);
           SqlCommand cmd = new SqlCommand("GetNoOfTrnsTotAmtRec", con);
           SqlParameter param = new SqlParameter("@ClientName", ClNm);
    
           SqlParameter param1 = new SqlParameter("@Approve", App);
           SqlParameter param2 = new SqlParameter("@From", from );
           SqlParameter param3 = new SqlParameter("@To", to);
           param.Direction = ParameterDirection.Input;
           param.DbType = DbType.String;
           cmd.Parameters.Add(param);
          
           param1.Direction = ParameterDirection.Input;
           param1.DbType = DbType.Int32;
           cmd.Parameters.Add(param1);
           param2.Direction = ParameterDirection.Input;
           param2.DbType = DbType.Date ;
           cmd.Parameters.Add(param2);
           param3.Direction = ParameterDirection.Input;
           param3.DbType = DbType.Date ;
           cmd.Parameters.Add(param3);
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
            public SqlDataReader GetRecClFrmToApp1(string ClNm, int App,DateTime from,DateTime to)
            {
                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand("GetRecClFrmToApp", con);
                SqlParameter param = new SqlParameter("@ClientName", ClNm);

                SqlParameter param1 = new SqlParameter("@Approve", App);
                SqlParameter param2 = new SqlParameter("@From", from );
                SqlParameter param3 = new SqlParameter("@To", to);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                
                param1.Direction = ParameterDirection.Input;
                param1.DbType = DbType.Int32 ;
                param2.Direction = ParameterDirection.Input;
                param2.DbType = DbType.Date ;
                param3.Direction = ParameterDirection.Input;
                param3.DbType = DbType.Date ;
                cmd.Parameters.Add(param);

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);

                
                cmd.Parameters.Add(param3);
                cmd.CommandType = CommandType.StoredProcedure;
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
            public SqlDataReader ViewRecFromToApp1(DateTime from,DateTime to, int App)
            {
                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand("ViewRecFromToApp", con);
                SqlParameter param = new SqlParameter("@From", from);
                SqlParameter param1 = new SqlParameter("@To", to);
                SqlParameter param2 = new SqlParameter("@Approve", App);
               
               
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Date  ;

                param1.Direction = ParameterDirection.Input;
                param1.DbType = DbType.Date  ;
                param2.Direction = ParameterDirection.Input;
                param2.DbType = DbType.Int32;
             
                cmd.Parameters.Add(param);

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);


                
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
            public SqlDataReader getNoOfTrnsToAmtbyRecNo1(string ClNm,int RecNo, int App, DateTime from, DateTime to)
            {
                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand("getNoOfTrnsToAmtbyRecNo", con);
                SqlParameter param = new SqlParameter("@ClientName", ClNm);
                SqlParameter param1 = new SqlParameter("@ReceiptNo", RecNo );
                SqlParameter param2 = new SqlParameter("@Approve", App);
                SqlParameter param3 = new SqlParameter("@From", from);
                SqlParameter param4 = new SqlParameter("@To", to);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;

                param1.Direction = ParameterDirection.Input;
                param1.DbType = DbType.Int32;
                param2.Direction = ParameterDirection.Input;
                param2.DbType = DbType.Int32 ;
                param3.Direction = ParameterDirection.Input;
                param3.DbType = DbType.Date;
                param4.Direction = ParameterDirection.Input;
                param4.DbType = DbType.Date ;
                cmd.Parameters.Add(param);

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);


                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior .CloseConnection );
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

            public SqlDataReader GetNoOfTrnsFromToApp(DateTime from, DateTime to,int App )
            {
                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand("GetNoOfTrnsFromToApp", con);
                SqlParameter param = new SqlParameter("@From", from);
                SqlParameter param1 = new SqlParameter("@To", to);
                SqlParameter param2 = new SqlParameter("@Approve", App);
               
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Date ;

                param1.Direction = ParameterDirection.Input;
                param1.DbType = DbType.Date ;
                param2.Direction = ParameterDirection.Input;
                param2.DbType = DbType.Int32;
              
                cmd.Parameters.Add(param);

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.CommandType = CommandType.StoredProcedure;
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

            public SqlDataReader GetNoOfTransRecNoApp(int Recno, int App)
            {
                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand("GetNoOfTransRecNoApp", con);
                SqlParameter param = new SqlParameter("@ReceiptNo", Recno );
               
                SqlParameter param2 = new SqlParameter("@Approve", App);

                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Int32 ;

                param2.Direction = ParameterDirection.Input;
                param2.DbType = DbType.Int32 ;
                cmd.Parameters.Add(param);
                cmd.Parameters.Add(param2);
                cmd.CommandType = CommandType.StoredProcedure;
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
            public SqlDataReader getAgainstBills(string Clientname, int Recno, DateTime from,DateTime to,int app)
            {
                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand("getAgainstBills", con);
                SqlParameter param = new SqlParameter("@ClientName", Clientname );
                SqlParameter param1 = new SqlParameter("@ReceiptNo", Recno);
                SqlParameter param2 = new SqlParameter("@From", from );

                SqlParameter param3 = new SqlParameter("@To", to );
                SqlParameter param4 = new SqlParameter("@Approve", app);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String ;
                param1.Direction = ParameterDirection.Input;
                param1.DbType = DbType.Int32;
                param2.Direction = ParameterDirection.Input;
                param2.DbType = DbType.Date ;
                param3.Direction = ParameterDirection.Input;
                param3.DbType = DbType.Date;
                param4.Direction = ParameterDirection.Input;
                param4.DbType = DbType.Int32 ;
                cmd.Parameters.Add(param);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.CommandType = CommandType.StoredProcedure;
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
            public SqlDataReader getNoOfTransRecAgainstBills(string Clientname, int Recno, DateTime from, DateTime to,int app)
            {
                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand("getNoOfTransRecAgainstBills", con);
                SqlParameter param = new SqlParameter("@ClientName", Clientname);
                SqlParameter param1 = new SqlParameter("@ReceiptNo", Recno);
                SqlParameter param2 = new SqlParameter("@From", from);

                SqlParameter param3 = new SqlParameter("@To", to);
                SqlParameter param4 = new SqlParameter("@Approve", app);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                param1.Direction = ParameterDirection.Input;
                param1.DbType = DbType.Int32;
                param2.Direction = ParameterDirection.Input;
                param2.DbType = DbType.Date;
                param3.Direction = ParameterDirection.Input;
                param3.DbType = DbType.Date;
                param4.Direction = ParameterDirection.Input;
                param4.DbType = DbType.Int32;
                cmd.Parameters.Add(param);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.CommandType = CommandType.StoredProcedure;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public  class DLAddReceipt
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;


        public void addReceipt(int intReceiptNo, DateTime dateReceiptDate, int intClId, int intGrpId, string strpaytyp,double doubleAmt,double doubleTDS, double doubleDisc, string strBnkNm, string strChqDftNo, DateTime dtChqDftDate, int intAgainstBills, double  intbalAmt, int intTDSCertRecvd, string strCmmnts, string strClNm, string strSubGrpNm, int intIsDel, double BillAmt, double TDSPerc, int intApp)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("AddReceipt", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ReceiptNo", SqlDbType.Int );
                param1.Value = intReceiptNo;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@ReceiptDate", SqlDbType.Date );
                param2.Value = dateReceiptDate;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@ClientID", SqlDbType.Int );
                param3.Value = intClId;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@GroupID", SqlDbType.Int );
                param4.Value = intGrpId;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@PaymentType", SqlDbType.VarChar);
                param5.Value = strpaytyp;
                cmd.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@Amount", SqlDbType.Float );
                param6.Value = doubleAmt ;
                cmd.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@TDS", SqlDbType.Float );
                param7.Value = doubleTDS ;
                cmd.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter("@BankName", SqlDbType.VarChar);
                param8.Value = strBnkNm;
                cmd.Parameters.Add(param8);
                SqlParameter param9 = new SqlParameter("@Discount", SqlDbType.Float );
                param9.Value = doubleDisc  ;
                cmd.Parameters.Add(param9);


                SqlParameter param10 = new SqlParameter("@ChqDraftNo", SqlDbType.VarChar);
                param10.Value = strChqDftNo;
                cmd.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter("@ChqDraftDate", SqlDbType.VarChar);
                param11.Value = dtChqDftDate;
                cmd.Parameters.Add(param11);

                SqlParameter param12 = new SqlParameter("@IsOnAccount", SqlDbType.VarChar);
                param12.Value = intAgainstBills;
                cmd.Parameters.Add(param12);

                SqlParameter param13 = new SqlParameter("@BalanceAmount", SqlDbType.VarChar);
                param13.Value = intbalAmt;
                cmd.Parameters.Add(param13);

                SqlParameter param14 = new SqlParameter("@TDSCertReceived", SqlDbType.VarChar);
                param14.Value = intTDSCertRecvd;
                cmd.Parameters.Add(param14);

                SqlParameter param15 = new SqlParameter("@Comments", SqlDbType.VarChar);
                param15.Value = strCmmnts;
                cmd.Parameters.Add(param15);

                SqlParameter param16 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param16.Value = strClNm;
                cmd.Parameters.Add(param16);

                SqlParameter param17 = new SqlParameter("@SubGroupName", SqlDbType.VarChar);
                param17.Value = strSubGrpNm;
                cmd.Parameters.Add(param17);

                SqlParameter param18 = new SqlParameter("@isDeleted", SqlDbType.VarChar);
                param18.Value = intIsDel;
                cmd.Parameters.Add(param18);

                SqlParameter param19 = new SqlParameter("@BillAmount", SqlDbType.Float );
                param19.Value = BillAmt;
                cmd.Parameters.Add(param19);

                SqlParameter param20 = new SqlParameter("@TDSPerc", SqlDbType.Float );
                param20.Value = TDSPerc;
                cmd.Parameters.Add(param20);

                SqlParameter param21 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param21.Value = intApp;
                cmd.Parameters.Add(param21);

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

        public void UpdateReceipt(int RecId, DateTime dateReceiptDate, int intGrpId, string strpaytyp, double doubleAmt, double doubleTDS, double doubleDisc, string strBnkNm, string strChqDftNo, DateTime dtChqDftDate, int intAgainstBills, double intbalAmt, int intTDSCertRecvd, string strCmmnts, string strSubGrpNm, int intIsDel, double BillAmt, double TDSPerc, int intApp)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateReceipt", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {

                SqlParameter param1 = new SqlParameter("@ReceiptId", SqlDbType.Int);
                param1.Value = RecId ;
                cmd.Parameters.Add(param1);
                SqlParameter param2 = new SqlParameter("@ReceiptDate", SqlDbType.Date);
                param2.Value = dateReceiptDate;
                cmd.Parameters.Add(param2);

                

                SqlParameter param4 = new SqlParameter("@GroupID", SqlDbType.Int);
                param4.Value = intGrpId;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@PaymentType", SqlDbType.VarChar);
                param5.Value = strpaytyp;
                cmd.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@Amount", SqlDbType.Float);
                param6.Value = doubleAmt;
                cmd.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@TDS", SqlDbType.Float);
                param7.Value = doubleTDS;
                cmd.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter("@BankName", SqlDbType.VarChar);
                param8.Value = strBnkNm;
                cmd.Parameters.Add(param8);
                SqlParameter param9 = new SqlParameter("@Discount", SqlDbType.Float);
                param9.Value = doubleDisc;
                cmd.Parameters.Add(param9);


                SqlParameter param10 = new SqlParameter("@ChqDraftNo", SqlDbType.VarChar);
                param10.Value = strChqDftNo;
                cmd.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter("@ChqDraftDate", SqlDbType.VarChar);
                param11.Value = dtChqDftDate;
                cmd.Parameters.Add(param11);

                SqlParameter param12 = new SqlParameter("@IsOnAccount", SqlDbType.VarChar);
                param12.Value = intAgainstBills;
                cmd.Parameters.Add(param12);

                SqlParameter param13 = new SqlParameter("@BalanceAmount", SqlDbType.VarChar);
                param13.Value = intbalAmt;
                cmd.Parameters.Add(param13);

                SqlParameter param14 = new SqlParameter("@TDSCertReceived", SqlDbType.VarChar);
                param14.Value = intTDSCertRecvd;
                cmd.Parameters.Add(param14);

                SqlParameter param15 = new SqlParameter("@Comments", SqlDbType.VarChar);
                param15.Value = strCmmnts;
                cmd.Parameters.Add(param15);

                
                SqlParameter param17 = new SqlParameter("@SubGroupName", SqlDbType.VarChar);
                param17.Value = strSubGrpNm;
                cmd.Parameters.Add(param17);

                SqlParameter param18 = new SqlParameter("@isDeleted", SqlDbType.VarChar);
                param18.Value = intIsDel;
                cmd.Parameters.Add(param18);

                SqlParameter param19 = new SqlParameter("@BillAmount", SqlDbType.Float);
                param19.Value = BillAmt;
                cmd.Parameters.Add(param19);

                SqlParameter param20 = new SqlParameter("@TDSPerc", SqlDbType.Float);
                param20.Value = TDSPerc;
                cmd.Parameters.Add(param20);

                SqlParameter param21 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param21.Value = intApp;
                cmd.Parameters.Add(param21);

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

        public void DelAdjustAmt(int BillId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("DelAdjustAmt", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {

                SqlParameter param1 = new SqlParameter("@BillId", SqlDbType.Int);
                param1.Value = BillId;
                cmd.Parameters.Add(param1);
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
            }
        }
        public SqlDataReader getClientRec()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetClientName", con);
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
       
        public SqlDataReader GetClientIdByNm1(string ClNm)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetClientIdByNm", con);
            SqlParameter param = new SqlParameter("@ClientName",ClNm );
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(param );
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
        public SqlDataReader GetRecDetForUpdate(int RecId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetRecDetForUpdate", con);
            SqlParameter param = new SqlParameter("@ReceiptId", RecId );
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.Int32 ;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(param);
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
        public SqlDataReader GetAdjustAmtForUpdate(int RecId, double amt,int invoiceid)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetAdjustAmtForUpdate", con);
            SqlParameter param = new SqlParameter("@ReceiptId", RecId);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.Int32;
            SqlParameter param1 = new SqlParameter("@AdjustAmount", amt);
            param1.Direction = ParameterDirection.Input;
            param1.DbType = DbType.Double ;
            SqlParameter param2 = new SqlParameter("@BillId", invoiceid);
            param2.Direction = ParameterDirection.Input;
            param2.DbType = DbType.Int32;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(param);
            cmd.Parameters.Add(param1);
           cmd.Parameters.Add(param2);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection );
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
        //public SqlDataReader GetInvIdForAdjustAmt(int ClId,double  amt)
        //{
        //    SqlConnection con = new SqlConnection(constr);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("GetInvIdForAdjustAmt", con);
        //    SqlParameter param = new SqlParameter("@ClientId", ClId );
        //    SqlParameter param1 = new SqlParameter("@Amount", amt);
        //    param.Direction = ParameterDirection.Input;
        //    param.DbType = DbType.Int32 ;
        //    param1.Direction = ParameterDirection.Input;
        //    param1.DbType = DbType.Double ;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add(param);
        //    cmd.Parameters.Add(param1);
        //    try
        //    {
        //        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection );
        //        return dr;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        //con.Close();
        //        //con.Dispose();
        //    }
       // }
        public SqlDataReader GetMaxRecId()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetMaxRecId", con);
           
            cmd.CommandType = CommandType.StoredProcedure;
            
            try
            {
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
        public SqlDataReader GetInvoiceByAddRec1(int ClId,int update)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetInvoiceByAddRec", con);
            SqlParameter param = new SqlParameter("@ClientId", ClId );
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.Int32 ;
            SqlParameter param1 = new SqlParameter("@Update", update);
            param1.Direction = ParameterDirection.Input;
            param1.DbType = DbType.Int32;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(param);
            cmd.Parameters.Add(param1);
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
      
       public SqlDataReader AddAdjustAmt(int RecId,int InvoiceId,double  amt,double  TDS,double  disc)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("AddAdjustAmt", con);
            SqlParameter param = new SqlParameter("@ReceiptId", RecId  );
           SqlParameter param1=new SqlParameter("@BillId",InvoiceId );
           SqlParameter param2=new SqlParameter("@AdjustAmt",amt  );
           SqlParameter param3=new SqlParameter("@TDS",TDS  );
           SqlParameter param4=new SqlParameter("@Discount",disc  );
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.Int32 ;
            param1.Direction = ParameterDirection.Input;
            param1.DbType = DbType.Int32;
            param2.Direction = ParameterDirection.Input;
            param2.DbType = DbType.Double ;
            param3.Direction = ParameterDirection.Input;
            param3.DbType = DbType.Double ;
            param4.Direction = ParameterDirection.Input;
            param4.DbType = DbType.Double ;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(param);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection );
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DLAddInvoice
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;

        public void AddInvoice(int InvoiceId, string InvoiceNo, DateTime Date, int ClientId, decimal Amount, decimal OtherCharges, decimal TotalAmount, string Remarks, string Status, int isDeleted, int Approve, int mode)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SaveInvoice", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {

                SqlParameter param1 = new SqlParameter("@InvoiceNo", SqlDbType.VarChar);
                param1.Value = InvoiceNo;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@Date", SqlDbType.Date);
                param2.Value = Date;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@ClientId", SqlDbType.Int);
                param3.Value = ClientId;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@Amount", SqlDbType.Decimal);
                param4.Value = Amount;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@OtherCharges", SqlDbType.Decimal);
                param5.Value = OtherCharges;
                cmd.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
                param6.Value = TotalAmount;
                cmd.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@Remarks", SqlDbType.VarChar);
                param7.Value = Remarks;
                cmd.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter("@Status", SqlDbType.VarChar);
                param8.Value = Status;
                cmd.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter("@isDeleted", SqlDbType.Int);
                param9.Value = isDeleted;
                cmd.Parameters.Add(param9);

                SqlParameter param10 = new SqlParameter("@Approve", SqlDbType.Int);
                param10.Value = Approve;
                cmd.Parameters.Add(param10);
                SqlParameter param11 = new SqlParameter("@Mode", SqlDbType.Int);
                param11.Value = mode;
                cmd.Parameters.Add(param11);
                SqlParameter param12 = new SqlParameter("@InvoiceId", SqlDbType.VarChar);
                param12.Value = InvoiceId;
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
        public void AddInvoiceDetail(int InvoiceId, int ProjectId, float ProjectAmount)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("AddInvoiceDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@InvoiceId", SqlDbType.Int);
                param1.Value = InvoiceId;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@ProjectId", SqlDbType.Int);
                param2.Value = ProjectId;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@ProjectAmount", SqlDbType.Float);
                param3.Value = ProjectAmount;
                cmd.Parameters.Add(param3);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        public void DelProjectDetail(int ProjectId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("DelProjectDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {

                SqlParameter param2 = new SqlParameter("@ProjectId", SqlDbType.Int);
                param2.Value = ProjectId;
                cmd.Parameters.Add(param2);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        public SqlDataReader getClientInvce()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetClientName", con);
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
        public SqlDataReader getClientIdName()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetClientIdName", con);
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
        public SqlDataReader getClientInfo(string ClNm)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlParameter param;

            param = new SqlParameter("@ClientName", ClNm);
            SqlCommand cmd = new SqlCommand("GetClientInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            cmd.Parameters.Add(param);

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
        public DataTable GetInvoiceDetailForUpdate(int invoiceid)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlParameter param;

            param = new SqlParameter("@InvoiceId", invoiceid);
            SqlCommand cmd = new SqlCommand("GetInvoiceDetailForUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.Int32;
            cmd.Parameters.Add(param);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                sda.Fill(dt);
                //SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
        public SqlDataReader getClIdByName(string ClNm)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlParameter param;
            SqlCommand cmd = new SqlCommand("GetClientIdByNm", con);
            param = new SqlParameter("@ClientName", ClNm);

            cmd.CommandType = CommandType.StoredProcedure;
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            cmd.Parameters.Add(param);

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
        public SqlDataReader GetInvoiceId1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetInvoiceId", con);
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

        public SqlDataReader getInvoiceForUpdate(int invoiceid)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getInvoiceForUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@InvoiceId", invoiceid);
            p.Direction = ParameterDirection.Input;
            p.DbType = DbType.Int32;
            cmd.Parameters.Add(p);
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
    }
}

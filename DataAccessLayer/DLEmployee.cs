using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DLEmployee
    {
        string msg;
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        public string saveEmployee1(string strEmployeeName, string strEmployeeCode, string strAddress1, string strAddress2, string strAddress3, string strPAN, string strBankName, string strBankAddress, string strAccountNo, string strBranch, string strDesignation, int intIsDeleted, string strMobile, string strTelephone, string strEmailID, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("saveEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
                param1.Value = strEmployeeName;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
                param2.Value = strEmployeeCode;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Address1", SqlDbType.VarChar);
                param3.Value = strAddress1;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@Address2", SqlDbType.VarChar);
                param4.Value = strAddress2;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@Address3", SqlDbType.VarChar);
                param5.Value = strAddress3;
                cmd.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@PAN", SqlDbType.VarChar);
                param6.Value = strPAN;
                cmd.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@BankName", SqlDbType.VarChar);
                param7.Value = strBankName;
                cmd.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter("@BankAddress", SqlDbType.VarChar);
                param8.Value = strBankAddress;
                cmd.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter("@AccountNo", SqlDbType.VarChar);
                param9.Value = strAccountNo;
                cmd.Parameters.Add(param9);

                SqlParameter param10 = new SqlParameter("@Branch", SqlDbType.VarChar);
                param10.Value = strBranch;
                cmd.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter("@Designation", SqlDbType.VarChar);
                param11.Value = strDesignation;
                cmd.Parameters.Add(param11);

                SqlParameter param12 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
                param12.Value = intIsDeleted;
                cmd.Parameters.Add(param12);

                SqlParameter param13 = new SqlParameter("@Mobile", SqlDbType.VarChar);
                param13.Value = strMobile;
                cmd.Parameters.Add(param13);

                SqlParameter param14 = new SqlParameter("@Telephone", SqlDbType.VarChar);
                param14.Value = strTelephone;
                cmd.Parameters.Add(param14);

                SqlParameter param15 = new SqlParameter("@EmailID", SqlDbType.VarChar);
                param15.Value = strEmailID;
                cmd.Parameters.Add(param15);

                SqlParameter param16 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param16.Value = intApprove;
                cmd.Parameters.Add(param16);

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
        public SqlDataReader getEmployeeName1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getEmployeeName", con);
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

        public SqlDataReader getEmployeeCode1(string strEmployeeName)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getEmployeeCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
                param1.Value = strEmployeeName;
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

        public SqlDataReader isDelEmpChecked1(int intIsDeleted)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelEmpChecked", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = intIsDeleted;
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

        public SqlDataReader isDelEmpNameChecked1(string strEmployeeName,int intIsDeleted)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelEmpNameChecked", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = intIsDeleted;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Value = strEmployeeName;
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

        public SqlDataReader isDelEmpNameAppChecked1(string strEmployeeName,int intApprove, int intIsDeleted)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelEmpNameAppChecked", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = intIsDeleted;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Value = strEmployeeName;
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
                //con.Close();
                //con.Dispose();
            }
        }
        public SqlDataReader gridFillEmployee1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillEmployee", con);
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
        public SqlDataAdapter getEmpNameEmployee1(string strEmployeeName)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getEmpNameEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter param1 = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
                param1.Value = strEmployeeName;
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
        public SqlDataReader gridFillApproveEmp1(int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillApproveEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = intApprove;
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
        public SqlDataReader gridFillApproveEmpName1(string strEmployeeName, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillApproveEmpName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strEmployeeName;
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
        public SqlDataReader getEmpCodeName1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getEmpCodeName", con);
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
        public SqlDataReader getEmpMaxCode1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getEmpMaxCode", con);
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
        public SqlDataReader getEmpDetailsForUpdate1(int intEmployeeID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getEmpDetailsForUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@EmployeeID", SqlDbType.Int);
                param1.Value = intEmployeeID;
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

        public void updateEmployee1(int intEmployeeID, string strAddress1, string strAddress2, string strAddress3, string strPAN, string strBankName, string strBankAddress, string strAccountNo, string strBranch, string strDesignation, int intIsDeleted, string strMobile, string strTelephone, string strEmailID, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("updateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@EmployeeID", SqlDbType.Int);
                param1.Value = intEmployeeID;
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

                SqlParameter param5 = new SqlParameter("@PAN", SqlDbType.VarChar);
                param5.Value = strPAN;
                cmd.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@BankName", SqlDbType.VarChar);
                param6.Value = strBankName;
                cmd.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@BankAddress", SqlDbType.VarChar);
                param7.Value = strBankAddress;
                cmd.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter("@AccountNo", SqlDbType.VarChar);
                param8.Value = strAccountNo;
                cmd.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter("@Branch", SqlDbType.VarChar);
                param9.Value = strBranch;
                cmd.Parameters.Add(param9);

                SqlParameter param10 = new SqlParameter("@Designation", SqlDbType.VarChar);
                param10.Value = strDesignation;
                cmd.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter("@IsDeleted", SqlDbType.Int);
                param11.Value = intIsDeleted;
                cmd.Parameters.Add(param11);

                SqlParameter param12 = new SqlParameter("@Mobile", SqlDbType.VarChar);
                param12.Value = strMobile;
                cmd.Parameters.Add(param12);

                SqlParameter param13 = new SqlParameter("@Telephone", SqlDbType.VarChar);
                param13.Value = strTelephone;
                cmd.Parameters.Add(param13);

                SqlParameter param14 = new SqlParameter("@EmailID", SqlDbType.VarChar);
                param14.Value = strEmailID;
                cmd.Parameters.Add(param14);

                SqlParameter param15 = new SqlParameter("@Approve", SqlDbType.Int);
                param15.Value = intApprove;
                cmd.Parameters.Add(param15);

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

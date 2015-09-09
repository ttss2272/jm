using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;  

namespace DataAccessLayer
{
    public class DLProject
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        
        string result;

        #region---------Update databse filename and filepath when Delete File---------
        public  string  UpadateFileDelete(int projectid,string worddoc,string file)
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("delFileOnProject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    byte[] newByte = StrToByteArray(worddoc);
                    cmd.Parameters.AddWithValue("ProjectId", projectid);
                        cmd.Parameters.AddWithValue("worddoc",newByte   );
                    cmd.Parameters.AddWithValue("filename",file  );
                 result= cmd.ExecuteNonQuery().ToString();
                    
                }
                catch
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return result;
    }
        #endregion
        public SqlDataReader getProjects1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getProjects", con);
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

        public SqlDataReader getCaseName1(string strClientName)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getCaseName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param1.Value = strClientName;
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

        public SqlDataReader gridFillStatus1(string strStatus)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@Status", strStatus);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strStatus;
               
                
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

        public SqlDataReader gridFillClientStatus1(string strClientName,string strStatus)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillClientStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strClientName;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@Status", SqlDbType.VarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Value = strStatus;
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

        public SqlDataReader gridFillClientCaseStatus1(string strClientName, string strCaseName, string strStatus)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillClientCaseStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strClientName;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@CaseName", SqlDbType.VarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Value = strCaseName;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Status", SqlDbType.VarChar);
                param3.Direction = ParameterDirection.Input;
                param3.Value = strStatus;
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

        public SqlDataReader gridFillClientApprove1(string strClientName, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillClientApprove", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClientName",SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strClientName;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@Approve",SqlDbType.VarChar);
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

        public SqlDataReader gridFillClientCaseApprove1(string strClientName, string strCaseName, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillClientCaseApprove", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strClientName;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@CaseName", SqlDbType.VarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Value = strCaseName;
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

        public SqlDataReader gridFillClientCaseStatusApprove1(string strClientName, string strCaseName, string strStatus, int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillClientCaseStatusApprove", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strClientName;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@CaseName", SqlDbType.VarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Value = strCaseName;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Status", SqlDbType.VarChar);
                param3.Direction = ParameterDirection.Input;
                param3.Value = strStatus;
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

            }
        }

        public SqlDataReader gridFillApprove1(int intApprove)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("gridFillApprove", con);
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

        public SqlDataReader isDelProjectUnChecked1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelProjectUnChecked", con);
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

        public SqlDataReader isDelProjectCliChecked1(string strClientName,int intIsDeleted)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelProjectCliChecked", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strClientName;
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

        public SqlDataReader isDelProjectCliCasChecked1(string strClientName, string strCaseName, int intIsDeleted)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelProjectCliCasChecked", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strClientName;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@CaseName", SqlDbType.VarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Value = strCaseName;
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
        public SqlDataReader isDelProjectCliStaCasChecked1(string strClientName, string strCaseName, string strStatus, int intIsDeleted)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelProjectCliStaCasChecked", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strClientName;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@CaseName", SqlDbType.VarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Value = strCaseName;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Status", SqlDbType.VarChar);
                param3.Direction = ParameterDirection.Input;
                param3.Value = strStatus;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
                param4.Direction = ParameterDirection.Input;
                param4.Value = intIsDeleted;
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

        public SqlDataReader isDelProjectCliStaCasAppChecked1(string strClientName, string strCaseName, string strStatus,int intApprove, int intIsDeleted)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("isDelProjectCliStaCasAppChecked", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Value = strClientName;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@CaseName", SqlDbType.VarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Value = strCaseName;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Status", SqlDbType.VarChar);
                param3.Direction = ParameterDirection.Input;
                param3.Value = strStatus;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param4.Direction = ParameterDirection.Input;
                param4.Value = intApprove;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
                param5.Direction = ParameterDirection.Input;
                param5.Value = intIsDeleted;
                cmd.Parameters.Add(param5);

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
        public SqlDataAdapter getProjectClientName1(string strClientName)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getProjectClientName", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter param1 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param1.Value = strClientName;
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
        public SqlDataAdapter getProjectCliCasName1(string strClientName, string strCaseName)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getProjectCliCasName", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter param1 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param1.Value = strClientName;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@CaseName", SqlDbType.VarChar);
                param2.Value = strCaseName;
                cmd.Parameters.Add(param2);
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
        public SqlDataReader getProject1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getProject", con);
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

        public void saveProject1(DateTime dtProjectDate, int intClientID, string strClientName, int intTypeOfWorkID, string strTypeOfWork, string strCaseName, int intExternalWork, bool boolNeedSearch, string strRemarks, decimal decPrice, decimal decOtherCharges, decimal decTotalAmount, string strStatus, bool boolIsDeleted, int intApprove, decimal decServiceTax, string strReferenceNo, string strLoanNO, string strPropertyAddress, DateTime dt_softcopysent, DateTime dt_MISclient, DateTime dt_search_initiated, DateTime dt_search_received, DateTime dt_search_received_receipt, DateTime dt_hardcopysent, DateTime dt_pendingdocumentsrec, DateTime dt_pendingdocumentsresp, DateTime dt_finalreportsent, string strworddoc, string strfilename, string strbranch, decimal decloanamt,string strEmailID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("saveProject", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectDate", SqlDbType.VarChar);
                param1.Value = dtProjectDate;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@ClientID", SqlDbType.VarChar);
                param2.Value = intClientID;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param3.Value = strClientName;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@TypeOfWorkID", SqlDbType.VarChar);
                param4.Value = intTypeOfWorkID;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@TypeOfWork", SqlDbType.VarChar);
                param5.Value = strTypeOfWork;
                cmd.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@CaseName", SqlDbType.VarChar);
                param6.Value = strCaseName;
                cmd.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@ExternalWork", SqlDbType.VarChar);
                param7.Value = intExternalWork;
                cmd.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter("@Remarks", SqlDbType.VarChar);
                param8.Value = strRemarks;
                cmd.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter("@Price", SqlDbType.VarChar);
                param9.Value = decPrice;
                cmd.Parameters.Add(param9);

                SqlParameter param10 = new SqlParameter("@OtherCharges", SqlDbType.VarChar);
                param10.Value = decOtherCharges;
                cmd.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter("@TotalAmount", SqlDbType.VarChar);
                param11.Value = decTotalAmount;
                cmd.Parameters.Add(param11);

                SqlParameter param12 = new SqlParameter("@Status", SqlDbType.VarChar);
                param12.Value = strStatus;
                cmd.Parameters.Add(param12);

                SqlParameter param13 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
                param13.Value = boolIsDeleted;
                cmd.Parameters.Add(param13);

                SqlParameter param14 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param14.Value = intApprove;
                cmd.Parameters.Add(param14);

                SqlParameter param15 = new SqlParameter("@ServiceTax", SqlDbType.VarChar);
                param15.Value = decServiceTax;
                cmd.Parameters.Add(param15);

                SqlParameter param16 = new SqlParameter("@ReferenceNo", SqlDbType.VarChar);
                param16.Value = strReferenceNo;
                cmd.Parameters.Add(param16);

                SqlParameter param17 = new SqlParameter("@LoanNO", SqlDbType.VarChar);
                param17.Value = strLoanNO;
                cmd.Parameters.Add(param17);

                SqlParameter param18 = new SqlParameter("@PropertyAddress", SqlDbType.VarChar);
                param18.Value = strPropertyAddress;
                cmd.Parameters.Add(param18);

                SqlParameter param19 = new SqlParameter("@dt_softcopysent", SqlDbType.VarChar);
                param19.Value = dt_softcopysent;
                cmd.Parameters.Add(param19);

                SqlParameter param20 = new SqlParameter("@dt_MISclient", SqlDbType.VarChar);
                param20.Value = dt_MISclient;
                cmd.Parameters.Add(param20);

                SqlParameter param21 = new SqlParameter("@dt_search_initiated", SqlDbType.VarChar);
                param21.Value = dt_search_initiated;
                cmd.Parameters.Add(param21);

                SqlParameter param22 = new SqlParameter("@dt_search_received", SqlDbType.VarChar);
                param22.Value = dt_search_received;
                cmd.Parameters.Add(param22);

                SqlParameter param23 = new SqlParameter("@dt_search_received_receipt", SqlDbType.VarChar);
                param23.Value = dt_search_received_receipt;
                cmd.Parameters.Add(param23);

                SqlParameter param24 = new SqlParameter("@dt_hardcopysent", SqlDbType.VarChar);
                param24.Value = dt_hardcopysent;
                cmd.Parameters.Add(param24);

                SqlParameter param25 = new SqlParameter("@dt_pendingdocumentsrec", SqlDbType.VarChar);
                param25.Value = dt_pendingdocumentsrec;
                cmd.Parameters.Add(param25);

                SqlParameter param26 = new SqlParameter("@dt_pendingdocumentsresp", SqlDbType.VarChar);
                param26.Value = dt_pendingdocumentsresp;
                cmd.Parameters.Add(param26);

                SqlParameter param27 = new SqlParameter("@dt_finalreportsent", SqlDbType.VarChar);
                param27.Value = dt_finalreportsent;
                cmd.Parameters.Add(param27);

                SqlParameter param28 = new SqlParameter("@worddoc", SqlDbType.VarBinary);
                if (strworddoc == null)
                {
                    param28.Value = DBNull.Value;
                    cmd.Parameters.Add(param28);
                }
                else
                {
                    byte[] newByte = StrToByteArray(strworddoc);
                    param28.Value = newByte;
                    cmd.Parameters.Add(param28);
                }

                SqlParameter param29 = new SqlParameter("@filename", SqlDbType.VarChar);
                param29.Value = strfilename;
                cmd.Parameters.Add(param29);

                SqlParameter param30 = new SqlParameter("@branch", SqlDbType.VarChar);
                param30.Value = strbranch;
                cmd.Parameters.Add(param30);

                SqlParameter param31 = new SqlParameter("@loanamt", SqlDbType.VarChar);
                param31.Value = decloanamt;
                cmd.Parameters.Add(param31);

                SqlParameter param32 = new SqlParameter("@NeedSearch", SqlDbType.VarChar);
                param32.Value = boolNeedSearch;
                cmd.Parameters.Add(param32);

                SqlParameter param33 = new SqlParameter("@EmailID", SqlDbType.VarChar);
                param33.Value = strEmailID;
                cmd.Parameters.Add(param33);

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
        public static byte[] StrToByteArray(string strValue)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(strValue);
        }


        public SqlDataReader getTypWrkIdByWrk1(string strWork)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getTypWrkIdByWrk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@Work", SqlDbType.VarChar);
                param1.Value = strWork;
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

        public SqlDataReader getMaxProjectId1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getMaxProjectId", con);
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
        public SqlDataReader getDocIdDocGrid1(string strDocument)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getDocIdDocGrid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@Document", SqlDbType.VarChar);
                param1.Value = strDocument;
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

        public void saveSelectedDoc1(int intProjectID, int intDocumentID, string strDocument)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("saveSelectedDoc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectID", SqlDbType.VarChar);
                param1.Value = intProjectID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@DocumentID", SqlDbType.VarChar);
                param2.Value = intDocumentID;
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
        public SqlDataReader getEmpIdEmpGrid1(string strEmployeeCode)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getEmpIdEmpGrid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
                param1.Value = strEmployeeCode;
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
        public void saveSelectedEmp1(int intProjectID, int intEmployeeID, string strEmployeeName, DateTime dtStartDate, DateTime dtEndDate)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("saveSelectedEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectID", SqlDbType.VarChar);
                param1.Value = intProjectID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@EmployeeID", SqlDbType.VarChar);
                param2.Value = intEmployeeID;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
                param3.Value = strEmployeeName;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@StartDate", SqlDbType.DateTime);
                param4.Value = dtStartDate;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@EndDate", SqlDbType.DateTime);
                param5.Value = dtEndDate;
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
        public SqlDataReader getDocBoyIdDocBoyGrid1(string strName)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getDocBoyIdDocBoyGrid", con);
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

        public void saveSelectedDocumentBoy1(int intProjectID, int intDocumentboyID, string strDocumentboyName)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("saveSelectedDocumentBoy", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectID", SqlDbType.VarChar);
                param1.Value = intProjectID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@DocumentboyID", SqlDbType.VarChar);
                param2.Value = intDocumentboyID;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@DocumentboyName", SqlDbType.VarChar);
                param3.Value = strDocumentboyName;
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
        public SqlDataReader getServiceIdServiceGrid1(string strServiceName)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getServiceIdServiceGrid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ServiceName", SqlDbType.VarChar);
                param1.Value = strServiceName;
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

        public void saveSelectedServices1(int intProjectID, int intServiceID, string strServices, float floatPrice)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("saveSelectedServices", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectID", SqlDbType.Int);
                param1.Value = intProjectID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@ServiceID", SqlDbType.Int);
                param2.Value = intServiceID;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Services", SqlDbType.VarChar);
                param3.Value = strServices;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@Price", SqlDbType.Float);
                param4.Value = floatPrice;
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

        public SqlDataReader getClerkIdClerkGrid1(string strClerkName)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getClerkIdClerkGrid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClerkName", SqlDbType.VarChar);
                param1.Value = strClerkName;
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
        public void saveSelectedClerk1(int intProjectID, int intSearchClerkID, string strSearchClerkName, DateTime dtSearchStarts, DateTime dtSearchEnd)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("saveSelectedClerk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectID", SqlDbType.VarChar);
                param1.Value = intProjectID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@SearchClerkID", SqlDbType.VarChar);
                param2.Value = intSearchClerkID;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@SearchClerkName", SqlDbType.VarChar);
                param3.Value = strSearchClerkName;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@SearchStarts", SqlDbType.DateTime);
                param4.Value = dtSearchStarts;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@SearchEnd", SqlDbType.DateTime);
                param5.Value = dtSearchEnd;
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

        public SqlDataReader getProjectDetailsForUpdate1(int intProjectId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getProjectDetailsForUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectId", SqlDbType.Int);
                param1.Value = intProjectId;
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

        public void updateProjects1(DateTime dtProjectDate, int intProjectId, string strClientName, int intTypeOfWorkID, string strTypeOfWork, string strCaseName, int intExternalWork, bool boolNeedSearch, string strRemarks, decimal decPrice, decimal decOtherCharges, decimal decTotalAmount, string strStatus, bool boolIsDeleted, int intApprove, decimal decServiceTax, string strReferenceNo, string strLoanNO, string strPropertyAddress, DateTime dt_softcopysent, DateTime dt_MISclient, DateTime dt_search_initiated, DateTime dt_search_received, DateTime dt_search_received_receipt, DateTime dt_hardcopysent, DateTime dt_pendingdocumentsrec, DateTime dt_pendingdocumentsresp, DateTime dt_finalreportsent, string strworddoc, string strfilename, string strbranch, decimal decloanamt,string strEmailID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("updateProjects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectDate", SqlDbType.VarChar);
                param1.Value = dtProjectDate;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@ProjectId", SqlDbType.VarChar);
                param2.Value = intProjectId;
                cmd.Parameters.Add(param2);

                //SqlParameter param3 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                //param3.Value = strClientName;
                //cmd.Parameters.Add(param3);

                //SqlParameter param4 = new SqlParameter("@TypeOfWorkID", SqlDbType.VarChar);
                //param4.Value = intTypeOfWorkID;
                //cmd.Parameters.Add(param4);

                //SqlParameter param5 = new SqlParameter("@TypeOfWork", SqlDbType.VarChar);
                //param5.Value = strTypeOfWork;
                //cmd.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@CaseName", SqlDbType.VarChar);
                param6.Value = strCaseName;
                cmd.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@ExternalWork", SqlDbType.VarChar);
                param7.Value = intExternalWork;
                cmd.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter("@Remarks", SqlDbType.VarChar);
                param8.Value = strRemarks;
                cmd.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter("@Price", SqlDbType.Decimal);
                param9.Value = decPrice;
                cmd.Parameters.Add(param9);

                SqlParameter param10 = new SqlParameter("@OtherCharges", SqlDbType.Decimal);
                param10.Value = decOtherCharges;
                cmd.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
                param11.Value = decTotalAmount;
                cmd.Parameters.Add(param11);

                SqlParameter param12 = new SqlParameter("@Status", SqlDbType.VarChar);
                param12.Value = strStatus;
                cmd.Parameters.Add(param12);

                SqlParameter param13 = new SqlParameter("@IsDeleted", SqlDbType.Bit);
                param13.Value = boolIsDeleted;
                cmd.Parameters.Add(param13);

                SqlParameter param14 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param14.Value = intApprove;
                cmd.Parameters.Add(param14);

                SqlParameter param15 = new SqlParameter("@ServiceTax", SqlDbType.Decimal);
                param15.Value = decServiceTax;
                cmd.Parameters.Add(param15);

                SqlParameter param16 = new SqlParameter("@ReferenceNo", SqlDbType.VarChar);
                param16.Value = strReferenceNo;
                cmd.Parameters.Add(param16);

                SqlParameter param17 = new SqlParameter("@LoanNO", SqlDbType.VarChar);
                param17.Value = strLoanNO;
                cmd.Parameters.Add(param17);

                SqlParameter param18 = new SqlParameter("@PropertyAddress", SqlDbType.VarChar);
                param18.Value = strPropertyAddress;
                cmd.Parameters.Add(param18);

                SqlParameter param19 = new SqlParameter("@dt_softcopysent", SqlDbType.VarChar);
                param19.Value = dt_softcopysent;
                cmd.Parameters.Add(param19);

                SqlParameter param20 = new SqlParameter("@dt_MISclient", SqlDbType.VarChar);
                param20.Value = dt_MISclient;
                cmd.Parameters.Add(param20);

                SqlParameter param21 = new SqlParameter("@dt_search_initiated", SqlDbType.VarChar);
                param21.Value = dt_search_initiated;
                cmd.Parameters.Add(param21);

                SqlParameter param22 = new SqlParameter("@dt_search_received", SqlDbType.VarChar);
                param22.Value = dt_search_received;
                cmd.Parameters.Add(param22);

                SqlParameter param23 = new SqlParameter("@dt_search_received_receipt", SqlDbType.VarChar);
                param23.Value = dt_search_received_receipt;
                cmd.Parameters.Add(param23);

                SqlParameter param24 = new SqlParameter("@dt_hardcopysent", SqlDbType.VarChar);
                param24.Value = dt_hardcopysent;
                cmd.Parameters.Add(param24);

                SqlParameter param25 = new SqlParameter("@dt_pendingdocumentsrec", SqlDbType.VarChar);
                param25.Value = dt_pendingdocumentsrec;
                cmd.Parameters.Add(param25);

                SqlParameter param26 = new SqlParameter("@dt_pendingdocumentsresp", SqlDbType.VarChar);
                param26.Value = dt_pendingdocumentsresp;
                cmd.Parameters.Add(param26);

                SqlParameter param27 = new SqlParameter("@dt_finalreportsent", SqlDbType.VarChar);
                param27.Value = dt_finalreportsent;
                cmd.Parameters.Add(param27);

                SqlParameter param28 = new SqlParameter("@worddoc", SqlDbType.VarBinary);
                if (strworddoc == null)
                {
                    param28.Value = DBNull.Value;
                    cmd.Parameters.Add(param28);
                }
                else
                {
                    byte[] newByte = StrToByteArray(strworddoc);
                    param28.Value = newByte;
                    cmd.Parameters.Add(param28);
                }
                //byte[] newByte = StrToByteArray(strworddoc);
                //param28.Value = newByte;
                //cmd.Parameters.Add(param28);
                
          
                SqlParameter param29 = new SqlParameter("@filename", SqlDbType.VarChar);
                param29.Value = strfilename;
                cmd.Parameters.Add(param29);

                SqlParameter param30 = new SqlParameter("@branch", SqlDbType.VarChar);
                param30.Value = strbranch;
                cmd.Parameters.Add(param30);

                SqlParameter param31 = new SqlParameter("@loanamt", SqlDbType.Decimal);
                param31.Value = decloanamt;
                cmd.Parameters.Add(param31);

                SqlParameter param32 = new SqlParameter("@NeedSearch", SqlDbType.Bit);
                param32.Value = boolNeedSearch;
                cmd.Parameters.Add(param32);

                SqlParameter param33 = new SqlParameter("@EmailID", SqlDbType.VarChar);
                param33.Value = strEmailID;
                cmd.Parameters.Add(param33);

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

        public SqlDataReader showSelectedDoc1(int intProjectId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("showSelectedDoc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectId", SqlDbType.Int);
                param1.Value = intProjectId;
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
        public SqlDataReader getClientName1()
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
        public SqlDataReader showSelectedDocBoys1(int intProjectId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("showSelectedDocBoys", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectId", SqlDbType.Int);
                param1.Value = intProjectId;
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
        public SqlDataReader showSelectedEmployees1(int intProjectId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("showSelectedEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectId", SqlDbType.Int);
                param1.Value = intProjectId;
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
        public SqlDataReader showSelectedClerk1(int intProjectId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("showSelectedClerk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectId", SqlDbType.Int);
                param1.Value = intProjectId;
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

        public SqlDataReader showSelectedServices1(int intProjectId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("showSelectedServices", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectId", SqlDbType.Int);
                param1.Value = intProjectId;
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
        //public string  DelDocument(int ProjectId)
        //{
        //    SqlConnection con = new SqlConnection(constr);
        //    string result;
        //    try
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("delDocOnProject", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@ProjectId", SqlDbType.Int);
        //        result= cmd.ExecuteNonQuery().ToString();
        //    }
        //    catch(Exception ex)
        //    {
        //        result = ex.Message.ToString();
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return result;
        //}


        public void delDocOnProject1(int intProjectId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("delDocOnProject", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectId", SqlDbType.VarChar);
                param1.Value = intProjectId;
                cmd.Parameters.Add(param1);

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

        public void deleteProject(int ProjectId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("deleteProject", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            SqlParameter param1 = new SqlParameter("@ProjectId", SqlDbType.VarChar);
            param1.Value = ProjectId;
            cmd.Parameters.Add(param1);
            cmd.ExecuteNonQuery(); 
            con.Close();
        }

        public void delUnSelectDoc1(int intProjectID, int intDocumentID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("delUnSelectDoc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectID", SqlDbType.Int);
                param1.Value = intProjectID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@DocumentID", SqlDbType.Int);
                param2.Value = intDocumentID;
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

        public void delUnSelectedServices1(int intProjectID, int intServiceID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("delUnSelectedServices", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectID", SqlDbType.Int);
                param1.Value = intProjectID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@ServiceID", SqlDbType.Int);
                param2.Value = intServiceID;
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
        public void delUnSelectedEmp1(int intProjectID, int intEmployeeID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("delUnSelectedEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectID", SqlDbType.Int);
                param1.Value = intProjectID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@EmployeeID", SqlDbType.Int);
                param2.Value = intEmployeeID;
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
        public void delUnselectClerk1(int intProjectID, int intSearchClerkID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("delUnselectClerk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectID", SqlDbType.Int);
                param1.Value = intProjectID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@SearchClerkID", SqlDbType.Int);
                param2.Value = intSearchClerkID;
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

        public void delUnSelectedDocBoy1(int intProjectID, int intDocumentboyID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("delUnSelectedDocBoy", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ProjectID", SqlDbType.Int);
                param1.Value = intProjectID;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@DocumentboyID", SqlDbType.Int);
                param2.Value = intDocumentboyID;
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

        public SqlDataReader getData(int LoginId)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("getUserMailAndUserNameByUserID", con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@UserId", LoginId);

            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.Int32;
            cmd.Parameters.Add(param);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
           //con.Close();
            return dr;
        }
        public SqlDataReader getServiceForEmpClient1(int intClientID)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getServiceForEmpClient", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param4 = new SqlParameter("@ClientID", SqlDbType.VarChar);
                param4.Direction = ParameterDirection.Input;
                param4.Value = intClientID;
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
        public SqlDataReader getClientNameForProject1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getClientNameForProject", con);
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
        public SqlDataReader getTypeOfWorkForProject1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getTypeOfWorkForProject", con);
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
    }
}

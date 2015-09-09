using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Configuration;

namespace BusinessLayer
{
    public class BLEmployee
    {
        string msg;
        public string saveEmployee1(string strEmployeeName, string strEmployeeCode, string strAddress1, string strAddress2, string strAddress3, string strPAN, string strBankName, string strBankAddress, string strAccountNo, string strBranch, string strDesignation, int intIsDeleted, string strMobile, string strTelephone, string strEmailID, int intApprove)
        {
            DLEmployee dle = new DLEmployee();
            try
            {
                msg = dle.saveEmployee1(strEmployeeName, strEmployeeCode, strAddress1, strAddress2, strAddress3, strPAN, strBankName, strBankAddress, strAccountNo, strBranch, strDesignation, intIsDeleted, strMobile, strTelephone, strEmailID, intApprove);
            }
            catch
            {
                throw;
            }
            finally
            {
                dle = null;
            }
            return msg;
        }

        public SqlDataReader getEmployeeName1()
        {
            DLEmployee dlc = new DLEmployee();
            try
            {
                SqlDataReader dr = dlc.getEmployeeName1();
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlc = null;
            }
        }

        public SqlDataReader getEmployeeCode1(string strEmployeeName)
        {
            DLEmployee dlsr = new DLEmployee();
            try
            {
                SqlDataReader dr = dlsr.getEmployeeCode1(strEmployeeName);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                dlsr = null;
            }
        }

        public SqlDataReader isDelEmpChecked1(int intIsDeleted)
        {
            DLEmployee dlc = new DLEmployee();
            try
            {
                SqlDataReader dr = dlc.isDelEmpChecked1(intIsDeleted);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlc = null;
            }
        }

        public SqlDataReader isDelEmpNameChecked1(string strEmployeeName,int intIsDeleted)
        {
            DLEmployee dlc = new DLEmployee();
            try
            {
                SqlDataReader dr = dlc.isDelEmpNameChecked1(strEmployeeName,intIsDeleted);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlc = null;
            }
        }

        public SqlDataReader isDelEmpNameAppChecked1(string strEmployeeName, int intApprove, int intIsDeleted)
        {
            DLEmployee dlc = new DLEmployee();
            try
            {
                SqlDataReader dr = dlc.isDelEmpNameAppChecked1(strEmployeeName,intApprove,intIsDeleted);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlc = null;
            }
        }
        public SqlDataReader gridFillEmployee1()
        {
            DLEmployee dld = new DLEmployee();
            try
            {
                SqlDataReader dr = dld.gridFillEmployee1();
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                dld = null;
            }
        }
        public SqlDataAdapter getEmpNameEmployee1(string strEmployeeName)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DLEmployee dltow = new DLEmployee();
            try
            {
                dltow.getEmpNameEmployee1(strEmployeeName);
                return da;
            }
            catch
            {
                throw;
            }
            finally
            {
                //dltow = null;
            }
        }
        public SqlDataReader gridFillApproveEmp1(int intApprove)
        {
            DLEmployee dlsr = new DLEmployee();
            try
            {
                SqlDataReader dr = dlsr.gridFillApproveEmp1(intApprove);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                dlsr = null;
            }
        }
        public SqlDataReader gridFillApproveEmpName1(string strEmployeeName, int intApprove)
        {
            DLEmployee dlsr = new DLEmployee();
            try
            {
                SqlDataReader dr = dlsr.gridFillApproveEmpName1(strEmployeeName, intApprove);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                dlsr = null;
            }
        }
        public SqlDataReader getEmpCodeName1()
        {
            DLEmployee dlc = new DLEmployee();
            try
            {
                SqlDataReader dr = dlc.getEmpCodeName1();
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlc = null;
            }
        }
        public SqlDataReader getEmpMaxCode1()
        {
            DLEmployee dlc = new DLEmployee();
            try
            {
                SqlDataReader dr = dlc.getEmpMaxCode1();
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlc = null;
            }
        }
        public SqlDataReader getEmpDetailsForUpdate1(int intEmployeeID)
        {
            DLEmployee dlsr = new DLEmployee();
            try
            {
                SqlDataReader dr = dlsr.getEmpDetailsForUpdate1(intEmployeeID);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                dlsr = null;
            }
        }
        public void updateEmployee1(int intEmployeeID, string strAddress1, string strAddress2, string strAddress3, string strPAN, string strBankName, string strBankAddress, string strAccountNo, string strBranch, string strDesignation, int intIsDeleted, string strMobile, string strTelephone, string strEmailID, int intApprove)
        {
            DLEmployee dlc = new DLEmployee();
            try
            {
                dlc.updateEmployee1( intEmployeeID,  strAddress1,  strAddress2,  strAddress3,  strPAN,  strBankName,  strBankAddress,  strAccountNo,  strBranch,  strDesignation,  intIsDeleted,  strMobile,  strTelephone,  strEmailID,  intApprove);
            }
            catch
            {
                throw;
            }
            finally
            {
                dlc = null;
            }
        }
    }
}

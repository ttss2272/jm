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
    public class BLClerk
    {
        string msg;
        public string saveClerk1(string strClerkName, string strAddress1, string strAddress2, string strAddress3, string strAddress4, string strTelephone, string strMobile, string strPanNo, string strEmailId, decimal decTDSRate, int intIsDeleted, int intApprove)
        {
            DLClerk dlc = new DLClerk();
            try
            {
                msg = dlc.saveClerk1(strClerkName, strAddress1, strAddress2, strAddress3, strAddress4, strTelephone, strMobile, strPanNo, strEmailId, decTDSRate, intIsDeleted, intApprove);
            }
            catch
            {
                throw;
            }
            finally
            {
                dlc = null;
            }
            return msg;
        }

        public SqlDataReader getClerkName1()
        {
            DLClerk dlc = new DLClerk();
            try
            {
                SqlDataReader dr = dlc.getClerkName1();
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

        public SqlDataAdapter getClerk1(string strClerkName)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DLClerk dlc = new DLClerk();
            try
            {
                dlc.getClerk1(strClerkName);
                return da;
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
        public SqlDataReader getClerkDetails1()
        {
            DLClerk dlc = new DLClerk();
            try
            {
                SqlDataReader dr = dlc.getClerkDetails1();
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

        public SqlDataReader gridFillApproveClerk1(int intApprove)
        {
            DLClerk dlsr = new DLClerk();
            try
            {
                SqlDataReader dr = dlsr.gridFillApproveClerk1(intApprove);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlsr = null;
            }
        }

        public SqlDataReader gridFillApproveClerkName1(string strClerkName, int intApprove)
        {
            DLClerk dlsr = new DLClerk();
            try
            {
                SqlDataReader dr = dlsr.gridFillApproveClerkName1(strClerkName,intApprove);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlsr = null;
            }
        }
        public SqlDataReader getClerkDetailsForUpdate1(int intClerkId)
        {
            DLClerk dlsr = new DLClerk();
            try
            {
                SqlDataReader dr = dlsr.getClerkDetailsForUpdate1( intClerkId);
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
        public void updateClerk1(int intClerkId, string strAddress1, string strAddress2, string strAddress3, string strAddress4, string strTelephone, string strMobile, string strPanNo, string strEmailId, decimal decTDSRate, int intIsDeleted, int intApprove)
        {
            DLClerk dlc = new DLClerk();
            try
            {
                dlc.updateClerk1(intClerkId, strAddress1, strAddress2, strAddress3, strAddress4, strTelephone, strMobile, strPanNo, strEmailId, decTDSRate, intIsDeleted, intApprove);
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

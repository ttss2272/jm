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
   public class BLServices
   {
       string msg;
        public string saveServices1(string strServiceName, int intIsDeleted, int intApprove)
        {
            DLServices dls = new DLServices();
            try
            {
               msg= dls.saveServices1(strServiceName, intIsDeleted, intApprove);
            }
            catch
            {
                throw;
            }
            finally
            {
                dls = null;
            }
            return msg;
        }
        public SqlDataReader getServiceName1()
        {
            DLServices dlc = new DLServices();
            try
            {
                SqlDataReader dr = dlc.getServiceName1();
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
        public SqlDataAdapter getService1(string strServiceName)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DLServices dlc = new DLServices();
            try
            {
                dlc.getService1(strServiceName);
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
        public SqlDataReader getServiceGridFill1()
        {
            DLServices dld = new DLServices();
            try
            {
                SqlDataReader dr = dld.getServiceGridFill1();
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
        public SqlDataReader gridFillApproveService1(int intApprove)
        {
            DLServices dlsr = new DLServices();
            try
            {
                SqlDataReader dr = dlsr.gridFillApproveService1(intApprove);
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
        public SqlDataReader gridFillApproveServiceName1(string strServiceName, int intApprove)
        {
            DLServices dlsr = new DLServices();
            try
            {
                SqlDataReader dr = dlsr.gridFillApproveServiceName1(strServiceName,intApprove);
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
        public SqlDataReader getServicePrice1(int intClientID)
        {
            DLServices dlsr = new DLServices();
            try
            {
                SqlDataReader dr = dlsr.getServicePrice1(intClientID);
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
        public SqlDataReader getClientIDforService1(string strClientName1)
        {
            DLServices dlsr = new DLServices();
            try
            {
                SqlDataReader dr = dlsr.getClientIDforService1(strClientName1);
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
        public SqlDataReader getServiceDetailsForUpdate1(int intServiceId)
        {
            DLServices dlsr = new DLServices();
            try
            {
                SqlDataReader dr = dlsr.getServiceDetailsForUpdate1( intServiceId);
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
        public void updateService1(int intServiceId, string strServiceName, int intIsDeleted, int intApprove)
        {
            DLServices dlc = new DLServices();
            try
            {
                dlc.updateService1(intServiceId, strServiceName, intIsDeleted, intApprove);
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

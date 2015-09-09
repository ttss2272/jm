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
   public class BLTypeOfWork
    {
       string msg;
       public string saveTypeOfWork1(string strWork, int intIsDeleted, int intApprove)
       {
           DLTypeOfWork dltow = new DLTypeOfWork();
           try
           {
              msg = dltow.saveTypeOfWork1(strWork, intIsDeleted, intApprove);
           }
           catch
           {
               throw;
           }
           finally
           {
               dltow = null;
           }
           return msg;
       }

       public SqlDataReader getTypeOfWork1()
       {
           DLTypeOfWork dltow = new DLTypeOfWork();
           try
           {
               SqlDataReader dr = dltow.getTypeOfWork1();
               return dr;
           }
           catch
           {
               throw;
           }
           finally
           {
               dltow = null;
           }
       }

       public SqlDataAdapter getWorkTypeOfWork1(string strWork)
       {
           SqlDataAdapter da = new SqlDataAdapter();
           DLTypeOfWork dltow = new DLTypeOfWork();
           try
           {
               dltow.getWorkTypeOfWork1(strWork);
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
       public SqlDataReader gridFillApproveTypWrk1(int intApprove)
       {
           DLTypeOfWork dltow = new DLTypeOfWork();
           try
           {
               SqlDataReader dr = dltow.gridFillApproveTypWrk1(intApprove);
               return dr;
           }
           catch
           {
               throw;
           }
           finally
           {
               dltow = null;
           }
       }
       public SqlDataReader gridFillApproveTypWrkName1(string strWork, int intApprove)
       {
           DLTypeOfWork dltow = new DLTypeOfWork();
           try
           {
               SqlDataReader dr = dltow.gridFillApproveTypWrkName1(strWork, intApprove);
               return dr;
           }
           catch
           {
               throw;
           }
           finally
           {
               dltow = null;
           }
       }
       public SqlDataReader isDelTypWrkChecked1(int intIsDeleted)
       {
           DLTypeOfWork dlc = new DLTypeOfWork();
           try
           {
               SqlDataReader dr = dlc.isDelTypWrkChecked1(intIsDeleted);
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
       public SqlDataReader isDelTypWrkCheckedWork1(string strWork, int intIsDeleted)
       {
           DLTypeOfWork dltow = new DLTypeOfWork();
           try
           {
               SqlDataReader dr = dltow.isDelTypWrkCheckedWork1(strWork, intIsDeleted);
               return dr;
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
       public SqlDataReader isDelTypWrkAppCheckedWork1(string strWork, int intApprove, int intIsDeleted)
       {
           DLTypeOfWork dltow = new DLTypeOfWork();
           try
           {
               SqlDataReader dr = dltow.isDelTypWrkAppCheckedWork1(strWork, intApprove, intIsDeleted);
               return dr;
           }
           catch
           {
               throw;
           }
           finally
           {
               dltow = null;
           }
       }
       public SqlDataReader getTypeWrkDetailsForUpdate1(int intTypeofWorkID)
       {
           DLTypeOfWork dltow = new DLTypeOfWork();
           try
           {
               SqlDataReader dr = dltow.getTypeWrkDetailsForUpdate1(intTypeofWorkID);
               return dr;
           }
           catch
           {
               throw;
           }
           finally
           {
               dltow = null;
           }
       }
       public void updateTypeOfWork1(int intTypeofWorkID, string strWork, int intIsDeleted, int intApprove)
       {
           DLTypeOfWork dltow = new DLTypeOfWork();
           try
           {
               dltow.updateTypeOfWork1(intTypeofWorkID, strWork, intIsDeleted, intApprove);
           }
           catch
           {
               throw;
           }
           finally
           {
               dltow = null;
           }
       }
    }
}

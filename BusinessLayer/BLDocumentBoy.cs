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
   public class BLDocumentBoy
    {
       string msg;
       public string saveDocumentBoy1(string strName, string strMobile, int intIsDeleted, string strCode, int intApprove,string strMailID)
       {
           DLDocumentBoy dldb = new DLDocumentBoy();
           try
           {
               msg = dldb.saveDocumentBoy1(strName,strMobile,intIsDeleted,strCode,intApprove,strMailID); //Parameter mailid added 
           }
           catch
           {
               throw;
           }
           finally
           {
               dldb = null;
           }
           return msg;
       }
       //ADD Comment
       public SqlDataReader getDocumentBoy1()
       {
           DLDocumentBoy dldb = new DLDocumentBoy();
           try
           {
               SqlDataReader dr = dldb.getDocumentBoy1();
               return dr;
           }
           catch
           {
               throw;
           }
           finally
           {
               dldb = null;
           }
       }
       public SqlDataReader getDocBoyCode1(string strName)
       {
           DLDocumentBoy dldb = new DLDocumentBoy();
           try
           {
               SqlDataReader dr = dldb.getDocBoyCode1(strName);
               return dr;
           }
           catch
           {
               throw;
           }
           finally
           {
               dldb = null;
           }
       }

       public SqlDataReader gridFillApproveDocumentBoy1(int intApprove)
       {
           DLDocumentBoy dlsr = new DLDocumentBoy();
           try
           {
               SqlDataReader dr = dlsr.gridFillApproveDocumentBoy1(intApprove);
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

       public SqlDataReader gridFillApproveDocumentBoyName1(string strName, int intApprove)
       {
           DLDocumentBoy dlsr = new DLDocumentBoy();
           try
           {
               SqlDataReader dr = dlsr.gridFillApproveDocumentBoyName1(strName,intApprove);
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

       public SqlDataReader isDelDocBoyChecked1(int intIsDeleted)
       {
           DLDocumentBoy dlsr = new DLDocumentBoy();
           try
           {
               SqlDataReader dr = dlsr.isDelDocBoyChecked1(intIsDeleted);
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

       public SqlDataReader isDelDocBoyNameChecked1(string strName, int intIsDeleted)
       {
           DLDocumentBoy dlsr = new DLDocumentBoy();
           try
           {
               SqlDataReader dr = dlsr.isDelDocBoyNameChecked1(strName,intIsDeleted);
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

       public SqlDataReader isDelDocBoyNameAppChecked1(string strName, int intApprove, int intIsDeleted)
       {
           DLDocumentBoy dlsr = new DLDocumentBoy();
           try
           {
               SqlDataReader dr = dlsr.isDelDocBoyNameAppChecked1( strName,intApprove,intIsDeleted);
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

       public SqlDataReader getDocBoyMaxCode1()
       {
           DLDocumentBoy dlc = new DLDocumentBoy();
           try
           {
               SqlDataReader dr = dlc.getDocBoyMaxCode1();
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
       public SqlDataReader getDocBoyName1()
       {
           DLDocumentBoy dldb = new DLDocumentBoy();
           try
           {
               SqlDataReader dr = dldb.getDocBoyName1();
               return dr;
           }
           catch
           {
               throw;
           }
           finally
           {
               dldb = null;
           }
       }
       public SqlDataReader getDocBoyDetailsForUpdate1(int intDocumentBoyID)
       {
           DLDocumentBoy dlsr = new DLDocumentBoy();
           try
           {
               SqlDataReader dr = dlsr.getDocBoyDetailsForUpdate1(intDocumentBoyID);
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
       public void updateDocumentBoy1(int intDocumentBoyID, string strMobile, int intIsDeleted, int intApprove, string strMailID)
       {
           DLDocumentBoy dlc = new DLDocumentBoy();
           try
           {
               dlc.updateDocumentBoy1( intDocumentBoyID,  strMobile,  intIsDeleted,  intApprove,strMailID);
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

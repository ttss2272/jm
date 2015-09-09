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
   public class BLDocument
    {
       string msg;
       public string saveDocument1(string strDocument, int intIsDeleted, int intApprove)
        {
            DLDocument dld = new DLDocument();
            try
            {
                msg = dld.saveDocument1(strDocument, intIsDeleted, intApprove);
            }
            catch
            {
                throw;
            }
            finally
            {
                dld = null;
            }
            return msg;
        }

       public SqlDataReader getDocument1()
       {
           DLDocument dld = new DLDocument();
           try
           {
               SqlDataReader dr = dld.getDocument1();
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

       public SqlDataAdapter getDocDocument1(string strDocument)
       {
           SqlDataAdapter da = new SqlDataAdapter();
           DLDocument dltow = new DLDocument();
           try
           {
               dltow.getDocDocument1(strDocument);
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

       public SqlDataReader gridFillApproveDoc1(int intApprove)
       {
           DLDocument dlsr = new DLDocument();
           try
           {
               SqlDataReader dr = dlsr.gridFillApproveDoc1(intApprove);
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

       public SqlDataReader gridFillApproveDocName1(string strDocument, int intApprove)
       {
           DLDocument dlsr = new DLDocument();
           try
           {
               SqlDataReader dr = dlsr.gridFillApproveDocName1(strDocument,intApprove);
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
       public SqlDataReader isDelDocChecked1(int intIsDeleted)
       {
           DLDocument dlc = new DLDocument();
           try
           {
               SqlDataReader dr = dlc.isDelDocChecked1(intIsDeleted);
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
       public SqlDataReader isDelDocNameChecked1(string strDocument, int intIsDeleted)
       {
           DLDocument dlc = new DLDocument();
           try
           {
               SqlDataReader dr = dlc.isDelDocNameChecked1(strDocument,intIsDeleted);
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

       public SqlDataReader isDelDocAppChkChecked1(int intApprove, int intIsDeleted)
       {
           DLDocument dlc = new DLDocument();
           try
           {
               SqlDataReader dr = dlc. isDelDocAppChkChecked1( intApprove, intIsDeleted);
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

       public SqlDataReader isDelDocNameAppChecked1(string strDocument, int intApprove, int intIsDeleted)
       {
           DLDocument dlc = new DLDocument();
           try
           {
               SqlDataReader dr = dlc.isDelDocNameAppChecked1( strDocument,intApprove, intIsDeleted);
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
       public SqlDataReader getDocDetailsForUpdate1(int intDocumentID)
       {
           DLDocument dlsr = new DLDocument();
           try
           {
               SqlDataReader dr = dlsr.getDocDetailsForUpdate1(intDocumentID);
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
       public void updateDocument1(int intDocumentID, string strDocument, int intIsDeleted, int intApprove)
       {
           DLDocument dlc = new DLDocument();
           try
           {
               dlc.updateDocument1(intDocumentID, strDocument, intIsDeleted, intApprove);
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

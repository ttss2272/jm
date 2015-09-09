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
   public class BLDocBoyHistory
    {
       public void saveDocumentBoyHistory1(DateTime dtDate, int intDBID, string strDocumentBoy, string strRemarks, int intProjectID)
       {
           DLDocBoyHistory dldbh = new DLDocBoyHistory();
           try
           {
               dldbh.saveDocumentBoyHistory1(dtDate, intDBID, strDocumentBoy, strRemarks, intProjectID);
           }
           catch
           {
               throw;
           }
           finally
           {
               dldbh = null;
           }
       }

       public void saveDocBoyHistoryDetails1(int intDBHID, int intDID, string strDocument)
       {
           DLDocBoyHistory dldbh = new DLDocBoyHistory();
           try
           {
               dldbh.saveDocBoyHistoryDetails1(intDBHID, intDID, strDocument);
           }
           catch
           {
               throw;
           }
           finally
           {
               dldbh = null;
           }
       }

       public SqlDataReader getDocBoyIdCode1(string strName)
       {
           DLDocBoyHistory dltow = new DLDocBoyHistory();
           try
           {
               SqlDataReader dr = dltow.getDocBoyIdCode1(strName);
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
       public SqlDataAdapter getDocOnDocBoyHistory1(int intProjectID)
       {
           SqlDataAdapter da = new SqlDataAdapter();
           DLDocBoyHistory dltow = new DLDocBoyHistory();
           try
           {
               dltow.getDocOnDocBoyHistory1( intProjectID);
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
       public SqlDataReader getDocBoyhistoryId1(string strName,int intProjectId)
       {
           DLDocBoyHistory dltow = new DLDocBoyHistory();
           try
           {
               SqlDataReader dr = dltow.getDocBoyhistoryId1( strName, intProjectId);
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
       public SqlDataAdapter fillGridDBHistoryDetails1(int intProjectID)
       {
           SqlDataAdapter da = new SqlDataAdapter();
           DLDocBoyHistory dltow = new DLDocBoyHistory();
           DataTable dt = new DataTable();
           try
           {
               da=dltow.fillGridDBHistoryDetails1(intProjectID);
               //da.Fill(dt);
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
       public DataSet showSelectedDocOfDocBoy1(int DBHID)
       {
           SqlDataAdapter da = new SqlDataAdapter();
           DLDocBoyHistory dltow = new DLDocBoyHistory();
           DataSet dt = new DataSet();
           try
           {
               dt= dltow.showSelectedDocOfDocBoy1(DBHID);
               return dt;
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
       public DataTable getSelectedUnSelectedDoc1(int intprojectID, int intDocumentboyId, DateTime dtdate, int intDBHID)
       {
           DataTable dt = new DataTable();
           DLDocBoyHistory dlsr = new DLDocBoyHistory();
           try
           {
               dt = dlsr.getSelectedUnSelectedDoc1( intprojectID, intDocumentboyId, dtdate,intDBHID);
               return dt;
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
       public SqlDataReader getDBHistDetails1(int intprojectID, int intDBHID)
       {
           DLDocBoyHistory dlsr = new DLDocBoyHistory();
           try
           {
               SqlDataReader dr = dlsr.getDBHistDetails1(intprojectID,intDBHID);
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
       public SqlDataReader getSelDocFromDBHDetails1(int intprojectID, int intDocumentboyId, DateTime dtdate, int intDBHID)
       {
           DLDocBoyHistory dlsr = new DLDocBoyHistory();
           try
           {
               SqlDataReader dr = dlsr.getSelDocFromDBHDetails1( intprojectID, intDocumentboyId, dtdate,intDBHID);
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
       public void delUnselectedDocOfDocBoy1(int intDBHID, int intDID)
       {
           DLDocBoyHistory dldbh = new DLDocBoyHistory();
           try
           {
               dldbh.delUnselectedDocOfDocBoy1(intDBHID, intDID);
           }
           catch
           {
               throw;
           }
           finally
           {
               dldbh = null;
           }
       }
       public void updateDocBoyHistory1(int intProjectID, DateTime dtDate, int intDBID, string strDocumentBoy, string strRemarks, int intDBHID)
       {
           DLDocBoyHistory dldbh = new DLDocBoyHistory();
           try
           {
               dldbh.updateDocBoyHistory1(intProjectID, dtDate, intDBID, strDocumentBoy, strRemarks, intDBHID);
           }
           catch
           {
               throw;
           }
           finally
           {
               dldbh = null;
           }
       }
    }
}

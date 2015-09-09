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
   public class BLProject
    {
        //ADD Comment
       string Result;
       public  string UpadateFileDelete(int projectid, string worddoc, string file)
       {
           DLProject dlDelFile = new DLProject();
           try
           {
            Result = dlDelFile.UpadateFileDelete(projectid, worddoc, file);

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
           return Result;
       }
       public SqlDataReader getProjects1()
       {
           DLProject dlc = new DLProject();
           try
           {
               SqlDataReader dr = dlc.getProjects1();
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

       public SqlDataReader getCaseName1(string strClientName)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.getCaseName1(strClientName);
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

       public SqlDataReader gridFillStatus1(string strStatus)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.gridFillStatus1(strStatus);
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

       public SqlDataReader gridFillClientStatus1(string strClientName, string strStatus)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.gridFillClientStatus1(strClientName,strStatus);
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

       public SqlDataReader gridFillClientCaseStatus1(string strClientName, string strCaseName, string strStatus)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.gridFillClientCaseStatus1(strClientName,strCaseName,strStatus);
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

       public SqlDataReader gridFillClientApprove1(string strClientName, int intApprove)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.gridFillClientApprove1(strClientName, intApprove);
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

       public SqlDataReader gridFillClientCaseApprove1(string strClientName, string strCaseName, int intApprove)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.gridFillClientCaseApprove1(strClientName,strCaseName,intApprove);
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

       public SqlDataReader gridFillClientCaseStatusApprove1(string strClientName, string strCaseName, string strStatus, int intApprove)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.gridFillClientCaseStatusApprove1(strClientName,strCaseName,strStatus,intApprove);
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

       public SqlDataReader gridFillApprove1(int intApprove)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.gridFillApprove1(intApprove);
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

       public SqlDataReader isDelProjectChecked1()
       {
           DLProject dlc = new DLProject();
           try
           {
               SqlDataReader dr = dlc.isDelProjectChecked1();
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

       public SqlDataReader isDelProjectUnChecked1()
       {
           DLProject dlc = new DLProject();
           try
           {
               SqlDataReader dr = dlc.isDelProjectUnChecked1();
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

       public SqlDataReader isDelProjectCliChecked1(string strClientName, int intIsDeleted)
       {
           DLProject dlc = new DLProject();
           try
           {
               SqlDataReader dr = dlc.isDelProjectCliChecked1(strClientName,intIsDeleted);
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

       public SqlDataReader isDelProjectCliCasChecked1(string strClientName, string strCaseName, int intIsDeleted)
       {
           DLProject dlc = new DLProject();
           try
           {
               SqlDataReader dr = dlc.isDelProjectCliCasChecked1(strClientName,strCaseName,intIsDeleted);
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

       public SqlDataReader isDelProjectCliStaCasChecked1(string strClientName, string strCaseName, string strStatus, int intIsDeleted)
       {
           DLProject dlc = new DLProject();
           try
           {
               SqlDataReader dr = dlc.isDelProjectCliStaCasChecked1(strClientName, strCaseName, strStatus, intIsDeleted);
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

       public SqlDataReader isDelProjectCliStaCasAppChecked1(string strClientName, string strCaseName, string strStatus, int intApprove, int intIsDeleted)
       {
           DLProject dlc = new DLProject();
           try
           {
               SqlDataReader dr = dlc.isDelProjectCliStaCasAppChecked1(strClientName, strCaseName, strStatus, intApprove, intIsDeleted);
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
       
       public SqlDataAdapter getProjectClientName1(string strClientName)
       {
           SqlDataAdapter da = new SqlDataAdapter();
           DLProject dltow = new DLProject();
           try
           {
               dltow.getProjectClientName1(strClientName);
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
       
       public SqlDataAdapter getProjectCliCasName1(string strClientName, string strCaseName)
       {
           SqlDataAdapter da = new SqlDataAdapter();
           DLProject dltow = new DLProject();
           try
           {
               dltow.getProjectCliCasName1(strClientName,strCaseName);
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
       
       public SqlDataReader getProject1()
       {
           DLProject dld = new DLProject();
           try
           {
               SqlDataReader dr = dld.getProject1();
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
       
       public void saveProject1(DateTime dtProjectDate, int intClientID, string strClientName, int intTypeOfWorkID, string strTypeOfWork, string strCaseName, int intExternalWork, bool boolNeedSearch, string strRemarks, decimal decPrice, decimal decOtherCharges, decimal decTotalAmount, string strStatus, bool boolIsDeleted, int intApprove, decimal decServiceTax, string strReferenceNo, string strLoanNO, string strPropertyAddress, DateTime dt_softcopysent, DateTime dt_MISclient, DateTime dt_search_initiated, DateTime dt_search_received, DateTime dt_search_received_receipt, DateTime dt_hardcopysent, DateTime dt_pendingdocumentsrec, DateTime dt_pendingdocumentsresp, DateTime dt_finalreportsent, string strworddoc, string strfilename, string strbranch, decimal decloanamt,string strEmailID)
       {
           DLProject dle = new DLProject();
           try
           {
               dle.saveProject1(dtProjectDate, intClientID, strClientName, intTypeOfWorkID, strTypeOfWork, strCaseName, intExternalWork, boolNeedSearch, strRemarks, decPrice, decOtherCharges, decTotalAmount, strStatus, boolIsDeleted, intApprove, decServiceTax, strReferenceNo, strLoanNO, strPropertyAddress, dt_softcopysent, dt_MISclient, dt_search_initiated, dt_search_received, dt_search_received_receipt, dt_hardcopysent, dt_pendingdocumentsrec, dt_pendingdocumentsresp, dt_finalreportsent, strworddoc, strfilename, strbranch, decloanamt, strEmailID);
           }
           catch
           {
               throw;
           }
           finally
           {
               dle = null;
           }
       }
       
       public SqlDataReader getTypWrkIdByWrk1(string strWork)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.getTypWrkIdByWrk1(strWork);
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
       
       public SqlDataReader getMaxProjectId1()
       {
           DLProject dldb = new DLProject();
           try
           {
               SqlDataReader dr = dldb.getMaxProjectId1();
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

       public SqlDataReader getDocIdDocGrid1(string strDocument)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.getDocIdDocGrid1(strDocument);
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

       public void saveSelectedDoc1(int intProjectID, int intDocumentID, string strDocument)
       {
           DLProject dle = new DLProject();
           try
           {
               dle.saveSelectedDoc1(intProjectID,intDocumentID,strDocument);
           }
           catch
           {
               throw;
           }
           finally
           {
               dle = null;
           }
       }
       
       public SqlDataReader getEmpIdEmpGrid1(string strEmployeeCode)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.getEmpIdEmpGrid1(strEmployeeCode);
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
       
       public void saveSelectedEmp1(int intProjectID, int intEmployeeID, string strEmployeeName, DateTime dtStartDate, DateTime dtEndDate)
       {
           DLProject dle = new DLProject();
           try
           {
               dle.saveSelectedEmp1(intProjectID, intEmployeeID, strEmployeeName, dtStartDate, dtEndDate);
           }
           catch
           {
               throw;
           }
           finally
           {
               dle = null;
           }
       }
       
       public SqlDataReader getDocBoyIdDocBoyGrid1(string strName)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.getDocBoyIdDocBoyGrid1(strName);
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

       public void saveSelectedDocumentBoy1(int intProjectID, int intDocumentboyID, string strDocumentboyName)
       {
           DLProject dle = new DLProject();
           try
           {
               dle.saveSelectedDocumentBoy1( intProjectID, intDocumentboyID, strDocumentboyName);
           }
           catch
           {
               throw;
           }
           finally
           {
               dle = null;
           }
       }
       
       public SqlDataReader getServiceIdServiceGrid1(string strServiceName)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.getServiceIdServiceGrid1(strServiceName);
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

       public void saveSelectedServices1(int intProjectID, int intServiceID, string strServices, float floatPrice)
       {
           DLProject dle = new DLProject();
           try
           {
               dle.saveSelectedServices1(intProjectID, intServiceID, strServices, floatPrice);
           }
           catch
           {
               throw;
           }
           finally
           {
               dle = null;
           }
       }
       
       public SqlDataReader getClerkIdClerkGrid1(string strClerkName)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.getClerkIdClerkGrid1( strClerkName);
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
       
       public void saveSelectedClerk1(int intProjectID, int intSearchClerkID, string strSearchClerkName, DateTime dtSearchStarts, DateTime dtSearchEnd)
       {
           DLProject dle = new DLProject();
           try
           {
               dle.saveSelectedClerk1(intProjectID, intSearchClerkID, strSearchClerkName, dtSearchStarts, dtSearchEnd);
           }
           catch
           {
               throw;
           }
           finally
           {
               dle = null;
           }
       }
       
       public SqlDataReader getProjectDetailsForUpdate1(int intProjectId)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.getProjectDetailsForUpdate1( intProjectId);
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
       
       public void updateProjects1(DateTime dtProjectDate, int intProjectId, string strClientName, int intTypeOfWorkID, string strTypeOfWork, string strCaseName, int intExternalWork, bool boolNeedSearch, string strRemarks, decimal decPrice, decimal decOtherCharges, decimal decTotalAmount, string strStatus, bool boolIsDeleted, int intApprove, decimal decServiceTax, string strReferenceNo, string strLoanNO, string strPropertyAddress, DateTime dt_softcopysent, DateTime dt_MISclient, DateTime dt_search_initiated, DateTime dt_search_received, DateTime dt_search_received_receipt, DateTime dt_hardcopysent, DateTime dt_pendingdocumentsrec, DateTime dt_pendingdocumentsresp, DateTime dt_finalreportsent, string strworddoc, string strfilename, string strbranch, decimal decloanamt,string strEmailID)
       {
           DLProject dlc = new DLProject();
           try
           {
               dlc.updateProjects1(dtProjectDate, intProjectId, strClientName, intTypeOfWorkID, strTypeOfWork, strCaseName, intExternalWork, boolNeedSearch, strRemarks, decPrice, decOtherCharges, decTotalAmount, strStatus, boolIsDeleted, intApprove, decServiceTax, strReferenceNo, strLoanNO, strPropertyAddress, dt_softcopysent, dt_MISclient, dt_search_initiated, dt_search_received, dt_search_received_receipt, dt_hardcopysent, dt_pendingdocumentsrec, dt_pendingdocumentsresp, dt_finalreportsent, strworddoc, strfilename, strbranch, decloanamt, strEmailID);
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
       
       public SqlDataReader showSelectedDoc1(int intProjectId)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.showSelectedDoc1( intProjectId);
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
       
       public SqlDataReader getClientName1()
       {
           DLProject dlc = new DLProject();
           try
           {
               SqlDataReader dr = dlc.getClientName1();
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
       
       public SqlDataReader showSelectedDocBoys1(int intProjectId)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.showSelectedDocBoys1( intProjectId);
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
       
       public SqlDataReader showSelectedEmployees1(int intProjectId)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.showSelectedEmployees1(intProjectId);
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
       
       public SqlDataReader showSelectedClerk1(int intProjectId)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.showSelectedClerk1(intProjectId);
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
       
       public SqlDataReader showSelectedServices1(int intProjectId)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.showSelectedServices1(intProjectId);
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
       
       //public string DelDocument(int Projectid)
       //{
       //    DLProject dlObjDelDoc = new DLProject();
       //    try
       //    {
       //        Result = dlObjDelDoc.DelDocument(Projectid );

       //    }
       //    catch(Exception ex)
       //    {
       //        Result = ex.Message.ToString();
       //    }
       //    finally
       //    {
       //        dlObjDelDoc = null;
       //    }
       //    return Result;
       //}

       public void delDocOnProject1(int intProjectId)
       {
           DLProject dlc = new DLProject();
           try
           {
               dlc.delDocOnProject1(intProjectId);
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

       public void deleteProject(int ProjectId)
       {
           DLProject dlProject = new DLProject();
           try
           {
               dlProject.deleteProject(ProjectId);
           }
           catch
           {
               throw;
           }
           finally
           {
               dlProject = null;
           }
       }

       public void delUnSelectDoc1(int intProjectID, int intDocumentID)
       {
           DLProject dle = new DLProject();
           try
           {
               dle.delUnSelectDoc1(intProjectID, intDocumentID);
           }
           catch
           {
               throw;
           }
           finally
           {
               dle = null;
           }
       }

       public void delUnSelectedServices1(int intProjectID, int intServiceID)
       {
           DLProject dle = new DLProject();
           try
           {
               dle.delUnSelectedServices1(intProjectID, intServiceID);
           }
           catch
           {
               throw;
           }
           finally
           {
               dle = null;
           }
       }

       public void delUnSelectedEmp1(int intProjectID, int intEmployeeID)
       {
           DLProject dle = new DLProject();
           try
           {
               dle.delUnSelectedEmp1(intProjectID, intEmployeeID);
           }
           catch
           {
               throw;
           }
           finally
           {
               dle = null;
           }
       }

       public void delUnselectClerk1(int intProjectID, int intSearchClerkID)
       {
           DLProject dle = new DLProject();
           try
           {
               dle.delUnselectClerk1(intProjectID, intSearchClerkID);
           }
           catch
           {
               throw;
           }
           finally
           {
               dle = null;
           }
       }

       public void delUnSelectedDocBoy1(int intProjectID, int intDocumentboyID)
       {
           DLProject dle = new DLProject();
           try
           {
               dle.delUnSelectedDocBoy1(intProjectID, intDocumentboyID);
           }
           catch
           {
               throw;
           }
           finally
           {
               dle = null;
           }
       }

       public SqlDataReader GetData(int LoginId)
       {
           DLProject dlc = new DLProject();
           try
           {
               SqlDataReader dr = dlc.getData(LoginId);
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
       
       public SqlDataReader getServiceForEmpClient1(int intClientID)
       {
           DLProject dlsr = new DLProject();
           try
           {
               SqlDataReader dr = dlsr.getServiceForEmpClient1(intClientID);
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
       
       public SqlDataReader getClientNameForProject1()
       {
           DLProject dlc = new DLProject();
           try
           {
               SqlDataReader dr = dlc.getClientNameForProject1();
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
       
       public SqlDataReader getTypeOfWorkForProject1()
       {
           DLProject dlc = new DLProject();
           try
           {
               SqlDataReader dr = dlc.getTypeOfWorkForProject1();
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
    }
}

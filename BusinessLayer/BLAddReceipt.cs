using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
  public   class BLAddReceipt
  {
      DLAddReceipt dlAddRec = new DLAddReceipt();
      public void addReceipt(int intReceiptNo, DateTime dateReceiptDate, int intClId, int intGrpId, string strpaytyp, double doubleAmt,double  doubleTDS, double doubleDisc, string strBnkNm, string strChqDftNo, DateTime dtChqDftDate, int intAgainstBills, double  intbalAmt, int intTDSCertRecvd, string strCmmnts, string strClNm, string strSubGrpNm, int intIsDel, double BillAmt, double TDSPerc, int intApp)
        {
           
            try
            {

                dlAddRec.addReceipt(intReceiptNo, dateReceiptDate, intClId, intGrpId, strpaytyp, doubleAmt , doubleTDS , doubleDisc , strBnkNm, strChqDftNo, dtChqDftDate, intAgainstBills, intbalAmt, intTDSCertRecvd, strCmmnts, strClNm, strSubGrpNm, intIsDel, BillAmt, TDSPerc, intApp);
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlAddRec = null;
            }
        }
      public void UpdateReceipt(int intReceiptId, DateTime dateReceiptDate, int intGrpId, string strpaytyp, double doubleAmt, double doubleTDS, double doubleDisc, string strBnkNm, string strChqDftNo, DateTime dtChqDftDate, int intAgainstBills, double intbalAmt, int intTDSCertRecvd, string strCmmnts, string strSubGrpNm, int intIsDel, double BillAmt, double TDSPerc, int intApp)
      {
          //DLAddReceipt dlAddRec = new DLAddReceipt();
          try
          {

              dlAddRec.UpdateReceipt(intReceiptId, dateReceiptDate, intGrpId, strpaytyp, doubleAmt, doubleTDS, doubleDisc, strBnkNm, strChqDftNo, dtChqDftDate, intAgainstBills, intbalAmt, intTDSCertRecvd, strCmmnts, strSubGrpNm, intIsDel, BillAmt, TDSPerc, intApp);
          }
          catch
          {
              throw;
          }
          finally
          {
              //dlAddRec = null;
          }
      }
        public SqlDataReader getClientRec()
        {
            //DLAddReceipt dlc = new DLAddReceipt();
            try
            {
                SqlDataReader dr = dlAddRec .getClientRec();
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

        public SqlDataReader GetClientIdByNm1(string ClNm)
        {
            //DLAddReceipt dlc = new DLAddReceipt();
            try
            {
                SqlDataReader dr = dlAddRec .GetClientIdByNm1(ClNm);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
               // dlAddRec  = null;
            }
        }
        public SqlDataReader GetRecDetForUpdate(int RecId)
        {
            //DLAddReceipt dlc = new DLAddReceipt();
            try
            {
                SqlDataReader dr = dlAddRec .GetRecDetForUpdate(RecId);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlAddRec  = null;
            }
        }
        public SqlDataReader GetInvoiceByAddRec1(int ClId,int update)
        {
            DLAddReceipt dlc = new DLAddReceipt();
            try
            {
                SqlDataReader dr = dlAddRec .GetInvoiceByAddRec1(ClId,update );
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
               // dlAddRec = null;
            }
        }
       

       
        //public SqlDataReader GetInvIdForAdjustAmt(int ClId,double amt)
        //{
        //    //DLAddReceipt dlc = new DLAddReceipt();
        //    try
        //    {
        //        SqlDataReader dr = dlAddRec .GetInvIdForAdjustAmt(ClId ,amt );
        //        return dr;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        //dlAddRec  = null;
        //    }
        //}
        public void  DelAdjustAmt(int BillId)
        {
            //DLAddReceipt dlc = new DLAddReceipt();
            try
            {
                 dlAddRec.DelAdjustAmt(BillId );
                
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlAddRec  = null;
            }
        }
        public SqlDataReader GetAdjustAmtForUpdate(int RecId, double amt,int invoiceid)
        {
            //DLAddReceipt dlc = new DLAddReceipt();
            try
            {
                SqlDataReader dr = dlAddRec.GetAdjustAmtForUpdate(RecId,amt,invoiceid );
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlAddRec  = null;
            }
        }
        public SqlDataReader GetMaxRecId()
        {
            //DLAddReceipt dlc = new DLAddReceipt();
            try
            {
                SqlDataReader dr = dlAddRec .GetMaxRecId();
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlAddRec = null;
            }
        }
        public SqlDataReader AddAdjustAmt(int RecId, int InvoiceId, double  amt, double  TDS, double  disc)
        {
            //DLAddReceipt dlc = new DLAddReceipt();
            try
            {
                SqlDataReader dr = dlAddRec .AddAdjustAmt(RecId, InvoiceId, amt, TDS, disc);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
               // dlAddRec = null;
            }
        }
    }
}

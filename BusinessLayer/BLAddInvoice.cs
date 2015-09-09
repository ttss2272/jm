using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
  public  class BLAddInvoice
    {
      public void AddInvoice(int invoiceid,string InvoiceNo, DateTime Date, int ClientId, decimal Amount, decimal OtherCharges, decimal TotalAmount, string Remarks, string Status, int isDeleted, int Approve,int mode)
      {
          DLAddInvoice   dlaRec = new DLAddInvoice  ();
          try
          {
              dlaRec.AddInvoice(invoiceid,InvoiceNo, Date, ClientId, Amount, OtherCharges, TotalAmount, Remarks, Status, isDeleted, Approve,mode );
          }
          catch
          {
              throw;
          }
          finally
          {
              dlaRec = null;
          }
      }
      public void AddInvoiceDetail(int InvoiceId, int ProjectId, float  ProjectAmount)
      {
          DLAddInvoice dlaRec = new DLAddInvoice();
          try
          {
              dlaRec.AddInvoiceDetail(InvoiceId, ProjectId, ProjectAmount);
          }
          catch
          {
              throw;
          }
          finally
          {
              dlaRec = null;
          }
      }
      public void DelProjectDetail(int ProjectId)
      {
          DLAddInvoice dlaRec = new DLAddInvoice();
          try
          {
              dlaRec.DelProjectDetail(ProjectId);
          }
          catch
          {
              throw;
          }
          finally
          {
              dlaRec = null;
          }
      }
        public SqlDataReader getClientInvce()
        {
            DLAddInvoice dlAddCl = new DLAddInvoice();
            try
            {
                SqlDataReader dr = dlAddCl.getClientInvce ();
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
        public SqlDataReader getClientidName()
        {
            DLAddInvoice dlAddCl = new DLAddInvoice();
            try
            {
                SqlDataReader dr = dlAddCl.getClientIdName ();
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
        public SqlDataReader getClientInfo(string ClNm)
        {
            DLAddInvoice dlAddCl = new DLAddInvoice();
            try
            {
                SqlDataReader dr = dlAddCl.getClientInfo(ClNm);
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
        public SqlDataReader getClIdByName(string ClNm)
        {
            DLAddInvoice dlAddCl = new DLAddInvoice();
            try
            {
                SqlDataReader dr = dlAddCl.getClIdByName(ClNm);
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
        public DataTable  GetInvoiceDetailForUpdate(int invoiceid)
        {
            DLAddInvoice dlAddCl = new DLAddInvoice();
            try
            {
                DataTable  dr = dlAddCl.GetInvoiceDetailForUpdate(invoiceid);
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
        public SqlDataReader GetInvoiceId1()
        {
            DLAddInvoice dlAdIn = new DLAddInvoice();
            try
            {
                SqlDataReader dr = dlAdIn.GetInvoiceId1();
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
        public SqlDataReader getInvoiceForUpdate(int invoiceid)
        {
            DLAddInvoice dlAdIn = new DLAddInvoice();
            try
            {
                SqlDataReader dr = dlAdIn.getInvoiceForUpdate(invoiceid );
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                dlAdIn = null;
                //con.Close();
                //con.Dispose();
            }
        }
    }
}

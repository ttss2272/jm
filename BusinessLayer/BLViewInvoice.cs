using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
  public  class BLViewInvoice
    {
        DLViewInvoice dlViewIn = new DLViewInvoice();
        public SqlDataReader ViewInvoiceDet(string ClNm, string InNo, int app)
        {
            try
            {
                SqlDataReader dr = dlViewIn.ViewInvoiceDet(ClNm, InNo, app);
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

    }
}

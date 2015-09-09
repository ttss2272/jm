using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLayer
{
  public   class BLSelectProject
    {
        public SqlDataReader GetProjectByAddInv1(int ClId, DateTime from, DateTime to)
        {
            DLSelectProject dlselPr = new DLSelectProject();
            try
            {
                SqlDataReader dr = dlselPr.GetProjectByAddInv1(ClId ,from ,to);
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
    }
}

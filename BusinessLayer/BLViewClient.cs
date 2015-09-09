using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLayer
{
  public   class BLViewClient
  {
      public SqlDataReader GetClientByNameType1(string ClNm, int App)
      {
          DLViewClient dlvwCl = new DLViewClient();
          try
          {
              SqlDataReader dr = dlvwCl.GetClientByNameType1(ClNm, App);
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
      public SqlDataReader GetClientAtLoad1()
      {
          DLViewClient dlvwCl = new DLViewClient();
          try
          {
              SqlDataReader dr = dlvwCl.GetClientAtLoad1();
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

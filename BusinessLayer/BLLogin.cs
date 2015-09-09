using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;


namespace BusinessLayer
{
    public class BLLogin
    {
        DLLogin dlLogin = new DLLogin();

        public SqlDataReader checklogin(string username, string password)
        {
            try
            {
                SqlDataReader dr = dlLogin.checklogin(username, password);
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

        //public DataSet CheckTrail()
        //{
        //    DataSet ds = dlLogin.CheckTrail();
        //    return ds;
        //}
    }
}

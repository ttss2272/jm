using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
namespace BusinessLayer
{
    public class BLAddSearchUser
    {
        string result;
        public string addSearchUser(string strUsername, string strPassword, string strType, string strMailid, int intIsDeleted)
        {
            DLAddSearchUser dlAddUsr = new DLAddSearchUser();
            try
            {
                result = dlAddUsr.addSearchUser(strUsername, strPassword, strType, strMailid, intIsDeleted);
                return result;
            }
            catch
            {
                throw;
            }
            finally
            {
                dlAddUsr = null;
            }
        }

        public SqlDataReader FillUserAtLoad1()
        {
            DLAddSearchUser dlAddSerch = new DLAddSearchUser();
            try
            {
                SqlDataReader dr = dlAddSerch.FillUserAtLoad1();
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

        public DataSet getAdminCount()
        {
            DLAddSearchUser dlAddSerch = new DLAddSearchUser();
            try
            {
                DataSet dr = dlAddSerch.getAdminCount();
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

        public SqlDataReader userisdeleted(string Unm, int isdel)
        {
            DLAddSearchUser dlAddSerch = new DLAddSearchUser();
            try
            {
                SqlDataReader dr = dlAddSerch.userisdeleted(Unm, isdel);
                return dr;
            }
            catch
            {
                throw;
            }
        }

        public SqlDataReader GetUserById(int UserId)
        {
            DLAddSearchUser dlAddSerch = new DLAddSearchUser();
            try
            {
                SqlDataReader dr = dlAddSerch.GetUserById(UserId);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                dlAddSerch = null;
            }
        }

        public SqlDataReader FillUsrNmType1(string Unm, string type)
        {
            DLAddSearchUser dlserchType = new DLAddSearchUser();
            try
            {
                SqlDataReader dr = dlserchType.FillUsrNmType1(Unm, type);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                dlserchType = null;
            }
        }

        public SqlDataReader FillUsrNmTypeIsDel1(string Unm, string type, int isdel)
        {
            DLAddSearchUser dlserchType = new DLAddSearchUser();
            try
            {
                SqlDataReader dr = dlserchType.FillUsrNmTypeIsDel1(Unm, type, isdel);
                return dr;
            }
            catch
            {
                throw;
            }
        }

        public string UpdateUser(int userid, string Unm, string pass, string mailid, int isdel)
        {
            DLAddSearchUser dlserchType = new DLAddSearchUser();
            try
            {
                result = dlserchType.UpdateUser(userid, Unm, pass, mailid, isdel);
                return result;
            }
            catch
            {
                throw;
            }
            finally
            {
                dlserchType = null;
            }

        }
        public SqlDataReader FillTypeIsDel1(string type, int isdel)
        {
            DLAddSearchUser dlserchType = new DLAddSearchUser();
            try
            {
                SqlDataReader dr = dlserchType.FillTypeIsDel1(type, isdel);
                return dr;
            }
            catch
            {
                throw;
            }
        }
    }
}

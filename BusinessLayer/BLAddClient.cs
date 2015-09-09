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
  public  class BLAddClient
    {
      string msg;
      public string  addClient(string strClientNm, string strAdd1, string strAdd2, string strAdd3, string strAdd4, string strTel, string strMob, string strPan, string strBranch, string strCity, string strConPer1, string strConPer2, string strConPer3, string strCntct1, string strCntct2, string strCntct3, string strEmail1, string strEmail2, string strEmail3, int intIsDel, string strPrefix, int intApprve, int intserviceTax, string emailinv, string multiemail)
      {
          DLAddClient dlaCl = new DLAddClient();
          try
          {
             msg= dlaCl.addClient(strClientNm, strAdd1, strAdd2, strAdd3, strAdd4, strTel, strMob, strPan, strBranch, strCity, strConPer1, strConPer2, strConPer3, strCntct1, strCntct2, strCntct3, strEmail1, strEmail2, strEmail3, intIsDel, strPrefix, intApprve, intserviceTax, emailinv, multiemail);
          }
          catch
          {
              throw;
          }
          finally
          {
              dlaCl = null;
          }
          return msg;
      }

      public string  UpdateClient(int ClientId, string strAdd1, string strAdd2, string strAdd3, string strAdd4, string strTel, string strMob, string strPan, string strBranch, string strCity, string strConPer1, string strConPer2, string strConPer3, string strCntct1, string strCntct2, string strCntct3, string strEmail1, string strEmail2, string strEmail3, int intIsDel, string strPrefix, int intApprve, int intserviceTax, string emailinv, string multiemail)
      {
          DLAddClient dlaCl = new DLAddClient();
          try
          {
             msg= dlaCl.UpdateClient(ClientId , strAdd1, strAdd2, strAdd3, strAdd4, strTel, strMob, strPan, strBranch, strCity, strConPer1, strConPer2, strConPer3, strCntct1, strCntct2, strCntct3, strEmail1, strEmail2, strEmail3, intIsDel, strPrefix, intApprve, intserviceTax, emailinv, multiemail);
          }
          catch
          {
              throw;
          }
          finally
          {
              dlaCl = null;
          }
          return msg;
      }

      public SqlDataReader GetClientDetails(int ClientId)
      {
          DLAddClient dlAddCl = new DLAddClient();
          try
          {
              SqlDataReader dr = dlAddCl.GetClientDetails(ClientId);
               
              return dr;
          }
          catch
          {
              throw;
          }
          finally
          {
              dlAddCl = null;
          }

      }

      public SqlDataReader GetServForUpdateClientServices(int ClientId)
      {
          DLAddClient dlAddCl = new DLAddClient();
          try
          {
              SqlDataReader dr = dlAddCl.GetServForUpdateClientServices(ClientId);

              return dr;
          }
          catch
          {
              throw;
          }
          finally
          {
              //dlAddCl = null;
          }

      }

        public SqlDataReader getClientId()
        {
            DLAddClient dlAddCl = new DLAddClient();
            try
            {
                SqlDataReader dr = dlAddCl.getClientId();
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                dlAddCl = null;
            }

        }
        public SqlDataReader GetServiceId()
        {
            DLAddClient dlAddCl = new DLAddClient();
            try
            {
                SqlDataReader dr = dlAddCl.GetServiceId();
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlAddCl = null;
            }

        }
        public SqlDataReader GetServiceCount()
        {
            DLAddClient dlAddCl = new DLAddClient();
            try
            {
                SqlDataReader dr = dlAddCl.GetServiceCount();
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlAddCl = null;
            }

        }
       public SqlDataReader GetServiceNmId1()

        {
            DLAddClient dlAddSer = new DLAddClient();
            try
            {
                SqlDataReader dr = dlAddSer.GetServiceNmId1();
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {
                //dlAddCl = null;
            }

        }

          public SqlDataReader GetServiceNm()
       {
           DLAddClient dlAddSer = new DLAddClient();
           try
           {
               SqlDataReader dr = dlAddSer.GetServiceNm();
               return dr;
           }
           catch
           {
               throw;
           }
           finally
           {
               //dlAddCl = null;
           }

       }
          public SqlDataReader GetServiceIdByNm1(string SerNm)
          {
              DLAddClient dlAddSer = new DLAddClient();
              try
              {
                  SqlDataReader dr = dlAddSer.GetServiceIdByNm1(SerNm );
                  return dr;
              }
              catch
              {
                  throw;
              }
              finally
              {
                  //dlAddCl = null;
              }

          }
          public void addClientServicePrice(int ClientId, int ServiceId, double Price)
          {
              DLAddClient dlAddSer = new DLAddClient();
              try
              {
                  dlAddSer.addClientServicePrice(ClientId, ServiceId, Price);
              }
              catch
              {
                  throw;
              }
              finally
              {
                  //dlAddCl = null;
              }

          }
          public void UpdateServiceForClient(int clientid, int serviceid, decimal price)
          {
              DLAddClient dlAddSer = new DLAddClient();
              try
              {
                  dlAddSer.UpdateServiceForClient(clientid, serviceid, price);
              }
              catch
              {
                  throw;
              }
              finally
              {
                  //dlAddCl = null;
              }

          }
       public SqlDataReader GetClientId1()
       {
           DLAddClient dlAddSer = new DLAddClient();
           try
           {
               SqlDataReader dr = dlAddSer.GetClientId1();
               return dr;
           }
           catch
           {
               throw;
           }
           finally
           {
               //dlAddCl = null;
           }

       }
       /* Name:Yogita
         * Purpose:GetService Nm When gridview checkbox check*/
       #region
       public SqlDataReader GetServiceNmById(int serviceid)
       {
           DLAddClient dlAddSer = new DLAddClient();
           try
           {
               SqlDataReader dr = dlAddSer.GetServiceNmById(serviceid );
               return dr;
           }
           catch
           {
               throw;
           }
           finally
           {
               //dlAddCl = null;
           }

       }
       #endregion
       /*Name:-Yogita
 * Purpose:-Savetempservices,delete temp services,get temp services-------*/
       #region-----------save temp service---------
       public string saveTempService(int loginid,int serviceid,string price,int clientid)
       {
           DLAddClient dlaCl = new DLAddClient();
           try
           {
               msg = dlaCl.saveTempService(loginid, serviceid,price,clientid  );
           }
           catch
           {
               throw;
           }
           finally
           {
               dlaCl = null;
           }
           return msg;
       }
        #endregion
       #region---------delete temp service------
       public void delTempService(int loginid)
       {
           DLAddClient dlaCl = new DLAddClient();
           try
           {
               dlaCl.delTempService(loginid);
           }
           catch
           {
               throw;
           }
           finally
           {
               dlaCl = null;
           }
           
       }
       #endregion
       #region-----------get temp services--------------
       public DataSet getTempService(int loginid,int clientid)
       {
           DLAddClient dlgetSer = new DLAddClient();
           DataSet ds=dlgetSer.getTempService(loginid,clientid );
           return ds;
       }
       #endregion
    }
}

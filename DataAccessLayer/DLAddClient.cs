using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace DataAccessLayer
{
    public class DLAddClient
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        string msg;
        public string  addClient(string strClientNm, string strAdd1, string strAdd2, string strAdd3, string strAdd4, string strTel, string strMob, string strPan, string strBranch, string strCity, string strConPer1, string strConPer2, string strConPer3, string strCntct1, string strCntct2, string strCntct3, string strEmail1, string strEmail2, string strEmail3, int intIsDel, string strPrefix, int intApprve, int intserviceTax, string emailinv, string multiemail)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("AddClient", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param1.Value = strClientNm;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@Address1", SqlDbType.VarChar);
                param2.Value = strAdd1;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Address2", SqlDbType.VarChar);
                param3.Value = strAdd2;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@Address3", SqlDbType.VarChar);
                param4.Value = strAdd3;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@Address4", SqlDbType.VarChar);
                param5.Value = strAdd4;
                cmd.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@Telephone", SqlDbType.VarChar);
                param6.Value = strTel;
                cmd.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@Mobile", SqlDbType.VarChar);
                param7.Value = strMob;
                cmd.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter("@PanNo", SqlDbType.VarChar);
                param8.Value = strPan;
                cmd.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter("@Branch", SqlDbType.VarChar);
                param9.Value = strBranch;
                cmd.Parameters.Add(param9);

                SqlParameter param10 = new SqlParameter("@City", SqlDbType.VarChar);
                param10.Value = strCity;
                cmd.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter("@ContactPerson1", SqlDbType.VarChar);
                param11.Value = strConPer1;
                cmd.Parameters.Add(param11);

                SqlParameter param12 = new SqlParameter("@ContactPerson2", SqlDbType.VarChar);
                param12.Value = strConPer2;
                cmd.Parameters.Add(param12);

                SqlParameter param13 = new SqlParameter("@ContactPerson3", SqlDbType.VarChar);
                param13.Value = strConPer3;
                cmd.Parameters.Add(param13);

                SqlParameter param14 = new SqlParameter("@ContactNo1", SqlDbType.VarChar);
                param14.Value = strCntct1;
                cmd.Parameters.Add(param14);

                SqlParameter param15 = new SqlParameter("@ContactNo2", SqlDbType.VarChar);
                param15.Value = strCntct2;
                cmd.Parameters.Add(param15);

                SqlParameter param16 = new SqlParameter("@ContactNo3", SqlDbType.VarChar);
                param16.Value = strCntct3;
                cmd.Parameters.Add(param16);

                SqlParameter param17 = new SqlParameter("@EmailId1", SqlDbType.VarChar);
                param17.Value = strEmail1;
                cmd.Parameters.Add(param17);

                SqlParameter param18 = new SqlParameter("@EmailId2", SqlDbType.VarChar);
                param18.Value = strEmail1;
                cmd.Parameters.Add(param18);

                SqlParameter param19 = new SqlParameter("@EmailId3", SqlDbType.VarChar);
                param19.Value = strEmail1;
                cmd.Parameters.Add(param19);

                SqlParameter param20 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
                param20.Value = intIsDel;
                cmd.Parameters.Add(param20);

                SqlParameter param21 = new SqlParameter("@Prefix", SqlDbType.VarChar);
                param21.Value = strPrefix;
                cmd.Parameters.Add(param21);

                SqlParameter param22 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param22.Value = intApprve;
                cmd.Parameters.Add(param22);

                SqlParameter param23 = new SqlParameter("@servicetax", SqlDbType.VarChar);
                param23.Value = intserviceTax;
                cmd.Parameters.Add(param23);

                SqlParameter param24 = new SqlParameter("@emailinv", SqlDbType.VarChar);
                param24.Value = emailinv;
                cmd.Parameters.Add(param24);

                SqlParameter param25 = new SqlParameter("@multiemail", SqlDbType.VarChar);
                param25.Value = multiemail;
                cmd.Parameters.Add(param25);


                msg=cmd.ExecuteScalar ().ToString ();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            return msg;
        }
        public string  UpdateClient(int ClientId, string strAdd1, string strAdd2, string strAdd3, string strAdd4, string strTel, string strMob, string strPan, string strBranch, string strCity, string strConPer1, string strConPer2, string strConPer3, string strCntct1, string strCntct2, string strCntct3, string strEmail1, string strEmail2, string strEmail3, int intIsDel, string strPrefix, int intApprve, int intserviceTax, string emailinv, string multiemail)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateClient", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClientId", SqlDbType.VarChar);
                param1.Value = ClientId ;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@Address1", SqlDbType.VarChar);
                param2.Value = strAdd1;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Address2", SqlDbType.VarChar);
                param3.Value = strAdd2;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter("@Address3", SqlDbType.VarChar);
                param4.Value = strAdd3;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter("@Address4", SqlDbType.VarChar);
                param5.Value = strAdd4;
                cmd.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter("@Telephone", SqlDbType.VarChar);
                param6.Value = strTel;
                cmd.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@Mobile", SqlDbType.VarChar);
                param7.Value = strMob;
                cmd.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter("@PanNo", SqlDbType.VarChar);
                param8.Value = strPan;
                cmd.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter("@Branch", SqlDbType.VarChar);
                param9.Value = strBranch;
                cmd.Parameters.Add(param9);

                SqlParameter param10 = new SqlParameter("@City", SqlDbType.VarChar);
                param10.Value = strCity;
                cmd.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter("@ContactPerson1", SqlDbType.VarChar);
                param11.Value = strConPer1;
                cmd.Parameters.Add(param11);

                SqlParameter param12 = new SqlParameter("@ContactPerson2", SqlDbType.VarChar);
                param12.Value = strConPer2;
                cmd.Parameters.Add(param12);

                SqlParameter param13 = new SqlParameter("@ContactPerson3", SqlDbType.VarChar);
                param13.Value = strConPer3;
                cmd.Parameters.Add(param13);

                SqlParameter param14 = new SqlParameter("@ContactNo1", SqlDbType.VarChar);
                param14.Value = strCntct1;
                cmd.Parameters.Add(param14);

                SqlParameter param15 = new SqlParameter("@ContactNo2", SqlDbType.VarChar);
                param15.Value = strCntct2;
                cmd.Parameters.Add(param15);

                SqlParameter param16 = new SqlParameter("@ContactNo3", SqlDbType.VarChar);
                param16.Value = strCntct3;
                cmd.Parameters.Add(param16);

                SqlParameter param17 = new SqlParameter("@EmailId1", SqlDbType.VarChar);
                param17.Value = strEmail1;
                cmd.Parameters.Add(param17);

                SqlParameter param18 = new SqlParameter("@EmailId2", SqlDbType.VarChar);
                param18.Value = strEmail1;
                cmd.Parameters.Add(param18);

                SqlParameter param19 = new SqlParameter("@EmailId3", SqlDbType.VarChar);
                param19.Value = strEmail1;
                cmd.Parameters.Add(param19);

                SqlParameter param20 = new SqlParameter("@IsDeleted", SqlDbType.VarChar);
                param20.Value = intIsDel;
                cmd.Parameters.Add(param20);

                SqlParameter param21 = new SqlParameter("@Prefix", SqlDbType.VarChar);
                param21.Value = strPrefix;
                cmd.Parameters.Add(param21);

                SqlParameter param22 = new SqlParameter("@Approve", SqlDbType.VarChar);
                param22.Value = intApprve;
                cmd.Parameters.Add(param22);

                SqlParameter param23 = new SqlParameter("@servicetax", SqlDbType.VarChar);
                param23.Value = intserviceTax;
                cmd.Parameters.Add(param23);

                SqlParameter param24 = new SqlParameter("@emailinv", SqlDbType.VarChar);
                param24.Value = emailinv;
                cmd.Parameters.Add(param24);

                SqlParameter param25 = new SqlParameter("@multiemail", SqlDbType.VarChar);
                param25.Value = multiemail;
                cmd.Parameters.Add(param25);


               msg= cmd.ExecuteNonQuery().ToString();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            return msg;
        }
        public void addClientServicePrice(int ClientId, int ServiceId,double Price)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("addClientPriceService", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@ClientId", SqlDbType.Int );
                param1.Value = ClientId;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@ServiceId", SqlDbType.Int );
                param2.Value = ServiceId;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Price", SqlDbType.Float );
                param3.Value = Price;
                cmd.Parameters.Add(param3);
                cmd.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public SqlDataReader GetClientDetails(int ClientId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetClientDetails", con);
            SqlParameter param = new SqlParameter("@ClientId", ClientId);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.Int32;
            cmd.Parameters.Add(param);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
            catch
            {
                throw;

            }
            finally
            {
                //con.Close();
            }
        }
        public SqlDataReader GetServForUpdateClientServices(int ClientId)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetServForUpdateClientServices", con);
            SqlParameter param = new SqlParameter("@ClientId",ClientId );
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.Int32;
            cmd.Parameters.Add(param );
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
            catch
            {
                throw;

            }
            finally
            {
                //con.Close();
            }

        }

        public SqlDataReader getClientId()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetClientId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader (CommandBehavior.CloseConnection );
                
                return dr;
            }
            catch
            {
                throw;

            }
            finally
            {
                //con.Close();
            }
            
        }
        public SqlDataReader GetServiceId()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetServiceId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
            catch
            {
                throw;

            }
            finally
            {
                //con.Close();
            }

        }
        public SqlDataReader GetServiceCount()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetServiceCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
            catch
            {
                throw;

            }
            finally
            {
                //con.Close();
            }

        }
        public SqlDataReader GetServiceNmId1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetServiceNmId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection );

                return dr;
            }
            catch
            {
                throw;

            }
            finally
            {
                //con.Close();
            }

        }
        public SqlDataReader GetClientId1()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetClientId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection );

                return dr;
            }
            catch
            {
                throw;

            }
            finally
            {
                //con.Close();
            }

        }
        public SqlDataReader GetServiceNm()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetServiceNm", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection );

                return dr;
            }
            catch
            {
                throw;

            }
            finally
            {
                //con.Close();
            }
        }
        /* Name:Yogita
         * Purpose:GetService Nm When gridview checkbox check*/
        #region
        public SqlDataReader GetServiceNmById(int serviceid)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getServiceNmById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("serviceid",serviceid );
            try
            {
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
            catch
            {
                throw;

            }
            finally
            {
                //con.Close();
            }
        }
        #endregion
        public SqlDataReader GetServiceIdByNm1(string SerNm)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetServiceIdByNm", con);
            SqlParameter param = new SqlParameter("@ServiceName",SerNm );
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String ;
            cmd.Parameters.Add(param );
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection );

                return dr;
            }
            catch
            {
                throw;

            }
            finally
            {
                //con.Close();
            }

        }
        public SqlDataReader UpdateServiceForClient(int clientid,int serviceid,decimal price)
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateServiceForClient", con);
                SqlParameter param = new SqlParameter("@ClientId", clientid );
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Int32 ;
                SqlParameter param1 = new SqlParameter("@ServiceId", serviceid );
                param1.Direction = ParameterDirection.Input;
                param1.DbType = DbType.Int32 ;
                SqlParameter param2 = new SqlParameter("@Price", price );
                param2.Direction = ParameterDirection.Input;
                param2.DbType = DbType.Decimal ;
                cmd.Parameters.Add(param);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    return dr;
                }
                catch
                {
                    throw;

                }
                finally
                {
                    //con.Close();
                }

            }
        /* Name:-Yogita
        
            * Purpose:-Deltete Temp Services,Save temp Services,get temp Services */
        #region---------Save temp Services------------
        public string  saveTempService(int loginid, int serviceid, string price,int clientid)
        {
            SqlConnection con = new SqlConnection(constr);

            try
            {
                SqlCommand cmd = new SqlCommand("saveTempService", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("loginid", loginid);
                cmd.Parameters.AddWithValue("serviceid", serviceid);
                cmd.Parameters.AddWithValue("price", price);
                cmd.Parameters.AddWithValue("clientid", clientid );
                con.Open();
                msg = cmd.ExecuteNonQuery().ToString();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
            return msg;
        }
        #endregion

        #region----DelTempServices-------
        public void delTempService(int loginid)
        {
            SqlConnection con = new SqlConnection(constr);
            try
            {
                SqlCommand cmd = new SqlCommand("delTempService", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("loginid", loginid);            
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
               
        }
        #endregion

        #region-----getTempServices----------
        public DataSet  getTempService(int loginid,int clientid)
        {
            SqlConnection con = new SqlConnection(constr);
            DataSet ds = new DataSet();
            try
            {
                   
                SqlCommand cmd = new SqlCommand("getTempService", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                cmd.Parameters.AddWithValue("loginid",loginid );
                cmd.Parameters.AddWithValue("clientid", clientid);
                da.Fill(ds);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
                    
            }
            return ds;
        }
        #endregion
    }
}

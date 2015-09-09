using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BusinessLayer;


namespace Juris
{
    public partial class _Default : System.Web.UI.Page
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            BLLogin blLogin = new BLLogin();
            BLAddSearchUser blObjAddAdmin = new BLAddSearchUser();


            int dateCount = DateCount();
            DataSet ds_chekTrail = null;
            if (dateCount != 0)
            {
                ds_chekTrail = CheckTrail();
            }
            else
            {
                ds_chekTrail = CheckTrail();
            }

            if (ds_chekTrail.Tables[0].Rows[0]["Status"].ToString() == "Valid")
            {
                DataSet ds = blObjAddAdmin.getAdminCount();

                if (ds.Tables[0].Rows[0]["Count"].ToString() == "0")
                {
                    Response.Redirect("~/AdminRegistration.aspx");
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
                Session["LoginId"] = null;
            }
            else
            {
                lblExpire.Text = ds_chekTrail.Tables[0].Rows[0]["Status"].ToString();
            }

            
            //if (drGetCnt.HasRows)
            //{
            //    drGetCnt.Read();
            //    int cnt = int.Parse(drGetCnt["Count"].ToString());
            //    drGetCnt.Close();
            //    if (cnt == 0)
            //    {
            //        Response.Redirect("~/AdminRegistration.aspx");
            //    }
            //}
        }

        public DataSet CheckTrail()
        {
            SqlConnection con = new SqlConnection(connstr);
            DataSet ds = null;
            SqlCommand cmd = new SqlCommand("getsysED", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        public int DateCount()
        {
            SqlConnection con = new SqlConnection(connstr);

            DataSet ds = null;
            SqlCommand cmd = new SqlCommand("getDateCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            int cnt ;
            if (ds.Tables[0].Rows[0]["Cnt"].ToString() == "0")
            {
                cnt = 0;
                SqlConnection conn = new SqlConnection(connstr);
                cmd = new SqlCommand("savesysD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sysSD", DateTime.Now);
                cmd.Parameters.AddWithValue("@sysEDCount", 5);
                conn.Open();
                string result = cmd.ExecuteNonQuery().ToString();
                conn.Close();
            }
            else
            {
                cnt = Convert.ToInt32(ds.Tables[0].Rows[0]["Cnt"].ToString());
            }
            return cnt;
        }
    }
}

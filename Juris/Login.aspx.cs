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
    public partial class Login : System.Web.UI.Page
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        BLLogin blLogin = new BLLogin();
        BLAddSearchUser blObjAddAdmin = new BLAddSearchUser();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                    Session["LoginId"] = null;
                }
                else
                {
                    lblExpire.Text = ds_chekTrail.Tables[0].Rows[0]["Status"].ToString();
                    btnLogin.Enabled = false;
                }                
            }
            
        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string username = txtUnm.Text;
            string password = txtPass.Text;

            SqlDataReader drLogin = blLogin.checklogin(username, password);
            if (drLogin.HasRows == true)
            {
                drLogin.Read();
                string type = drLogin["Type"].ToString();
                int LoginId = int.Parse(drLogin["UserId"].ToString());
                Session["LoginId"] = LoginId;
                Session.Timeout = 20;
                if (type == "admin")
                    Response.Redirect("~/adminHome.aspx");
                else
                    if (type == "employee")
                        Response.Redirect("~/employeeHome.aspx");
                drLogin.Close();
            }
            else
            {
                lblInUnmPass.Visible = true;
            }
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
            int cnt;
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
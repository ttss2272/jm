using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace Juris
{
    public partial class AdminRegistration : System.Web.UI.Page
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        BLAddSearchUser blObjAddAdmin = new BLAddSearchUser();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddAdmin_Click(object sender, EventArgs e)
        {
            string strMailid = txtEmail.Text;         
            string Unm = txtUNm.Text;
            string Pass = txtPass.Text;
            string type = "admin";
            int isdeleted = 0;
            string result = blObjAddAdmin.addSearchUser(Unm, Pass, type,strMailid,isdeleted);
           if (result == "1")
           {
               lblMsg.Visible = true;
               lblMsg.Text = "Admin Registered Successfully";
               Response.Redirect("~/Login.aspx");
           }
           else
           {
               lblMsg.Visible = true;
               lblMsg.Text = result;
           }
           txtUNm.Text = "";
           txtPass.Text = "";
        }
    }
}
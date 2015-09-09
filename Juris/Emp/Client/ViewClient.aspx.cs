using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace Juris.Emp.Client
{
    public partial class ViewClient : System.Web.UI.Page
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((HttpContext.Current.Session["LoginId"]) == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                if (!Page.IsPostBack)
                {
                    int app;
                    if (drpdwnlstApp.SelectedItem.Text == "Approve")
                        app = 1;
                    else app = 0;
                    string ClNm = drpdwnlstApp.SelectedItem.Text;

                    BLViewClient blVwCl = new BLViewClient();
                    SqlDataReader dr = blVwCl.GetClientAtLoad1();
                    if (dr.HasRows)
                    {
                        GdVwViewClient.DataSource = dr;
                        GdVwViewClient.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not available";
                        GdVwViewClient.DataSource = null;
                        GdVwViewClient.DataBind();
                    }
                    dr.Close();
                }
                else
                {
                    lblErrorMsg.Text = "";
                    lblCatchError.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnAddNewClient_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Emp/Client/AddClient.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void drpdwnlstApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
                int app = Convert.ToInt32(drpdwnlstApp.SelectedItem.Value);
                string ClNm;
                //Yogita
                #region
                //Edited Stored procedure to serch by client name and approve
                BLViewClient blVwCl = new BLViewClient();
                if (txtSearchCl.Text == "")
                {
                    ClNm = "NA";
                }
                else
                {
                    ClNm = txtSearchCl.Text;
                }
                SqlDataReader dr = blVwCl.GetClientByNameType1(ClNm, app);
                if (dr.HasRows)
                {
                    GdVwViewClient.DataSource = dr;
                    GdVwViewClient.DataBind();

                }
                else
                {
                    lblErrorMsg.Text = "Records not available";
                    GdVwViewClient.DataSource = null;
                    GdVwViewClient.DataBind();
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void GdVwViewClient_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    int ClientId = int.Parse(GdVwViewClient.Rows[rowIndex].Cells[1].Text);
                    Response.Redirect("~/Emp/Client/AddClient.aspx?ClientId=" + ClientId);
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/employeeHome.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
    }
}
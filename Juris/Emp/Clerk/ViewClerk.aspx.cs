using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer;

namespace Juris.Emp.Clerk
{
    public partial class ViewClerk : System.Web.UI.Page
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        /* Name-:
         * Purpose-:Load view Clerk page,and fill dropdownlist at page load
         * 
         */
        #region-----------------Page_Load(object sender, EventArgs e)--------
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
                    BLClerk blsr = new BLClerk();
                    SqlDataReader dr = blsr.getClerkName1();
                    ddlClerk.Items.Clear();
                    ddlClerk.Items.Insert(0, new ListItem("--Select--", "-1"));
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                            ddlClerk.Items.Add(dr.GetString(1));
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not available";
                        fillgrid();
                    }
                    fillgrid();
                    dr.Close();
                }
                else
                {
                    lblCatchError.Text = "";
                    lblErrorMsg.Text = "";
                }
                
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }

        }
        #endregion

        /* Name-:Snehal
         * Purpose-:Fill grid at page load
         * Updated Date-:
         */
        #region ---------fillgrid()------------
        public void fillgrid()
        {
            try
            {
                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand();
                DataSet ds = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getClerkDetails";
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                GdVwViewClerk.DataSource = ds.Tables[0];
                GdVwViewClerk.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        /* Name-:Snehal
         * Purpose-:Redirect to add clerk page
         * Updated Date-:
         */
        #region ---------protected void btnAddNewClerk_Click(object sender, EventArgs e)------------
        protected void btnAddNewClerk_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Emp/Clerk/AddEditClerk.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }

        }
        #endregion

        /* Name-:Snehal
         * Purpose-:Fill grid when name and approve dropdown list items are selected
         * Updated Date-:
         */
        #region ---------fillgrid() at ddlApprovVwClerk_SelectedIndexChanged------------
        protected void ddlApprovVwClerk_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int intApprove = -1;
                if (ddlApprovVwClerk.SelectedItem.Text != "--Select--")
                {
                    intApprove = int.Parse(ddlApprovVwClerk.SelectedItem.Value);
                }
                else
                {
                    GdVwViewClerk.DataSource = null;
                    GdVwViewClerk.DataBind();
                }
                string strClerkName = ddlClerk.SelectedItem.Text;

                if (ddlClerk.SelectedItem.Text == "--Select--" && ddlApprovVwClerk.SelectedItem.Text != "--Select--")
                {
                    BLClerk blpr = new BLClerk();
                    SqlDataReader dr = blpr.gridFillApproveClerk1(intApprove);
                    DataTable dt = new DataTable();
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                        GdVwViewClerk.DataSource = dt;
                        GdVwViewClerk.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not found";
                        GdVwViewClerk.DataSource = null;
                        GdVwViewClerk.DataBind();
                    }
                    dr.Close();
                }
                if (ddlClerk.SelectedItem.Text != "--Select--" && ddlApprovVwClerk.SelectedItem.Text != "--Select--")
                {
                    BLClerk blpr = new BLClerk();
                    SqlDataReader dr = blpr.gridFillApproveClerkName1(strClerkName, intApprove);
                    DataTable dt = new DataTable();
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                        GdVwViewClerk.DataSource = dt;
                        GdVwViewClerk.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not found";
                        GdVwViewClerk.DataSource = null;
                        GdVwViewClerk.DataBind();
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        /* Name-:Snehal
         * Purpose-:Fill grid when clerk name dropdown list items is selected
         * Updated Date-:
         */
        #region ---------fillgrid() at ddlClerk_SelectedIndexChanged------------
        protected void ddlClerk_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getClerkDetails();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        /* Name-:Snehal
         * Purpose-:Redirect to Add clerk page in edit mode on edit button in gridview click 
         * Updated Date-:
         */
        #region ---------GdVwViewClerk_RowCommand for edit clerk------------
        //protected void GdVwViewClerk_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName == "EditClerk")
        //        {
        //            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        //            int rowIndex = gvr.RowIndex;
        //            int ClerkId = Convert.ToInt32(GdVwViewClerk.Rows[rowIndex].Cells[1].Text);
        //            //Session["ClerkId"] = ClerkId.ToString();
        //            Response.Redirect("~/Emp/Clerk/AddEditClerk.aspx?ClerkId=" + ClerkId);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}
        #endregion

        /* Name-:Snehal
         * Purpose-:Redirect to Admin home page 
         * Updated Date-:
         */
        #region--------protected void btnCancl_Click(object sender, EventArgs e)----------
        protected void btnCancl_Click(object sender, EventArgs e)
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
        #endregion

        /* Name-:Snehal
         * Purpose-:Fill grid when clerk name is selected
         * Updated Date-:26/03/2015
         */
        #region-------protected void getClerkDetails()--------
        protected void getClerkDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand();
                SqlParameter param;
                DataSet ds = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getClerk";
                param = new SqlParameter("@ClerkName", ddlClerk.SelectedItem.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GdVwViewClerk.DataSource = ds.Tables[0];
                    GdVwViewClerk.DataBind();
                }
                else
                {
                    lblErrorMsg.Text = "Records not available";
                    GdVwViewClerk.DataSource = null;
                    GdVwViewClerk.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        protected void GdVwViewClerk_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditClerks")
                {
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    int ClerkId = Convert.ToInt32(GdVwViewClerk.Rows[rowIndex].Cells[1].Text);
                    //Session["ClerkId"] = ClerkId.ToString();
                    Response.Redirect("~/Emp/Clerk/AddEditClerk.aspx?ClerkId=" + ClerkId);
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
              
    }
}
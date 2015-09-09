using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer;
using System.Data;


namespace Juris.Admin.Services
{
    public partial class ViewService : System.Web.UI.Page
    {
        #region------Connection String-------------- 
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter();
        #endregion

        #region-------------Page Load----------
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
                    BLServices blsr = new BLServices();
                    SqlDataReader dr = blsr.getServiceName1();
                    ddlSearchByServiceNameSer.Items.Clear();
                    ddlSearchByServiceNameSer.Items.Add("--Select--");
                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                            ddlSearchByServiceNameSer.Items.Add(dr.GetString(0));
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not available";
                        fillgrid();
                    }
                    dr.Close();
                    fillgrid();
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

        #region----------Fillgrid-----------
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
                cmd.CommandText = "getServiceGridFill";
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GdVwViewService.DataSource = ds.Tables[0];
                    GdVwViewService.DataBind();
                }
                else
                {
                    lblErrorMsg.Text = "Records not available";
                    GdVwViewService.DataSource = null;
                    GdVwViewService.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region----------btnAddNewService_Click--------------
        protected void btnAddNewService_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Admin/Services/AddEditService.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion
        
        #region---------------ddlSearchByServiceNameSer_SelectedIndexChanged--------------------
        protected void ddlSearchByServiceNameSer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connstr);
                SqlDataAdapter adapter;
                SqlCommand command = new SqlCommand();
                SqlParameter param;
                DataSet ds = new DataSet();
                con.Open();
                command.Connection = con;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "getService";
                param = new SqlParameter("@ServiceName", ddlSearchByServiceNameSer.SelectedItem.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GdVwViewService.DataSource = ds.Tables[0];
                    GdVwViewService.DataBind();
                }
                else
                {
                    lblErrorMsg.Text = "Records not available";
                    GdVwViewService.DataSource = null;
                    GdVwViewService.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        /*Name:- swapnil joshi
        purpose:- code written on protected void ddlApproveSer_SelectedIndexChanged for "--Select--". user select this("--Select--") grid is set null 
        */
        #region------------------ddlApproveSer_SelectedIndexChanged------------------------
        protected void ddlApproveSer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strServiceName = ddlSearchByServiceNameSer.SelectedItem.Text;
                int intApprove = int.Parse(ddlApproveSer.SelectedItem.Value);

                if (ddlSearchByServiceNameSer.SelectedItem.Text == "--Select--" && ddlApproveSer.SelectedItem.Text != "--Select--")
                {
                    BLServices blpr = new BLServices();
                    SqlDataReader dr = blpr.gridFillApproveService1(intApprove);
                    DataTable dt = new DataTable();
                    if (dr.HasRows == true)
                    {
                        dt.Load(dr);
                        GdVwViewService.DataSource = dt;
                        GdVwViewService.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not Available";
                        GdVwViewService.DataSource = dt;
                        GdVwViewService.DataBind();
                    }
                    dr.Close();
                }
                if (ddlSearchByServiceNameSer.SelectedItem.Text != "--Select--" && ddlApproveSer.SelectedItem.Text != "--Select--")
                {
                    BLServices blpr = new BLServices();
                    SqlDataReader dr = blpr.gridFillApproveServiceName1(strServiceName, intApprove);
                    DataTable dt = new DataTable();
                    if (dr.HasRows == true)
                    {
                        dt.Load(dr);
                        GdVwViewService.DataSource = dt;
                        GdVwViewService.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not Available";
                        GdVwViewService.DataSource = dt;
                        GdVwViewService.DataBind();
                    }
                    dr.Close();
                }
                if (ddlSearchByServiceNameSer.SelectedItem.Text == "--Select--" && ddlApproveSer.SelectedItem.Text == "--Select--")
                {
                    lblErrorMsg.Text = "Records not Available";
                    GdVwViewService.DataSource = null;
                    GdVwViewService.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion
        
        #region----------btnClear_Click-------------------------
        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region-------------------GdVwViewService_RowCommand------------------------------
        protected void GdVwViewService_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    int ServiceId = Convert.ToInt32(GdVwViewService.Rows[rowIndex].Cells[1].Text);
                    Session["ServiceId"] = ServiceId.ToString();
                    // int index = Convert.ToInt32(e.CommandArgument.ToString());
                    //    GridViewRow row = GdVwSelPrjct .Rows[index];
                    Response.Redirect("~/Admin/Services/AddEditService.aspx?ServiceId=" + ServiceId);
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region---------btnCncl_Click------------------------------------------

        protected void btnCncl_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/adminHome.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion
    }
}
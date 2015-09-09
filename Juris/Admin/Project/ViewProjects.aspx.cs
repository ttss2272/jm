using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer;
using System.Data;

namespace Juris.Admin.Project
{
    public partial class ViewProjects : System.Web.UI.Page
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter();

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
                    BLProject blvc = new BLProject();
                    GetClientData(blvc);

                    string strClientName = "";
                    GetCaseData(blvc, strClientName);
                    //fillgrid();
                    this.GetCustomersPageWise(1);
                }
                else
                {
                    lblmsg.Text = "";
                    lblError.Text = "";
                    lblCatchError.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        private void GetCaseData(BLProject blvc, string strClientName)
        {
            SqlDataReader dr1 = blvc.getCaseName1(strClientName);
            ddlCasNmPrj.Items.Add("--Select--");
            if (dr1.HasRows == true)
            {
                while (dr1.Read())
                    ddlCasNmPrj.Items.Add(dr1.GetString(0));
            }
            else
            {
                lblError.Text = "Records not available";
            }
        }

        private void GetClientData(BLProject blvc)
        {
            SqlDataReader dr = blvc.getClientName1();
            ddlCliNmPrj.Items.Add("--Select--");
            if (dr.HasRows == true)
            {
                while (dr.Read())
                    ddlCliNmPrj.Items.Add(dr.GetString(0));
            }
            else
            {
                lblError.Text = "Records not available";
            }
        }

        private void GetCustomersPageWise(int pageIndex)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand("GetProjectsPageWise", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@PageSize", int.Parse(System.Configuration.ConfigurationManager.AppSettings["PageSize"]));
                    if (ddlCliNmPrj.SelectedItem.Text == "--Select--")
                    {
                        cmd.Parameters.AddWithValue("@ClientName", null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ClientName", ddlCliNmPrj.SelectedItem.Text);
                    }

                    if (ddlCasNmPrj.SelectedItem.Text == "--Select--")
                    {
                        cmd.Parameters.AddWithValue("@CaseName", null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CaseName", ddlCasNmPrj.SelectedItem.Text);
                    }

                    if (ddlStatus.SelectedItem.Text == "--Select--")
                    {
                        cmd.Parameters.AddWithValue("@Status", null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedItem.Text);
                    }

                    if (ddlApprove.SelectedItem.Text == "--Select--")
                    {
                        cmd.Parameters.AddWithValue("@Approve", 2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Approve", ddlApprove.SelectedValue);
                    }

                    if (chkBxShwDelProjects.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@IsDeleted", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                    }
                    //cmd.Parameters.AddWithValue("@ClientName", null);
                    //cmd.Parameters.AddWithValue("@CaseName", null);
                    //cmd.Parameters.AddWithValue("@Status", null);
                    //cmd.Parameters.AddWithValue("@Approve", 1);
                    //cmd.Parameters.AddWithValue("@IsDeleted", 0);
                    cmd.Parameters.AddWithValue("@RecordCount", 4);
                    cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                    con.Open();
                    //da = new SqlDataAdapter(cmd);
                    //da.Fill(ds);
                    //GdVwSrchProjects.DataSource = ds;
                    //GdVwSrchProjects.DataBind();
                    IDataReader idr = cmd.ExecuteReader();
                    GdVwSrchProjects.DataSource = idr;
                    GdVwSrchProjects.DataBind();
                    idr.Close();
                    con.Close();
                    int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                    this.PopulatePager(recordCount, pageIndex);
                }
            }
        }

        protected void PageSize_Changed(object sender, EventArgs e)
        {
            this.GetCustomersPageWise(1);
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(ddlTotalPages.SelectedValue);
            this.GetCustomersPageWise(pageIndex);
            
            ddlTotalPages.SelectedIndex = pageIndex - 1;
        }

        private void PopulatePager(int recordCount, int currentPage)
        {
            double dblPageCount = (double)((decimal)recordCount / decimal.Parse(System.Configuration.ConfigurationManager.AppSettings["PageSize"]));
            int pageCount = (int)Math.Ceiling(dblPageCount);

            DataTable dtName = new DataTable();
            //Add Columns to Table
            dtName.Columns.Add(new DataColumn("DisplayPageNo"));
            dtName.Columns.Add(new DataColumn("ValuePageNo"));

            List<ListItem> pages = new List<ListItem>();
            if (pageCount > 0)
            {
                //pages.Add(new ListItem("First", "1", currentPage > 1));
                for (int i = 1; i <= pageCount; i++)
                {
                    dtName.Rows.Add(i.ToString(), i.ToString());
                    //pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
                //pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
            }
            //rptPager.DataSource = pages;
            //rptPager.DataBind();
            //At Last Bind datatable to dropdown.
            ddlTotalPages.DataSource = dtName;
            ddlTotalPages.DataTextField = dtName.Columns["DisplayPageNo"].ToString();
            ddlTotalPages.DataValueField = dtName.Columns["ValuePageNo"].ToString();
            ddlTotalPages.DataBind();
        }
        
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
                cmd.CommandText = "getProject";
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GdVwSrchProjects.DataSource = ds.Tables[0];
                    GdVwSrchProjects.DataBind();
                }
                else
                {
                    lblError.Text = "Records not available";
                    GdVwSrchProjects.DataSource = null;
                    GdVwSrchProjects.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void ddlCliNmPrj_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                GetCustomersPageWise(1);
            //    SqlConnection con = new SqlConnection(connstr);
            //    SqlCommand cmd = new SqlCommand();
            //    SqlParameter param;
            //    DataSet ds = new DataSet();
            //    con.Open();
            //    cmd.Connection = con;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.CommandText = "getProjectClientName";
            //    param = new SqlParameter("@ClientName", ddlCliNmPrj.SelectedItem.Text);
            //    param.Direction = ParameterDirection.Input;
            //    param.DbType = DbType.String;
            //    cmd.Parameters.Add(param);
            //    da = new SqlDataAdapter(cmd);
            //    da.Fill(ds);
            //    if (ds.Tables[0].Rows.Count != 0)
            //    {
            //        GdVwSrchProjects.DataSource = ds.Tables[0];
            //        GdVwSrchProjects.DataBind();
            //    }
            //    else
            //    {
            //        lblmsg.Text = "Records not available";
            //        GdVwSrchProjects.DataSource = null;
            //        GdVwSrchProjects.DataBind();
            //    }
            //    con.Close();

            //    BLProject blsr = new BLProject();
            //    string strClientName = ddlCliNmPrj.SelectedItem.Text;
            //    SqlDataReader dr = blsr.getCaseName1(strClientName);
            //    ddlCasNmPrj.Items.Clear();
            //    ddlCasNmPrj.Items.Insert(0, new ListItem("--Select--", "-1"));
            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //            ddlCasNmPrj.Items.Add(dr.GetString(0));
            //        dr.Close();
            //    }
            //    else
            //    {
            //        lblError.Text = "No Added Projects available so there is no case name available";
            //    }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetCustomersPageWise(1);
                //string strStatus = ddlStatus.SelectedItem.Text;
                //string strClientName = ddlCliNmPrj.SelectedItem.Text;
                //string strCaseName = ddlCasNmPrj.SelectedItem.Text;
                //if (ddlCliNmPrj.SelectedItem.Text == "--Select--")
                //{
                //    BLProject blpr = new BLProject();
                //    SqlDataReader dr = blpr.gridFillStatus1(strStatus);
                //    DataTable dt = new DataTable();
                //    if (dr.HasRows)
                //    {
                //        dt.Load(dr);
                //        GdVwSrchProjects.DataSource = dt;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    else
                //    {
                //        lblmsg.Text = "Records not found";
                //        GdVwSrchProjects.DataSource = null;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    dr.Close();
                //}
                //else if (ddlCliNmPrj.SelectedItem.Text != "--Select--" && ddlCasNmPrj.SelectedItem.Text == "--Select--")
                //{
                //    BLProject blpr = new BLProject();
                //    SqlDataReader dr = blpr.gridFillClientStatus1(strClientName, strStatus);
                //    DataTable dt = new DataTable();
                //    if (dr.HasRows)
                //    {
                //        dt.Load(dr);
                //        GdVwSrchProjects.DataSource = dt;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    else
                //    {
                //        lblmsg.Text = "Records not found";
                //        GdVwSrchProjects.DataSource = null;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    dr.Close();
                //}
                //else if (ddlCliNmPrj.SelectedItem.Text != "--Select--" && ddlCasNmPrj.SelectedItem.Text != "--Select--")
                //{
                //    BLProject blpr = new BLProject();
                //    SqlDataReader dr = blpr.gridFillClientCaseStatus1(strClientName, strCaseName, strStatus);
                //    DataTable dt = new DataTable();
                //    if (dr.HasRows)
                //    {
                //        dt.Load(dr);
                //        GdVwSrchProjects.DataSource = dt;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    else
                //    {
                //        lblmsg.Text = "Records not found";
                //        GdVwSrchProjects.DataSource = null;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    dr.Close();
                //}
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void ddlApprove_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetCustomersPageWise(1);
                //string strClientName = ddlCliNmPrj.SelectedItem.Text;
                //int intApprove = int.Parse(ddlApprove.SelectedItem.Value);
                //string strCaseName = ddlCasNmPrj.SelectedItem.Text;
                //string strStatus = ddlStatus.SelectedItem.Text;
                //BLProject blpr = new BLProject();
                //DataTable dt = new DataTable();
                //if (ddlCliNmPrj.SelectedItem.Text == "--Select--" && ddlCasNmPrj.SelectedItem.Text == "--Select--" && ddlStatus.SelectedItem.Text == "--Select--")
                //{
                //    SqlDataReader dr = blpr.gridFillApprove1(intApprove);
                //    if (dr.HasRows)
                //    {
                //        dt.Load(dr);
                //        GdVwSrchProjects.DataSource = dt;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    else
                //    {
                //        lblmsg.Text = "Records not found";
                //        GdVwSrchProjects.DataSource = null;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    dr.Close();
                //}
                //if (ddlCliNmPrj.SelectedItem.Text != "--Select--" && ddlCasNmPrj.SelectedItem.Text == "--Select--" && ddlStatus.SelectedItem.Text == "--Select--")
                //{
                //    SqlDataReader dr = blpr.gridFillClientApprove1(strClientName, intApprove);
                //    if (dr.HasRows)
                //    {
                //        dt.Load(dr);
                //        GdVwSrchProjects.DataSource = dt;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    else
                //    {
                //        lblmsg.Text = "Records not found";
                //        GdVwSrchProjects.DataSource = null;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    dr.Close();
                //}
                //if (ddlCliNmPrj.SelectedItem.Text != "--Select--" && ddlCasNmPrj.SelectedItem.Text != "--Select--" && ddlStatus.SelectedItem.Text == "--Select--")
                //{
                //    SqlDataReader dr = blpr.gridFillClientCaseApprove1(strClientName, strCaseName, intApprove);
                //    if (dr.HasRows)
                //    {
                //        dt.Load(dr);
                //        GdVwSrchProjects.DataSource = dt;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    else
                //    {
                //        lblmsg.Text = "Records not found";
                //        GdVwSrchProjects.DataSource = null;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    dr.Close();
                //}
                //if (ddlCliNmPrj.SelectedItem.Text != "--Select--" && ddlCasNmPrj.SelectedItem.Text != "--Select--" && ddlStatus.SelectedItem.Text != "--Select--")
                //{
                //    SqlDataReader dr = blpr.gridFillClientCaseStatusApprove1(strClientName, strCaseName, strStatus, intApprove);
                //    if (dr.HasRows)
                //    {
                //        dt.Load(dr);
                //        GdVwSrchProjects.DataSource = dt;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    else
                //    {
                //        lblmsg.Text = "Records not found";
                //        GdVwSrchProjects.DataSource = null;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    dr.Close();
                //}
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void ddlCasNmPrj_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetCustomersPageWise(1);
                //SqlConnection con = new SqlConnection(connstr);
                //SqlCommand cmd = new SqlCommand();
                //SqlParameter param, param1;
                //DataSet ds = new DataSet();
                //con.Open();
                //cmd.Connection = con;
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "getProjectCliCasName";
                //param = new SqlParameter("@ClientName", ddlCliNmPrj.SelectedItem.Text);
                //param1 = new SqlParameter("@CaseName", ddlCasNmPrj.SelectedItem.Text);
                //param.Direction = ParameterDirection.Input;
                //param1.Direction = ParameterDirection.Input;
                //param.DbType = DbType.String;
                //param1.DbType = DbType.String;
                //cmd.Parameters.Add(param);
                //cmd.Parameters.Add(param1);
                //da = new SqlDataAdapter(cmd);
                //da.Fill(ds);
                //if (ds.Tables[0].Rows.Count != 0)
                //{
                //    GdVwSrchProjects.DataSource = ds.Tables[0];
                //    GdVwSrchProjects.DataBind();
                //}
                //else
                //{
                //    lblmsg.Text = "Records not available";
                //    GdVwSrchProjects.DataSource = null;
                //    GdVwSrchProjects.DataBind();
                //}
                //con.Close();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void chkBxShwDelProjects_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetCustomersPageWise(1);
                //int intApprove = 0;
                //string strClientName = ddlCliNmPrj.SelectedItem.Text;
                //string strCaseName = ddlCasNmPrj.SelectedItem.Text;
                //string strStatus = ddlStatus.SelectedItem.Text;
                //if (ddlApprove.SelectedItem.Text != "--Select--")
                //{
                //    intApprove = int.Parse(ddlApprove.SelectedItem.Value);
                //}
                //int intIsDeleted;

                //if (chkBxShwDelProjects.Checked == true)
                //    intIsDeleted = 1;
                //else
                //    intIsDeleted = 0;
                //if (ddlCliNmPrj.SelectedItem.Text == "--Select--" && ddlCasNmPrj.SelectedItem.Text == "--Select--" && ddlStatus.SelectedItem.Text == "--Select--" && ddlApprove.SelectedItem.Text == "--Select--")
                //{
                //    BLProject blpr = new BLProject();
                //    SqlDataReader dr = blpr.isDelProjectChecked1();
                //    DataTable dt = new DataTable();
                //    if (dr.HasRows)
                //    {
                //        dt.Load(dr);
                //        GdVwSrchProjects.DataSource = dt;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    else
                //    {
                //        lblmsg.Text = "Records not available";
                //        GdVwSrchProjects.DataSource = null;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    dr.Close();
                //}
                //if (ddlCliNmPrj.SelectedItem.Text != "--Select--" && ddlCasNmPrj.SelectedItem.Text == "--Select--" && ddlStatus.SelectedItem.Text == "--Select--" && ddlApprove.SelectedItem.Text == "--Select--" && (chkBxShwDelProjects.Checked == true || chkBxShwDelProjects.Checked == false))
                //{
                //    BLProject blpr = new BLProject();
                //    SqlDataReader dr = blpr.isDelProjectCliChecked1(strClientName, intIsDeleted);
                //    DataTable dt = new DataTable();
                //    if (dr.HasRows)
                //    {
                //        dt.Load(dr);
                //        GdVwSrchProjects.DataSource = dt;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    else
                //    {
                //        lblmsg.Text = "Records not available";
                //        GdVwSrchProjects.DataSource = null;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    dr.Close();
                //}
                //if (ddlCliNmPrj.SelectedItem.Text != "--Select--" && ddlCasNmPrj.SelectedItem.Text != "--Select--" && ddlStatus.SelectedItem.Text == "--Select--" && ddlApprove.SelectedItem.Text == "--Select--" && (chkBxShwDelProjects.Checked == true || chkBxShwDelProjects.Checked == false))
                //{
                //    BLProject blpr = new BLProject();
                //    SqlDataReader dr = blpr.isDelProjectCliCasChecked1(strClientName, strCaseName, intIsDeleted);
                //    DataTable dt = new DataTable();
                //    if (dr.HasRows)
                //    {
                //        dt.Load(dr);
                //        GdVwSrchProjects.DataSource = dt;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    else
                //    {
                //        lblmsg.Text = "Records not available";
                //        GdVwSrchProjects.DataSource = null;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    dr.Close();
                //}
                //if (ddlCliNmPrj.SelectedItem.Text != "--Select--" && ddlCasNmPrj.SelectedItem.Text != "--Select--" && ddlStatus.SelectedItem.Text != "--Select--" && ddlApprove.SelectedItem.Text == "--Select--" && (chkBxShwDelProjects.Checked == true || chkBxShwDelProjects.Checked == false))
                //{
                //    BLProject blpr = new BLProject();
                //    SqlDataReader dr = blpr.isDelProjectCliStaCasChecked1(strClientName, strCaseName, strStatus, intIsDeleted);
                //    DataTable dt = new DataTable();
                //    if (dr.HasRows)
                //    {
                //        dt.Load(dr);
                //        GdVwSrchProjects.DataSource = dt;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    else
                //    {
                //        lblmsg.Text = "Records not available";
                //        GdVwSrchProjects.DataSource = null;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    dr.Close();
                //}
                //if (ddlCliNmPrj.SelectedItem.Text != "--Select--" && ddlCasNmPrj.SelectedItem.Text != "--Select--" && ddlStatus.SelectedItem.Text != "--Select--" && ddlApprove.SelectedItem.Text != "--Select--" && (chkBxShwDelProjects.Checked == true || chkBxShwDelProjects.Checked == false))
                //{
                //    BLProject blpr = new BLProject();
                //    SqlDataReader dr = blpr.isDelProjectCliStaCasAppChecked1(strClientName, strCaseName, strStatus, intApprove, intIsDeleted);
                //    DataTable dt = new DataTable();
                //    if (dr.HasRows)
                //    {
                //        dt.Load(dr);
                //        GdVwSrchProjects.DataSource = dt;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    else
                //    {
                //        lblmsg.Text = "Records not available";
                //        GdVwSrchProjects.DataSource = null;
                //        GdVwSrchProjects.DataBind();
                //    }
                //    dr.Close();
                //}
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void CheckSelPrj()
        {
            try
            {
                DataTable dtSelProject = new DataTable();
                dtSelProject.Columns.AddRange(new DataColumn[1] { new DataColumn("ProjectId") });
                dtSelProject.Columns.AddRange(new DataColumn[1] { new DataColumn("Amount") });

                foreach (GridViewRow gvrow in GdVwSrchProjects.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        //finding the checkbox in the gridview
                        CheckBox ChkBxSelProject = (gvrow.Cells[0].FindControl("ChkBxSelProject") as CheckBox);
                        // checking which checkbox are selected
                        if (ChkBxSelProject.Checked)
                        {
                            int ProjectID = int.Parse(gvrow.Cells[3].Text);
                            Session["ProjectID"] = ProjectID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void ChkBxSelProject_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Session["ProjectID"] != null)
                {
                    //lblmsg.Text = "Select atleast one project";
                }
                else
                {
                    CheckSelPrj();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnDocBoysHistory_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dtSelProject = new System.Data.DataTable();
                dtSelProject.Columns.AddRange(new DataColumn[1] { new DataColumn("Projectid") });
                foreach (GridViewRow gvrow in GdVwSrchProjects.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        //finding the checkbox in the gridview
                        System.Web.UI.WebControls.CheckBox ChkBxSelProject = (gvrow.Cells[0].FindControl("ChkBxSelProject") as System.Web.UI.WebControls.CheckBox);
                        // checking which checkbox are selected
                        if (ChkBxSelProject.Checked)
                        {
                            int Projectid = int.Parse(gvrow.Cells[2].Text);
                            dtSelProject.Rows.Add(Projectid);
                        }
                    }
                }
                if (dtSelProject.Rows.Count > 1)
                {
                    lblmsg.Text = "Select only one Project";
                }
                else
                {
                    if (dtSelProject.Rows.Count == 0)
                    {
                        lblmsg.Text = "Select atleast one Project";
                    }
                    else
                    {
                        Response.Redirect("~/Admin/Project/AddEditDocBoyHistory.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void GdVwSrchProjects_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    int ProjectId = Convert.ToInt32(GdVwSrchProjects.Rows[rowIndex].Cells[3].Text);
                    Session["ProjectId"] = ProjectId.ToString();
                    Response.Redirect("~/Admin/Project/AddEditWork.aspx?ProjectId=" + ProjectId);
                }

                if (e.CommandName == "Delete")
                {
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    int ProjectId = Convert.ToInt32(GdVwSrchProjects.Rows[rowIndex].Cells[3].Text);
                    BLProject objBLProject = new BLProject();
                    objBLProject.deleteProject(ProjectId);
                    lblmsg.Text = "Project(s) Deleted.";
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnAddNwProject_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Admin/Project/AddEditWork.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnCancl_Click(object sender, EventArgs e)
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

        protected void btnDeleteSelectedProject_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gvrow in GdVwSrchProjects.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        //finding the checkbox in the gridview
                        CheckBox ChkBxSelProject = (gvrow.Cells[0].FindControl("ChkBxSelProject") as CheckBox);
                        // checking which checkbox are selected
                        if (ChkBxSelProject.Checked)
                        {
                            int ProjectID = int.Parse(gvrow.Cells[3].Text);
                            BLProject objBLProject = new BLProject();
                            objBLProject.deleteProject(ProjectID);
                            lblmsg.Text = "Project(s) Deleted.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        //protected void GdVwSrchProjects_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GdVwSrchProjects.PageIndex = e.NewPageIndex;
        //    //fillgrid();
        //    //GdVwSrchProjects.DataBind();
        //}

    }
}

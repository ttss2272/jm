using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Juris.Admin.Project
{
    public partial class SelectProject : System.Web.UI.Page
    {
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((HttpContext.Current.Session["LoginId"]) == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                if (IsPostBack)
                {
                    lblCatchError.Text = "";
                    lblErrorMsg.Text = "";
                    CalendarExtender1.SelectedDate = DateTime.ParseExact(txtFromDate.Text, CalendarExtender1.Format, null);
                    CalendarExtender2.SelectedDate = DateTime.ParseExact(txtToDate.Text, CalendarExtender2.Format, null);
                }
                else
                {
                    txtFromDate.Text = System.DateTime.Now.ToShortDateString();
                    txtToDate.Text = System.DateTime.Now.ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void chkSelAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSelAll.Checked == false)
                    chkSelAll.Text = "Select All";
                else chkSelAll.Text = "Clear All";
                if (chkSelAll.Text == "Select All")
                {
                    foreach (GridViewRow gvrow in GdVwSelPrjct.Rows)
                    {

                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkSelect = (gvrow.Cells[0].FindControl("chkSelect") as CheckBox);
                            chkSelect.Checked = false;
                        }
                    }
                }
                else
                {
                    foreach (GridViewRow gvrow in GdVwSelPrjct.Rows)
                    {

                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            // int i;
                            //Finding the Checkbox in the Gridview
                            CheckBox chkSelect = (gvrow.Cells[0].FindControl("chkSelect") as CheckBox);
                            chkSelect.Checked = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindPrimaryGrid();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        
        public void BindPrimaryGrid()
        {
            try
            {
                int clientId = Convert.ToInt32(Session["ClId"]);
                DateTime from = Convert.ToDateTime(txtFromDate.Text);
                DateTime to = Convert.ToDateTime(txtToDate.Text);
                BLSelectProject blselPr = new BLSelectProject();
                SqlDataReader dr = blselPr.GetProjectByAddInv1(clientId, from, to);
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    GdVwSelPrjct.DataSource = dt.DefaultView;
                    GdVwSelPrjct.DataBind();
                    dr.Close();
                }
                else
                {
                    GdVwSelPrjct.DataSource = null;
                    GdVwSelPrjct.DataBind();
                    lblErrorMsg.Text = "Records not Available";
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        protected void btnSelectRecords_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtgetselectedRecords = new DataTable();

                double diniamt = 0.0;

                // Adding Dynamic Column to the datatable using the add range method
                dtgetselectedRecords.Columns.AddRange(new DataColumn[1] { new DataColumn("ProjectId") });
                dtgetselectedRecords.Columns.AddRange(new DataColumn[1] { new DataColumn("ProjectDate") });
                dtgetselectedRecords.Columns.AddRange(new DataColumn[1] { new DataColumn("CaseName") });
                dtgetselectedRecords.Columns.AddRange(new DataColumn[1] { new DataColumn("TypeOfWork") });
                dtgetselectedRecords.Columns.AddRange(new DataColumn[1] { new DataColumn("Price") });

                // Running a For Loop accross the First Grid View
                foreach (GridViewRow gvrow in GdVwSelPrjct.Rows)
                {

                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        // int i;
                        //Finding the Checkbox in the Gridview
                        CheckBox chkSelect = (gvrow.Cells[0].FindControl("chkSelect") as CheckBox);
                        // Checking which checkbox are selected
                        if (chkSelect.Checked)
                        {
                            int ProjectId = Convert.ToInt32(gvrow.Cells[2].Text);
                            string Date = gvrow.Cells[3].Text;
                            string CaseName = gvrow.Cells[4].Text;
                            string TypeOfWork = gvrow.Cells[5].Text;
                            string Amount = gvrow.Cells[6].Text;
                            dtgetselectedRecords.Rows.Add(ProjectId, Date, CaseName, TypeOfWork, Amount);

                            double damt = Convert.ToDouble(Amount);

                            diniamt = damt + diniamt;
                            Session["Typeofwork"] = TypeOfWork;
                        }
                    }
                }
                // Adding the Data table to Session for passing it to another page.
                Session.Add("dtgetselectedRecords", dtgetselectedRecords);
                // Session.Add("amt", diniamt);

                id = 1;
                Response.Redirect("~/Admin/Invoice/AddInvoice.aspx?Id=" + id);
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

       protected void RowCommand(object sender, GridViewCommandEventArgs e)
       {
           try
           {
               if (e.CommandName == "Edit")
               {
                   GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                   int rowIndex = gvr.RowIndex;
                   int projectid = Convert.ToInt32(GdVwSelPrjct.Rows[rowIndex].Cells[2].Text);
                   Response.Redirect("~/Admin/Project/AddEditWork.aspx?ProjectId=" + projectid);
                   Session["SelectProject"] = Convert.ToString(1);
               }
           }
           catch (Exception ex)
           {
               lblCatchError.Text = ex.Message.ToString();
           }
       }

        protected void GdVwSelPrjct_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int projectid = 0;
                foreach (GridViewRow gvrow in GdVwSelPrjct.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        int s = int.Parse(GdVwSelPrjct.DataKeys[gvrow.RowIndex].Value.ToString());
                        projectid = int.Parse(gvrow.Cells[2].Text);
                    }
                }
                Response.Redirect("~/Admin/Project/AddEditWork.aspx?projectId=" + projectid);
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnCancelClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Admin/Invoice/AddInvoice.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
    }
}
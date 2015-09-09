using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer;

using System.Data;

namespace Juris.Emp.Employees
{
    public partial class ViewEmployees : System.Web.UI.Page
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
                    BLEmployee blsr = new BLEmployee();
                    SqlDataReader dr = blsr.getEmployeeName1();
                    ddlEmpNameVwEmp.Items.Clear();
                    ddlEmpNameVwEmp.Items.Add("--Select--");
                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                            ddlEmpNameVwEmp.Items.Add(dr.GetString(0));
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
                cmd.CommandText = "gridFillEmployee";
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GdVwViewEmp.DataSource = ds.Tables[0];
                    GdVwViewEmp.DataBind();
                }
                else
                {
                    lblErrorMsg.Text = "Records not available";
                    GdVwViewEmp.DataSource = null;
                    GdVwViewEmp.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnCreateNewEmp_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Emp/Employees/AddEditEmployees.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        /*
           Create By :- Kunal
           Created Date :- 13/3/2015
           Updated Date :- 
           Purpose :- View Employee Search On Dropdown List
        */
        #region-----------ddlEmpNameVwEmp_SelectedIndexChanged------------
        protected void ddlEmpNameVwEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLEmployee blaee = new BLEmployee();
                string strEmployeeName = Convert.ToString(ddlEmpNameVwEmp.SelectedItem.Text);
                SqlDataReader dr = blaee.getEmployeeCode1(strEmployeeName);
                //ddlEmpNameVwEmp.Items.Clear();
                while (dr.Read())
                    txtEmpCodeVwEmp.Text = dr.GetString(0);

                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand();
                SqlParameter param;
                DataSet ds = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getEmpNameEmployee";
                param = new SqlParameter("@EmployeeName", ddlEmpNameVwEmp.SelectedItem.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GdVwViewEmp.DataSource = ds.Tables[0];
                    GdVwViewEmp.DataBind();
                }
                else
                {
                    lblErrorMsg.Text = "Records not available";
                    GdVwViewEmp.DataSource = null;
                    GdVwViewEmp.DataBind();
                }
                con.Close();
                if (ddlEmpNameVwEmp.SelectedItem.Text == "--Select--")
                {
                    txtEmpCodeVwEmp.Text = "";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion


        protected void ChkbxShowDeletedEmp_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string strEmployeeName = ddlEmpNameVwEmp.SelectedItem.Text;
                int intIsDeleted;
                if (ChkbxShowDeletedEmp.Checked == true)
                    intIsDeleted = 1;
                else
                    intIsDeleted = 0;
                if (ddlEmpNameVwEmp.SelectedItem.Text == "--Select--" && ddlApproveEmp.SelectedItem.Text == "--Select--" && (ChkbxShowDeletedEmp.Checked == true || ChkbxShowDeletedEmp.Checked == false))
                {
                    BLEmployee blpr = new BLEmployee();
                    SqlDataReader dr = blpr.isDelEmpChecked1(intIsDeleted);
                    DataTable dt = new DataTable();
                    if (dr.HasRows == true)
                    {
                        dt.Load(dr);
                        GdVwViewEmp.DataSource = dt;
                        GdVwViewEmp.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not Available";
                        GdVwViewEmp.DataSource = null;
                        GdVwViewEmp.DataBind();
                    }
                    dr.Close();
                }
                if (ddlEmpNameVwEmp.SelectedItem.Text != "--Select--" && ddlApproveEmp.SelectedItem.Text == "--Select--" && (ChkbxShowDeletedEmp.Checked == true || ChkbxShowDeletedEmp.Checked == false))
                {
                    BLEmployee blpr = new BLEmployee();
                    SqlDataReader dr = blpr.isDelEmpNameChecked1(strEmployeeName, intIsDeleted);
                    DataTable dt = new DataTable();
                    if (dr.HasRows == true)
                    {
                        dt.Load(dr);
                        GdVwViewEmp.DataSource = dt;
                        GdVwViewEmp.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not Available";
                        GdVwViewEmp.DataSource = null;
                        GdVwViewEmp.DataBind();
                    }
                    dr.Close();
                }
                if (ddlEmpNameVwEmp.SelectedItem.Text != "--Select--" && ddlApproveEmp.SelectedItem.Text != "--Select--" && (ChkbxShowDeletedEmp.Checked == true || ChkbxShowDeletedEmp.Checked == false))
                {
                    int intApprove = int.Parse(ddlApproveEmp.SelectedItem.Value);
                    BLEmployee blpr = new BLEmployee();
                    SqlDataReader dr = blpr.isDelEmpNameAppChecked1(strEmployeeName, intApprove, intIsDeleted);
                    DataTable dt = new DataTable();
                    if (dr.HasRows == true)
                    {
                        dt.Load(dr);
                        GdVwViewEmp.DataSource = dt;
                        GdVwViewEmp.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not Available";
                        GdVwViewEmp.DataSource = null;
                        GdVwViewEmp.DataBind();
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        /*
            Create By :- Kunal
            Created Date :- 13/3/2015
            Updated Date :- Rameshwar(Added Try catch)
            Purpose :- View Employee Search On Dropdown List
         */
        #region-----------ddlApproveEmp_SelectedIndexChanged------------
        protected void ddlApproveEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlApproveEmp.SelectedItem.Text == "--Select--")
            {
                GdVwViewEmp.DataSource = null;
                GdVwViewEmp.DataBind();
            }
            else
            {
                string strEmployeeName = ddlEmpNameVwEmp.SelectedItem.Text;
                int intApprove = int.Parse(ddlApproveEmp.SelectedItem.Value);
                if (ddlEmpNameVwEmp.SelectedItem.Text == "--Select--" && ddlApproveEmp.SelectedItem.Text != "--Select--")
                {
                    txtEmpCodeVwEmp.Text = null;
                    BLEmployee blpr = new BLEmployee();
                    SqlDataReader dr = blpr.gridFillApproveEmp1(intApprove);
                    DataTable dt = new DataTable();
                    if (dr.HasRows == true)
                    {
                        dt.Load(dr);
                        GdVwViewEmp.DataSource = dt;
                        GdVwViewEmp.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not Available";
                        GdVwViewEmp.DataSource = null;
                        GdVwViewEmp.DataBind();
                    }
                    dr.Close();
                }
                if (ddlEmpNameVwEmp.SelectedItem.Text != "--Select--" && ddlApproveEmp.SelectedItem.Text != "--Select--")
                {
                    BLEmployee blpr = new BLEmployee();
                    SqlDataReader dr = blpr.gridFillApproveEmpName1(strEmployeeName, intApprove);
                    DataTable dt = new DataTable();
                    if (dr.HasRows == true)
                    {
                        dt.Load(dr);
                        GdVwViewEmp.DataSource = dt;
                        GdVwViewEmp.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not Available";
                        GdVwViewEmp.DataSource = null;
                        GdVwViewEmp.DataBind();
                    }
                    dr.Close();
                }
            }
        }
        #endregion

        protected void GdVwViewEmp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditEmp")
                {
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    int EmpId = Convert.ToInt32(GdVwViewEmp.Rows[rowIndex].Cells[1].Text);
                    Session["EmpId"] = EmpId.ToString();
                    Response.Redirect("~/Emp/Employees/AddEditEmployees.aspx?EmpId=" + EmpId);
                }
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
                Response.Redirect("~/employeeHome.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
    }
}
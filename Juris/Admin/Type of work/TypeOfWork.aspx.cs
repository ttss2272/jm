using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer;
using System.Data;

namespace Juris.Admin.Type_of_work
{
    public partial class TypeOfWork : System.Web.UI.Page
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter();
        BLTypeOfWork bltow = new BLTypeOfWork();
        DataSet ds = new DataSet(); string strwork; int intTypeofWorkID; int intApprove = 0; int intIsDeleted = 0;
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
                    SqlConnection con = new SqlConnection(connstr);
                    fillDDLTypWork();
                    fillgrid();
                    if (Session["TypWrkId"] != null)
                    {
                        lblTypWrkId.Text = Session["TypWrkId"].ToString();
                        int intTypeofWorkID = int.Parse(Session["TypWrkId"].ToString());
                        con.Open();
                    }
                }
                else
                {
                    lblCatchError.Text = "";
                    lblErrorMsg.Text = "";
                    lblResult.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        public void fillDDLTypWork()
        {
            SqlDataReader dr = bltow.getTypeOfWork1();
            ddlTypWrk.Items.Clear();
            ddlTypWrk.Items.Add("--Select--");
            if (dr.HasRows == true)
            {
                while (dr.Read())
                    ddlTypWrk.Items.Add(dr.GetString(1));
            }
            else
            {
                lblErrorMsg.Text = "Records not available";
                fillgrid();
            }
            dr.Close();
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
                cmd.CommandText = "getTypeOfWork";
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GdVwViewTypWrk.DataSource = ds.Tables[0];
                    GdVwViewTypWrk.DataBind();
                }
                else
                {
                    lblErrorMsg.Text = "Records not available";
                    GdVwViewTypWrk.DataSource = null;
                    GdVwViewTypWrk.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        protected void setparameters()
        {
            try
            {
                strwork = txtTypeOfWork.Text;

                if (ChkBxApprovTypOfWrk.Checked == true)
                    intApprove = 1;
                else
                    intApprove = 0;


                if (rbYesIsDeltypWrk.Checked == true)
                    intIsDeleted = 1;
                else
                    intIsDeleted = 0;
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
         Purpose :- Type of Work on btnSaveTypWrk_Click Session null 
         */
        #region--------btnSaveTypWrk_Click-------
        protected void btnSaveTypWrk_Click(object sender, EventArgs e)
        {
            try
            {
                BLTypeOfWork bltow = new BLTypeOfWork();
                //SqlDataReader dr = bldb.getDocDetailsForUpdate1(intDocumentID);
                setparameters();
                if (Session["TypWrkId"] != null)
                {
                    //setparameters();
                    intTypeofWorkID = int.Parse(Session["TypWrkId"].ToString());
                    bltow.updateTypeOfWork1(intTypeofWorkID, strwork, intIsDeleted, intApprove);
                    fillgrid();
                    lblResult.Visible = true;
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Type of Work Details are Updated Successfully";
                    lblErrorMsg.Text = "";
                    fillgrid();
                    btnClearTypWrk.Enabled = false;
                    Session["TypWrkId"] = null;
                }
                else
                {
                   string msg = bltow.saveTypeOfWork1(strwork, intIsDeleted, intApprove);
                    fillgrid();
                    if (msg == "1")
                    {
                        lblResult.Visible = true;
                        lblResult.ForeColor = System.Drawing.Color.Green;
                        lblResult.Text = "Type of Work Details are Added Successfully";
                        fillDDLTypWork();
                    }
                    else
                    {
                        lblResult.Visible = true;
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Text = "Type of Work Details are Already Exists";
                    }
                    fillgrid();
                    lblErrorMsg.Text = "";
                    Session["TypWrkId"] = null;

                }
                txtTypeOfWork.Text = "";
                rbYesIsDeltypWrk.Checked = false;
                rbNoIsDeltypWrk.Checked = false;
                ChkBxApprovTypOfWrk.Checked = false;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        protected void btnClearTypWrk_Click(object sender, EventArgs e)
        {
            try
            {
                txtTypeOfWork.Text = "";
                rbYesIsDeltypWrk.Checked = false;
                ChkBxApprovTypOfWrk.Checked = false;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        protected void ddlTypWrk_SelectedIndexChanged(object sender, EventArgs e)
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
                cmd.CommandText = "getWorkTypeOfWork";
                param = new SqlParameter("@Work", ddlTypWrk.SelectedItem.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GdVwViewTypWrk.DataSource = ds.Tables[0];
                    GdVwViewTypWrk.DataBind();
                }
                else
                {
                    lblErrorMsg.Text = "Records not available";
                    GdVwViewTypWrk.DataSource = null;
                    GdVwViewTypWrk.DataBind();
                }
                con.Close();
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
         Purpose :- Type Of work Search on Dropdown List
         */
        #region--------ddlApprvtypWrk_SelectedIndexChanged-------
        protected void ddlApprvtypWrk_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strWork = ddlTypWrk.SelectedItem.Text;
                int intApprove = int.Parse(ddlApprvtypWrk.SelectedItem.Value);
                if (ddlTypWrk.SelectedItem.Text == "--Select--" && ddlApprvtypWrk.SelectedItem.Text != "--Select--")
                {
                    // int intApprove = int.Parse(ddlApprvtypWrk.SelectedItem.Value);
                    BLTypeOfWork blpr = new BLTypeOfWork();
                    SqlDataReader dr = blpr.gridFillApproveTypWrk1(intApprove);
                    DataTable dt = new DataTable();
                    if (dr.HasRows == true)
                    {
                        dt.Load(dr);
                        GdVwViewTypWrk.DataSource = dt;
                        GdVwViewTypWrk.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not Available";
                        GdVwViewTypWrk.DataSource = null;
                        GdVwViewTypWrk.DataBind();
                    }
                    dr.Close();

                }
                if (ddlTypWrk.SelectedItem.Text != "--Select--" && ddlApprvtypWrk.SelectedItem.Text != "--Select--")
                {
                    // int intApprove = int.Parse(ddlApprvtypWrk.SelectedItem.Value);
                    BLTypeOfWork blpr = new BLTypeOfWork();
                    SqlDataReader dr = blpr.gridFillApproveTypWrkName1(strWork, intApprove);
                    DataTable dt = new DataTable();
                    if (dr.HasRows == true)
                    {
                        dt.Load(dr);
                        GdVwViewTypWrk.DataSource = dt;
                        GdVwViewTypWrk.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not Available";
                        GdVwViewTypWrk.DataSource = null;
                        GdVwViewTypWrk.DataBind();
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

        /*
         Create By :- Kunal
         Created Date :- 13/3/2015
         Updated Date :- 
         Purpose :- Type Of Work Search on Checkbox CheckedChaged
         */
        #region--------ChkbxShowDeletedTypWrk_CheckedChanged-------
        protected void ChkbxShowDeletedTypWrk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string strWork = ddlTypWrk.SelectedItem.Text;
                int intIsDeleted;
                if (ChkbxShowDeletedTypWrk.Checked == true)
                intIsDeleted = 1;
                else
                {
                    intIsDeleted = 0;
                }
                if (ddlTypWrk.SelectedItem.Text == "--Select--" && ddlApprvtypWrk.SelectedItem.Text == "--Select--" && (ChkbxShowDeletedTypWrk.Checked == true || ChkbxShowDeletedTypWrk.Checked == false))
                {
                    BLTypeOfWork blpr = new BLTypeOfWork();
                    SqlDataReader dr = blpr.isDelTypWrkChecked1(intIsDeleted);
                    DataTable dt = new DataTable();
                    if (dr.HasRows == true)
                    {
                        dt.Load(dr);
                        GdVwViewTypWrk.DataSource = dt;
                        GdVwViewTypWrk.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not Available";
                        GdVwViewTypWrk.DataSource = null;
                        GdVwViewTypWrk.DataBind();
                    }
                    dr.Close();
                }
                if (ddlTypWrk.SelectedItem.Text != "--Select--" && ddlApprvtypWrk.SelectedItem.Text == "--Select--" && (ChkbxShowDeletedTypWrk.Checked == true || ChkbxShowDeletedTypWrk.Checked == false))
                {
                    BLTypeOfWork blpr = new BLTypeOfWork();
                    SqlDataReader dr = blpr.isDelTypWrkCheckedWork1(strWork, intIsDeleted);
                    DataTable dt = new DataTable();
                    if (dr.HasRows == true)
                    {
                        dt.Load(dr);
                        GdVwViewTypWrk.DataSource = dt;
                        GdVwViewTypWrk.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not Available";
                        GdVwViewTypWrk.DataSource = null;
                        GdVwViewTypWrk.DataBind();
                    }
                    dr.Close();
                }
                if (ddlTypWrk.SelectedItem.Text != "--Select--" && ddlApprvtypWrk.SelectedItem.Text != "--Select--" && (ChkbxShowDeletedTypWrk.Checked == true || ChkbxShowDeletedTypWrk.Checked == false))
                {
                    int intApprove = int.Parse(ddlApprvtypWrk.SelectedItem.Value);
                    BLTypeOfWork blpr = new BLTypeOfWork();
                    SqlDataReader dr = blpr.isDelTypWrkAppCheckedWork1(strWork, intApprove, intIsDeleted);
                    DataTable dt = new DataTable();
                    if (dr.HasRows == true)
                    {
                        dt.Load(dr);
                        GdVwViewTypWrk.DataSource = dt;
                        GdVwViewTypWrk.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not Available";
                        GdVwViewTypWrk.DataSource = null;
                        GdVwViewTypWrk.DataBind();
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

        protected void GdVwViewTypWrk_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                BLTypeOfWork bltow = new BLTypeOfWork();
                if (e.CommandName == "EditTypWrk")
                {
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    int TypWrkId = Convert.ToInt32(GdVwViewTypWrk.Rows[rowIndex].Cells[1].Text);
                    Session["TypWrkId"] = TypWrkId.ToString();
                    SqlDataReader dr1 = bltow.getTypeWrkDetailsForUpdate1(TypWrkId);
                    if (dr1.HasRows == true)
                    {
                        while (dr1.Read())
                        {
                            btnClearTypWrk.Enabled = false;
                            txtTypeOfWork.Text = dr1.GetString(1);
                            bool isdel = dr1.GetBoolean(2);
                            if (isdel == true)
                                rbYesIsDeltypWrk.Checked = true;
                            else
                                rbNoIsDeltypWrk.Checked = true;
                            int approve = dr1.GetInt32(3);
                            if (approve == 1)
                                ChkBxApprovTypOfWrk.Checked = true;
                            else
                                ChkBxApprovTypOfWrk.Checked = false;
                        }
                    }
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
         Updated Date :- 
         Purpose :- Type Of Work make Session null
      */
        #region--------btnCancl_Click-------
        protected void btnCancl_Click(object sender, EventArgs e)
        {
            try
            {
                Session["DocBoyId"] = null;
                Response.Redirect("~/adminHome.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        protected void Page_Unload(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Session["DocBoyId"] = null;
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
    }
}
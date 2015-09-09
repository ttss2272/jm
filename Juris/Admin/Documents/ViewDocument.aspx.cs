using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer;
using System.Data;

namespace Juris.Admin.Documents
{
    public partial class ViewDocument : System.Web.UI.Page
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string strDocument;
        int intApprove = 0;
        int intIsDeleted = 0;
        int intDocumentID;
        BLDocument bltow = new BLDocument();
        // Name-: Snehal
        // Purpose-:Load page,and fill dropdownlist at page load 
        #region------------protected void Page_Load(object sender, EventArgs e)-----------------
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblResult.Text = "";
                if (!Page.IsPostBack)
                {
                    if (Session["DocId"] == null)
                    {
                        if ((HttpContext.Current.Session["LoginId"]) == null)
                        {
                            Response.Redirect("~/Login.aspx");
                        }
                        SqlConnection con = new SqlConnection(connstr);
                        fillDDLDocument();
                        fillgrid();
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
        #endregion

        public void fillDDLDocument()
        {
            SqlDataReader dr = bltow.getDocument1();
            ddlDocumentDoc.Items.Clear();
            ddlDocumentDoc.Items.Add("--Select--");
            if (dr.HasRows)
            {
                while (dr.Read())
                    ddlDocumentDoc.Items.Add(dr.GetString(1));
            }
            else
            {
                lblErrorMsg.Text = "Records not available";
                fillgrid();
            }
        }

        // Name-: Snehal
        // Purpose-:fill gridview at page load 
        #region------------public void fillgrid()-----------------
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
                cmd.CommandText = "getDocument";
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                GdVwDocPaper.DataSource = ds.Tables[0];
                GdVwDocPaper.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        // Name-: Snehal
        // Purpose-:set values to parameters for save and update 
        #region------------protected void setparameters()-----------------
        protected void setparameters()
        {
            try
            {
                strDocument = txtDocPaper.Text;
                if (ChkBxApprovDoc.Checked == true)
                    intApprove = 1;
                else
                    intApprove = 0;

                if (rbYesIsDelDoc.Checked == true)
                    intIsDeleted = 1;
                else
                    intIsDeleted = 0;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        // Name-: Snehal
        // Purpose-:save and update document details 
        #region------------protected void btnSaveDocPaper_Click(object sender, EventArgs e)-----------------
        protected void btnSaveDocPaper_Click(object sender, EventArgs e)
        {
            try
            {
                BLDocument bldb = new BLDocument();
                setparameters();
                if (Session["DocId"] != null)
                {
                    intDocumentID = int.Parse(Session["DocId"].ToString());
                    bldb.updateDocument1(intDocumentID, strDocument, intIsDeleted, intApprove);
                    fillgrid();
                    lblResult.Visible = true;
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Document Details are Updated Successfully";
                    btnClearDocPaper.Enabled = true;
                    lblErrorMsg.Text = ""; 
                    Session["DocId"] = null;
                    fillgrid();
                }
                else
                {
                    string msg = bldb.saveDocument1(strDocument, intIsDeleted, intApprove);
                    fillgrid();
                    if (msg == "1")
                    {
                        lblResult.Visible = true;
                        lblResult.ForeColor = System.Drawing.Color.Green;
                        lblResult.Text = "Document Details are Saved Successfully";
                        fillDDLDocument();
                    }
                    else
                    {
                        lblResult.Visible = true;
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Text = "Document Details Details are already Exists";
                    }
                    Session["DocId"] = null;
                    lblErrorMsg.Text = ""; 
                    fillgrid();
                }
                Clearfields();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        // Name-: Snehal
        // Purpose-:clear controls after save or update 
        #region------------protected void Clearfields()-----------------
        protected void Clearfields()
        {
            try
            {
                txtDocPaper.Text = "";
                rbYesIsDelDoc.Checked = false;
                ChkBxApprovDoc.Checked = false;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        #endregion

        // Name-: Snehal
        // Purpose-:clear controls after save or update 
        #region------------protected void btnClearDocPaper_Click(object sender, EventArgs e)-----------------
        protected void btnClearDocPaper_Click(object sender, EventArgs e)
        {
            try
            {
                Clearfields();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        // Name-: Snehal
        // Purpose-:fillgrid at selected index change
        #region-----------protected void ddlDocumentDoc_SelectedIndexChanged(object sender, EventArgs e)-----------------
        protected void ddlDocumentDoc_SelectedIndexChanged(object sender, EventArgs e)
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
                cmd.CommandText = "getDocDocument";
                param = new SqlParameter("@Document", ddlDocumentDoc.SelectedItem.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GdVwDocPaper.DataSource = ds.Tables[0];
                    GdVwDocPaper.DataBind();
                }
                else
                {
                    lblErrorMsg.Text = "Records not available";
                    GdVwDocPaper.DataSource = null;
                    GdVwDocPaper.DataBind();
                }
                con.Close();
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
          Purpose :- View Document Search On Dropdown List
       */
        #region-----------ddlApprovDoc_SelectedIndexChanged------------
        protected void ddlApprovDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlApprovDoc.SelectedItem.Text == "--Select--")
                {
                    GdVwDocPaper.DataSource = null;
                    GdVwDocPaper.DataBind();
                }
                else
                {
                    string strDocument = ddlDocumentDoc.SelectedItem.Text;
                    int intApprove = int.Parse(ddlApprovDoc.SelectedItem.Value);
                    if (ddlDocumentDoc.SelectedItem.Text == "--Select--" && ddlApprovDoc.SelectedItem.Text != "--Select--")
                    {
                        BLDocument blpr = new BLDocument();
                        SqlDataReader dr = blpr.gridFillApproveDoc1(intApprove);
                        DataTable dt = new DataTable();
                        if (dr.HasRows == true)
                        {
                            dt.Load(dr);
                            GdVwDocPaper.DataSource = dt;
                            GdVwDocPaper.DataBind();
                        }
                        else
                        {
                            lblErrorMsg.Text = "Records not Available";
                            GdVwDocPaper.DataSource = null;
                            GdVwDocPaper.DataBind();
                        }
                        dr.Close();
                    }
                    if (ddlDocumentDoc.SelectedItem.Text != "--Select--" && ddlApprovDoc.SelectedItem.Text != "--Select--")
                    {
                        BLDocument blpr = new BLDocument();
                        SqlDataReader dr = blpr.gridFillApproveDocName1(strDocument, intApprove);
                        DataTable dt = new DataTable();
                        if (dr.HasRows == true)
                        {
                            dt.Load(dr);
                            GdVwDocPaper.DataSource = dt;
                            GdVwDocPaper.DataBind();
                        }
                        else
                        {
                            lblErrorMsg.Text = "Records not Available";
                            GdVwDocPaper.DataSource = null;
                            GdVwDocPaper.DataBind();
                        }
                        dr.Close();
                    }
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
          Purpose :- View Document Search on Checkbox CheckedChaged
       */
        #region-----------ChkbxShowDeletedDocPaper1_CheckedChanged------------
        protected void ChkbxShowDeletedDocPaper1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string strDocument = ddlDocumentDoc.SelectedItem.Text;

                int intIsDeleted;

                if (ChkbxShowDeletedDocPaper1.Checked == true)
                    intIsDeleted = 1;
                else
                    intIsDeleted = 0;

                if (ddlDocumentDoc.SelectedItem.Text == "--Select--" && ddlApprovDoc.SelectedItem.Text == "--Select--" && (ChkbxShowDeletedDocPaper1.Checked == true || ChkbxShowDeletedDocPaper1.Checked == false))
                {
                    BLDocument blpr = new BLDocument();
                    SqlDataReader dr = blpr.isDelDocChecked1(intIsDeleted);
                    DataTable dt = new DataTable();
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                    }
                    GdVwDocPaper.DataSource = dt;
                    GdVwDocPaper.DataBind();

                }
                if (ddlDocumentDoc.SelectedItem.Text != "--Select--" && ddlApprovDoc.SelectedItem.Text == "--Select--" && (ChkbxShowDeletedDocPaper1.Checked == true || ChkbxShowDeletedDocPaper1.Checked == false))
                {
                    BLDocument blpr = new BLDocument();
                    SqlDataReader dr = blpr.isDelDocNameChecked1(strDocument, intIsDeleted);
                    DataTable dt = new DataTable();
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                    }
                    GdVwDocPaper.DataSource = dt;
                    GdVwDocPaper.DataBind();

                }
                if (ddlDocumentDoc.SelectedItem.Text != "--Select--" && ddlApprovDoc.SelectedItem.Text != "--Select--" && (ChkbxShowDeletedDocPaper1.Checked == true || ChkbxShowDeletedDocPaper1.Checked == false))
                {
                    int intApprove = int.Parse(ddlApprovDoc.SelectedItem.Value);
                    BLDocument blpr = new BLDocument();
                    SqlDataReader dr = blpr.isDelDocNameAppChecked1(strDocument, intApprove, intIsDeleted);
                    DataTable dt = new DataTable();
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                    }
                    GdVwDocPaper.DataSource = dt;
                    GdVwDocPaper.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        // Name-: Snehal
        // Purpose-:get details for update after gridview edit button click
        #region-----------protected void GdVwDocPaper_RowCommand(object sender, GridViewCommandEventArgs e)-----------------
        protected void GdVwDocPaper_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                BLDocument blc = new BLDocument();
                if (e.CommandName == "EditDocument")
                {
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    int DocId = Convert.ToInt32(GdVwDocPaper.Rows[rowIndex].Cells[1].Text);
                    Session["DocId"] = DocId;
                    SqlDataReader dr2 = blc.getDocDetailsForUpdate1(DocId);
                    if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {
                            btnClearDocPaper.Enabled = false;
                            txtDocPaper.Text = dr2.GetString(1);
                            bool isdel = dr2.GetBoolean(2);
                            if (isdel == true)
                                rbYesIsDelDoc.Checked = true;
                            else
                                rbNoIsDelDoc.Checked = true;
                            int approve = dr2.GetInt32(3);
                            if (approve == 1)
                                ChkBxApprovDoc.Checked = true;
                            else
                                ChkBxApprovDoc.Checked = false;
                        }
                        dr2.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        // Name-: Snehal
        // Purpose-:redirect to home page
        #region----------protected void btnCancl_Click(object sender, EventArgs e)-----------------
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
        #endregion

        // Name-: Snehal
        // Purpose-:clear session
        #region---------protected void Page_Unload(object sender, EventArgs e)-----------------
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
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer;
using System.Data;



namespace Juris.Admin.Document_Boys
{
    public partial class DocumentBoys : System.Web.UI.Page
    {
        
        //ADD Comment
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string strName;
        string strMobile;
        string strDocBoyCodeGen;
        string strCode;
        string strMailID;
        int intApprove = 0;
        int intIsDeleted = 0;
        int intDocumentBoyID;
        BLDocumentBoy bldb = new BLDocumentBoy();

        // Name-: Snehal
        // Purpose-:Fill dropdownlist at page load
        #region--------------protected void Page_Load(object sender, EventArgs e)-------
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connstr);
                if (!Page.IsPostBack)
                {
                    if ((HttpContext.Current.Session["LoginId"]) == null)
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                    fillDDLDocBoy();
                    fillgrid();
                    getMaxCode();
                }
                else
                {
                    lblCatchError.Text = "";
                    lblResult.Text = "";
                    lblErrorMsg.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        public void fillDDLDocBoy()
        {
            SqlDataReader dr = bldb.getDocumentBoy1();
            ddlDocBoy.Items.Clear();
            ddlDocBoy.Items.Add("--Select--");
            if (dr.HasRows == true)
            {
                while (dr.Read())
                    ddlDocBoy.Items.Add(dr.GetString(2));
            }
            else
            {
                lblErrorMsg.Text = "Records not available";
                fillgrid();
            }
            dr.Close();
        }

        // Name-: Snehal
        // Purpose-:Fill gridview at page load
        #region--------------public void fillgrid()-------
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
                cmd.CommandText = "getDocumentBoy";
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GdVwViewDocumentBoy.DataSource = ds.Tables[0];
                    GdVwViewDocumentBoy.DataBind();
                }
                else
                {
                    lblErrorMsg.Text = "Records not available";
                    GdVwViewDocumentBoy.DataSource = null;
                    GdVwViewDocumentBoy.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        // Name-: Snehal
        // Purpose-:Set values to parameters for save and update
        #region--------------protected void setparameters()-------
        protected void setparameters()
        {
            try
            {
                strName = txtNameDocBoy.Text;
                strMobile = txtMobileDocBoy.Text;
                strDocBoyCodeGen = TextBox1.Text + lblDocMaxCode.Text;
                strCode = strDocBoyCodeGen;
                txtCodeDocBoy.Text = strCode;
                strMailID = txtMailIDDocBoy.Text;//Added for mailing purpose

                if (ChkBxApprovDocBoy.Checked == true)
                    intApprove = 1;
                else
                    intApprove = 0;
                if (rbYesIsDelDocBoy.Checked == true)
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
        // Purpose-:use to get max code for add document boy
        #region-------------- public void getMaxCode()-------
        public void getMaxCode()
        {
            try
            {
                SqlDataReader dr1 = bldb.getDocBoyMaxCode1();
                if (dr1.HasRows == true)
                {
                    dr1.Read();
                    lblDocMaxCode.Text = Convert.ToString(dr1.GetInt32(0));
                    string strDocBoyCodeGen = TextBox1.Text + lblDocMaxCode.Text;
                    string strDocBoyCode = strDocBoyCodeGen;
                    txtCodeDocBoy.Text = strDocBoyCode;
                }
                dr1.Close();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        // Name-: Snehal
        // Purpose-:Save and update document boy details
        #region------------protected void btnSaveDocBoy_Click(object sender, EventArgs e)-------
        protected void btnSaveDocBoy_Click(object sender, EventArgs e)
        {
            try
            {
                BLDocumentBoy bldb = new BLDocumentBoy();
                SqlDataReader dr = bldb.getDocBoyDetailsForUpdate1(intDocumentBoyID);
                setparameters();
                if (Session["DocBoyId"] != null)
                {
                    setparameters();
                    intDocumentBoyID = int.Parse(Session["DocBoyId"].ToString()); //int.Parse(Request.QueryString["DocBoyId"]);
                    bldb.updateDocumentBoy1(intDocumentBoyID, strMobile, intIsDeleted, intApprove, strMailID);
                    fillgrid();
                    lblResult.Visible = true;
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Document Boys Details are Updated Successfully";
                    txtNameDocBoy.Enabled = true;
                    btnClearDocBoy.Enabled = true;
                    fillgrid();
                    Session["DocBoyId"] = null;
                    getMaxCode();
                }
                else
                {
                    string msg = bldb.saveDocumentBoy1(strName, strMobile, intIsDeleted, strCode, intApprove, strMailID); //mail id added 
                    fillgrid();
                    if (msg == "1")
                    {
                        lblResult.Visible = true;
                        lblResult.ForeColor = System.Drawing.Color.Green;
                        lblResult.Text = "Document Boy Details Details are Added Successfully";
                        fillDDLDocBoy();
                    }
                    else
                    {
                        lblResult.Visible = true;
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Text = "Document Boy Details Details are already Exists";
                    }
                    
                    fillgrid();
                    Session["DocBoyId"] = null;
                    getMaxCode();
                }
                ClearFields();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        // Name-: Snehal
        // Purpose-:clear controls after save and update
        #region------------protected void ClearFields()-------
        protected void ClearFields()
        {
            try
            {
                txtNameDocBoy.Text = "";
                txtMobileDocBoy.Text = "";
                txtMailIDDocBoy.Text = "";
                rbYesIsDelDocBoy.Checked = false;
                ChkBxApprovDocBoy.Checked = false;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        // Name-: Snehal
        // Purpose-:clear controls after cleat button click
        #region------------protected void btnClearDocBoy_Click(object sender, EventArgs e)-------
        protected void btnClearDocBoy_Click(object sender, EventArgs e)
        {
            try
            {
                lblResult.Text = "";
                lblCatchError.Text = "";
                ClearFields();
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
          Purpose :- Document Boy Search On Dropdown List
       */
        #region-----------ddlDocBoy_SelectedIndexChanged------------
        protected void ddlDocBoy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLDocumentBoy bldb = new BLDocumentBoy();
                string strName = Convert.ToString(ddlDocBoy.SelectedItem.Text);
                SqlDataReader dr = bldb.getDocBoyCode1(strName);
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                        txtCode1.Text = dr.GetString(1);
                    dr.Close();
                }
                if (ddlDocBoy.SelectedItem.Text == "--Select--")
                {
                    txtCode1.Text = "";
                }
                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand();
                SqlParameter param;
                //DataSet ds = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getDocBoyCode";
                param = new SqlParameter("@Name", ddlDocBoy.SelectedItem.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GdVwViewDocumentBoy.DataSource = ds.Tables[0];
                    GdVwViewDocumentBoy.DataBind();
                }
                else
                {
                    lblErrorMsg.Text = "Records not available";
                    GdVwViewDocumentBoy.DataSource = null;
                    GdVwViewDocumentBoy.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion


        // Name-: Snehal
        // Purpose-:fill grid after selected index change
        #region-----------protected void ddlApprovDocBoy_SelectedIndexChanged(object sender, EventArgs e)-------
        protected void ddlApprovDocBoy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlApprovDocBoy.SelectedItem.Text == "--Select--")
                {
                    GdVwViewDocumentBoy.DataSource = null;
                    GdVwViewDocumentBoy.DataBind();
                }
                else
                {
                    string strName = ddlDocBoy.SelectedItem.Text;
                    int intApprove = int.Parse(ddlApprovDocBoy.SelectedItem.Value);
                    if (ddlDocBoy.SelectedItem.Text == "--Select--" && ddlApprovDocBoy.SelectedItem.Text != "--Select--")
                    {
                        BLDocumentBoy blpr = new BLDocumentBoy();
                        SqlDataReader dr = blpr.gridFillApproveDocumentBoy1(intApprove);
                        DataTable dt = new DataTable();
                        if (dr.HasRows == true)
                        {
                            dt.Load(dr);
                            GdVwViewDocumentBoy.DataSource = dt;
                            GdVwViewDocumentBoy.DataBind();
                        }
                        else
                        {
                            lblErrorMsg.Text = "Records not Available";
                            GdVwViewDocumentBoy.DataSource = dt;
                            GdVwViewDocumentBoy.DataBind();
                        }
                        dr.Close();
                    }
                    if (ddlDocBoy.SelectedItem.Text != "--Select--" && ddlApprovDocBoy.SelectedItem.Text != "--Select--")
                    {
                        BLDocumentBoy blpr = new BLDocumentBoy();
                        SqlDataReader dr = blpr.gridFillApproveDocumentBoyName1(strName, intApprove);
                        DataTable dt = new DataTable();
                        if (dr.HasRows == true)
                        {
                            dt.Load(dr);
                            GdVwViewDocumentBoy.DataSource = dt;
                            GdVwViewDocumentBoy.DataBind();
                        }
                        else
                        {
                            lblErrorMsg.Text = "Records not Available";
                            GdVwViewDocumentBoy.DataSource = dt;
                            GdVwViewDocumentBoy.DataBind();
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

        // Name-: Snehal
        // Purpose-:show deleted records after check change
        #region----------protected void ChkbxShowDeletedDocBoy_CheckedChanged(object sender, EventArgs e)-------
        protected void ChkbxShowDeletedDocBoy_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string strName = ddlDocBoy.SelectedItem.Text;
                // int intApprove = int.Parse(ddlApprovDocBoy.SelectedItem.Value);
                int intIsDeleted;
                if (ChkbxShowDeletedDocBoy.Checked == true)
                    intIsDeleted = 1;
                else
                    intIsDeleted = 0;
                if (ddlDocBoy.SelectedItem.Text == "--Select--" && ddlApprovDocBoy.SelectedItem.Text == "--Select--" && (ChkbxShowDeletedDocBoy.Checked == true || ChkbxShowDeletedDocBoy.Checked == false))
                {
                    BLDocumentBoy blpr = new BLDocumentBoy();
                    SqlDataReader dr = blpr.isDelDocBoyChecked1(intIsDeleted);
                    DataTable dt = new DataTable();
                    if (dr.HasRows == true)
                    {
                        dt.Load(dr);
                        GdVwViewDocumentBoy.DataSource = dt;
                        GdVwViewDocumentBoy.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not Available";
                        GdVwViewDocumentBoy.DataSource = null;
                        GdVwViewDocumentBoy.DataBind();
                    }
                    dr.Close();
                }
                if (ddlDocBoy.SelectedItem.Text != "--Select--" && ddlApprovDocBoy.SelectedItem.Text == "--Select--" && (ChkbxShowDeletedDocBoy.Checked == true || ChkbxShowDeletedDocBoy.Checked == false))
                {
                    BLDocumentBoy blpr = new BLDocumentBoy();
                    SqlDataReader dr = blpr.isDelDocBoyNameChecked1(strName, intIsDeleted);
                    DataTable dt = new DataTable();
                    if (dr.HasRows == true)
                    {
                        dt.Load(dr);
                        GdVwViewDocumentBoy.DataSource = dt;
                        GdVwViewDocumentBoy.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not Available";
                        GdVwViewDocumentBoy.DataSource = null;
                        GdVwViewDocumentBoy.DataBind();
                    }
                    dr.Close();
                }
                if (ddlDocBoy.SelectedItem.Text != "--Select--" && ddlApprovDocBoy.SelectedItem.Text != "--Select--" && (ChkbxShowDeletedDocBoy.Checked == true || ChkbxShowDeletedDocBoy.Checked == false))
                {
                    int intApprove = int.Parse(ddlApprovDocBoy.SelectedItem.Value);
                    BLDocumentBoy blpr = new BLDocumentBoy();
                    SqlDataReader dr = blpr.isDelDocBoyNameAppChecked1(strName, intApprove, intIsDeleted);
                    DataTable dt = new DataTable();
                    if (dr.HasRows == true)
                    {
                        dt.Load(dr);
                        GdVwViewDocumentBoy.DataSource = dt;
                        GdVwViewDocumentBoy.DataBind();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Records not Available";
                        GdVwViewDocumentBoy.DataSource = null;
                        GdVwViewDocumentBoy.DataBind();
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

        // Name-: Snehal
        // Purpose-:get docboy id and show details for editing
        #region----------protected void GdVwViewDocumentBoy_RowCommand(object sender, GridViewCommandEventArgs e)-------
        protected void GdVwViewDocumentBoy_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                BLDocumentBoy blc = new BLDocumentBoy();
                if (e.CommandName == "Editdocboy")
                {
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    int DocBoyId = Convert.ToInt32(GdVwViewDocumentBoy.Rows[rowIndex].Cells[1].Text);
                    Session["DocBoyId"] = DocBoyId;
                    SqlDataReader dr2 = blc.getDocBoyDetailsForUpdate1(DocBoyId);
                    if (dr2.HasRows == true)
                    {
                        while (dr2.Read())
                        {
                            txtCodeDocBoy.Enabled = false;
                            txtNameDocBoy.Enabled = false;
                            btnClearDocBoy.Enabled = false;
                            txtNameDocBoy.Text = dr2.GetString(1);
                            txtMobileDocBoy.Text = dr2.GetString(2);
                            txtCodeDocBoy.Text = dr2.GetString(4);
                            if (dr2["MailID"] == DBNull.Value)
                            {
                                txtMailIDDocBoy.Text = "";
                            }
                            else
                            {
                                txtMailIDDocBoy.Text = dr2.GetString(6);
                            }
                            bool isdel = dr2.GetBoolean(3);
                            if (isdel == true)
                                rbYesIsDelDocBoy.Checked = true;
                            else
                                rbNoIsDelDocBoy.Checked = true;
                            int approve = dr2.GetInt32(5);
                            if (approve == 1)
                                ChkBxApprovDocBoy.Checked = true;
                            else
                                ChkBxApprovDocBoy.Checked = false;
                            if (txtMobileDocBoy.Text == "-")
                            {
                                txtMobileDocBoy.Text = "";
                            }
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

        /*
          Create By :- Kunal
          Created Date :- 13/3/2015
          Updated Date :- 
          Purpose :- Document Boy Session Null on btnCncl_Click
       */
        #region-----------btnCncl_Click------------
        protected void btnCncl_Click(object sender, EventArgs e)
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

        // Name-: Snehal
        // Purpose-:clear session
        #region----protected void Page_Unload(object sender, EventArgs e)------
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

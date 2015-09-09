using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using MSWord = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.Diagnostics;
using Novacode;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Word;

namespace Juris.Emp.Project
{
    public partial class AddEditWork : System.Web.UI.Page
    {
        #region---------------------Variable Declaration----------------
        RichTextBox richTextBox1 = new RichTextBox();
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string str;
        int intProjectId = 0;
        DateTime dtProjectDate;
        int intClientID, intTypeOfWorkID, intApprove = 0;
        string strClientName, strTypeOfWork, strCaseName;
        int intExternalWork = 0;
        bool boolNeedSearch = false, boolIsDeleted = false;
        string strRemarks;
        decimal decPrice, decloanamt, decOtherCharges, decTotalAmount, decServiceTax;
        string strReferenceNo, strLoanNO, strPropertyAddress, strworddoc, strfilename, strbranch, strStatus;
        DateTime dt_softcopysent, dt_MISclient, dt_search_initiated, dt_search_received, dt_search_received_receipt, dt_hardcopysent,
        dt_pendingdocumentsrec, dt_pendingdocumentsresp, dt_finalreportsent;
        BLProject BLObj = new BLProject(); string c = ""; string filenew = "", strFilePath = "";
        string strEmailID; string strFileName; string[] values; string filename = "";
        int projectid = 0; int iFailedCnt = 0;
        #endregion

        #region------------------Page_Load-----------------------
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

                    Session["strFileName"] = null;
                    Session["strFilePath"] = null;
                    Session["chars"] = null;
                    Session["filenew"] = null;
                    //cbpdf.Visible = false;
                    #region------------fill DDLClient------------
                    BLProject blvc = new BLProject();
                    SqlDataReader dr = blvc.getClientNameForProject1();
                    ddlCliNm.Items.Clear();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                            ddlCliNm.Items.Add(dr.GetString(0));
                        ddlCliNm.Items.Insert(0, new ListItem("--Select--", "-1"));
                        dr.Close();
                    }
                    #endregion

                    #region----------Fill DDLTypeofWork--------------
                    BLProject bltow = new BLProject();
                    SqlDataReader dr1 = bltow.getTypeOfWorkForProject1();
                    ddlTypWrk.Items.Clear();
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                            ddlTypWrk.Items.Add(dr1.GetString(1));
                        ddlTypWrk.Items.Insert(0, new ListItem("--Select--", "-1"));
                        dr1.Close();
                    }
                    #endregion

                    ddlStatus.Items.Insert(0, new ListItem("--Select--", "-1"));
                    #region-----------All fillgrid function call--------------
                    fillgridClerk();
                    fillgridPapers();
                    fillgridEmployees();
                    fillgridDocBoy();
                    #endregion

                    #region------------------Show values to date textboxces-----------------
                    txtDate.Text = DateTime.Now.Date.ToShortDateString();
                    txtSoftCopySent.Text = DateTime.Now.Date.ToShortDateString();
                    txtPendingDocRcd.Text = DateTime.Now.Date.ToShortDateString();
                    txtHardCopySent.Text = DateTime.Now.Date.ToShortDateString();
                    //txtPendingDocRcsp.Text = DateTime.Now.Date.ToShortDateString();
                    txtSearchInitiated.Text = DateTime.Now.Date.ToShortDateString();
                    //txtFinalReportSent.Text = DateTime.Now.Date.ToShortDateString();
                    txtSearchReceived.Text = DateTime.Now.Date.ToShortDateString();
                    txtReceiptSearch.Text = DateTime.Now.Date.ToShortDateString();
                    txtStrDtEmp.Text = DateTime.Now.Date.ToShortDateString();
                    txtEndDtEmp.Text = DateTime.Now.Date.ToShortDateString();
                    txtStrStarDtClerk.Text = DateTime.Now.Date.ToShortDateString();
                    txtStrEndDtClerk.Text = DateTime.Now.Date.ToShortDateString();
                    #endregion

                    if (Request.QueryString["ProjectId"] != null)
                    {
                        //dpdwnlstFileNames.Visible = true;
                        lblProjectId.Text = Request.QueryString["ProjectId"].ToString();
                        int intProjectId = int.Parse(lblProjectId.Text);
                        BLProject blc = new BLProject();
                        //btnOpenAddWrk.Enabled = true;
                        //btnDelAddWrk.Enabled = true;
                        //btnEmailAddWrk.Enabled = true;

                        // Code to show selected Documents
                        int gvdocid;
                        //intProjectId = int.Parse(Session["ProjectId"].ToString());
                        SqlDataReader dr3 = blc.showSelectedDoc1(intProjectId);
                        System.Data.DataTable dt = new System.Data.DataTable(); dt.Columns.Add("docid");
                        if (dr3.HasRows)
                        {
                            while (dr3.Read())
                            {
                                int doc = dr3.GetInt32(0);
                                dt.Rows.Add(doc);
                            }
                            dr3.Close();
                        }

                        foreach (GridViewRow gvrow in GVPapers.Rows)
                        {

                            if (gvrow.RowType == DataControlRowType.DataRow)
                            {
                                System.Web.UI.WebControls.Label lblDocumentID = (gvrow.Cells[0].FindControl("lblDocumentId") as System.Web.UI.WebControls.Label);
                                gvdocid = int.Parse(lblDocumentID.Text);
                                System.Web.UI.WebControls.CheckBox chksel = (gvrow.Cells[0].FindControl("ChkBxSelDoc") as System.Web.UI.WebControls.CheckBox);
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    int doc = int.Parse(dt.Rows[i].Field<string>(0));
                                    if (doc == gvdocid)
                                    {
                                        chksel.Checked = true;
                                    }
                                }
                            }
                        }

                        //Code to show selected Employees
                        int gvempid;
                        // intProjectId = int.Parse(Session["ProjectId"].ToString());
                        SqlDataReader dr4 = blc.showSelectedEmployees1(intProjectId);
                        System.Data.DataTable dt1 = new System.Data.DataTable();
                        dt1.Columns.Add("empid");
                        if (dr4.HasRows)
                        {
                            while (dr4.Read())
                            {
                                int emp = dr4.GetInt32(0);
                                dt1.Rows.Add(emp);
                            }
                            dr4.Close();
                        }


                        foreach (GridViewRow gvrow in GVEmployees.Rows)
                        {

                            if (gvrow.RowType == DataControlRowType.DataRow)
                            {
                                System.Web.UI.WebControls.Label lblEmployeeID = (gvrow.Cells[0].FindControl("lblEmployeeID") as System.Web.UI.WebControls.Label);
                                gvempid = Convert.ToInt32(lblEmployeeID.Text);
                                System.Web.UI.WebControls.CheckBox chksel = (gvrow.Cells[0].FindControl("ChkBxSelEmp") as System.Web.UI.WebControls.CheckBox);
                                for (int i = 0; i < dt1.Rows.Count; i++)
                                {
                                    int emp = int.Parse(dt1.Rows[i].Field<string>(0));
                                    if (emp == gvempid)
                                    {
                                        chksel.Checked = true;
                                    }
                                }
                            }
                        }

                        //Code To show Selected Document Boys
                        int gvdocboyid;
                        // intProjectId = int.Parse(Session["ProjectId"].ToString());
                        SqlDataReader dr5 = blc.showSelectedDocBoys1(intProjectId);
                        System.Data.DataTable dt2 = new System.Data.DataTable();
                        dt2.Columns.Add("docboyid");
                        if (dr5.HasRows)
                        {

                            while (dr5.Read())
                            {
                                int doc = dr5.GetInt32(0);
                                dt2.Rows.Add(doc);
                            }
                            dr5.Close();
                        }


                        foreach (GridViewRow gvrow in GVDocBoy.Rows)
                        {

                            if (gvrow.RowType == DataControlRowType.DataRow)
                            {
                                System.Web.UI.WebControls.Label lblDocumentBoyID = (gvrow.Cells[0].FindControl("lblDocumentBoyID") as System.Web.UI.WebControls.Label);
                                gvdocboyid = int.Parse(lblDocumentBoyID.Text);
                                System.Web.UI.WebControls.CheckBox chksel = (gvrow.Cells[0].FindControl("ChkBxSelDocBoy") as System.Web.UI.WebControls.CheckBox);
                                for (int i = 0; i < dt2.Rows.Count; i++)
                                {
                                    int docboy = int.Parse(dt2.Rows[i].Field<string>(0));
                                    if (docboy == gvdocboyid)
                                    {
                                        chksel.Checked = true;
                                    }
                                }
                            }
                        }

                        //Code to show selected clerk
                        int gvclerkid;
                        //intProjectId = int.Parse(Session["ProjectId"].ToString());
                        SqlDataReader dr6 = blc.showSelectedClerk1(intProjectId);
                        System.Data.DataTable dt3 = new System.Data.DataTable();
                        dt3.Columns.Add("clerkid");
                        if (dr6.HasRows)
                        {
                            while (dr6.Read())
                            {
                                int clerk = dr6.GetInt32(0);
                                dt3.Rows.Add(clerk);
                            }
                        }
                        dr6.Close();
                        foreach (GridViewRow gvrow in GVClerk.Rows)
                        {

                            if (gvrow.RowType == DataControlRowType.DataRow)
                            {
                                System.Web.UI.WebControls.Label lblClerkID = (gvrow.Cells[0].FindControl("lblClerkID") as System.Web.UI.WebControls.Label);
                                gvclerkid = int.Parse(lblClerkID.Text);
                                System.Web.UI.WebControls.CheckBox chksel = (gvrow.Cells[0].FindControl("ChkBxSelClerk") as System.Web.UI.WebControls.CheckBox);
                                for (int i = 0; i < dt3.Rows.Count; i++)
                                {
                                    int clerk = int.Parse(dt3.Rows[i].Field<string>(0));
                                    if (clerk == gvclerkid)
                                    {
                                        chksel.Checked = true;
                                    }
                                }
                            }
                        }


                        SqlDataReader dr2 = blc.getProjectDetailsForUpdate1(intProjectId);
                        if (dr2.HasRows)
                        {
                            while (dr2.Read())
                            {
                                Button1.Enabled = false;
                                //btnSaveWordFile.Enabled = true;
                                ddlCliNm.Enabled = false;
                                ddlTypWrk.Enabled = false;
                                //ddlStatus.Visible = false;
                                txtDate.Text = dr2.GetDateTime(1).ToShortDateString();
                                ddlCliNm.SelectedValue = dr2.GetString(3);

                                //code for fill grid of service
                                BLServices blaee = new BLServices();
                                string strClientName1 = Convert.ToString(ddlCliNm.SelectedItem.Text);
                                SqlDataReader dr8 = blaee.getClientIDforService1(strClientName1);
                                if (dr8.HasRows)
                                {
                                    while (dr8.Read())
                                        lblCliId1.Text = dr8.GetInt32(0).ToString();
                                }
                                dr8.Close();

                                int intClientID = int.Parse(lblCliId1.Text);
                                BLServices blpr = new BLServices();
                                SqlDataReader dr9 = blpr.getServicePrice1(intClientID);
                                System.Data.DataTable dt5 = new System.Data.DataTable();
                                if (dr9.HasRows)
                                {
                                    dt5.Load(dr9);
                                    GVServices.DataSource = dt5;
                                    GVServices.DataBind();
                                }
                                dr9.Close();


                                //Code to show selected Services
                                int gvserviceid;
                                // intProjectId = int.Parse(Session["ProjectId"].ToString());
                                SqlDataReader drService = blc.showSelectedServices1(intProjectId);
                                System.Data.DataTable dtService = new System.Data.DataTable(); dtService.Columns.Add("serviceid");
                                if (drService.HasRows)
                                {
                                    while (drService.Read())
                                    {
                                        int service = drService.GetInt32(0);
                                        dtService.Rows.Add(service);
                                    }
                                }
                                drService.Close();

                                foreach (GridViewRow gvrow in GVServices.Rows)
                                {

                                    if (gvrow.RowType == DataControlRowType.DataRow)
                                    {
                                        System.Web.UI.WebControls.Label lblSeviceID = (gvrow.Cells[0].FindControl("lblServiceID") as System.Web.UI.WebControls.Label);
                                        gvserviceid = int.Parse(lblSeviceID.Text);
                                        System.Web.UI.WebControls.CheckBox chksel = (gvrow.Cells[0].FindControl("ChkBxSelService") as System.Web.UI.WebControls.CheckBox);
                                        for (int i = 0; i < dtService.Rows.Count; i++)
                                        {
                                            int service = int.Parse(dtService.Rows[i].Field<string>(0));
                                            if (service == gvserviceid)
                                            {
                                                chksel.Checked = true;
                                            }
                                        }
                                    }
                                }

                                lblTypWrkID.Text = dr2.GetInt32(4).ToString();
                                ddlTypWrk.SelectedValue = dr2.GetString(5);
                                txtCasNm.Text = dr2.GetString(6);

                                bool intExternalWork = dr2.GetBoolean(7);
                                if (intExternalWork == true)
                                    chkBxDsReqExtWrk.Checked = true;
                                else
                                    chkBxDsReqExtWrk.Checked = false;

                                bool intNeedSearch = dr2.GetBoolean(8);
                                if (intNeedSearch == true)
                                    chkBxDsReqSrch.Checked = true;
                                else
                                    chkBxDsReqSrch.Checked = false;

                                txtRemarks.Text = dr2.GetString(9);
                                txtPrice.Text = dr2.GetDecimal(10).ToString();
                                txtOtherCharge.Text = dr2.GetDecimal(11).ToString();
                                txtTotAmt.Text = dr2.GetDecimal(12).ToString();
                                txtStatus.Text = dr2.GetString(13);
                                ddlStatus.SelectedValue = dr2.GetString(13);
                                bool intIsDeleted = dr2.GetBoolean(14);
                                if (intIsDeleted == true)
                                    rbYesIsDel.Checked = true;
                                else
                                    rbNoIsDel.Checked = true;

                                int intApprove = dr2.GetInt32(15);
                                if (intApprove == 1)
                                    ChkBxApprovProject.Checked = true;
                                else
                                    ChkBxApprovProject.Checked = false;

                                txtServiceTax.Text = dr2.GetDecimal(16).ToString();
                                txtRefNo.Text = dr2.GetString(17);
                                if (dr2["LoanNo"] != DBNull.Value)
                                {
                                    txtLoanAcNoAddWrk.Text = dr2.GetString(18);
                                }
                                else
                                {
                                    txtLoanAcNoAddWrk.Text = "";
                                }

                                if (dr2["PropertyAddress"] != DBNull.Value)
                                {
                                    txtPropertyDetails.Text = dr2.GetString(19);
                                }
                                else
                                {
                                    txtPropertyDetails.Text = "";
                                }
                                if (dr2["dt_softcopysent"] != DBNull.Value)
                                {
                                    txtSoftCopySent.Text = dr2.GetDateTime(20).ToShortDateString();
                                }
                                else
                                {
                                    txtSoftCopySent.Text = DateTime.Now.Date.ToShortDateString();
                                }

                                DateTime dt_MISclient = Convert.ToDateTime("1990-01-01 00:00:00.000");

                                if (dr2["dt_search_initiated"] != DBNull.Value)
                                {
                                    txtSearchInitiated.Text = dr2.GetDateTime(22).ToShortDateString();
                                }
                                else
                                {
                                    txtSearchInitiated.Text = DateTime.Now.Date.ToShortDateString();
                                }
                                if (dr2["dt_search_received"] != DBNull.Value)
                                {
                                    txtSearchReceived.Text = dr2.GetDateTime(23).ToShortDateString();
                                }
                                else
                                {
                                    txtSearchReceived.Text = DateTime.Now.Date.ToShortDateString();
                                }
                                if (dr2["dt_search_received_receipt"] != DBNull.Value)
                                {
                                    txtReceiptSearch.Text = dr2.GetDateTime(24).ToShortDateString();
                                }
                                else
                                {
                                    txtReceiptSearch.Text = DateTime.Now.Date.ToShortDateString();
                                }
                                if (dr2["dt_hardcopysent"] != DBNull.Value)
                                {
                                    txtHardCopySent.Text = dr2.GetDateTime(25).ToShortDateString();
                                }
                                else
                                {
                                    txtHardCopySent.Text = DateTime.Now.Date.ToShortDateString();
                                }
                                if (dr2["dt_pendingdocumentsrec"] != DBNull.Value)
                                {
                                    txtPendingDocRcd.Text = dr2.GetDateTime(26).ToShortDateString();
                                }
                                else
                                {
                                    txtPendingDocRcd.Text = DateTime.Now.Date.ToShortDateString();
                                }
                                //if (dr2["dt_pendingdocumentsresp"] != DBNull.Value)
                                //{
                                //    txtPendingDocRcsp.Text = dr2.GetDateTime(27).ToShortDateString();
                                //}
                                //else
                                //{
                                //    txtPendingDocRcsp.Text = DateTime.Now.Date.ToShortDateString();
                                //}
                                //if (dr2["dt_finalreportsent"] != DBNull.Value)
                                //{
                                //    txtFinalReportSent.Text = dr2.GetDateTime(28).ToShortDateString();
                                //}
                                //else
                                //{
                                //    txtPendingDocRcsp.Text = DateTime.Now.Date.ToShortDateString();
                                //}

                                if (dr2["branch"] != DBNull.Value)
                                {
                                    txtBranchAddWrk.Text = dr2.GetString(31);
                                }
                                else
                                {
                                    txtBranchAddWrk.Text = "";
                                }
                                //if (dr2["loanamt"] != DBNull.Value)
                                //{
                                //    txtLoanAmtAddWrk.Text = dr2.GetDecimal(32).ToString();
                                //}
                                //else
                                //{
                                //    txtLoanAmtAddWrk.Text = "";
                                //}
                                if (dr2["worddoc"] != DBNull.Value)
                                {
                                    Byte[] strworddoc = (byte[])dr2["worddoc"];
                                    str = System.Text.Encoding.Default.GetString(strworddoc);
                                    Session["strFilePath"] = str;
                                }
                                else
                                {
                                    Session["strFilePath"] = null;
                                }

                                if (dr2["filename"] != DBNull.Value)
                                {
                                    //string filename = dr2.GetString(30);
                                    //string[] values = filename.Split(',');
                                    //for (int i = 0; i < values.Length; i++)
                                    //{
                                    //    values[i] = values[i].Trim();
                                    //    filename = values[i];
                                    //    dpdwnlstFileNames.Items.Add(filename);
                                    //}
                                    //Session["strFileName"] = dr2.GetString(30);
                                }
                                else
                                {
                                    Session["strFileName"] = null;
                                }
                                //TRy
                                if (dr2["EmailID"] != DBNull.Value)
                                {
                                    //txtEmail.Text = dr2.GetString(33);
                                }

                            }
                            dr2.Close();
                        }
                    }
                }
                else
                {
                    //Span1.InnerHtml = "";

                    lblResult.Text = "";
                    lblCatchError.Text = "";
                    lbltesting.Text = "";
                    lblMessageFile.Text = "";
                    lblDelMsg.Text = "";
                    //CEDate.SelectedDate = DateTime.ParseExact(txtDate.Text, CEDate.Format, null);
                    CalendarExtender9.SelectedDate = DateTime.ParseExact(txtStrDtEmp.Text, CalendarExtender9.Format, null);
                    CalendarExtender10.SelectedDate = DateTime.ParseExact(txtEndDtEmp.Text, CalendarExtender10.Format, null);
                    CalendarExtender11.SelectedDate = DateTime.ParseExact(txtStrStarDtClerk.Text, CalendarExtender11.Format, null);
                    CalendarExtender12.SelectedDate = DateTime.ParseExact(txtStrEndDtClerk.Text, CalendarExtender12.Format, null);

                    CalendarExtender1.SelectedDate = DateTime.ParseExact(txtSoftCopySent.Text, CalendarExtender1.Format, null);
                    CalendarExtender2.SelectedDate = DateTime.ParseExact(txtPendingDocRcd.Text, CalendarExtender2.Format, null);
                    CalendarExtender3.SelectedDate = DateTime.ParseExact(txtHardCopySent.Text, CalendarExtender3.Format, null);
                    //CalendarExtender5.SelectedDate = DateTime.ParseExact(txtPendingDocRcsp.Text, CalendarExtender5.Format, null);
                    CalendarExtender4.SelectedDate = DateTime.ParseExact(txtSearchInitiated.Text, CalendarExtender4.Format, null);
                    //CalendarExtender6.SelectedDate = DateTime.ParseExact(txtFinalReportSent.Text, CalendarExtender6.Format, null);
                    CalendarExtender7.SelectedDate = DateTime.ParseExact(txtSearchReceived.Text, CalendarExtender7.Format, null);
                    CalendarExtender8.SelectedDate = DateTime.ParseExact(txtReceiptSearch.Text, CalendarExtender8.Format, null);

                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        protected int getMaxProjectId()
        {
            try
            {
                BLProject blp = new BLProject();
                SqlDataReader dr = blp.getMaxProjectId1();
                if (dr.HasRows)
                {
                    dr.Read();
                    lblMaxPrjId.Text = Convert.ToString(dr.GetInt32(0));
                    projectid = int.Parse(lblMaxPrjId.Text);
                    projectid++;
                    dr.Close();
                }
                return projectid;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();

            }
            return projectid;
        }

        public void fillgridPapers()
        {
            try
            {
                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand();
                DataSet ds = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getDocumentForProject";
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblnameofpapermessage.Text = "";
                    GVPapers.DataSource = ds.Tables[0];
                    GVPapers.DataBind();
                    con.Close();
                }
                else
                {
                    GVPapers.DataSource = null;
                    GVPapers.DataBind();
                    lblnameofpapermessage.Visible = true;
                    lblnameofpapermessage.Text = "Paper details are not available";
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        public void fillgridDocBoy()
        {
            try
            {
                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand();
                DataSet ds = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getDocBoyNameForProject";
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbldocboymessage.Text = "";
                    GVDocBoy.DataSource = ds.Tables[0];
                    GVDocBoy.DataBind();
                    con.Close();
                }
                else
                {
                    GVDocBoy.DataSource = null;
                    GVDocBoy.DataBind();
                    lbldocboymessage.Visible = true;
                    lbldocboymessage.Text = "Document Boyes details are not available";
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        public void fillgridEmployees()
        {
            try
            {
                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand();
                DataSet ds = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getEmpCodeNameForProject";
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblemployeemessage.Text = "";
                    GVEmployees.DataSource = ds.Tables[0];
                    GVEmployees.DataBind();
                    con.Close();
                }
                else
                {
                    GVEmployees.DataSource = null;
                    GVEmployees.DataBind();
                    lblemployeemessage.Visible = true;
                    lblemployeemessage.Text = "Employee Details are not available ";
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
         Updated By : raj
         Updated Date :- 16/04/2015
         Purpose :- Document Boy Search On Dropdown List
      */
        #region-----------fillgridService------------
        public void fillgridService()
        {
            try
            {
                int intClientID = int.Parse(lblCliId1.Text);
                BLServices blpr = new BLServices();
                SqlDataReader dr = blpr.getServicePrice1(intClientID);
                System.Data.DataTable dt = new System.Data.DataTable();

                if (dr.HasRows)
                {
                    lblServices.Text = "";
                    dt.Load(dr);
                    GVServices.DataSource = dt;
                    GVServices.DataBind();
                    if (ddlCliNm.SelectedItem.Text == "--Select--")
                    {
                        GVServices.DataSource = null;
                        GVServices.DataBind();
                        lblServices.Visible = true;
                        lblServices.Text = "Services are not available for the selected Client";
                    }
                }
                else
                {
                    GVServices.DataSource = null;
                    GVServices.DataBind();
                    lblServices.Visible = true;
                    lblServices.Text = "Services are not available for the selected Client";
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        public void fillgridClerk()
        {
            try
            {
                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand();
                DataSet ds = new DataSet();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getClerkNameForProject";
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblsearchclarkmessage.Text = "";
                    GVClerk.DataSource = ds.Tables[0];
                    GVClerk.DataBind();
                    con.Close();
                }
                else
                {
                    GVClerk.DataSource = null;
                    GVClerk.DataBind();
                    lblsearchclarkmessage.Visible = true;
                    lblsearchclarkmessage.Text = "Clark details not available";
                }

            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void ddlCliNm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLAddInvoice blInv = new BLAddInvoice();
                string strClientName1 = Convert.ToString(ddlCliNm.SelectedItem.Text);
                SqlDataReader dr = blInv.getClIdByName(strClientName1);
                if (dr.HasRows)
                {
                    dr.Read();
                    lblCliId1.Text = dr.GetInt32(0).ToString();
                }
                dr.Close();
                fillgridService();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void ChkBxSCS_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkBxSCS.Checked == true)
                    txtSoftCopySent.Enabled = true;
                else
                    txtSoftCopySent.Enabled = false;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void ChkBxSI_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkBxSI.Checked == true)
                    txtSearchInitiated.Enabled = true;
                else
                    txtSearchInitiated.Enabled = false;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void ChkBxSR_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkBxSR.Checked == true)
                    txtSearchReceived.Enabled = true;
                else
                    txtSearchReceived.Enabled = false;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void ChkBxPDR_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkBxPDR.Checked == true)
                    txtPendingDocRcd.Enabled = true;
                else
                    txtPendingDocRcd.Enabled = false;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        //protected void ChkBxPDRcsp_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ChkBxPDRcsp.Checked == true)
        //            txtPendingDocRcsp.Enabled = true;
        //        else
        //            txtPendingDocRcsp.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}

        protected void ChkBxRS_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkBxRS.Checked == true)
                    txtReceiptSearch.Enabled = true;
                else
                    txtReceiptSearch.Enabled = false;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void ChkBxHCS_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkBxHCS.Checked == true)
                    txtHardCopySent.Enabled = true;
                else
                    txtHardCopySent.Enabled = false;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        //protected void ChkBxFRS_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ChkBxFRS.Checked == true)
        //            txtFinalReportSent.Enabled = true;
        //        else
        //            txtFinalReportSent.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}

        protected void GVPapers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void setparameters()
        {
            try
            {
                dtProjectDate = Convert.ToDateTime(txtDate.Text);
                intClientID = int.Parse(lblCliId1.Text);
                strClientName = ddlCliNm.SelectedItem.Text;

                intTypeOfWorkID = int.Parse(lblTypWrkID.Text);

                strTypeOfWork = ddlTypWrk.SelectedItem.Text;
                strCaseName = txtCasNm.Text;
                //int intExternalWork = 0;
                if (chkBxDsReqExtWrk.Checked == true)
                    intExternalWork = 1;
                else
                    intExternalWork = 0;

                //int intNeedSearch = 0;
                if (boolNeedSearch == true)
                    chkBxDsReqSrch.Checked = true;
                else
                    chkBxDsReqSrch.Checked = false;

                strRemarks = txtRemarks.Text;
                decPrice = decimal.Parse(txtPrice.Text);
                decOtherCharges = decimal.Parse(txtOtherCharge.Text);
                decTotalAmount = decimal.Parse(txtTotAmt.Text);
                strStatus = ddlStatus.SelectedItem.Text;
                // int intIsDeleted = 0;
                if (rbYesIsDel.Checked == true)
                    boolIsDeleted = true;
                else
                    boolIsDeleted = false;

                //int intApprove = 0;
                if (ChkBxApprovProject.Checked == true)
                    intApprove = 1;
                else
                    intApprove = 0;

                decServiceTax = decimal.Parse(txtServiceTax.Text);
                strReferenceNo = txtRefNo.Text;
                strLoanNO = txtLoanAcNoAddWrk.Text;
                strPropertyAddress = txtPropertyDetails.Text;
                if (ChkBxSCS.Checked == true)
                {
                    dt_softcopysent = Convert.ToDateTime(txtSoftCopySent.Text);
                }
                else
                {
                    dt_softcopysent = Convert.ToDateTime("1990-01-01 00:00:00.000");
                }

                dt_MISclient = Convert.ToDateTime("1990-01-01 00:00:00.000");//"1990-01-01 00:00:00.000"
                
                if (ChkBxSI.Checked == true)
                {
                    dt_search_initiated = Convert.ToDateTime(txtSearchInitiated.Text);
                }
                else
                {
                    dt_search_initiated = Convert.ToDateTime("1990-01-01 00:00:00.000");
                }

                if (ChkBxSR.Checked == true)
                {
                    dt_search_received = Convert.ToDateTime(txtSearchReceived.Text);
                }
                else
                {
                    dt_search_received = Convert.ToDateTime("1990-01-01 00:00:00.000");
                }

                if (ChkBxRS.Checked == true)
                {
                    dt_search_received_receipt = Convert.ToDateTime(txtReceiptSearch.Text);
                }
                else
                {
                    dt_search_received_receipt = Convert.ToDateTime("1990-01-01 00:00:00.000");
                }

                if (ChkBxHCS.Checked == true)
                {
                    dt_hardcopysent = Convert.ToDateTime(txtHardCopySent.Text);
                }
                else
                {
                    dt_hardcopysent = Convert.ToDateTime("1990-01-01 00:00:00.000");
                }

                if (ChkBxPDR.Checked ==true)
                {
                    dt_pendingdocumentsrec = Convert.ToDateTime(txtPendingDocRcd.Text);
                }
                else
                {
                    dt_pendingdocumentsrec = Convert.ToDateTime("1990-01-01 00:00:00.000");
                }

                dt_pendingdocumentsresp = Convert.ToDateTime("1990-01-01 00:00:00.000");
                dt_finalreportsent = Convert.ToDateTime("1990-01-01 00:00:00.000");
                strEmailID = "";

                strbranch = txtBranchAddWrk.Text;
                //if (txtLoanAmtAddWrk.Text != "")
                //{
                //    decloanamt = decimal.Parse(txtLoanAmtAddWrk.Text);
                //}
                //else
                //    decloanamt = 0;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void AddSelectedRecords(int intProjectId)
        {
            try
            {
                BLProject blp = new BLProject();
                //Data Table for save Selected Documents and delete unselected document
                int intProjectId1 = intProjectId;
                System.Data.DataTable dtSelDocument = new System.Data.DataTable();
                System.Data.DataTable dtUnSelDocument = new System.Data.DataTable();
                dtSelDocument.Columns.AddRange(new DataColumn[1] { new DataColumn("Docid") });
                dtSelDocument.Columns.AddRange(new DataColumn[1] { new DataColumn("Document") });
                dtUnSelDocument.Columns.AddRange(new DataColumn[1] { new DataColumn("Docid") });
                foreach (GridViewRow gvrow in GVPapers.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        //finding the checkbox in the gridview
                        System.Web.UI.WebControls.CheckBox ChkBxSelDoc = (gvrow.Cells[0].FindControl("ChkBxSelDoc") as System.Web.UI.WebControls.CheckBox);
                        System.Web.UI.WebControls.Label lblDocId = (gvrow.Cells[0].FindControl("lblDocumentId") as System.Web.UI.WebControls.Label);
                        System.Web.UI.WebControls.Label lblDocName = (gvrow.Cells[0].FindControl("lblDocumentName") as System.Web.UI.WebControls.Label);

                        // checking which checkbox are selected
                        if (ChkBxSelDoc.Checked)
                        {
                            int Docid = int.Parse(lblDocId.Text);
                            string Document = lblDocName.Text;
                            dtSelDocument.Rows.Add(Docid, Document);
                        }
                        else
                        {
                            int Docid = int.Parse(lblDocId.Text);
                            dtUnSelDocument.Rows.Add(Docid);
                        }
                    }
                }
                // System.Data.DataTable dt = (System.Data.DataTable)dtSelDocument;
                for (int i = 0; i < dtSelDocument.Rows.Count; i++)
                {
                    int docid = int.Parse(dtSelDocument.Rows[i].Field<string>(0));
                    string document = dtSelDocument.Rows[i].Field<string>(1);
                    blp.saveSelectedDoc1(intProjectId, docid, document);
                }
                for (int i = 0; i < dtUnSelDocument.Rows.Count; i++)
                {
                    int docid = int.Parse(dtUnSelDocument.Rows[i].Field<string>(0));
                    blp.delUnSelectDoc1(intProjectId, docid);
                }

                // Data Table for save Selected Employees and delete unselected employee

                System.Data.DataTable dtSelEmployee = new System.Data.DataTable();
                System.Data.DataTable dtUnSelEmployee = new System.Data.DataTable();
                dtSelEmployee.Columns.AddRange(new DataColumn[1] { new DataColumn("Empid") });
                dtSelEmployee.Columns.AddRange(new DataColumn[1] { new DataColumn("EmpCode") });
                dtSelEmployee.Columns.AddRange(new DataColumn[1] { new DataColumn("StartDt") });
                dtSelEmployee.Columns.AddRange(new DataColumn[1] { new DataColumn("EndDt") });
                dtUnSelEmployee.Columns.AddRange(new DataColumn[1] { new DataColumn("Empid") });
                foreach (GridViewRow gvrow in GVEmployees.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        //finding the checkbox in the gridview
                        System.Web.UI.WebControls.CheckBox ChkBxSelEmp = (gvrow.Cells[0].FindControl("ChkBxSelEmp") as System.Web.UI.WebControls.CheckBox);
                        System.Web.UI.WebControls.Label lblEmployeeID = (gvrow.Cells[0].FindControl("lblEmployeeID") as System.Web.UI.WebControls.Label);
                        System.Web.UI.WebControls.Label lblEmployeeCode = (gvrow.Cells[0].FindControl("lblEmployeeCode") as System.Web.UI.WebControls.Label);

                        // checking which checkbox are selected
                        if (ChkBxSelEmp.Checked)
                        {
                            int Empid = int.Parse(lblEmployeeID.Text);
                            string EmpCode = lblEmployeeCode.Text;
                            DateTime StartDt = DateTime.Parse(txtStrDtEmp.Text);
                            DateTime EndDt = DateTime.Parse(txtEndDtEmp.Text);
                            dtSelEmployee.Rows.Add(Empid, EmpCode, StartDt, EndDt);
                        }
                        else
                        {
                            int Empid = int.Parse(lblEmployeeID.Text);
                            dtUnSelEmployee.Rows.Add(Empid);
                        }

                    }
                }
                //System.Data.DataTable dt1 = (System.Data.DataTable)dtSelEmployee;
                for (int i = 0; i < dtSelEmployee.Rows.Count; i++)
                {
                    string EmpCode = dtSelEmployee.Rows[i].Field<string>(1);
                    DateTime StartDt = Convert.ToDateTime(dtSelEmployee.Rows[i].Field<string>(2));
                    DateTime EndDt = Convert.ToDateTime(dtSelEmployee.Rows[i].Field<string>(3));
                    int intEmployeeID = int.Parse(dtSelEmployee.Rows[i].Field<string>(0));
                    string strEmployeeName = EmpCode;
                    blp.saveSelectedEmp1(intProjectId, intEmployeeID, strEmployeeName, StartDt, EndDt);
                }
                for (int i = 0; i < dtUnSelEmployee.Rows.Count; i++)
                {
                    int empid = int.Parse(dtUnSelEmployee.Rows[i].Field<string>(0));
                    blp.delUnSelectedEmp1(intProjectId, empid);
                }
                // Data Table for Selected save Clerk and delete unselected clerk
                System.Data.DataTable dtSelClerk = new System.Data.DataTable();
                System.Data.DataTable dtUnSelClerk = new System.Data.DataTable();
                dtSelClerk.Columns.AddRange(new DataColumn[1] { new DataColumn("Clerkid") });
                dtSelClerk.Columns.AddRange(new DataColumn[1] { new DataColumn("ClerkName") });
                dtSelClerk.Columns.AddRange(new DataColumn[1] { new DataColumn("StartDt") });
                dtSelClerk.Columns.AddRange(new DataColumn[1] { new DataColumn("EndDt") });
                dtUnSelClerk.Columns.AddRange(new DataColumn[1] { new DataColumn("Clerkid") });
                foreach (GridViewRow gvrow in GVClerk.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        //finding the checkbox in the gridview
                        System.Web.UI.WebControls.CheckBox ChkBxSelClerk = (gvrow.Cells[0].FindControl("ChkBxSelClerk") as System.Web.UI.WebControls.CheckBox);

                        System.Web.UI.WebControls.Label lblClerkID = (gvrow.Cells[0].FindControl("lblClerkID") as System.Web.UI.WebControls.Label);
                        System.Web.UI.WebControls.Label lblClerkName = (gvrow.Cells[0].FindControl("lblClerkName") as System.Web.UI.WebControls.Label);

                        // checking which checkbox are selected
                        if (ChkBxSelClerk.Checked)
                        {
                            int Clerkid = int.Parse(lblClerkID.Text);
                            string ClerkName = lblClerkName.Text;
                            DateTime StartDt = DateTime.Parse(txtStrStarDtClerk.Text);
                            DateTime EndDt = DateTime.Parse(txtStrEndDtClerk.Text);
                            dtSelClerk.Rows.Add(Clerkid, ClerkName, StartDt, EndDt);

                        }
                        else
                        {
                            int Clerkid = int.Parse(lblClerkID.Text);
                            dtUnSelClerk.Rows.Add(Clerkid);
                        }
                    }
                }
                //System.Data.DataTable dt4 = (System.Data.DataTable)dtSelClerk;
                for (int i = 0; i < dtSelClerk.Rows.Count; i++)
                {
                    int Clerkid = int.Parse(dtSelClerk.Rows[i].Field<string>(0));
                    string ClerkName = dtSelClerk.Rows[i].Field<string>(1);
                    DateTime StartDt = Convert.ToDateTime(dtSelClerk.Rows[i].Field<string>(2));
                    DateTime EndDt = Convert.ToDateTime(dtSelClerk.Rows[i].Field<string>(3));
                    blp.saveSelectedClerk1(intProjectId, Clerkid, ClerkName, StartDt, EndDt);
                }
                for (int i = 0; i < dtUnSelClerk.Rows.Count; i++)
                {
                    int Clerkid = int.Parse(dtUnSelClerk.Rows[i].Field<string>(0));
                    blp.delUnselectClerk1(intProjectId, Clerkid);
                }

                //Data Table for save Selected Services and delete unselected service

                System.Data.DataTable dtSelService = new System.Data.DataTable();
                System.Data.DataTable dtUnSelService = new System.Data.DataTable();
                dtSelService.Columns.AddRange(new DataColumn[1] { new DataColumn("Serviceid") });
                dtSelService.Columns.AddRange(new DataColumn[1] { new DataColumn("Service") });
                dtSelService.Columns.AddRange(new DataColumn[1] { new DataColumn("Price") });
                dtUnSelService.Columns.AddRange(new DataColumn[1] { new DataColumn("Serviceid") });
                foreach (GridViewRow gvrow in GVServices.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        //finding the checkbox in the gridview
                        System.Web.UI.WebControls.CheckBox ChkBxSelService = (gvrow.Cells[0].FindControl("ChkBxSelService") as System.Web.UI.WebControls.CheckBox);

                        System.Web.UI.WebControls.Label lblServiceID = (gvrow.Cells[0].FindControl("lblServiceID") as System.Web.UI.WebControls.Label);
                        System.Web.UI.WebControls.Label lblServiceName = (gvrow.Cells[0].FindControl("lblServiceName") as System.Web.UI.WebControls.Label);
                        System.Web.UI.WebControls.Label lblServicePrice = (gvrow.Cells[0].FindControl("lblServicePrice") as System.Web.UI.WebControls.Label);

                        // checking which checkbox are selected
                        if (ChkBxSelService.Checked)
                        {
                            int Serviceid = int.Parse(lblServiceID.Text);
                            string Service = lblServiceName.Text;
                            decimal Price = decimal.Parse(lblServicePrice.Text);
                            dtSelService.Rows.Add(Serviceid, Service, Price);
                        }
                        else
                        {
                            int Serviceid = int.Parse(lblServiceID.Text);
                            dtUnSelService.Rows.Add(Serviceid);
                        }
                    }
                }
                for (int i = 0; i < dtSelService.Rows.Count; i++)
                {
                    int Serviceid = int.Parse(dtSelService.Rows[i].Field<string>(0));
                    string Service = dtSelService.Rows[i].Field<string>(1);
                    float flotPrice = float.Parse(dtSelService.Rows[i].Field<string>(2));
                    blp.saveSelectedServices1(intProjectId, Serviceid, Service, flotPrice);
                }
                for (int i = 0; i < dtUnSelService.Rows.Count; i++)
                {
                    int Serviceid = int.Parse(dtUnSelService.Rows[i].Field<string>(0));
                    blp.delUnSelectedServices1(intProjectId, Serviceid);
                }

                //Data Table for save Selected DocumentBoys and delete unselected Document boy

                System.Data.DataTable dtSelDocumentBoy = new System.Data.DataTable();
                System.Data.DataTable dtUnSelDocumentBoy = new System.Data.DataTable();
                dtSelDocumentBoy.Columns.AddRange(new DataColumn[1] { new DataColumn("DocBoyid") });
                dtSelDocumentBoy.Columns.AddRange(new DataColumn[1] { new DataColumn("DocumentBoy") });
                dtUnSelDocumentBoy.Columns.AddRange(new DataColumn[1] { new DataColumn("DocBoyid") });
                foreach (GridViewRow gvrow in GVDocBoy.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        //finding the checkbox in the gridview
                        System.Web.UI.WebControls.CheckBox ChkBxSelDocBoy = (gvrow.Cells[0].FindControl("ChkBxSelDocBoy") as System.Web.UI.WebControls.CheckBox);
                        System.Web.UI.WebControls.Label lblDocumentBoyID = (gvrow.Cells[0].FindControl("lblDocumentBoyID") as System.Web.UI.WebControls.Label);
                        System.Web.UI.WebControls.Label lblDocumentBoyName = (gvrow.Cells[0].FindControl("lblDocumentBoyName") as System.Web.UI.WebControls.Label);
                        
                        // checking which checkbox are selected
                        if (ChkBxSelDocBoy.Checked)
                        {
                            int DocBoyid = int.Parse(lblDocumentBoyID.Text);
                            string DocumentBoy = lblDocumentBoyName.Text;
                            dtSelDocumentBoy.Rows.Add(DocBoyid, DocumentBoy);
                        }
                        else
                        {
                            int DocBoyid = int.Parse(lblDocumentBoyID.Text);
                            dtUnSelDocumentBoy.Rows.Add(DocBoyid);
                        }
                    }
                }
                for (int i = 0; i < dtSelDocumentBoy.Rows.Count; i++)
                {
                    int DocBoyid = int.Parse(dtSelDocumentBoy.Rows[i].Field<string>(0));
                    string DocBoy = dtSelDocumentBoy.Rows[i].Field<string>(1);
                    blp.saveSelectedDocumentBoy1(intProjectId, DocBoyid, DocBoy);
                }
                for (int i = 0; i < dtUnSelDocumentBoy.Rows.Count; i++)
                {
                    int DocBoyid = int.Parse(dtUnSelDocumentBoy.Rows[i].Field<string>(0));
                    blp.delUnSelectedDocBoy1(intProjectId, DocBoyid);
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Label1.Text = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveProject();
            }
            catch (Exception ex)
            {
                lblMessageFile.Text = ex.Message.ToString();
            }
        }

        private void SaveProject()
        {
            try
            {
                setparameters();

                if (Request.QueryString["ProjectId"] != null)
                {
                    //if (dpdwnlstFileNames.Text == "" || dpdwnlstFileNames.Text == null)
                    //{
                    //    if (lblFileuploadValue.Text == "0")
                    //    {
                    //        lbltesting.Text = "Please select file to upload before saving the project";
                    //    }
                    //    else
                    //    {
                    //        UpdateProject();
                    //        lbltesting.Text = "";
                    //    }
                    //}
                    //else
                    //{
                    UpdateProject();
                    //}
                }
                else
                {
                    if (lblFileuploadValue.Text == "0")
                    {
                        //lbltesting.Text = "Please select file to upload before saving the project";
                        strworddoc = null;
                        strfilename = null;
                        BLObj.saveProject1(dtProjectDate, intClientID, strClientName, intTypeOfWorkID, strTypeOfWork, strCaseName, intExternalWork, boolNeedSearch, strRemarks, decPrice, decOtherCharges, decTotalAmount, strStatus, boolIsDeleted, intApprove, decServiceTax, strReferenceNo, strLoanNO, strPropertyAddress, dt_softcopysent, dt_MISclient, dt_search_initiated, dt_search_received, dt_search_received_receipt, dt_hardcopysent, dt_pendingdocumentsrec, dt_pendingdocumentsresp, dt_finalreportsent, strworddoc, strfilename, strbranch, decloanamt, strEmailID);
                        //fillgrid();
                        // Span2.InnerHtml = "";
                        // Span1.InnerHtml = "";
                        lblMessageFile.Text = "";
                        Session["ProjectId"] = null;
                        Session["strFileName"] = null;
                        Session["strFilePath"] = null;
                        SqlDataReader dr = BLObj.getMaxProjectId1();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lblMaxPrjId.Text = Convert.ToString(dr.GetInt32(0));
                            dr.Close();
                        }
                        int maxprjId = int.Parse(lblMaxPrjId.Text);
                        AddSelectedRecords(maxprjId);
                        Clearfields();
                        lbltesting.Text = "";
                        lblResult.Visible = true;
                        lblResult.Text = "Project Details are Added Successfully";
                    }
                    else
                    {
                        if (Session["strFilePath"] == null)
                        {
                            strworddoc = null;
                        }
                        else
                        {
                            strworddoc = Session["strFilePath"].ToString();
                        }
                        if (Session["strFileName"] == null)
                        {
                            strfilename = null;
                        }
                        else
                        {
                            strfilename = Session["strFileName"].ToString();
                        }
                        BLObj.saveProject1(dtProjectDate, intClientID, strClientName, intTypeOfWorkID, strTypeOfWork, strCaseName, intExternalWork, boolNeedSearch, strRemarks, decPrice, decOtherCharges, decTotalAmount, strStatus, boolIsDeleted, intApprove, decServiceTax, strReferenceNo, strLoanNO, strPropertyAddress, dt_softcopysent, dt_MISclient, dt_search_initiated, dt_search_received, dt_search_received_receipt, dt_hardcopysent, dt_pendingdocumentsrec, dt_pendingdocumentsresp, dt_finalreportsent, strworddoc, strfilename, strbranch, decloanamt, strEmailID);
                        //fillgrid();

                        lblMessageFile.Text = "";
                        Session["ProjectId"] = null;
                        Session["strFileName"] = null;
                        Session["strFilePath"] = null;
                        SqlDataReader dr = BLObj.getMaxProjectId1();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lblMaxPrjId.Text = Convert.ToString(dr.GetInt32(0));
                            dr.Close();
                        }
                        int maxprjId = int.Parse(lblMaxPrjId.Text);
                        AddSelectedRecords(maxprjId);
                        Clearfields();
                        lbltesting.Text = "";
                        lblResult.Visible = true;
                        lblResult.Text = "Project Details are Added Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void UpdateProject()
        {
            try
            {
                if (Session["strFilePath"] == null)
                {
                    strworddoc = null;
                }
                else
                {
                    strworddoc = Session["strFilePath"].ToString();
                }
                if (Session["strFileName"] == null)
                {
                    strfilename = null;
                }
                else
                {
                    strfilename = Session["strFileName"].ToString();
                }
                intProjectId = int.Parse(Request.QueryString["ProjectId"]);
                BLObj.updateProjects1(dtProjectDate, intProjectId, strClientName, intTypeOfWorkID, strTypeOfWork, strCaseName, intExternalWork, boolNeedSearch, strRemarks, decPrice, decOtherCharges, decTotalAmount, strStatus, boolIsDeleted, intApprove, decServiceTax, strReferenceNo, strLoanNO, strPropertyAddress, dt_softcopysent, dt_MISclient, dt_search_initiated, dt_search_received, dt_search_received_receipt, dt_hardcopysent, dt_pendingdocumentsrec, dt_pendingdocumentsresp, dt_finalreportsent, strworddoc, strfilename, strbranch, decloanamt, strEmailID);

                //Span2.InnerHtml = "";
                Session["ProjectId"] = null;
                Session["strFileName"] = null;
                Session["strFilePath"] = null;
                //dpdwnlstFileNames.Items.Clear();
                //Session.Clear();
                AddSelectedRecords(intProjectId);
                Clearfields();
                ddlCliNm.Enabled = true;
                ddlTypWrk.Enabled = true;
                lblResult.Visible = true;
                lblResult.Text = "Project Details are Updated Successfully";
                //Span1.InnerHtml = "";
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void Clearfields()
        {
            try
            {
                lblCliId1.Text = "";
                lblTypWrkID.Text = "";
                txtCasNm.Text = "";
                chkBxDsReqExtWrk.Checked = false;
                chkBxDsReqSrch.Checked = false;
                txtRemarks.Text = "";
                txtPrice.Text = "";
                txtOtherCharge.Text = "";
                txtTotAmt.Text = "";
                rbYesIsDel.Checked = false;
                ChkBxApprovProject.Checked = false;
                txtServiceTax.Text = "";
                txtRefNo.Text = "";
                txtLoanAcNoAddWrk.Text = "";
                txtPropertyDetails.Text = "";
                txtBranchAddWrk.Text = "";
                //txtLoanAmtAddWrk.Text = "";
                ddlCliNm.SelectedIndex = -1;
                ddlStatus.SelectedIndex = -1;
                ddlTypWrk.SelectedIndex = -1;
                //txtFileName.Text = "";
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        //  /*
        //   Create By :- Kunal
        //   Created Date :- 13/3/2015
        //   Updated Date :- 
        //   Purpose :- Add Edit Work Upload File
        //*/
        //  #region-----------UploadButton_Click------------
        //  protected void UploadButton_Click(object sender, EventArgs e)
        //  {
        //      try
        //      {
        //          if (FileUpload1.HasFile)
        //          {
        //              string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
        //              string fileExt = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);

        //              if (fileExt == ".doc" || fileExt == ".docx")
        //              {
        //                  try
        //                  {
        //                      Session["uploadedfile"] = fileName;
        //                      if (Request.QueryString["ProjectId"] != null)
        //                      {
        //                          projectid = int.Parse(Request.QueryString["ProjectId"]);
        //                          FileUpload(projectid);
        //                      }
        //                      else
        //                      {
        //                          projectid = getMaxProjectId();
        //                          FileUpload(projectid);
        //                          //cbpdf.Visible = true;
        //                          //btnOpenAddWrk.Enabled = true;
        //                      }
        //                  }
        //                  catch
        //                  {
        //                      lblMessageFile.Text = "Some Error occured.";
        //                  }
        //              }
        //              else
        //              {
        //                  lblMessageFile.Text = "File is not valid please select .doc or .docx file only.";
        //              }
        //          }
        //      }
        //      catch (Exception ex)
        //      {
        //          lblCatchError.Text = ex.Message.ToString();
        //      }

        //  }
        //  #endregion

        //  char suffix = 'a'; string file = "";
        //  protected void FileUpload(int projectid)
        //  {
        //      try
        //      {
        //          string dirPath = Server.MapPath("~/Document/");
        //          string filenm = projectid.ToString();
        //          string fileExt = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
        //          BLProject BlObjGetDetails = new BLProject();
        //          if (Request.QueryString["ProjectId"] != null)
        //          {
        //              SqlDataReader dr2 = BlObjGetDetails.getProjectDetailsForUpdate1(projectid);
        //              dr2.Read();
        //              //Split Mutiple files separated by comma and get last filename
        //              if (dr2["filename"] != DBNull.Value)
        //              {
        //                  string[] Files = Directory.GetFiles(dirPath, filenm + "*.*", SearchOption.AllDirectories);
        //                  int getFileCount = Files.Length;
        //                  filename = dr2.GetString(30);
        //                  values = filename.Split(',');
        //                  for (int i = 0; i < values.Length; i++)
        //                  {
        //                      values[i] = values[i].Trim();
        //                      file = values[i];
        //                  }
        //                  if (Session["filenew"] == null)
        //                  {
        //                      Session["filenew"] = filename;
        //                  }

        //              }
        //              else
        //              {
        //                  string[] Files = Directory.GetFiles(dirPath, filenm + ".*", SearchOption.AllDirectories);
        //                  int getFileCount = Files.Length;
        //                  if (getFileCount == 0)
        //                  {
        //                      file = projectid.ToString();
        //                  }
        //                  foreach (string f in Files)
        //                  {
        //                      if (f.Contains(filenm))
        //                      {
        //                          file = Session["filenew"].ToString();
        //                          suffix = 'a';
        //                      }
        //                      else
        //                      {
        //                          file = projectid.ToString();
        //                      }
        //                  }
        //              }
        //              dr2.Close();
        //              //Split Upto filename and . character
        //              values = file.Split('.');
        //              for (int i = 0; i < values.Length; i++)
        //              {
        //                  values[i] = values[i].Trim();
        //                  file = values[i];
        //                  break;
        //              }

        //              int length = file.Length;
        //              suffix = file.Last();
        //              if (Char.IsDigit(suffix))
        //              {
        //                  suffix = 'a';
        //              }
        //          }
        //          strFileName = FileUpload1.PostedFile.FileName;
        //          c = projectid.ToString() + fileExt;
        //          string[] Files1 = Directory.GetFiles(dirPath, filenm + "*.*", SearchOption.AllDirectories);
        //          int getFileCount1 = Files1.Length;
        //          if (getFileCount1 == 0)
        //          {
        //              strFilePath = Server.MapPath("~\\Document\\" + c);
        //              FileUpload1.SaveAs(Server.MapPath("~\\Document\\") + c);
        //              filenew = c;
        //              Session["file"] = filenew;
        //              Session["filenew"] = filenew;
        //              Session["strFilePath"] = strFilePath;
        //              lblMessageFile.ForeColor = System.Drawing.Color.Green;
        //              lblMessageFile.Text = c + " file Uploaded Sucessfully.";
        //              lblFileuploadValue.Text = "1";

        //          }
        //          else
        //          {

        //              if (Session["file"] != null)
        //              {
        //                  file = Session["file"].ToString();
        //              }

        //              if (Session["chars"] != null)
        //              {
        //                  suffix = Convert.ToChar(Session["chars"]);
        //              }
        //              if (file.Contains(suffix))
        //              {
        //                  suffix++;

        //              }

        //              c = projectid.ToString() + suffix + fileExt;
        //              Session["chars"] = suffix;
        //              strFilePath = Session["strFilePath"].ToString() + "," + Server.MapPath("~\\Document\\" + c);
        //              FileUpload1.SaveAs(Server.MapPath("~\\Document\\") + c);
        //              if (Session["filenew"] != null)
        //              {
        //                  filenew = Session["filenew"].ToString();
        //              }
        //              if (Request.QueryString["ProjectId"] != null)
        //              {
        //                  dpdwnlstFileNames.Items.Add(c);
        //                  //filenew = filename;
        //              }
        //              filenew = filenew + "," + c;
        //              Session["file"] = c;

        //              Session["filenew"] = filenew;
        //              lblMessageFile.ForeColor = System.Drawing.Color.Green;
        //              lblMessageFile.Text = c + " file Uploaded Sucessfully.";
        //              lblFileuploadValue.Text = "1";
        //          }
        //          Session["strFilePath"] = strFilePath;
        //          Session["strFileName"] = filenew;
        //      }
        //      catch (Exception ex)
        //      {
        //          lblCatchError.Text = ex.Message.ToString();
        //      }
        //  }

        protected void ddlTypWrk_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int intTypeOfWorkID = 0;
                BLProject blp = new BLProject();
                string strWork = ddlTypWrk.SelectedItem.Text;
                SqlDataReader dr = blp.getTypWrkIdByWrk1(strWork);
                if (dr.HasRows)
                {
                    dr.Read();
                    intTypeOfWorkID = dr.GetInt32(0);
                }
                dr.Close();
                lblTypWrkID.Text = intTypeOfWorkID.ToString();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void CheckCeckboxForAmt()
        {
            try
            {
                decimal Price = 0;
                foreach (GridViewRow gvrow in GVServices.Rows)
                {

                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        //finding the checkbox in the gridview
                        System.Web.UI.WebControls.CheckBox ChkBxSelService = (gvrow.Cells[0].FindControl("ChkBxSelService") as System.Web.UI.WebControls.CheckBox);
                        // checking which checkbox are selected
                        if (ChkBxSelService.Checked == true)
                        {
                            System.Web.UI.WebControls.Label lblServicePrice = (gvrow.Cells[0].FindControl("lblServicePrice") as System.Web.UI.WebControls.Label);
                            decimal IniPrice = Convert.ToDecimal(lblServicePrice.Text);
                            Price = Price + IniPrice;
                            txtPrice.Text = Convert.ToString(Price);
                            txtTotAmt.Text = Convert.ToString(Price);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }


        protected void ChkBxSelService_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // CheckCeckboxForAmt();
                if (GVServices.SelectedIndex == -1)
                {
                    txtPrice.Text = "0";
                    txtTotAmt.Text = "0";
                }
                CheckCeckboxForAmt();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtOtherCharge.Text))
                {
                    txtTotAmt.Text = (Convert.ToDecimal(txtPrice.Text) + Convert.ToDecimal(txtOtherCharge.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void txtOtherCharge_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtOtherCharge.Text))
                {
                    txtTotAmt.Text = (Convert.ToDecimal(txtPrice.Text) + Convert.ToDecimal(txtOtherCharge.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnResetAmt_Click(object sender, EventArgs e)
        {
            try
            {
                txtPrice.Text = "0";
                txtOtherCharge.Text = "0";
                txtTotAmt.Text = "0";
                txtServiceTax.Text = "0";
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
        Purpose :- Add Edit Work Open Doc File
     */
        //#region-----------btnOpenAddWrk_Click------------
        //protected void btnOpenAddWrk_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //if (cbpdf.Checked == true)
        //        //{
        //        //    OpenpdfFileByBrowser();
        //        //}
        //        //else
        //        //{
        //            OpenMSWordFileByBrowser();
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}
        //#endregion
        /**** Name:-Yogita
         * Purpose:-To check delete file
         * Update By:-Yogita
         * Updated date:-8/4/2015
         * **********/
        //#region -------------To delete file in edit mode--------
        //protected void btnDelAddWrk_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string strfile; BLProject blp = new BLProject(); string filename, strConcatfile = "", filePath = "", strConFilePath = "", deleteallfile, filenew = "";
        //        DialogResult result = MessageBox.Show("Are You sure to Delete Document");
        //        //string strfile = Session["strFileName"].ToString();
        //        strfile = dpdwnlstFileNames.SelectedItem.Text;
        //        filename = Session["strFileName"].ToString();
        //        filePath = Session["strFilePath"].ToString();
        //        SqlDataReader dr2 = BLObj.getProjectDetailsForUpdate1(projectid);
        //        dr2.Read();
        //        //Split Mutiple files separated by comma and get last filename

        //        string[] values = filename.Split(',');
        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            values[i] = values[i].Trim();
        //            filename = values[i];
        //            if (filename != strfile)
        //            {
        //                //if (i == values.Length )
        //                //{
        //                //    strConcatfile=filename 
        //                //}
        //                strConcatfile = strConcatfile + "," + filename;
        //            }
        //        }
        //        strConcatfile = strConcatfile.TrimStart(',');
        //        string path = Server.MapPath("~/Document/") + strfile;
        //        values = filePath.Split(',');
        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            values[i] = values[i].Trim();
        //            filePath = values[i];
        //            if (filePath != path)
        //            {
        //                strConFilePath = strConFilePath + "," + filePath;
        //            }
        //        }
        //        strConFilePath = strConFilePath.TrimStart(',');
        //        if (Request.QueryString["ProjectId"] != null)
        //        {
        //            projectid = int.Parse(Request.QueryString["ProjectId"]);
        //        }
        //        deleteallfile = projectid.ToString();
        //        FileInfo file = new FileInfo(path);
        //        string dirPath = Server.MapPath("~/Document/");
        //        if (result == DialogResult.OK)
        //        {

        //            if (Session["strFilePath"].ToString() != null && Session["strFileName"].ToString() != null)
        //            {
        //                if (file.Exists)
        //                {
        //                    file.Delete();
        //                    lblDelMsg.Visible = true;
        //                    lblDelMsg.Text = strfile + " file deleted successfully";
        //                    string msg = blp.UpadateFileDelete(projectid, strConFilePath, strConcatfile);
        //                    string[] Files = Directory.GetFiles(dirPath, deleteallfile + "*.*", SearchOption.AllDirectories);
        //                    int getFileCount = Files.Length;
        //                    if (getFileCount == 0)
        //                    {
        //                        blp.delDocOnProject1(projectid);
        //                    }
        //                    dr2 = BLObj.getProjectDetailsForUpdate1(projectid);
        //                    dr2.Read();
        //                    if (dr2["filename"] != DBNull.Value)
        //                    {
        //                        filenew = dr2.GetString(30);
        //                    }
        //                    if (dr2["worddoc"] != DBNull.Value)
        //                    {

        //                        Byte[] strworddoc = (byte[])dr2["worddoc"];
        //                        str = System.Text.Encoding.Default.GetString(strworddoc);
        //                    }
        //                    Session["strFileName"] = filenew;
        //                    Session["strFilePath"] = str;
        //                    //txtFileName.Text = "";
        //                }
        //                else
        //                {
        //                    lblDelMsg.Visible = true;
        //                    lblDelMsg.Text = strfile + " file not exist";
        //                }
        //            }
        //            int i = dpdwnlstFileNames.Items.Count;
        //            for (int j = 0; j < i; j++)
        //            {
        //                if (dpdwnlstFileNames.Items[j].Selected == true)
        //                {
        //                    dpdwnlstFileNames.Items.Remove(dpdwnlstFileNames.Items[j].ToString());
        //                    i--;
        //                }

        //            }

        //            Session["file"] = strConcatfile;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}
        //#endregion

        //protected void btnEmailAddWrk_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string file_name = dpdwnlstFileNames.SelectedItem.Text;
        //        Session["strFileNM"] = file_name;
        //        string MailID = "";
        //        string UserName = "";
        //        int LoginId = Convert.ToInt32(Session["LoginId"].ToString());

        //        BLProject bl = new BLProject();
        //        SqlDataReader dr = bl.GetData(LoginId);


        //        if (dr.Read())
        //        {
        //            if (dr["MailID"] != DBNull.Value)
        //            {
        //                MailID = dr.GetString(0);
        //                UserName = dr.GetString(1);
        //            }
        //            else
        //            {
        //                lblResult.Text = "Database email id field is null";
        //            }
        //        }

        //        Session["UserName"] = UserName;
        //        Session["Mail"] = MailID;
        //        Session["clientName"] = ddlCliNm.SelectedItem.Text;
        //        Session["caseName"] = txtCasNm.Text;
        //        if (txtLoanAcNoAddWrk.Text != "")
        //        {
        //            Session["LoanAcNo"] = txtLoanAcNoAddWrk.Text;
        //        }
        //        if (txtBranchAddWrk.Text != "")
        //        {
        //            Session["Branch"] = txtBranchAddWrk.Text;
        //        }
        //        if (txtLoanAmtAddWrk.Text != "")
        //        {
        //            Session["LoanAmmt"] = txtLoanAmtAddWrk.Text;
        //        }
        //        if (txtPropertyDetails.Text != "")
        //        {
        //            Session["Property"] = txtPropertyDetails.Text;
        //        }
        //        if (txtRemarks.Text != "")
        //        {
        //            Session["Remarks"] = txtRemarks.Text;
        //        }
        //        Response.Redirect("~/Emp/Mail/SendMail.aspx");
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}
        /*
       Create By :- Kunal
       Created Date :- 13/3/2015
       Updated Date :- 
       Purpose :- Add Edit Work Open Doc File
    */
        //#region-----------OpenMSWordFileByBrowser------------
        //private void OpenMSWordFileByBrowser()
        //{
        //    try
        //    {
        //        string file_name = dpdwnlstFileNames.SelectedItem.Text;
        //        Session["strFileNM"] = file_name;
        //        string file_path = Session["strFilePath"].ToString();
        //        string filepathSpecificfile = "";
        //        string[] values = file_path.Split(',');

        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            values[i] = values[i].Trim();
        //            file_path = values[i];
        //            if (file_path.Contains(file_name))
        //            {
        //                filepathSpecificfile = file_path;
        //            }
        //        }
        //        Response.ClearContent();
        //        Response.ClearHeaders();
        //        if (file_path.Substring(file_path.IndexOf('.') + 1).ToLower() == "docx")
        //        {
        //            Response.AppendHeader("Content-Type", "application/msword");
        //            Response.AppendHeader("Content-disposition", "attachment; filename=" + file_name);
        //        }

        //        Response.WriteFile(filepathSpecificfile);
        //        Response.Flush();
        //        Response.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}
        //private void OpenpdfFileByBrowser()
        //{
        //    try
        //    {
        //        //save file to folder
        //        if (Page.IsPostBack)
        //        {
        //            string fileName = Session["uploadedfile"].ToString();

        //            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);
        //            ////convert file from doc to pfd
        //            Document doc = new Document(fileName);
        //            doc.Activate();

        //         //  doc.SaveAs("d:/desktop/document.pdf", WdSaveFormat.wdFormatPDF); tempcomment

        //            //temp code
        //            string[] filePaths = Directory.GetFiles(Server.MapPath("~/PDFdoc/"));
        //           List<ListItem> files = new List<ListItem>();
        //           foreach (string filePath in filePaths)
        //           {
        //               files.Add(new ListItem(Path.GetFileName(filePath), filePath));
        //           }
        //           GridView1.DataSource = files;
        //           GridView1.DataBind();

        //            //temp code


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}

        //#endregion

        protected void DeleteFilesOnLoad()
        {
            try
            {
                projectid = getMaxProjectId();

                string dirPath = Server.MapPath("~/Document/");
                string filenm = projectid.ToString();

                string[] Files = Directory.GetFiles(dirPath, filenm + "*.*", SearchOption.AllDirectories);

                foreach (string f in Files)
                {
                    if (f.Contains(filenm))
                    {
                        File.Delete(f);

                    }
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

        protected void Page_Unload(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    DeleteFilesOnLoad();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnSaveWordFile_Click(object sender, EventArgs e)
        {
            try
            {
                Thread newThread = new Thread(new ThreadStart(ThreadMethod));
                newThread.SetApartmentState(ApartmentState.STA);
                newThread.Start();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void ThreadMethod()
        {
            try
            {
                SaveFileDialog saveFile1 = new SaveFileDialog();

                // Initialize the SaveFileDialog to specify the RTF extension for the file.
                var fnm = Server.MapPath("~\\Document\\" + "demo1" + ".docx");
                saveFile1.DefaultExt = "*.doc";
                saveFile1.Filter = "*.doc|*.docx";

                // Determine if the user selected a file name from the saveFileDialog. 
                if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                saveFile1.FileName.Length > 0)
                {
                    // Save the contents of the RichTextBox into the file.
                    richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        //protected void cbpdf_CheckedChanged(object sender, EventArgs e)
        //{
        //    if(cbpdf.Checked == true)
        //    {
        //        btnOpenAddWrk.Enabled = true;
        //    }
        //}

        public Document wordDocument { get; set; }
    }
}
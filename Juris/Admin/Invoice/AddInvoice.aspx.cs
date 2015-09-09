using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
namespace Juris.Admin.Invoice
{
    public partial class AddInvoice : System.Web.UI.Page
    {
        int InvoiceId = 0;
        string clnm;
        DataTable dtSelProject = new DataTable();
        DataTable dtUnselProject = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BLAddInvoice blAddCl = new BLAddInvoice();
                txtDtInvce.Text = System.DateTime.Now.ToShortDateString();
                if ((HttpContext.Current.Session["LoginId"]) == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                Session["SelectProject"] = 0;
                if (Page.IsPostBack)
                {
                    Session["dtgetselectedRecords"] = null;
                }
                SqlDataReader dr = blAddCl.getClientInvce();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                        drpdwnClientNm.Items.Add(dr.GetString(0));
                    drpdwnClientNm.Items.Insert(0, new ListItem("--Select--", "-1"));
                    dr.Close();
                }

                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["Id"] == "1")
                    {
                        clnm = Session["ClNm"].ToString();
                        drpdwnClientNm.SelectedValue = clnm;
                        txtAddInvce.Text = Session["Add"].ToString();
                        txtPanNo.Text = Session["PAN"].ToString();
                        txtBillNo.Text = Session["BillNo"].ToString();
                        string amt = txtAmtAddInvce.Text.ToString();
                        Session["TotalAmount"] = amt;
                        string ClientName = drpdwnClientNm.SelectedValue.ToString();
                        Session["ClientName"] = ClientName;
                    }
                    DataTable dt = Session["dtgetselectedRecords"] as DataTable;
                    double amt1 = Convert.ToDouble(Session["amt"]);

                    if (dt != null)
                    {
                        GdVwAddInvce.DataSource = dt;
                        GdVwAddInvce.DataBind();
                    }
                    if (dt != null)
                    {
                        double amtNew = 0.0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            amtNew += double.Parse(dt.Rows[i].Field<string>(4));
                        }
                        Session["addedamt"] = amtNew.ToString();
                        txtAmtAddInvce.Text = amtNew.ToString();
                    }

                    SelAllCheckbox();

                    if (Request.QueryString["InvoiceId"] != null)
                    {
                        InvoiceId = int.Parse(Request.QueryString["InvoiceId"]);
                        Session["InvoiceId"] = InvoiceId;
                        SqlDataReader drgetInv = blAddCl.getInvoiceForUpdate(InvoiceId);

                        if (drgetInv.HasRows == true)
                        {
                            while (drgetInv.Read())
                            {
                                DateTime indate = drgetInv.GetDateTime(2);
                                txtDtInvce.Text = indate.ToString("dd/MM/yyyy");
                                int ClId = drgetInv.GetInt32(3);
                                Session["ClId"] = ClId.ToString();
                                drpdwnClientNm.SelectedValue = Session["ClientName"].ToString();
                                GetClientInfo();
                                txtAmtAddInvce.Text = drgetInv.GetDecimal(4).ToString();
                                txtBillNo.Text = Session["InvoiceNo"].ToString();
                                txtRemrk.Text = drgetInv.GetString(7);
                                if (drgetInv.GetInt32(9) == 1)
                                    chkbxisDel.Checked = true;
                                else
                                    chkbxisDel.Checked = false;
                                if (drgetInv.GetInt32(10) == 1)
                                    chkbxAppInv.Checked = true;
                                else
                                    chkbxAppInv.Checked = false;
                            }
                            drgetInv.Close();
                        }
                        DataTable dtgetInvDet = blAddCl.GetInvoiceDetailForUpdate(InvoiceId);
                        GdVwAddInvce.DataSource = dtgetInvDet;
                        GdVwAddInvce.DataBind();
                        Session["dtgetselectedRecordsUpdate"] = dtgetInvDet;
                        SelAllCheckbox();
                    }
                }
                else
                {
                    lblCatchError.Text = "";
                    lblSelProjectMessage.Text = "";
                    lblResult.Text = "";
                }
                //if (!Page.IsPostBack)
                //{
                //    if (Request.QueryString["InvoiceId"] != null)
                //    {
                //        InvoiceId = int.Parse(Request.QueryString["InvoiceId"]);
                //        Session["InvoiceId"] = InvoiceId;
                //        SqlDataReader drgetInv = blAddCl.getInvoiceForUpdate(InvoiceId);

                //        //SqlDataReader dr = blAddCl.getClientInvce();
                //        //if (dr.HasRows == true)
                //        //{
                //        //    while (dr.Read())
                //        //        drpdwnClientNm.Items.Add(dr.GetString(0));
                //        //    drpdwnClientNm.Items.Insert(0, new ListItem("--Select--", "-1"));
                //        //    dr.Close();
                //        //}
                //        if (Request.QueryString["Id"] == "1")
                //        {
                //            clnm = Session["ClNm"].ToString();
                //            drpdwnClientNm.SelectedValue = clnm;
                //            txtAddInvce.Text = Session["Add"].ToString();
                //            txtPanNo.Text = Session["PAN"].ToString();
                //            txtBillNo.Text = Session["BillNo"].ToString();
                //            string amt = txtAmtAddInvce.Text.ToString();
                //            Session["TotalAmount"] = amt;
                //            string ClientName = drpdwnClientNm.SelectedValue.ToString();
                //            Session["ClientName"] = ClientName;
                //        }
                //        DataTable dt = Session["dtgetselectedRecords"] as DataTable;
                //        double amt1 = Convert.ToDouble(Session["amt"]);

                //        if (dt != null)
                //        {
                //            GdVwAddInvce.DataSource = dt;
                //            GdVwAddInvce.DataBind();

                //            double amtNew = 0.0;
                //            for (int i = 0; i < dt.Rows.Count; i++)
                //            {
                //                amtNew += double.Parse(dt.Rows[i].Field<string>(4));
                //            }
                //            Session["addedamt"] = amtNew.ToString();
                //            txtAmtAddInvce.Text = amtNew.ToString();
                //        }

                //        if (drgetInv.HasRows == true)
                //        {
                //            while (drgetInv.Read())
                //            {
                //                DateTime indate = drgetInv.GetDateTime(2);
                //                txtDtInvce.Text = indate.ToString("dd/MM/yyyy");
                //                int ClId = drgetInv.GetInt32(3);
                //                Session["ClId"] = ClId.ToString();
                //                drpdwnClientNm.SelectedValue = Session["ClientName"].ToString();
                //                GetClientInfo();
                //                txtAmtAddInvce.Text = drgetInv.GetDecimal(4).ToString();
                //                txtBillNo.Text = Session["InvoiceNo"].ToString();
                //                txtRemrk.Text = drgetInv.GetString(7);
                //                if (drgetInv.GetInt32(9) == 1)
                //                    chkbxisDel.Checked = true;
                //                else
                //                    chkbxisDel.Checked = false;
                //                if (drgetInv.GetInt32(10) == 1)
                //                    chkbxAppInv.Checked = true;
                //                else
                //                    chkbxAppInv.Checked = false;
                //            }
                //            drgetInv.Close();
                //        }
                //        DataTable dtgetInvDet = blAddCl.GetInvoiceDetailForUpdate(InvoiceId);
                //        GdVwAddInvce.DataSource = dtgetInvDet;
                //        GdVwAddInvce.DataBind();
                //        Session["dtgetselectedRecordsUpdate"] = dtgetInvDet;
                //    }
                //    SelAllCheckbox();
                //}
                //else
                //{
                //    //Session["dtgetselectedRecords"] = null;
                //    lblCatchError.Text = "";
                //    lblSelProjectMessage.Text = "";
                //    lblResult.Text = "";
                //}
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        protected void SelAllCheckbox()
        {
            try
            {
                foreach (GridViewRow gvrow in GdVwAddInvce.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkSelect = (gvrow.Cells[0].FindControl("chkSel") as CheckBox);
                        chkSelect.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void drpdwnClientNm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ClientId = 0;
                string ClNm = drpdwnClientNm.SelectedItem.Text;
                BLAddInvoice blAddCl = new BLAddInvoice();
                GetClientInfo();
                DataTable dtCleintDet = new DataTable();

                dtCleintDet.Columns.Add("Address");
                dtCleintDet.Columns.Add("PAN");
                dtCleintDet.Columns.Add("BillNo");
                string add = txtAddInvce.Text;
                string pan = txtPanNo.Text;
                string billno = txtBillNo.Text;
                dtCleintDet.Rows.Add(add, pan, billno);
                Session["ClNm"] = ClNm;
                Session["Add"] = txtAddInvce.Text;
                Session["PAN"] = txtPanNo.Text;
                Session["BillNo"] = txtBillNo.Text;

                SqlDataReader dr1 = blAddCl.getClIdByName(ClNm);
                if (dr1.HasRows)
                {
                    dr1.Read();
                    ClientId = dr1.GetInt32(0);
                    dr1.Close();
                }
                Session["ClId"] = ClientId;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        
        public void GetClientInfo()
        {
            try
            {
                BLAddInvoice blAddCl = new BLAddInvoice();
                string ClNm = drpdwnClientNm.SelectedItem.Text;
                if (drpdwnClientNm.SelectedItem.Text != "--Select--")
                {
                    SqlDataReader dr = blAddCl.getClientInfo(ClNm);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            string add = dr.GetString(0) + "\n" + dr.GetString(1) + "\n" + dr.GetString(2) + "\n" + dr.GetString(3) + "\n" + dr.GetString(4);
                            txtAddInvce.Text = add;
                            txtPanNo.Text = dr.GetString(5);
                            txtBillNo.Text = dr.GetString(6);
                        }
                        dr.Close();
                    }
                }
                Session["ClNm"] = ClNm;
                Session["Add"] = txtAddInvce.Text;
                Session["PAN"] = txtPanNo.Text;
                Session["BillNo"] = txtBillNo.Text;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnSaveInvce_Click(object sender, EventArgs e)
        {
            try
            {
                // Session["InvoiceId"] = null;
                int mode = 0, Invoiceid = 0;
                BLAddInvoice blgetIn = new BLAddInvoice();
                SqlDataReader dr = blgetIn.GetInvoiceId1();
                if (dr.HasRows)
                {
                    dr.Read();
                    Invoiceid = dr.GetInt32(0);
                    dr.Close();
                }
                Invoiceid++;
                string InvoiceNo = Session["BillNo"] + Invoiceid.ToString();
                DateTime date = Convert.ToDateTime(txtDtInvce.Text);
                int ClId = Convert.ToInt32(Session["ClId"]);
                decimal amt = decimal.Parse(txtAmtAddInvce.Text);
                decimal OtherChrge = Convert.ToDecimal(0);
                decimal TotAmt = Convert.ToDecimal(txtAmtAddInvce.Text);
                string remark = txtRemrk.Text;
                string status = "In Process";
                int isdel = 0;
                if (chkbxisDel.Checked)
                    isdel = 1;
                else
                    isdel = 0;
                int app = 0;
                if (chkbxAppInv.Checked)
                    app = 1;
                else
                    app = 0;
                if (GdVwAddInvce.Rows.Count == 0)
                {
                    lblSelProjectMessage.Text = "Please Select At Least One Project";
                }
                else
                {
                    fillSelUnselectedProjects();
                    if (Session["InvoiceId"] != null)
                    {
                        InvoiceNo = txtBillNo.Text;
                        int InvId = int.Parse(Session["InvoiceId"].ToString());
                        mode = 1;

                        if (dtSelProject.Rows.Count == 0)
                        {
                            lblSelProjectMessage.Text = "Please Select At Least One Project";
                        }
                        else
                        {
                            blgetIn.AddInvoice(InvId, InvoiceNo, date, ClId, amt, OtherChrge, TotAmt, remark, status, isdel, app, mode);
                            SaveProjectDetail(InvId, mode);
                            HiddenFieldInvoiceId.Value = Convert.ToString(InvId);
                            lblResult.Visible = true;
                            lblResult.Text = "Invoice Details are Updated Successfully";
                            //ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", "Invoice.aspx?InvoiceID=" + InvId));
                
                            Generate_Invoice_and_Annexure();
                            //Session["InvoiceId"] = null;
                            clearfilelds();
                        }
                    }
                    else
                    {
                        if (dtSelProject.Rows.Count == 0)
                        {
                            lblSelProjectMessage.Text = "please select atleast one project";
                        }
                        else
                        {
                            blgetIn.AddInvoice(Invoiceid, InvoiceNo, date, ClId, amt, OtherChrge, TotAmt, remark, status, isdel, app, mode);
                            SaveProjectDetail(Invoiceid, mode);
                            HiddenFieldInvoiceId.Value = Convert.ToString(Invoiceid);
                            lblResult.Visible = true;
                            lblResult.Text = "Invoice Details are Added Successfully";
                            //ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", "Invoice.aspx?InvoiceID=" + Invoiceid));
                
                            Generate_Invoice_and_Annexure();
                            clearfilelds();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        protected void clearfilelds()
        {
            try
            {
                txtBillNo.Text = "";
                // txtAmtAddInvce.Text = "0";
                txtPanNo.Text = "";
                txtRemrk.Text = "";
                txtAddInvce.Text = "";
                drpdwnClientNm.SelectedItem.Text = "--Select--";
                GdVwAddInvce.DataSource = null;
                GdVwAddInvce.DataBind();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        public void fillSelUnselectedProjects()
        {
            try
            {
                dtSelProject.Columns.AddRange(new DataColumn[1] { new DataColumn("ProjectId") });
                dtSelProject.Columns.AddRange(new DataColumn[1] { new DataColumn("Amount") });
                dtUnselProject.Columns.AddRange(new DataColumn[1] { new DataColumn("ProjectId") });
                foreach (GridViewRow gvrow in GdVwAddInvce.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        //finding the checkbox in the gridview
                        CheckBox chksel = (gvrow.Cells[0].FindControl("chkSel") as CheckBox);
                        // checking which checkbox are selected
                        if (chksel.Checked)
                        {
                            int projectId = int.Parse(gvrow.Cells[1].Text);
                            double calamt = double.Parse(gvrow.Cells[5].Text);
                            dtSelProject.Rows.Add(projectId, calamt);
                        }
                        else
                        {
                            int projectId = int.Parse(gvrow.Cells[1].Text);
                            dtUnselProject.Rows.Add(projectId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        protected void SaveProjectDetail(int InvoiceId, int mode)
        {
            try
            {
                BLAddInvoice blgetIn = new BLAddInvoice();
                for (int i = 0; i < dtSelProject.Rows.Count; i++)
                {
                    int projectid = int.Parse(dtSelProject.Rows[i].Field<string>(0));
                    float proamt = float.Parse(dtSelProject.Rows[i].Field<string>(1));
                    blgetIn.AddInvoiceDetail(InvoiceId, projectid, proamt);
                }
                for (int i = 0; i < dtUnselProject.Rows.Count; i++)
                {
                    int ProjectId = int.Parse(dtUnselProject.Rows[i].Field<string>(0));
                    blgetIn.DelProjectDetail(ProjectId);
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void chkbxSelAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkbxSelAll.Checked == false)
                    chkbxSelAll.Text = "Clear All";
                else chkbxSelAll.Text = "Select All";

                if (chkbxSelAll.Checked == false)
                {
                    foreach (GridViewRow gvrow in GdVwAddInvce.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            //Finding the Checkbox in the Gridview
                            CheckBox chkSelect = (gvrow.Cells[0].FindControl("chkSel") as CheckBox);
                            chkSelect.Checked = true;
                            if (chkSelect.Checked)
                            {
                                CheckCeckboxForAmt();
                            }
                        }
                    }
                }
                else
                {
                    foreach (GridViewRow gvrow in GdVwAddInvce.Rows)
                    {

                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkSelect = (gvrow.Cells[0].FindControl("chkSel") as CheckBox);
                            chkSelect.Checked = false;
                            txtAmtAddInvce.Text = Convert.ToString(0);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnSelPrjct_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Admin/Project/SelectProject.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void OnCheckboxCheck(object sender, EventArgs e)
        {
            try
            {
                if (GdVwAddInvce.SelectedIndex == -1)
                {
                    txtAmtAddInvce.Text = "0";
                }
                CheckCeckboxForAmt();
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
                double addedamt = 0.0; double iniamt = 0.0; int cnt = 0;
                foreach (GridViewRow gvrow in GdVwAddInvce.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        //finding the checkbox in the gridview
                        CheckBox chksel = (gvrow.Cells[0].FindControl("chksel") as CheckBox);
                        // checking which checkbox are selected
                        if (chksel.Checked)
                        {
                            iniamt = double.Parse(gvrow.Cells[5].Text);
                            addedamt = addedamt + iniamt;
                            txtAmtAddInvce.Text = Convert.ToString(addedamt);
                            Session["addedamt"] = txtAmtAddInvce.Text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnCncl_Click(object sender, EventArgs e)
        {
            try
            {
                Session["InvoiceId"] = null;
                Response.Redirect("~/adminHome.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnSvPrvInv_Click(object sender, EventArgs e)
        {
            int ClId = 0;

            try
            {
                // Session["InvoiceId"] = null;
                int mode = 0, Invoiceid = 0;
                BLAddInvoice blgetIn = new BLAddInvoice();
                SqlDataReader dr = blgetIn.GetInvoiceId1();
                if (dr.HasRows)
                {
                    dr.Read();
                    Invoiceid = dr.GetInt32(0);
                    dr.Close();
                }
                Invoiceid++;
                string InvoiceNo = Session["BillNo"] + Invoiceid.ToString();
                DateTime date = Convert.ToDateTime(txtDtInvce.Text);
                ClId = Convert.ToInt32(Session["ClId"]);
                decimal amt = decimal.Parse(txtAmtAddInvce.Text);
                decimal OtherChrge = Convert.ToDecimal(0);
                decimal TotAmt = Convert.ToDecimal(txtAmtAddInvce.Text);
                string remark = txtRemrk.Text;
                string status = "In Process";
                int isdel = 0;
                if (chkbxisDel.Checked)
                    isdel = 1;
                else
                    isdel = 0;
                int app = 0;
                if (chkbxAppInv.Checked)
                    app = 1;
                else
                    app = 0;
                if (GdVwAddInvce.Rows.Count == 0)
                {
                    lblSelProjectMessage.Text = "Please Select At Least One Project";
                }
                else
                {
                    fillSelUnselectedProjects();
                    int InvId;
                    if (Session["InvoiceId"] != null)
                    {
                        InvoiceNo = txtBillNo.Text;
                        InvId = int.Parse(Session["InvoiceId"].ToString());
                        mode = 1;

                        if (dtSelProject.Rows.Count == 0)
                        {
                            lblSelProjectMessage.Text = "Please Select At Least One Project";
                        }
                        else
                        {
                            blgetIn.AddInvoice(InvId, InvoiceNo, date, ClId, amt, OtherChrge, TotAmt, remark, status, isdel, app, mode);
                            SaveProjectDetail(InvId, mode);
                            HiddenFieldInvoiceId.Value = Convert.ToString(InvId);                            
                            lblResult.Visible = true;
                            lblResult.Text = "Invoice Details are Updated Successfully";
                            //ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", "Invoice.aspx?InvoiceID=" + InvId));
                            Generate_Invoice_and_Annexure();
                            //Session["InvoiceId"] = null;
                            clearfilelds();
                        }
                    }
                    else
                    {
                        if (dtSelProject.Rows.Count == 0)
                        {
                            lblSelProjectMessage.Text = "please select atleast one project";
                        }
                        else
                        {
                            blgetIn.AddInvoice(Invoiceid, InvoiceNo, date, ClId, amt, OtherChrge, TotAmt, remark, status, isdel, app, mode);
                            SaveProjectDetail(Invoiceid, mode);
                            HiddenFieldInvoiceId.Value = Convert.ToString(Invoiceid);
                            lblResult.Visible = true;
                            lblResult.Text = "Invoice Details are Added Successfully";
                            //ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", "Invoice.aspx?InvoiceID=" + Invoiceid));
                            Generate_Invoice_and_Annexure();
                            clearfilelds();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
            string amount = txtAmtAddInvce.Text;
            decimal TotAmt1 = Convert.ToDecimal(txtAmtAddInvce.Text);
        }

        private void Generate_Invoice_and_Annexure()
        {
            if (drplstRprtTyp.SelectedItem.ToString() == "Invoice With Annexure")
            {
                int InvoiceId = Convert.ToInt32(HiddenFieldInvoiceId.Value);
                
                if (rbInvoice1.Checked == true)
                {
                    Session["InvoiceType"] = 1;
                }
                else
                {
                    Session["InvoiceType"] = 2;
                }

                string strPopupInvoice = "<script language='javascript' ID='script1'>"
               
                // Passing intId to popup window.
                + "window.open('Invoice.aspx?InvoiceID=" + HttpUtility.UrlEncode(InvoiceId.ToString())
                + "','new window', 'top=90, left=200, width=768, height=1024, dependant=no, location=0, alwaysRaised=no, menubar=no, resizeable=no, scrollbars=n, toolbar=no, status=no, center=yes')"
                + "</script>";
                ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "Script1", strPopupInvoice, false);
            }
        }

        //protected void btnShowInvoice_Click(object sender, EventArgs e)
        //{
        //    if (drplstRprtTyp.SelectedItem.ToString() == "Invoice With Annexure")
        //    {
        //        int InvoiceId = Convert.ToInt32(HiddenFieldInvoiceId.Value);

        //        string strPopupInvoice = "<script language='javascript' ID='script1'>"

        //        // Passing intId to popup window.
        //        + "window.open('Invoice.aspx?InvoiceID=" + HttpUtility.UrlEncode(InvoiceId.ToString())

        //        + "','new window', 'top=90, left=200, width=768, height=1024, dependant=no, location=0, alwaysRaised=no, menubar=no, resizeable=no, scrollbars=n, toolbar=no, status=no, center=yes')"

        //        + "</script>";

        //        ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "Script1", strPopupInvoice, false);

        //        string strPopupAnnexure = "<script language='javascript' ID='script2'>"

        //        // Passing intId to popup window.
        //        + "window.open('Annexure.aspx?InvoiceID=" + HttpUtility.UrlEncode(InvoiceId.ToString())

        //        + "','new window', 'top=90, left=200, width=768, height=1024, dependant=no, location=0, alwaysRaised=no, menubar=no, resizeable=no, scrollbars=n, toolbar=no, status=no, center=yes')"

        //        + "</script>";

        //        ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "Script2", strPopupAnnexure, false);
                
        //        //Response.Redirect("~/Admin/Invoice/Invoice.aspx?InvoiceID=" + Convert.ToInt32(HiddenFieldInvoiceId.Value));
        //        /*
        //        string url = "Invoice.aspx";
        //        string s = "window.open('" + url + "', 'popup_window', 'width=768,height=1024,left=100,top=100,resizable=yes');";
        //        ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

        //        string url1 = "Annexure.aspx";
        //        string s1 = "window.open('" + url1 + "', 'popup_window', 'width=768,height=1024,left=100,top=100,resizable=yes');";
        //        ClientScript.RegisterStartupScript(this.GetType(), "script", s1, true);

        //        //Response.Write("<script> window.open( '../Invoice/Invoice.aspx','_blank' ); </script>");
        //        //Response.Write("<script> window.open( '../Invoice/Annexure.aspx','_blank' ); </script>");
        //         * */
        //    }
        //}

        //protected void btnShowAnnexure_Click(object sender, EventArgs e)
        //{

        //}
    }
}


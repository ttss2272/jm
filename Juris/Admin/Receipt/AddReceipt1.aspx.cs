using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;

namespace Juris.Admin.Receipt
{
    public partial class AddReceipt1 : System.Web.UI.Page
    {
        //int RecId; int update = 1;
        //BLAddReceipt blObjAddRec = new BLAddReceipt();
        //int recid;
        //int noofbills = 0; double addedamt = 0.0; double addcaltds = 0.0; int InvoiceId = 0;
        //int recId;
        //DataTable dtSelRecDet = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {

            //try
            //{
            //    SqlDataReader dr;
            //    BLAddReceipt blViewRec = new BLAddReceipt();
            //    if ((HttpContext.Current.Session["LoginId"]) == null)
            //    {
            //        Response.Redirect("~/Login.aspx");
            //    }
            //    txtChqOrDftDt.Text = System.DateTime.Now.ToShortDateString();
            //    dr = blViewRec.GetMaxRecId();
            //    if (dr.Read())
            //    {
            //        if (dr.IsDBNull(0))
            //        {
            //            recid = 0;
            //        }
            //        else
            //        {
            //            recid = dr.GetInt32(0);
            //            dr.Close();

            //        }
            //    }
            //    recid++;
            //    if (!Page.IsPostBack)
            //    {
            //        txtRecNo.Text = recid.ToString();
            //        dr = blViewRec.getClientRec();

            //        if (dr.HasRows)
            //        {
            //            while (dr.Read())
            //                DrplstClRec.Items.Add(dr.GetString(0));
            //            DrplstClRec.Items.Insert(0, new ListItem("--Select--", "-1"));
            //            dr.Close();
            //        }
            //        txtRecDate.Text = System.DateTime.Now.ToShortDateString();
            //        txtChqOrDftDt.Text = System.DateTime.Now.ToShortDateString();

            //        if (Request.QueryString["ReceiptId"] != null)
            //        {

            //            RecId = int.Parse(Request.QueryString["ReceiptId"]);
            //            SqlDataReader drGetRecDet = blViewRec.GetRecDetForUpdate(RecId);
            //            if (drGetRecDet.HasRows == true)
            //            {
            //                while (drGetRecDet.Read())
            //                {
            //                    txtRecNo.Text = (drGetRecDet.GetInt32(1)).ToString();
            //                    DateTime recdate = drGetRecDet.GetDateTime(2);
            //                    txtRecDate.Text = recdate.ToShortDateString();
            //                    txtClId.Enabled = false;

            //                    txtClId.Text = drGetRecDet.GetInt32(3).ToString();
            //                    int ClientId = int.Parse(txtClId.Text);
            //                    txtGrpId.Text = drGetRecDet.GetInt32(4).ToString();
            //                    string paymenttype = drGetRecDet.GetString(5);
            //                    DRpDwnLstPmntTyp.SelectedValue = paymenttype;
            //                    txtAmt.Text = (drGetRecDet.GetSqlMoney(6)).ToString();
            //                    txtTDSReadOnly.Text = drGetRecDet.GetSqlMoney(7).ToString();
            //                    txtDisc.Text = drGetRecDet.GetSqlMoney(8).ToString();
            //                    txtBnkNm.Text = drGetRecDet.GetString(9);
            //                    txtChqOrDftNo.Text = drGetRecDet.GetString(10).ToString();
            //                    DateTime chequedftdate = drGetRecDet.GetDateTime(11);
            //                    txtChqOrDftDt.Text = chequedftdate.ToShortDateString();
            //                    bool isonacc = drGetRecDet.GetBoolean(12);
            //                    if (isonacc == true)
            //                        chkAgainstBills.Checked = true;
            //                    else
            //                        chkAgainstBills.Checked = false;
            //                    txtBalamt.Text = drGetRecDet.GetSqlMoney(13).ToString();
            //                    bool tdsCerRecceived = drGetRecDet.GetBoolean(14);
            //                    if (tdsCerRecceived == true)
            //                        chkbxTDSCertRecvd.Checked = true;
            //                    else
            //                        chkbxTDSCertRecvd.Checked = false;
            //                    txtCoommnts.Text = drGetRecDet.GetString(15);
            //                    DrplstClRec.Enabled = false;
            //                    DrplstClRec.SelectedValue = drGetRecDet.GetString(16);
            //                    txtSubGrpNm.Text = drGetRecDet.GetString(17);
            //                    bool isdel = drGetRecDet.GetBoolean(18);
            //                    if (isdel == true)
            //                        rbtnlstIsDel.Items.FindByValue("Yes").Selected = true;
            //                    else
            //                        rbtnlstIsDel.Items.FindByValue("No").Selected = true;
            //                    txtBllAmt.Text = drGetRecDet.GetDecimal(19).ToString();
            //                    txtTDSPerc.Text = drGetRecDet.GetDecimal(20).ToString();
            //                    int app = drGetRecDet.GetInt32(21);
            //                    if (app == 1)
            //                        chkbxAppRecpt.Checked = true;
            //                    else
            //                        chkbxAppRecpt.Checked = false;

            //                    //if against bills is true then diaplay invoice details in gridview
            //                    if (chkAgainstBills.Checked == true)
            //                    {
            //                        SqlDataReader drGetInvForGirdview = blViewRec.GetInvoiceByAddRec1(ClientId, update);
            //                        Panel1.Visible = true;
            //                        GrdVwInvoice.Visible = true;
            //                        GrdVwInvoice.DataSource = drGetInvForGirdview;
            //                        GrdVwInvoice.DataBind();
            //                    }
            //                }
            //                drGetRecDet.Close();
            //                BtnClearRec.Enabled = false;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        lblAmtMsg.Text = "";
            //        CalendarExtender1.SelectedDate = DateTime.ParseExact(txtChqOrDftDt.Text, CalendarExtender1.Format, null);
            //        CalendarExtender2.SelectedDate = DateTime.ParseExact(txtRecDate.Text, CalendarExtender2.Format, null);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lblCatchError.Text = ex.Message.ToString();
            //}
        }
        
        protected void BtnCnclRec_Click(object sender, EventArgs e)
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

        /*
        Create By :- Kunal
        Created Date :- 13/3/2015
        Updated Date :- 
        Purpose :- Add Receipt Session REmove
     */

        //private void ClearAll()
        //{
        //    try
        //    {
        //        txtCoommnts.Text = "";
        //        txtDisc.Text = Convert.ToString(0);
        //        txtAmt.Text = Convert.ToString(0);
        //        txtBllAmt.Text = "";
        //        txtBnkNm.Text = "";
        //        txtChqOrDftNo.Text = "";
        //        txtClId.Text = "";
        //        txtDisc.Text = Convert.ToString(0);
        //        txtGrpId.Text = "";
        //        txtSubGrpNm.Text = "";
        //        txtBalamt.Text = "";
        //        txtTDSReadOnly.Text = "";
        //        lblValAllBillsAmount.Text = "0";
        //        lblValNoOfBill.Text = "0";
        //        lblValTDSAmount.Text = "0";
        //        Panel1.Visible = false;
        //        if (chkAgainstBills.Checked == true)
        //            chkAgainstBills.Checked = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}

        //protected void updateAdjustAmount(int mode, int recid)
        //{
        //    try
        //    {
        //        dtSelRecDet.Columns.Add("ReceiptId");
        //        dtSelRecDet.Columns.Add("BillId");
        //        dtSelRecDet.Columns.Add("AdjustAmount");
        //        dtSelRecDet.Columns.Add("TDS");
        //        dtSelRecDet.Columns.Add("Discount");
        //        DataTable DtUnSelInvRec = new DataTable();
        //        DtUnSelInvRec.Columns.Add("ReceiptId");
        //        DtUnSelInvRec.Columns.Add("BillId");
        //        foreach (GridViewRow gvrow in GrdVwInvoice.Rows)
        //        {
        //            if (gvrow.RowType == DataControlRowType.DataRow)
        //            {
        //                CheckBox chkSel = gvrow.Cells[0].FindControl("chksel") as CheckBox;
        //                Label invid = (gvrow.Cells[0].FindControl("lblInvoiceId") as Label);
        //                Label adjustamt = (gvrow.Cells[0].FindControl("lbladjamt") as Label);
        //                Label tds = (gvrow.Cells[0].FindControl("lbltds") as Label);
        //                if (chkSel.Checked)
        //                {
        //                    int InvoiceId = int.Parse(invid.Text); //Bill Id in AdjustAmount
        //                    double AdjustAmt = double.Parse(adjustamt.Text);
        //                    double TDS = double.Parse(tds.Text);
        //                    double disc = double.Parse(txtDisc.Text);

        //                    dtSelRecDet.Rows.Add(recid, InvoiceId, AdjustAmt, TDS, disc);
        //                }
        //                else
        //                {
        //                    int BillId = int.Parse(invid.Text);//Invoice Id
        //                    DtUnSelInvRec.Rows.Add(recid, BillId);

        //                }
        //            }
        //        }
        //        for (int i = 0; i < dtSelRecDet.Rows.Count; i++)
        //        {
        //            //Convert.ToInt32(dtSelRecDet.Rows[i].Field<string>(0));
        //            int InvId = Convert.ToInt32(dtSelRecDet.Rows[i].Field<string>(1));
        //            double adjustAmt = double.Parse(dtSelRecDet.Rows[i].Field<string>(2));
        //            double TDS = double.Parse(dtSelRecDet.Rows[i].Field<string>(3));
        //            double disc = double.Parse(dtSelRecDet.Rows[i].Field<string>(4));

        //            blObjAddRec.AddAdjustAmt(recid, InvId, adjustAmt, TDS, disc);
        //        }

        //        for (int i = 0; i < DtUnSelInvRec.Rows.Count; i++)
        //        {
        //            int BillId = int.Parse(DtUnSelInvRec.Rows[i].Field<string>(1));
        //            blObjAddRec.DelAdjustAmt(BillId);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}
        //protected void DrplstClRec_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        lblResult.Text = "";
        //        string ClNm = DrplstClRec.SelectedItem.Text;

        //        BLAddReceipt bladdRec = new BLAddReceipt();
        //        SqlDataReader dr = bladdRec.GetClientIdByNm1(ClNm);
        //        if (dr.HasRows)
        //        {
        //            dr.Read();
        //            txtClId.Text = Convert.ToString(dr.GetInt32(0));
        //            dr.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}
        //public bool validate()
        //{
        //    try
        //    {
        //        double amt = Convert.ToDouble(txtAmt.Text);
        //        if (amt == 0)
        //            return false;
        //        else
        //            return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //        return false;
        //    }
        //}
        //private void txtBalamt_Enter(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        txtBalamt.Text = Convert.ToString(Convert.ToInt32(txtAmt.Text) + Convert.ToInt32(txtDisc.Text));
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}
        //protected void chkAgainstBills_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Request.QueryString["ReceiptId"] != null)
        //        {
        //            if (chkAgainstBills.Checked == true)
        //            {
        //                Panel1.Visible = true;
        //                GrdVwInvoice.Visible = true;
        //                BLAddReceipt bladdInvce = new BLAddReceipt();
        //                int ClId = Convert.ToInt32(txtClId.Text);
        //                getInvByAddRec(ClId, update);
        //            }
        //        }
        //        if (chkAgainstBills.Checked == true)
        //        {
        //            update = 0;
        //            Panel1.Visible = true;
        //            GrdVwInvoice.Visible = true;
        //            int ClId = Convert.ToInt32(txtClId.Text);
        //            getInvByAddRec(ClId, update);
        //        }
        //        else
        //            Panel1.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}
        //protected void getInvByAddRec(int clientId, int Update)
        //{
        //    try
        //    {
        //        SqlDataReader dr = blObjAddRec.GetInvoiceByAddRec1(clientId, Update);
        //        if (dr.HasRows)
        //        {
        //            GrdVwInvoice.DataSource = dr;
        //            GrdVwInvoice.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}
        //protected void onCheck(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (GrdVwInvoice.SelectedIndex == -1)
        //        {
        //            txtBalamt.Text = "0";
        //            txtBllAmt.Text = "0";
        //            txtTDSReadOnly.Text = "0";
        //            lblValNoOfBill.Text = "0";
        //            lblValAllBillsAmount.Text = "0";
        //            lblValTDSAmount.Text = "0";
        //        }

        //        foreach (GridViewRow gvrow in GrdVwInvoice.Rows)
        //        {
        //            if (gvrow.RowType == DataControlRowType.DataRow)
        //            {
        //                //finding the checkbox in the gridview
        //                CheckBox chksel = (gvrow.Cells[0].FindControl("chksel") as CheckBox);
        //                Label AdjAmt = (gvrow.Cells[0].FindControl("lbladjamt") as Label);
        //                Label tds = (gvrow.Cells[0].FindControl("lbltds") as Label);

        //                Label invoiceId = (gvrow.Cells[0].FindControl("lblInvoiceNo") as Label);
        //                Label Date = (gvrow.Cells[0].FindControl("lblDate") as Label);
        //                Label Amt = (gvrow.Cells[0].FindControl("lblamt") as Label);
        //                // checking which checkbox are selected
        //                if (chksel.Checked)
        //                {
        //                    double amt = double.Parse(Amt.Text);
        //                    AdjAmt.Text = amt.ToString();
        //                    double tdsperc = Convert.ToDouble(txtTDSPerc.Text);
        //                    double caltdsInRs = (amt * tdsperc) / 100;
        //                    addcaltds = addcaltds + caltdsInRs;

        //                    tds.Text = caltdsInRs.ToString();
        //                    addedamt += amt;
        //                    noofbills++;
        //                    txtBllAmt.Text = addedamt.ToString();
        //                    txtTDSReadOnly.Text = addcaltds.ToString();

        //                    double tdsRs = double.Parse(txtTDSReadOnly.Text);
        //                    double BillAmt = double.Parse(txtBllAmt.Text);
        //                    double balAmt = BillAmt - tdsRs;

        //                    txtBalamt.Text = balAmt.ToString();
        //                    double calbalamt = (Convert.ToDouble(txtBalamt.Text) + Convert.ToDouble(txtAmt.Text)) - Convert.ToDouble(txtDisc.Text);

        //                    Session["BalAmt"] = calbalamt.ToString();//Use for calculating balance amt
        //                    txtBalamt.Text = calbalamt.ToString();
        //                    lblValNoOfBill.Text = noofbills.ToString();
        //                    lblValAllBillsAmount.Text = addedamt.ToString();
        //                    lblValTDSAmount.Text = addcaltds.ToString();

        //                }
        //                else
        //                {
        //                    AdjAmt.Text = "";
        //                    tds.Text = "";
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}

        protected void DRpDwnLstPmntTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DRpDwnLstPmntTyp.SelectedItem.Text == "Cash")
                {
                    //txtBnkNm.Enabled = false;
                    txtChqOrDftNo.Enabled = false;
                }
                else
                {
                    //txtBnkNm.Enabled = true;
                    txtChqOrDftNo.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        //protected void txtAmt_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        decimal i;
        //        if (!decimal.TryParse(txtAmt.Text, out i))
        //        {
        //            lblAmtMsg.Text = "Enter Only Numbers";
        //        }
        //        else
        //        {
        //            if (!string.IsNullOrEmpty(txtAmt.Text) || string.IsNullOrEmpty(txtDisc.Text))
        //            {
        //                txtBalamt.Text = (Convert.ToDecimal(txtAmt.Text) - Convert.ToDecimal(txtDisc.Text)).ToString();
        //            }
        //            //CalBalAmt();
        //            lblAmtMsg.Text = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}

        protected void txtDisc_TextChanged(object sender, EventArgs e)
        {
        //    try
        //    {
        //        decimal i;
        //        if (!decimal.TryParse(txtDisc.Text, out i))
        //        {
        //            lblAmtMsg.Text = "Enter Only Numbers";
        //        }
        //        else
        //        {
        //            if (!string.IsNullOrEmpty(txtAmt.Text) || string.IsNullOrEmpty(txtDisc.Text))
        //            {
        //                txtBalamt.Text = (Convert.ToDecimal(txtAmt.Text) - Convert.ToDecimal(txtDisc.Text)).ToString();
        //            }
        //            //CalBalAmt();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        }
        //protected void CalBalAmt()
        //{
        //    try
        //    {

        //        if ((!string.IsNullOrEmpty(txtAmt.Text) || string.IsNullOrEmpty(txtDisc.Text)) && !string.IsNullOrEmpty(txtBalamt.Text))
        //        {
        //            foreach (GridViewRow gvrow in GrdVwInvoice.Rows)
        //            {
        //                if (gvrow.RowType == DataControlRowType.DataRow)
        //                {
        //                    //finding the checkbox in the gridview
        //                    CheckBox chksel = (gvrow.Cells[0].FindControl("chksel") as CheckBox);
        //                    // checking which checkbox are selected
        //                    if (chksel.Checked)
        //                    {
        //                        double balamt = Convert.ToDouble(Session["BalAmt"]);
        //                        double calbalamt = (balamt + Convert.ToDouble(txtAmt.Text)) - Convert.ToDouble(txtDisc.Text);
        //                        txtBalamt.Text = calbalamt.ToString();
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}

        //protected void GrdVwInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        //Show Adjust amount and tds in update mode
        //        if (Request.QueryString["ReceiptId"] != null)
        //        {
        //            if (e.Row.RowType == DataControlRowType.DataRow)
        //            {
        //                //finding the checkbox in the gridview
        //                //CheckBox chksel = (gvrow.Cells[0].FindControl("chksel") as CheckBox);
        //                Label invoiceid = (e.Row.Cells[0].FindControl("lblInvoiceId") as Label);
        //                Label invoiceNo = (e.Row.Cells[0].FindControl("lblInvoiceNo") as Label);
        //                Label Date = (e.Row.Cells[0].FindControl("lblDate") as Label);
        //                Label Amt = (e.Row.Cells[0].FindControl("lblamt") as Label);
        //                CheckBox chksel = (e.Row.Cells[0].FindControl("chksel") as CheckBox);

        //                Label AdjAmt = (e.Row.Cells[0].FindControl("lbladjamt") as Label);
        //                Label tds = (e.Row.Cells[0].FindControl("lbltds") as Label);
        //                double amt = double.Parse(Amt.Text);

        //                double tdsperc = Convert.ToDouble(txtTDSPerc.Text);
        //                double caltdsInRs = (amt * tdsperc) / 100;
        //                int invid = int.Parse(invoiceid.Text);

        //                //SqlDataReader dr = blObjAddRec.GetAdjustAmtForUpdate(RecId, amt,invoiceId );
        //                SqlDataReader dr = blObjAddRec.GetAdjustAmtForUpdate(RecId, amt, invid);
        //                if (dr != null)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        chksel.Checked = true;
        //                        noofbills++;
        //                        addedamt += amt;
        //                        addcaltds += caltdsInRs;
        //                        int ReceiptId = dr.GetInt32(0);
        //                        decimal amt1 = dr.GetDecimal(1);
        //                        if (amt1 == Convert.ToDecimal(Amt.Text))
        //                        {

        //                            AdjAmt.Text = amt.ToString();
        //                            tds.Text = caltdsInRs.ToString();
        //                        }
        //                    }
        //                    dr.Close();
        //                }
        //                lblValNoOfBill.Text = noofbills.ToString();
        //                lblValAllBillsAmount.Text = addedamt.ToString();
        //                lblValTDSAmount.Text = addcaltds.ToString();

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}

        //protected void BtnClearRec_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        lblResult.Text = "";
        //        lblCatchError.Text = "";
        //        ClearAll();
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}

        //protected void btnSaveRecpt_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        recId = int.Parse(txtRecNo.Text);
        //        if (validate())
        //        {
        //            CustomValidator1.IsValid = true;
        //            CustomValidator1.ErrorMessage = "";
        //            int intReceiptNo = Convert.ToInt32(txtRecNo.Text);
        //            DateTime dateReceiptDate = Convert.ToDateTime(txtRecDate.Text);
        //            int mode = 0;
        //            int intClId = Convert.ToInt32(txtClId.Text);
        //            int intGrpId;
        //            if (txtGrpId.Text == "")
        //                intGrpId = 0;
        //            else
        //                intGrpId = Convert.ToInt32(txtGrpId.Text);
        //            string strpaytyp = DRpDwnLstPmntTyp.SelectedItem.Text;
        //            double doubleAmt = Convert.ToDouble(txtAmt.Text);
        //            double doubleTDS = Convert.ToDouble(txtTDSReadOnly.Text);
        //            double doubledisc = Convert.ToDouble(txtDisc.Text);
        //            string strBnkNm = txtBnkNm.Text;
        //            string strChqDftNo = txtChqOrDftNo.Text;
        //            DateTime dtChqDftDate = Convert.ToDateTime(txtChqOrDftDt.Text);
        //            int intAgainstBills = 0;
        //            if (chkAgainstBills.Checked == true)
        //                intAgainstBills = 1;
        //            else intAgainstBills = 0;
        //            double doublebalAmt = double.Parse(txtBalamt.Text);
        //            int intTDSCertRecvd = 0;
        //            if (chkbxTDSCertRecvd.Checked == true)
        //                intTDSCertRecvd = 1;
        //            else intTDSCertRecvd = 0;
        //            string strCmmnts = txtCoommnts.Text;
        //            string strClNm = DrplstClRec.SelectedItem.Text;
        //            string strSubGrpNm = txtSubGrpNm.Text;
        //            int intIsDel = 0;
        //            if (rbtnlstIsDel.SelectedItem.Text == "Yes")
        //                intIsDel = 1;
        //            else
        //                intIsDel = 0;
        //            double BillAmt = Convert.ToDouble(txtBllAmt.Text);
        //            double TDSPerc = Convert.ToDouble(txtTDSPerc.Text);
        //            int intApp = 0;
        //            if (chkbxAppRecpt.Checked == true)
        //                intApp = 1;
        //            else
        //                intApp = 0;
        //            BLAddReceipt bladdRec = new BLAddReceipt();
        //            if (Request.QueryString["ReceiptId"] != null)
        //            {
        //                mode = 1;
        //                RecId = int.Parse(Request.QueryString["ReceiptId"]);
        //                bladdRec.UpdateReceipt(RecId, dateReceiptDate, intGrpId, strpaytyp, doubleAmt, doubleTDS, doubledisc, strBnkNm, strChqDftNo, dtChqDftDate, intAgainstBills, doublebalAmt, intTDSCertRecvd, strCmmnts, strSubGrpNm, intIsDel, BillAmt, TDSPerc, intApp);
        //                updateAdjustAmount(mode, RecId);
        //                DrplstClRec.Enabled = true;
        //                lblResult.Visible = true;
        //                lblResult.Text = "Receipt Details are Updated Successfully";
        //                BtnClearRec.Enabled = true;
        //                recId++;
        //                txtRecNo.Text = recId.ToString();
        //                ClearAll();
        //            }
        //            else
        //            {
        //                bladdRec.addReceipt(intReceiptNo, dateReceiptDate, intClId, intGrpId, strpaytyp, doubleAmt, doubleTDS, doubledisc, strBnkNm, strChqDftNo, dtChqDftDate, intAgainstBills, doublebalAmt, intTDSCertRecvd, strCmmnts, strClNm, strSubGrpNm, intIsDel, BillAmt, TDSPerc, intApp);

        //                updateAdjustAmount(mode, recId);
        //                recId++;
        //                txtRecNo.Text = recId.ToString();

        //                lblResult.Visible = true;
        //                lblResult.Text = "Receipt Details are Added Successfully";
        //                DrplstClRec.Enabled = true;
        //                ClearAll();
        //            }
        //        }
        //        else
        //        {
        //            CustomValidator1.IsValid = false;
        //            CustomValidator1.ErrorMessage = "*";
        //            CustomValidator1.ToolTip = "Enter Proper Amt";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblCatchError.Text = ex.Message.ToString();
        //    }
        //}

    }
}
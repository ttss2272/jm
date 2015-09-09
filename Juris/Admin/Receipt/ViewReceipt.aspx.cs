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
    public partial class ViewReceipt : System.Web.UI.Page
    {
        DataTable dtViewRec = new DataTable();
        BLViewReceipt blVwRec = new BLViewReceipt();
        int RecNo = 0; bool isonacc = true; int recno; decimal amt; string mode; DateTime recdt; string ClNm; int App; string clnm;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";
                lblMessage.Text = "";
                if ((HttpContext.Current.Session["LoginId"]) == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                if (IsPostBack)
                {
                    calExtendrFromDt.SelectedDate = DateTime.ParseExact(txtFromRecpt.Text, calExtendrFromDt.Format, null);
                    CalextendrToDt.SelectedDate = DateTime.ParseExact(txtToRecpt.Text, CalextendrToDt.Format, null);
                    dtViewRec.Columns.Add("Receipt No");
                    dtViewRec.Columns.Add("Date");
                    dtViewRec.Columns.Add("Client Name");
                    dtViewRec.Columns.Add("Amount");
                    dtViewRec.Columns.Add("Mode");
                    dtViewRec.Columns.Add("Type");
                    lblCatchError.Text = "";
                    lblMessage.Text = "";
                    lblmsg.Text = "";
                }
                else
                {
                    txtFromRecpt.Text = System.DateTime.Now.ToShortDateString();
                    txtToRecpt.Text = System.DateTime.Now.ToShortDateString();

                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnAdNwReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Admin/Receipt/AddReceipt.aspx");
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
        Purpose :- View Receipt Add Messages When Grid Not fill for required condition
     */
        #region-----------drpdwnlstApp_SelectedIndexChanged------------
        protected void drpdwnlstApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClNm = txtClNmRecpt.Text;
                RecNo = 0; isonacc = true;
                recno = 0; string recdate;
                DateTime from = Convert.ToDateTime(txtFromRecpt.Text);
                DateTime to = Convert.ToDateTime(txtToRecpt.Text);

                if (txtRecNo.Text != "")
                {
                    RecNo = Convert.ToInt32(txtRecNo.Text);
                }
                App = Convert.ToInt32(drpdwnlstApp.SelectedItem.Value);
                if (ClNm != "" && txtRecNo.Text != "" && drpdwnlstApp.SelectedItem.Text != "--Select--")
                {
                    GdVwRecpt.DataSource = null;
                    GdVwRecpt.DataBind();
                    SqlDataReader dr = blVwRec.ViewRecByClNmRecNoApp1(ClNm, RecNo, App, from, to);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            isonacc = dr.GetBoolean(5);

                            recno = dr.GetInt32(0);
                            recdt = dr.GetDateTime(1);
                            recdate = recdt.ToShortDateString();
                            //DateTime recdt = dr.GetDateTime(1);
                            clnm = dr.GetString(2);
                            amt = dr.GetDecimal(3);
                            mode = dr.GetString(4);

                            if (isonacc == true)
                            {

                                string type = "OnAccount";

                                dtViewRec.Rows.Add(recno, recdate, clnm, amt, mode, type);
                            }
                            else
                            {
                                string type = "Against Bills";
                                dtViewRec.Rows.Add(recno, recdate, clnm, amt, mode, type);
                            }

                            GdVwRecpt.DataSource = dtViewRec;
                            GdVwRecpt.DataBind();
                        }
                        dr.Close();
                    }
                    else
                    {
                        lblMessage.Text = "Record Not Found";
                        lblNoOfTrns.Text = "0";
                        lblTotAmt.Text = "0.00";
                    }
                    if (GdVwRecpt.Rows.Count > 0)
                    {
                        SqlDataReader dr1 = blVwRec.getNoOfTrnsToAmtbyRecNo1(ClNm, RecNo, App, from, to);
                        if (dr1.HasRows == true)
                        {
                            while (dr1.Read())
                            {
                                lblNoOfTrns.Text = Convert.ToString(dr1.GetInt32(0));
                                lblTotAmt.Text = Convert.ToString(dr1.GetDecimal(1));
                            }
                        }
                    }


                }
                if (ClNm != "" && txtRecNo.Text == "" && drpdwnlstApp.SelectedItem.Text != "--Select--")
                {
                    GdVwRecpt.DataSource = null;
                    GdVwRecpt.DataBind();
                    SqlDataReader dr = blVwRec.GetRecClFrmToApp1(ClNm, App, from, to);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            isonacc = dr.GetBoolean(5);

                            recno = dr.GetInt32(0);
                            recdt = dr.GetDateTime(1);
                            recdate = recdt.ToShortDateString();
                            clnm = dr.GetString(2);
                            amt = dr.GetDecimal(3);
                            mode = dr.GetString(4);

                            if (isonacc == true)
                            {

                                string type = "OnAccount";

                                dtViewRec.Rows.Add(recno, recdate, clnm, amt, mode, type);
                            }
                            else
                            {
                                string type = "Against Bills";
                                dtViewRec.Rows.Add(recno, recdate, clnm, amt, mode, type);
                            }
                        }
                        dr.Close();
                        GdVwRecpt.DataSource = dtViewRec;
                        GdVwRecpt.DataBind();
                    }
                    else
                    {
                        lblMessage.Text = "Record Not Found";
                        lblNoOfTrns.Text = "0";
                        lblTotAmt.Text = "0.00";
                    }
                    if (GdVwRecpt.Rows.Count > 0)
                    {
                        SqlDataReader dr1 = blVwRec.GetNoOfTrnsTotAmtRec1(ClNm, App, from, to);
                        if (dr1.HasRows)
                        {
                            dr1.Read();

                            lblNoOfTrns.Text = Convert.ToString(dr1.GetInt32(0));
                            lblTotAmt.Text = Convert.ToString(dr1.GetDecimal(1));

                            dr1.Close();
                        }
                    }
                }

                if (txtClNmRecpt.Text == "" && txtRecNo.Text == "" && drpdwnlstApp.SelectedItem.Text != "--Select--")
                {
                    GdVwRecpt.DataSource = null;
                    GdVwRecpt.DataBind();
                    SqlDataReader dr = blVwRec.ViewRecFromToApp1(from, to, App);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            isonacc = dr.GetBoolean(5);

                            recno = dr.GetInt32(0);
                            recdt = dr.GetDateTime(1);
                            recdate = recdt.ToShortDateString();
                            clnm = dr.GetString(2);
                            amt = dr.GetDecimal(3);
                            mode = dr.GetString(4);

                            if (isonacc == true)
                            {

                                string type = "OnAccount";

                                dtViewRec.Rows.Add(recno, recdate, clnm, amt, mode, type);
                            }
                            else
                            {
                                string type = "Against Bills";
                                dtViewRec.Rows.Add(recno, recdate, clnm, amt, mode, type);
                            }
                        }
                        dr.Close();
                        GdVwRecpt.DataSource = dtViewRec;
                        GdVwRecpt.DataBind();
                    }
                    else
                    {
                        lblMessage.Text = "Record Not Found !From Date to Till Date";
                        lblNoOfTrns.Text = "0";
                        lblTotAmt.Text = "0.00";
                    }
                    if (GdVwRecpt.Rows.Count > 0)
                    {
                        SqlDataReader dr1 = blVwRec.GetNoOfTrnsFromToApp(from, to, App);
                        if (dr1.HasRows == true)
                        {
                            dr1.Read();

                            lblNoOfTrns.Text = Convert.ToString(dr1.GetInt32(0));
                            lblTotAmt.Text = Convert.ToString(dr1.GetDecimal(1));
                            dr1.Close();
                        }
                    }
                }


                if (txtClNmRecpt.Text == "" && txtRecNo.Text != "" && drpdwnlstApp.SelectedItem.Text != "--Select--")
                {
                    GdVwRecpt.DataSource = null;
                    GdVwRecpt.DataBind();
                    SqlDataReader dr = blVwRec.GetRecByRecNoApp(RecNo, App);
                    if (dr.HasRows)
                    {
                        dr.Read();
                        isonacc = dr.GetBoolean(5);
                        recno = dr.GetInt32(0);

                        recdt = dr.GetDateTime(1);
                        recdate = recdt.ToShortDateString();
                        clnm = dr.GetString(2);
                        amt = dr.GetDecimal(3);
                        mode = dr.GetString(4);


                        if (isonacc == true)
                        {

                            string type = "OnAccount";

                            dtViewRec.Rows.Add(recno, recdate, clnm, amt, mode, type);
                        }
                        else
                        {
                            string type = "Against Bills";
                            dtViewRec.Rows.Add(recno, recdate, clnm, amt, mode, type);
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Record Not Found !For This Status";
                    }
                    dr.Close();
                    GdVwRecpt.DataSource = dtViewRec;
                    GdVwRecpt.DataBind();
                    if (GdVwRecpt.Rows.Count > 0)
                    {
                        SqlDataReader dr1 = blVwRec.GetNoOfTransRecNoApp(recno, App);
                        if (dr1.HasRows == true)
                        {
                            dr1.Read();

                            lblNoOfTrns.Text = Convert.ToString(dr1.GetInt32(0));
                            lblTotAmt.Text = Convert.ToString(dr1.GetDecimal(1));
                            dr1.Close();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion


        protected void GdVwRecpt_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowindex = row.RowIndex;
                int RecId = int.Parse(GdVwRecpt.Rows[rowindex].Cells[1].Text);
                Response.Redirect("~/Admin/Receipt/AddReceipt.aspx?ReceiptId=" + RecId);
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        protected void chkbxAgstBl_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int app = 0;
                if (chkbxAgstBl.Checked == true)
                {
                    ClNm = txtClNmRecpt.Text;
                    string recNum = txtRecNo.Text;
                    if (recNum == "")
                    {
                        RecNo = 0;
                    }
                    else
                    {
                        RecNo = int.Parse(txtRecNo.Text);
                    }
                    DateTime from = Convert.ToDateTime(txtFromRecpt.Text);
                    DateTime to = Convert.ToDateTime(txtToRecpt.Text);
                    if (drpdwnlstApp.SelectedItem.Text != "--Select--")
                    {
                        app = Convert.ToInt32(drpdwnlstApp.SelectedItem.Value);
                    }
                    else
                        app = 2;
                    SqlDataReader dr = blVwRec.getAgainstBills(ClNm, RecNo, from, to, app);
                    if (dr.HasRows == true)
                    {
                        lblmsg.Text = "";
                        while (dr.Read())
                        {
                            isonacc = Convert.ToBoolean(dr["IsOnAccount"]);
                            recno = dr.GetInt32(0);
                            recdt = Convert.ToDateTime(dr["ReceiptDate"]);
                            string recdate = recdt.ToShortDateString();
                            clnm = dr["ClientName"].ToString();
                            amt = Convert.ToDecimal(dr["Amount"]);
                            mode = dr["PaymentType"].ToString();

                            if (isonacc == true)
                            {
                                string type = "OnAccount";
                                dtViewRec.Rows.Add(recno, recdate, clnm, amt, mode, type);
                            }
                            else
                            {
                                string type = "Against Bills";
                                dtViewRec.Rows.Add(recno, recdate, clnm, amt, mode, type);
                            }
                            GdVwRecpt.DataSource = dtViewRec;
                            GdVwRecpt.DataBind();
                        }
                        dr.Close();

                    }
                    else
                    {
                        GdVwRecpt.DataSource = dtViewRec;
                        GdVwRecpt.DataBind();
                        lblmsg.Text = "Records not Available";
                    }
                    if (GdVwRecpt.Rows.Count > 0)
                    {
                        BLViewReceipt blObjAgainstBill = new BLViewReceipt();
                        SqlDataReader drGetAgainstBill = blObjAgainstBill.getNoOfTransRecAgainstBills(ClNm, RecNo, from, to, app);
                        if (drGetAgainstBill.HasRows == true)
                        {
                            drGetAgainstBill.Read();
                            lblNoOfTrns.Text = (drGetAgainstBill.GetInt32(0)).ToString();
                            lblTotAmt.Text = drGetAgainstBill.GetDecimal(1).ToString();
                        }

                    }
                    txtClNmRecpt.Text = "";
                    txtRecNo.Text = "";
                }
                else
                {
                    GdVwRecpt.DataSource = null;
                    GdVwRecpt.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        protected void btncncl_Click(object sender, EventArgs e)
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
    }
}
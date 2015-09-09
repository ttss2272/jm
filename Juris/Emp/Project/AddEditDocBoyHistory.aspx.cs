using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer;
using System.Data;


namespace Juris.Emp.Project
{
    public partial class AddEditDocBoyHistory : System.Web.UI.Page
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter();
        int intDBHID = 0;
        DateTime dtDate;
       // int intDBID;
        string strCode;
        string strDocumentBoy;
        string strRemarks;
        int intProjectID;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //ddlSelDocBoy.Items.Insert(0, new ListItem("--Select--", "-1"));
                if ((HttpContext.Current.Session["LoginId"]) == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                if (!Page.IsPostBack)
                {
                    lblPrjId.Text = Session["ProjectID"].ToString();
                    txtDate.Text = DateTime.Now.Date.ToShortDateString();
                    BLDocumentBoy blObjDocB = new BLDocumentBoy();
                    SqlDataReader dr = blObjDocB.getDocumentBoy1();
                    ddlSelDocBoy.Items.Clear();
                    ddlSelDocBoy.Items.Insert(0, new ListItem("--Select--", "-1"));
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            string strcode = dr.GetString(1);
                            string strname = dr.GetString(2);
                            string strCodeName = strcode + " - " + strname;
                            ddlSelDocBoy.Items.Add(strCodeName);
                        }
                    }
                    else
                    {
                        lblCatchError.Text = "";
                    }
                    dr.Close();
                    fillgridDocBoyHistory();
                    fillgridDocBoyHistoryDetails();
                }
                else
                {
                    lblresult.Text = "";
                    lblresult1.Text = "";
                    lblCatchError.Text = "";
                    lblErrorMsg.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        public void fillgridDocBoyHistory()
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
                cmd.CommandText = "getDocOnDocBoyHistory";
                param = new SqlParameter("@ProjectID", lblPrjId.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Int32;
                cmd.Parameters.Add(param);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GVSelPendingDoc.DataSource = ds.Tables[0];
                    GVSelPendingDoc.DataBind();
                }
                else
                {
                    lblErrorMsg.Text = "Records not available";
                    GVSelPendingDoc.DataSource =null;
                    GVSelPendingDoc.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        public void fillgridDocBoyHistoryDetails()
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
                cmd.CommandText = "fillGridDBHistoryDetails";
                //da = new SqlDataAdapter(cmd);
                //da.Fill(ds);
                param = new SqlParameter("@ProjectID", lblPrjId.Text);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    GVViewDocBoy.DataSource = ds.Tables[0];
                    GVViewDocBoy.DataBind();
                }
                else
                {
                    lblErrorMsg.Text = "Records not available";
                    GVViewDocBoy.DataSource = null;
                    GVViewDocBoy.DataBind();
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
                dtDate = Convert.ToDateTime(txtDate.Text);
                strCode = lblCode.Text;
                strDocumentBoy = ddlSelDocBoy.SelectedItem.Text;
                strRemarks = txtRemarks.Text;
                intProjectID = int.Parse(lblPrjId.Text);
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
                BLDocBoyHistory bldb = new BLDocBoyHistory();
                setparameters();
                if (Session["DBHID"] != null)
                {
                    int intDBHID = int.Parse(Session["DBHID"].ToString());
                    int intDBID = getDocBoyID();
                    bldb.updateDocBoyHistory1(intProjectID, dtDate, intDBID, strDocumentBoy, strRemarks, intDBHID);
                    lblErrorMsg.Text = "";
                    Session["DBHID"] = null;
                    lblresult.Visible = true;
                    lblresult.Text = "Document Boy history Successfully updated";
                }
                else
                {
                    int intDBID = getDocBoyID();
                    // intDBID = int.Parse(lblId.Text);
                    bldb.saveDocumentBoyHistory1(dtDate, intDBID, strDocumentBoy, strRemarks, intProjectID);
                    lblErrorMsg.Text = "";
                    Session["DBHID"] = null;
                    lblresult.Visible = true;
                    lblresult.Text = "Document Boy history Successfully added";
                }

                lblId.Text = "";
                lblCode.Text = "";
                txtRemarks.Text = "";
                string strName1 = ddlSelDocBoy.SelectedItem.Text;
                int intProjectId = int.Parse(lblPrjId.Text);
                SqlDataReader dr1 = bldb.getDocBoyhistoryId1(strName1, intProjectId);
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        intDBHID = dr1.GetInt32(0);
                    }
                    dr1.Close();
                }
                //Data Table to get Selected Documents and insert record into document boy history details
                BLDocBoyHistory bldbh = new BLDocBoyHistory();
                BLProject blp = new BLProject();
                DataTable dtSelDocument = new DataTable();
                DataTable dtUnSelDocument = new DataTable();
                dtSelDocument.Columns.AddRange(new DataColumn[1] { new DataColumn("Docid") });
                dtSelDocument.Columns.AddRange(new DataColumn[1] { new DataColumn("Document") });
                dtUnSelDocument.Columns.AddRange(new DataColumn[1] { new DataColumn("Docid") });
                dtUnSelDocument.Columns.AddRange(new DataColumn[1] { new DataColumn("Document") });
                foreach (GridViewRow gvrow in GVSelPendingDoc.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        //finding the checkbox in the gridview
                        CheckBox ChkBxSelDoc = (gvrow.Cells[0].FindControl("ChkBxSelDoc") as CheckBox);
                        // checking which checkbox are selected
                        if (ChkBxSelDoc.Checked)
                        {
                            int docid = int.Parse(gvrow.Cells[1].Text);
                            string Doc = gvrow.Cells[2].Text;
                            dtSelDocument.Rows.Add(docid, Doc);
                        }
                        else
                        {
                            string Docid = gvrow.Cells[1].Text;
                            string Doc = gvrow.Cells[2].Text;
                            dtUnSelDocument.Rows.Add(Docid, Doc);
                        }
                    }
                }

                //DataTable dt = (DataTable)dtSelDocument;
                for (int i = 0; i < dtSelDocument.Rows.Count; i++)
                {
                    int docid = int.Parse(dtSelDocument.Rows[i].Field<string>(0));
                    string doc = dtSelDocument.Rows[i].Field<string>(1);
                    bldb.saveDocBoyHistoryDetails1(intDBHID, docid, doc);
                   
                    Session["DBHID"] = null;
                    lblresult1.Visible = true;
                    lblresult1.Text = "Document Boy history details Successfully added";
                }
                for (int i = 0; i < dtUnSelDocument.Rows.Count; i++)
                {
                    int docid = int.Parse(dtUnSelDocument.Rows[i].Field<string>(0));
                    bldbh.delUnselectedDocOfDocBoy1(intDBHID, docid);
                }
                if (dtUnSelDocument != null)
                {
                    GVSelPendingDoc.DataSource = dtUnSelDocument;
                    GVSelPendingDoc.DataBind();
                }

                //show grid for document boy history details
                fillgridDocBoyHistoryDetails();
                //lblresult.Text = "Exist";
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected int getDocBoyID()
        {
            try
            {
                int docboyid = 0;
                string strname = ddlSelDocBoy.SelectedItem.Text;
                int len = strname.Length;
                int index = strname.IndexOf("- ");
                index += 2;
                string strname1 = strname.Substring(index, len - index);

                BLDocBoyHistory bldb = new BLDocBoyHistory();
                string strName1 = ddlSelDocBoy.SelectedItem.Text;
                SqlDataReader dr = bldb.getDocBoyIdCode1(strname1);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        docboyid = dr.GetInt32(0);
                        lblCode.Text = dr.GetString(1);
                    }
                    dr.Close();
                }
                return docboyid;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
                return 0;
            }
        }
        protected void ddlSelDocBoy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getDocBoyID();

            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void GVViewDocBoy_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                BLDocBoyHistory bldb = new BLDocBoyHistory();
                int gvDocid;
                int intProjectId = int.Parse(Session["ProjectId"].ToString());
                System.Data.DataTable dt3 = new System.Data.DataTable();
                if (e.CommandName == "EditDocBoyHistory")
                {
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    //int DocBoyId = Conavert.ToInt32(GVViewDocBoy.Rows[rowIndex].Cells[1].Text);
                    int intDBHID = int.Parse(GVViewDocBoy.Rows[rowIndex].Cells[1].Text);
                    Session["DBHID"] = intDBHID;
                    SqlDataReader dr = bldb.getDBHistDetails1(intProjectId, intDBHID);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DateTime dtdate = dr.GetDateTime(1);
                            txtDate.Text = dtdate.ToShortDateString();
                            int intDocumentboyId = dr.GetInt32(2);
                            ddlSelDocBoy.SelectedItem.Text = dr.GetString(3);
                            txtRemarks.Text = dr.GetString(4);
                            DataTable dt = bldb.getSelectedUnSelectedDoc1(intProjectId, intDocumentboyId, dtdate, intDBHID);
                            GVSelPendingDoc.DataSource = dt;
                            GVSelPendingDoc.DataBind();
                            SqlDataReader dr1 = bldb.getSelDocFromDBHDetails1(intProjectId, intDocumentboyId, dtdate, intDBHID);
                            dt3.Columns.Add("Docid");
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    int docid = dr1.GetInt32(0);
                                    dt3.Rows.Add(docid);
                                }
                            }
                            dr1.Close();
                        }
                        dr.Close();
                    }

                    foreach (GridViewRow gvrow in GVSelPendingDoc.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            gvDocid = int.Parse(gvrow.Cells[1].Text);
                            System.Web.UI.WebControls.CheckBox chksel = (gvrow.Cells[0].FindControl("ChkBxSelDoc") as System.Web.UI.WebControls.CheckBox);
                            for (int i = 0; i < dt3.Rows.Count; i++)
                            {
                                int doc = int.Parse(dt3.Rows[i].Field<string>(0));
                                if (doc == gvDocid)
                                {
                                    chksel.Checked = true;
                                }
                            }
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
                Response.Redirect("~/employeeHome.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtDate.Text = DateTime.Today.Date.ToShortDateString();
                txtRemarks.Text = "";
                fillgridDocBoyHistory();
                Session["DBHID"] = null;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
    }
}
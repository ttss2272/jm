using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer;
using System.Windows.Forms;

namespace Juris.Emp.Clerk
{
    public partial class AddEditClerk : System.Web.UI.Page
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string strClerkName;
        string strAddress1;
        string strAddress2;
        string strAddress3;
        string strAddress4;
        string strTelephone;
        string strMobile;
        string strPanNo;
        string strEmailId;
        decimal decTDSRate;
        int intClerkId; int intIsDeleted = 0; int intApprove = 0;
        BLClerk blc = new BLClerk();

        // Name-: Snehal
        // Purpose-:Load Add,Edit Clerk page,and fill dropdownlist at page load and check if request.querystring to check for add or update
        #region------------protected void Page_Load(object sender, EventArgs e)-----------------
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connstr);
                if ((HttpContext.Current.Session["LoginId"]) == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                if (!Page.IsPostBack)
                {
                    //int intClerkId = 0;
                    if (Request.QueryString["ClerkId"] != null)
                    {
                       int intClerkId = int.Parse(Request.QueryString["ClerkId"]);
                        SqlDataReader dr = blc.getClerkDetailsForUpdate1(intClerkId);
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                txtClerkNm.Enabled = false;
                                btnClearAddClerk.Enabled = false;
                                txtClerkNm.Text = dr.GetString(1);
                                txtClrkAdd1.Text = dr.GetString(2);
                                txtClrkAdd2.Text = dr.GetString(3);
                                txtClrkAdd3.Text = dr.GetString(4);
                                txtClrkAdd4.Text = dr.GetString(5);
                                txtTelephnClrk.Text = dr.GetString(6);
                                txtMobClrk.Text = dr.GetString(7);
                                txtPanNoClrk.Text = dr.GetString(8);
                                txtEmailClrk.Text = dr.GetString(9);
                                txtTDSRateClrk.Text = dr.GetDecimal(10).ToString();
                                bool isdel = dr.GetBoolean(11);
                                if (isdel == true)
                                    rbYes.Checked = true;
                                else
                                    rbNo.Checked = true;
                                int approve = dr.GetInt32(12);
                                if (approve == 1)
                                    chkBxApprove.Checked = true;
                                else
                                    chkBxApprove.Checked = false;
                                if (txtTelephnClrk.Text == "-")
                                {
                                    txtTelephnClrk.Text = "";
                                }
                                if (txtMobClrk.Text == "-")
                                {
                                    txtMobClrk.Text = "";
                                }
                                if (txtPanNoClrk.Text == "-")
                                {
                                    txtPanNoClrk.Text = "";
                                }
                                if (txtEmailClrk.Text == "-")
                                {
                                    txtEmailClrk.Text = "";
                                }
                            }
                            dr.Close();
                        }
                    }
                    else
                    {

                    }

                }
                else
                {
                    lblError.Text = "";
                    lblResult.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = (ex).ToString(); ;
            }
        }
       
        #endregion

        // Name-: Snehal
        // Purpose-:Set parameters for save and edit clerk
        #region---------- protected void setparameters()--------------
        protected void setparameters()
        {
            try
            {
                //intClerkId=int.Parse(Request.QueryString["ClerkId"]);
                strClerkName = txtClerkNm.Text;
                strAddress1 = txtClrkAdd1.Text;
                strAddress2 = txtClrkAdd2.Text;
                strAddress3 = txtClrkAdd3.Text;
                strAddress4 = txtClrkAdd4.Text;
                strTelephone = txtTelephnClrk.Text;
                strMobile = txtMobClrk.Text;
                strPanNo = txtPanNoClrk.Text;
                strEmailId = txtEmailClrk.Text;
                decTDSRate = decimal.Parse(txtTDSRateClrk.Text);

                if (rbYes.Checked == true)
                    intIsDeleted = 1;
                else
                    intIsDeleted = 0;


                if (chkBxApprove.Checked == true)
                    intApprove = 1;
                else
                    intApprove = 0;
            }
            catch (Exception ex)
            {
                lblError.Text = (ex).ToString();
            }
        }
        #endregion

        // Name-: Snehal
        // Purpose-:Save details after add and edit of clerk
        #region-------protected void btnSaveAddClerk_Click(object sender, EventArgs e)-------------
        protected void btnSaveAddClerk_Click(object sender, EventArgs e)
        {
            try
            {
                setparameters();
                if (Request.QueryString["ClerkId"] != null)
                {
                    setparameters();
                    intClerkId = int.Parse(Request.QueryString["ClerkId"]);
                    blc.updateClerk1(intClerkId, strAddress1, strAddress2, strAddress3, strAddress4, strTelephone, strMobile, strPanNo, strEmailId, decTDSRate, intIsDeleted, intApprove);
                    lblResult.Visible = true;
                    lblResult.Text = "Clerk Details are Updated Successfully";
                    txtClerkNm.Enabled = true;
                    btnClearAddClerk.Enabled = true;
                }
                else
                {
                    string msg = blc.saveClerk1(strClerkName, strAddress1, strAddress2, strAddress3, strAddress4, strTelephone, strMobile, strPanNo, strEmailId, decTDSRate, intIsDeleted, intApprove);
                    if (msg == "1")
                    {
                        lblResult.Visible = true;
                        lblResult.ForeColor = System.Drawing.Color.Green;
                        lblResult.Text = "Clerk Details are Added Successfully";
                    }
                    else
                    {
                        lblResult.Visible = true;
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Text = "Clerk Details are already Exists";
                    }
                }
                Clearfields();
            }
            catch (Exception ex)
            {
                lblError.Text = (ex).ToString();
            }
        }
        #endregion

        // Name-: Snehal
        // Purpose-:Clear all controls saving details of clerk
        #region----------------protected void Clearfields()-----------------
        protected void Clearfields()
        {
            try
            {
                txtClerkNm.Text = "";
                txtClrkAdd1.Text = "";
                txtClrkAdd2.Text = "";
                txtClrkAdd3.Text = "";
                txtClrkAdd4.Text = "";
                txtTelephnClrk.Text = "";
                txtMobClrk.Text = "";
                txtPanNoClrk.Text = "";
                txtEmailClrk.Text = "";
                txtTDSRateClrk.Text = "";
                rbYes.Checked = false;
                //rbNo.Checked = false;
                chkBxApprove.Checked = false;
            }
            catch (Exception ex)
            {
                lblError.Text = (ex).ToString();
            }
        }
        #endregion

        // Purpose-:Clear all controls after button click
        #region-------------------- protected void btnClearAddClerk_Click(object sender, EventArgs e)-----------
        protected void btnClearAddClerk_Click(object sender, EventArgs e)
        {
            Clearfields();
        }
        #endregion

        // Purpose-:Redirect on Admin home page after clicking cancel button
        #region-----------------protected void btnCancl_Click(object sender, EventArgs e)--------------
        protected void btnCancl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/employeeHome.aspx");
        }
        #endregion
    }
}
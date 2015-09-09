using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer;

namespace Juris.Emp.Services
{
    public partial class AddEditService : System.Web.UI.Page
    {
        #region--------Connection String and variable Declare Part----------------------
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        int intIsDeleted = 0;
        int intApprove = 0;
        int intServiceId;
        string strServiceName;
        #endregion


        /*
         created by :- Swapnil
         * created date:
         * updated date
         Purpose :- Add Edit Service Page load
         * logic
         */

        #region-----Page_Load-----------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["ServiceId"] == null)
                    {
                        if ((HttpContext.Current.Session["LoginId"]) == null)
                        {
                            Response.Redirect("~/Login.aspx");
                        }
                    }

                    if (Session["ServiceId"] != null)
                    {
                        SqlConnection con = new SqlConnection(connstr);
                        lblServiceId.Text = Session["ServiceId"].ToString();
                        int intServiceId = int.Parse(Session["ServiceId"].ToString());
                        BLServices blc = new BLServices();
                        con.Open();
                        SqlDataReader dr = blc.getServiceDetailsForUpdate1(intServiceId);
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                btnClear.Enabled = false;
                                txtServiceNm.Text = dr.GetString(1);
                                bool isdel = dr.GetBoolean(2);
                                if (isdel == true)
                                    rbYesIsDelSer.Checked = true;
                                else
                                    rbNoIsDelSer.Checked = true;
                                int approve = dr.GetInt32(3);
                                if (approve == 1)
                                    chBxApproveServc.Checked = true;
                                else
                                    chBxApproveServc.Checked = false;
                            }
                            dr.Close();
                        }
                    }
                }
                else
                {
                    lblResult.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region-----void setparameters---------------
        protected void setparameters()
        {
            try
            {
                strServiceName = txtServiceNm.Text;

                if (rbYesIsDelSer.Checked == true)
                    intIsDeleted = 1;
                else
                    intIsDeleted = 0;


                if (chBxApproveServc.Checked == true)
                    intApprove = 1;
                else
                    intApprove = 0;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        /* Name:- swapnil joshi
         purpose:- set Session["ServiceId"] = null on btnSaveService_Click
        */
        #region------------btnSaveService_Click-----------------------------
        protected void btnSaveService_Click(object sender, EventArgs e)
        {
            try
            {
                BLServices bls = new BLServices();
                setparameters();

                if (Session["ServiceId"] != null)
                {
                    intServiceId = int.Parse(Session["ServiceId"].ToString());
                    bls.updateService1(intServiceId, strServiceName, intIsDeleted, intApprove);
                    lblResult.Visible = true;
                    lblResult.Text = "Service Details are Updated Successfully";
                    //Session.Clear();
                    Session["ServiceId"] = null;
                    btnClear.Enabled = true;
                }
                else
                {
                   string msg = bls.saveServices1(strServiceName, intIsDeleted, intApprove);
                   if (msg == "1")
                   {
                       lblResult.Visible = true;
                       lblResult.ForeColor = System.Drawing.Color.Green;
                       lblResult.Text = "Service Details are Added Successfully";
                   }
                   else
                   {
                       lblResult.Visible = true;
                       lblResult.ForeColor = System.Drawing.Color.Red;
                       lblResult.Text = "Service Details are Already Exists";
                   }
                    //Session.Clear();
                    Session["ServiceId"] = null;
                }
                ClearFields();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        protected void ClearFields()
        {
            try
            {
                txtServiceNm.Text = "";
                rbYesIsDelSer.Checked = false;
                //rbNoIsDelSer.Checked = false;
                chBxApproveServc.Checked = false;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #region------------btnClear_Click----------------------------
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFields();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

       /* Name:- swapnil joshi
        purpose:- set Session["ServiceId"] = null on btncncl_Click
        */
        #region-------------btncncl_Click---------------------------
        protected void btncncl_Click(object sender, EventArgs e)
        {
            try
            {
                // Session.Abandon();
                Session["ServiceId"] = null;
                Response.Redirect("~/employeeHome.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion
    }
}
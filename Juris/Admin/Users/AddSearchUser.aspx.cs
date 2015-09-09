using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace Juris.Admin.User
{
    public partial class AddSearchUser : System.Web.UI.Page
    {
        //ADD Comment
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        BLAddSearchUser blAddUser = new BLAddSearchUser();
        /*Name:-Yogita
         Purpose:-Add Edit User
         */
        #region------PageLoad---------
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
                    FillUser();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion
        #region-------FillUserGridview-------
        protected void FillUser()
        {
            try
            {
                SqlDataReader dr = blAddUser.FillUserAtLoad1();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    grdvwSerchUser.DataSource = dt;
                    grdvwSerchUser.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion
        #region---------Submit button Click------
        protected void btnSubmitUsr_Click(object sender, EventArgs e)
        {
            try
            {
                string Usrname = txtUNm.Text;
                string password = txtPass.Text;
                string MailID = txtUMailID.Text;
                string type = drpDwnlstType.SelectedItem.Text;
                int isdel = 0;
                if (ChkbxIsDelUsr.Checked == true)
                    isdel = 1;
                else isdel = 0;
                BLAddSearchUser bladdusr = new BLAddSearchUser();

                if (HttpContext.Current.Session["UserId"] != null)
                {
                    int Userid = int.Parse(Session["UserId"].ToString());
                    drpDwnlstType.Enabled = false;
                    string result = bladdusr.UpdateUser(Userid, Usrname, password, MailID, isdel);
                    if (result == "1")
                        lblMsg.Text = "Record Updated Sucessfully";
                    else
                        lblMsg.Text = "Username already exists";
                    Session["UserId"] = null;
                    txtUNm.Enabled = true;
                    drpDwnlstType.Enabled = true;
                    FillUser();
                }
                else
                {
                    string result = bladdusr.addSearchUser(Usrname, password, type, MailID, isdel);
                    if (result == "1")
                        lblMsg.Text = "Record Added Sucessfully";
                    else
                        lblMsg.Text = "Username already exists";
                    FillUser();
                    Session["UserId"] = null;
                }

                txtUNm.Text = "";
                txtPass.Text = "";
                txtUMailID.Text = "";
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion
        #region------Search User By Approve---------
        protected void drpdwnlstTypSrch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string unm = txtUNmSrch.Text;
                string type = drpdwnlstTypSrch.SelectedItem.Text;
                BLAddSearchUser blAddUser = new BLAddSearchUser();
                SqlDataReader dr = blAddUser.FillUsrNmType1(unm, type);
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
                grdvwSerchUser.DataSource = dt;
                grdvwSerchUser.DataBind();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion
        #region--------Search User By Is Deleted--------
        protected void chkbxSrchIsDel_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                int isdel = 0;
                if (chkbxSrchIsDel.Checked == true)
                    isdel = 1;
                else
                    isdel = 0;
                string unm = txtUNmSrch.Text;
                string type = drpdwnlstTypSrch.SelectedItem.Text;
                BLAddSearchUser blAddUser = new BLAddSearchUser();

                if (txtUNmSrch.Text != "" && chkbxSrchIsDel.Checked == true)
                {
                    SqlDataReader dr = blAddUser.userisdeleted(unm, isdel);
                    if (dr.HasRows)
                    {
                        grdvwSerchUser.DataSource = dr;
                    }
                    grdvwSerchUser.DataBind();

                }
                if (txtUNmSrch.Text == "" && (chkbxSrchIsDel.Checked == true || chkbxSrchIsDel.Checked == false) && drpdwnlstTypSrch.SelectedItem.Text == "--Select--")
                {
                    SqlDataReader dr = blAddUser.userisdeleted(unm, isdel);
                    if (dr.HasRows)
                    {
                        grdvwSerchUser.DataSource = dr;
                    }
                    grdvwSerchUser.DataBind();

                }

                if (txtUNmSrch.Text != "" && (drpdwnlstTypSrch.SelectedItem.Text == "Both" || drpdwnlstTypSrch.SelectedItem.Text == "admin" || drpdwnlstTypSrch.SelectedItem.Text == "employee"))
                {
                    SqlDataReader dr = blAddUser.FillUsrNmTypeIsDel1(unm, type, isdel);
                    if (dr.HasRows)
                    {
                        grdvwSerchUser.DataSource = dr;
                        grdvwSerchUser.DataBind();
                    }
                }
                if ((drpdwnlstTypSrch.SelectedItem.Text == "Both" || drpdwnlstTypSrch.SelectedItem.Text == "admin" || drpdwnlstTypSrch.SelectedItem.Text == "employee") && (chkbxSrchIsDel.Checked == true || chkbxSrchIsDel.Checked == false))
                {
                    SqlDataReader dr = blAddUser.FillTypeIsDel1(type, isdel);
                    if (dr.HasRows)
                    {
                        grdvwSerchUser.DataSource = dr;
                    }
                    grdvwSerchUser.DataBind();

                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        #endregion
        #region--------Show User Details On Edit Button---------
        protected void grdvwSerchUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                BLAddSearchUser blEditUsr = new BLAddSearchUser();
                if (e.CommandName == "UpdateThis")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowindex = row.RowIndex;
                    int UserId = int.Parse(grdvwSerchUser.Rows[rowindex].Cells[1].Text);
                    Session["UserId"] = UserId;
                    SqlDataReader dr = blEditUsr.GetUserById(UserId);
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtUNm.Text = dr.GetString(1);
                        txtUNm.Enabled = false;
                        txtPass.TextMode = TextBoxMode.SingleLine;
                        txtPass.Text = dr.GetString(2);
                        string type = dr.GetString(3);
                        if (dr["MailID"] != DBNull.Value)
                        {
                            txtUMailID.Text = dr.GetString(5);
                        }
                        else
                        {
                            txtUMailID.Text = "";
                        }
                        
                        drpDwnlstType.Enabled = false;
                        drpDwnlstType.SelectedValue = type;
                        bool isdel = dr.GetBoolean(4);
                        if (isdel == true)
                            ChkbxIsDelUsr.Checked = true;
                        else
                            ChkbxIsDelUsr.Checked = false;
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
        #region--------Cancel button---------
        protected void btnCancl_Click(object sender, EventArgs e)
        {
            try
            {
                //Session.Abandon();
                Response.Redirect("~/adminHome.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion
        #region--------Clear Session of user on Page Unload------
        protected void Page_Unload(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Session["UserId"] = null;
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
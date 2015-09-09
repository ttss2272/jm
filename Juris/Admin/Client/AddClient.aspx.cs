using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;

namespace Juris.Admin.Client
{
    public partial class AddClient : System.Web.UI.Page
    {
        #region--------------Variable decleration-------------
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        DataTable dtSelSer;
        string strClientNm; string strAdd1; string strAdd2; string strAdd3;
        string strAdd4; string strTel; string strMob; string strPan; string strBranch; string strCity; string strConPer1; string strConPer2;
        string strConPer3; string strCntct1; string strCntct2; string strCntct3; string strEmail1; string strEmail2; string strEmail3; int intIsDel = 0;
        int intIsApprve = 0; string strPrefix;
        int id, ClId = 0; int intserviceTax = 0;
        BLAddClient blaCl = new BLAddClient();
        string emilinv;
        string mulemailid; int ClientId; int upClientId; int ServiceId; double price;
        int btnAddClientFlag = 0;
        #endregion

        /*
         *Name:-Yogita 
         *Purpose:-Add Edit Client and Services
          */
        BLAddClient blAddCl = new BLAddClient();
        #region------PageLoad-------
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connstr);
                if ((HttpContext.Current.Session["LoginId"]) == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                dtSelSer = new DataTable();
                if (!Page.IsPostBack)
                {
                    setClientCode();
                    BindServiceDropdown();
                    SqlDataReader drserId = blAddCl.GetServiceIdByNm1(drpDwnlstSerNm.SelectedItem.Text);
                        if (drserId.HasRows)
                        {
                            drserId.Read();
                            lblSerId.Text = drserId.GetInt32(0).ToString();
                            drserId.Close();
                        }
                       
                    if (Request.QueryString["ClientId"] != null)
                    {
                        int ClientId = int.Parse(Request.QueryString["ClientId"]);
                        txtClientNm.Enabled = false;
                        UpdateClientDetails(ClientId);
                    }
                    else
                    {
                        //delTempService();
                    }
                }
                else
                {
                    lblCatchError.Text = "";
                    lblser.Text = "";
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
        /* Name :-Yogita
         * Purpose:-set Client code function created
       
         */
        #region-------Set Client Code function--------
        protected void setClientCode()
        {
            try
            {
                SqlDataReader dr = blAddCl.getClientId();

                if (dr.HasRows)
                {
                    dr.Read();
                    id = dr.GetInt32(0);
                    dr.Close();
                    //id++;
                }
                txtClientCode.Text = "JMC" + id;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region------Set Service Name On Page Load -----------
        protected void BindServiceDropdown()
        {
            try
            {
                SqlDataReader drSer = blAddCl.GetServiceNm();
                if (drSer.HasRows)
                {
                    while (drSer.Read())
                        drpDwnlstSerNm.Items.Add(drSer.GetString(0));
                    drSer.Close();
                }
                else
                {
                    lblErrorMsg.Text = "Services not Available";
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region ------------delete temp services-------
        public void delTempService()
        {
            try
            {
                int loginid = int.Parse(Session["LoginId"].ToString());
                blaCl.delTempService(loginid);
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region----------get Update Client details in edit mode-------
        protected void UpdateClientDetails(int ClientId)
        {
            try
            {
                BLAddClient blUpClient = new BLAddClient();
                SqlDataReader dr = blUpClient.GetClientDetails(ClientId);
                if (dr.HasRows)
                {
                    dr.Read();
                    txtClientCode.Text = "JMC" + ClientId;
                    txtClientNm.Text = dr.GetString(1);
                    txtadd1.Text = dr.GetString(2);
                    txtadd2.Text = dr.GetString(3);
                    txtadd3.Text = dr.GetString(4);

                    txtPin.Text = dr.GetString(5);
                    if (dr["Telephone"].ToString() == "-")
                    {
                        txtTelClient.Text = "";
                    }
                    else
                    {
                        txtTelClient.Text = dr.GetString(6);
                    }
                    string mobno = dr.GetString(7);
                    if (mobno == "-")
                    {
                        txtMobClient.Text = "";
                    }
                    else
                    {
                        txtMobClient.Text = mobno;
                    }
                    txtPANClient.Text = dr.GetString(8);
                    txtClientBranch.Text = dr.GetString(9);
                    txtCityClient.Text = dr.GetString(10);
                    txtContactPer1.Text = dr.GetString(11);
                    txtContactPer2.Text = dr.GetString(12);
                    txtContactPer3.Text = dr.GetString(13);
                    txtContact1.Text = dr.GetString(14);
                    txtContact2.Text = dr.GetString(15);
                    txtContact3.Text = dr.GetString(16);
                    string email1 = dr.GetString(17);
                    string email2 = dr.GetString(18);
                    string email3 = dr.GetString(19);
                    if (email1 == "-")
                        txtEmailId1.Text = "";
                    else
                        txtEmailId1.Text = email1;
                    if (email2 == "-")

                        txtEmailId2.Text = "";
                    else
                        txtEmailId2.Text = email2;
                    if (email3 == "-")
                        txtEmailId3.Text = "";
                    else

                        txtEmailId3.Text = email3;
                    bool isdel = dr.GetBoolean(20);
                    if (isdel == true)
                        rbtnYesIsDel.Checked = true;
                    else
                        rbtnNoIsDel.Checked = true;
                    txtPrefix.Enabled = false;
                    txtPrefix.Text = dr.GetString(21);
                    int app = dr.GetInt32(22);
                    if (app == 1)
                        chkbxAppCl.Checked = true;
                    else
                        chkbxAppCl.Checked = true;
                    txtSerTaxClient.Text = dr.GetInt32(23).ToString();
                    if (dr["emailinv"] == DBNull.Value)
                    {
                        txtEmlIdInvce.Text = "";
                    }
                    else
                    {
                        txtEmlIdInvce.Text = dr.GetString(24);
                    }
                    if (dr["multiemail"] == DBNull.Value)
                    {
                        txtMulEmailId.Text = "";
                    }
                    else
                    {
                        txtMulEmailId.Text = dr.GetString(25);
                    }


                    dr.Close();
                    btnClearFlds.Enabled = false;
                }
                getServicesForUpdate(ClientId);

            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region----get services for update-----
        public void getServicesForUpdate(int ClientId)
        {
            try
            {
                SqlDataReader drGetServices = blaCl.GetServForUpdateClientServices(ClientId);
                if (drGetServices.HasRows)
                {
                    GdVwService.DataSource = drGetServices;
                    GdVwService.DataBind();
                    drGetServices.Close();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region------ set parameters with controls value-----
        protected void SetParameters()
        {
            try
            {
                //txtClientNm.Enabled=false;
                strClientNm = txtClientNm.Text;
                strAdd1 = txtadd1.Text;
                strAdd2 = txtadd2.Text;
                strAdd3 = txtadd3.Text;
                strAdd4 = txtPin.Text;
                strTel = txtTelClient.Text;
                strMob = txtMobClient.Text;
                strPan = txtPANClient.Text;
                strBranch = txtClientBranch.Text;
                strCity = txtCityClient.Text;
                strConPer1 = txtContactPer1.Text;
                strConPer2 = txtContactPer2.Text;
                strConPer3 = txtContactPer3.Text;
                strCntct1 = txtContact1.Text;
                strCntct2 = txtContact2.Text;
                strCntct3 = txtContact3.Text;
                strEmail1 = txtEmailId1.Text;
                strEmail2 = txtEmailId2.Text;
                strEmail3 = txtEmailId2.Text;
                intIsDel = 0;
                if (rbtnYesIsDel.Checked == true)
                    intIsDel = 1;
                else
                    intIsDel = 0;

                intIsApprve = 0;
                if (chkbxAppCl.Checked == true)
                    intIsApprve = 1;
                else
                    intIsApprve = 0;
                strPrefix = txtPrefix.Text;

                int intserviceTax = Convert.ToInt32(txtSerTaxClient.Text);
                //BLAddClient blaCl = new BLAddClient();
                emilinv = txtEmlIdInvce.Text;
                mulemailid = txtMulEmailId.Text;
                txtSerPrice.Text = "0";

            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }

        }
        #endregion

        #region------Button Save Click Client save-------------
        protected void btnSaveClient_Click(object sender, EventArgs e)
        {
            try
            {
                SetParameters();
                if (Request.QueryString["ClientId"] != null)
                {
                    upClientId = int.Parse(Request.QueryString["ClientId"]);
                    string result = blaCl.UpdateClient(upClientId, strAdd1, strAdd2, strAdd3, strAdd4, strTel, strMob, strPan, strBranch, strCity, strConPer1, strConPer2, strConPer3, strCntct2, strCntct2, strCntct3, strEmail1, strEmail2, strEmail3, intIsDel, strPrefix, intIsApprve, intserviceTax, emilinv, mulemailid);
                    if (result == "1")
                    {
                        lblResult.Visible = true;
                        lblResult.Text = "Client Details are Updated Successfully";
                        SaveServicesForClient(upClientId);
                        setClientCode();
                    }
                    GdVwService.DataSource = null;
                    GdVwService.DataBind();
                    Session["SelectedServices"] = null;
                    txtClientNm.Enabled = true;
                    txtPrefix.Enabled = true;
                    ClearAllFields();
                    btnClearFlds.Enabled = true;
                }
                else
                {
                    string msg = blaCl.addClient(strClientNm, strAdd1, strAdd2, strAdd3, strAdd4, strTel, strMob, strPan, strBranch, strCity, strConPer1, strConPer2, strConPer3, strCntct1, strCntct2, strCntct3, strEmail1, strEmail2, strEmail3, intIsDel, strPrefix, intIsApprve, intserviceTax, emilinv, mulemailid);
                    if (msg == "1")
                    {
                        lblPrefixmsg.Text = "Client Added Successfully";
                    }
                    else
                    {
                        lblPrefixmsg.Text = msg;
                        delTempService();
                    }
                    getclientid();
                    if (msg == "1")
                    {
                        SaveServicesForClient(ClId);
                    }
                    ClId = getclientid();
                    //ClId++;
                    txtClientCode.Text = "JMC" + ClId;
                    GdVwService.DataSource = null;
                    GdVwService.DataBind();
                    ClearAllFields();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region---------GetClientId for display-----------
        public int getclientid()
        {
            try
            {
                BLAddClient blgetSer = new BLAddClient();
                SqlDataReader dr = blgetSer.GetClientId1();
                if (dr.HasRows)
                {
                    dr.Read();
                    ClId = dr.GetInt32(0);
                    dr.Close();
                }
                return ClId;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
                return 0;
            }
        }
        #endregion

        #region----------Save Services for client----------
        protected void SaveServicesForClient(int ClId)
        {
            try
            {
                //Save Selected Services For Client
                DataTable dtSelServices = new DataTable();
                dtSelServices.Columns.AddRange(new DataColumn[1] { new DataColumn("ClientId") });
                dtSelServices.Columns.AddRange(new DataColumn[1] { new DataColumn("ServiceId") });
                dtSelServices.Columns.AddRange(new DataColumn[1] { new DataColumn("Price") });
                foreach (GridViewRow gvrow in GdVwService.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        ClientId = ClId;
                        ServiceId = int.Parse(gvrow.Cells[1].Text);
                        double Price = double.Parse(gvrow.Cells[2].Text);
                        dtSelServices.Rows.Add(ClientId, ServiceId, Price);

                    }

                }

                for (int i = 0; i < dtSelServices.Rows.Count; i++)
                {
                    ClientId = int.Parse(dtSelServices.Rows[i].Field<string>("ClientId"));
                    ServiceId = int.Parse(dtSelServices.Rows[i].Field<string>("ServiceId"));
                    price = double.Parse(dtSelServices.Rows[i].Field<string>("Price"));
                    decimal newprice = Convert.ToDecimal(price);
                    blaCl.UpdateServiceForClient(ClientId, ServiceId, newprice);
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region-------Function Clear control values------------
        public void ClearAllFields()
        {
            try
            {
                txtClientNm.Text = "";
                txtPrefix.Text = "";
                txtadd1.Text = "";
                txtadd2.Text = "";
                txtadd3.Text = "";
                txtPin.Text = "";
                txtTelClient.Text = "";
                txtMobClient.Text = "";
                txtPANClient.Text = "";
                txtClientBranch.Text = "";
                txtCityClient.Text = "";
                txtContactPer1.Text = "";
                txtContact1.Text = "";
                txtContact2.Text = null;
                txtContact3.Text = "";
                txtContactPer2.Text = "";
                txtContactPer3.Text = "";
                txtEmailId1.Text = "";
                txtEmailId2.Text = "";
                txtEmailId3.Text = "";
                txtMulEmailId.Text = "";
                rbtnYesIsDel.Checked = true;
                rbtnNoIsDel.Checked = false;
                chkbxAppCl.Checked = false;
                GdVwService.DataSource = null;
                GdVwService.DataBind();
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region------Button to clear All values---------
        protected void btnClearFlds_Click(object sender, EventArgs e)
        {
            try
            {
                lblResult.Text = "";
                lblCatchError.Text = "";
                ClearAllFields();
                txtClientNm.Enabled = true;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region------------Select Services From Dropdownlist and Show Serviceid in label------
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string SerNm = drpDwnlstSerNm.SelectedItem.Text;
                BLAddClient blGetSerId = new BLAddClient();
                SqlDataReader drGetSerId = blGetSerId.GetServiceIdByNm1(SerNm);
                if (drGetSerId.HasRows)
                {
                    drGetSerId.Read();

                    lblSerId.Text = Convert.ToString(drGetSerId.GetInt32(0));
                    drGetSerId.Close();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region----------Function to get Temp services--------
        public void getTempService(int clientid)
        {
            try
            {
                int loginid = int.Parse(Session["LoginId"].ToString());

                DataSet ds = blaCl.getTempService(loginid, clientid);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    GdVwService.DataSource = ds;
                    GdVwService.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region----------Button to add services ------------
        protected void btnAddSer_Click(object sender, EventArgs e)
        {
            try
            {
                int loginid = int.Parse(Session["LoginId"].ToString());
                int clientid = 0;
                if (Request.QueryString["ClientId"] == null)
                {
                    if (Convert.ToInt32(txtSerPrice.Text) == 0)
                    {
                        lblser.Text = "Enter Price greter than Zero";
                    }
                    else
                    {
                        clientid = getclientid();
                        clientid++;
                        ServiceId = int.Parse(lblSerId.Text);
                        string price = txtSerPrice.Text;
                        string msg = blaCl.saveTempService(loginid, ServiceId, price, clientid);

                        getTempService(clientid);
                        lblser.Text = "Successfully";
                    }
                }
                else
                {
                    clientid = int.Parse(Request.QueryString["ClientId"]);
                    ServiceId = int.Parse(lblSerId.Text);
                    string price = txtSerPrice.Text;
                    string msg = blaCl.saveTempService(loginid, ServiceId, price, clientid);

                    getTempService(clientid);
                    lblser.Text = "Successfully";
                }

            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region-------Button to go to home page--------
        protected void btnCncl_Click(object sender, EventArgs e)
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
        /* Name:Yogita
          Purpose:In EDit Mode Select service and edit price */
        #region---------GridviewOnCheck------
        protected void onCheck(object sender, EventArgs e)
        {
            try
            {
                lblser.Text = "";
                string servicename = "";
                foreach (GridViewRow gvrow in GdVwService.Rows)
                {

                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        ServiceId = int.Parse(gvrow.Cells[1].Text);
                        price = double.Parse(gvrow.Cells[2].Text);
                        SqlDataReader dr = blaCl.GetServiceNmById(ServiceId);
                        if (dr.HasRows)
                        {
                            dr.Read();
                            servicename = dr.GetString(0);
                        }
                        System.Web.UI.WebControls.CheckBox chksel = (gvrow.Cells[0].FindControl("chksel") as System.Web.UI.WebControls.CheckBox);
                        if (chksel.Checked)
                        {
                            lblSerId.Text = ServiceId.ToString();
                            txtSerPrice.Text = price.ToString();
                            drpDwnlstSerNm.SelectedValue = servicename;
                        }
                    }
                }
                foreach (GridViewRow gvrow in GdVwService.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        System.Web.UI.WebControls.CheckBox chksel = (gvrow.Cells[0].FindControl("chksel") as System.Web.UI.WebControls.CheckBox);
                        if (chksel.Checked)
                        {
                            chksel.Checked = false;
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
    }
}



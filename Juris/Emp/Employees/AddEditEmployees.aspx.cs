using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer;


namespace Juris.Emp.Employees
{
    public partial class AddEditEmployees : System.Web.UI.Page
    {
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        string strEmployeeCode;
        string strEmployeeName;
        string strAddress1;
        string strAddress2;
        string strAddress3;
        string strPAN;
        string strBankName;
        string strBankAddress;
        string strAccountNo;
        string strBranch;
        string strDesignation;
        int intIsDeleted = 0;
        string strMobile;
        string strTelephone;
        string strEmailID;
        int intApprove = 0;
        int intEmployeeID;
        BLEmployee ble = new BLEmployee();
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
                    lblResult.Text = "";
                    SqlConnection con = new SqlConnection(connstr);
                    con.Open();
                    setEmpCode();
                    if (Request.QueryString["EmpId"] != null)
                    {
                        lblEmpId.Text = Request.QueryString["EmpId"].ToString();
                        int intEmployeeID = int.Parse(lblEmpId.Text);
                        BLEmployee blc = new BLEmployee();
                        SqlDataReader dr2 = blc.getEmpDetailsForUpdate1(intEmployeeID);
                        if (dr2.HasRows)
                        {
                            while (dr2.Read())
                            {
                                txtEmpNm.Enabled = false;
                                txtEmpCode.Enabled = false;
                                btnClearAddEmp.Enabled = false;
                                txtEmpNm.Text = dr2.GetString(1);
                                txtEmpCode.Text = dr2.GetString(2);
                                txtAddressL1.Text = dr2.GetString(3);
                                txtAddressL2.Text = dr2.GetString(4);
                                txtAddressL3.Text = dr2.GetString(5);
                                txtPanNo.Text = dr2.GetString(6);
                                txtBnkNm.Text = dr2.GetString(7);
                                txtBnkAddress.Text = dr2.GetString(8);
                                txtAccNo.Text = dr2.GetString(9);
                                txtBranch.Text = dr2.GetString(10);
                                txtDesig.Text = dr2.GetString(11);
                                txtMobEmp.Text = dr2.GetString(13);
                                txtTelephn.Text = dr2.GetString(14);
                                txtEmail.Text = dr2.GetString(15);

                                bool isdel = dr2.GetBoolean(12);
                                if (isdel == true)
                                    rbYes.Checked = true;
                                else
                                    rbNo.Checked = true;
                                int approve = dr2.GetInt32(16);
                                if (approve == 1)
                                    chkBxApprove.Checked = true;
                                else
                                    chkBxApprove.Checked = false;
                                if (txtMobEmp.Text == "-")
                                {
                                    txtMobEmp.Text = "";
                                }
                                if (txtTelephn.Text == "-")
                                {
                                    txtTelephn.Text = "";
                                }
                                if (txtEmail.Text == "-")
                                {
                                    txtEmail.Text = "";
                                }
                            }

                        }
                        dr2.Close();
                    }
                }
                else
                {
                    lblCatchError.Text = "";
                    lblResult.Text = "";
                }

            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        protected void setEmpCode()
        {
            try
            {
                SqlDataReader dr1 = ble.getEmpMaxCode1();
                if (dr1.HasRows)
                {
                    dr1.Read();
                    lblEmpMaxCode.Text = dr1.GetInt32(0).ToString();
                    dr1.Close();
                }
                string strEmployeeCodeGen = TextBox2.Text + lblEmpMaxCode.Text;
                string strEmployeeCode = strEmployeeCodeGen;
                txtEmpCode.Text = strEmployeeCode;
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
                strEmployeeCode = TextBox2.Text + lblEmpMaxCode.Text;
                strEmployeeName = txtEmpNm.Text;
                strAddress1 = txtAddressL1.Text;
                strAddress2 = txtAddressL2.Text;
                strAddress3 = txtAddressL3.Text;
                strPAN = txtPanNo.Text;
                strBankName = txtBnkNm.Text;
                strBankAddress = txtBnkAddress.Text;
                strAccountNo = txtAccNo.Text;
                strBranch = txtBranch.Text;
                strDesignation = txtDesig.Text;
                if (rbYes.Checked == true)
                    intIsDeleted = 1;
                else
                    intIsDeleted = 0;
                strMobile = txtMobEmp.Text;
                strTelephone = txtTelephn.Text;
                strEmailID = txtEmail.Text;

                if (chkBxApprove.Checked == true)
                    intApprove = 1;
                else
                    intApprove = 0;
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
          Purpose :- Add Edit Emolyee Session null
       */
        #region-----------btnSaveAddEmp_Click------------
        protected void btnSaveAddEmp_Click(object sender, EventArgs e)
        {
            BLEmployee bldb = new BLEmployee();
        setparameters();
            if (Request.QueryString["EmpId"] != null)
            {
                intEmployeeID = int.Parse(Request.QueryString["EmpId"]);
               bldb.updateEmployee1(intEmployeeID, strAddress1, strAddress2, strAddress3, strPAN, strBankName, strBankAddress, strAccountNo, strBranch, strDesignation, intIsDeleted, strMobile, strTelephone, strEmailID, intApprove);
                lblResult.Visible = true;
                lblResult.Text = "Employee Details are Updated Successfully";
                txtEmpNm.Enabled = true;
                txtEmpCode.Enabled = true;
                setEmpCode();
                btnClearAddEmp.Enabled = true;
                
              }
            else
            {
                string msg = bldb.saveEmployee1(strEmployeeName, strEmployeeCode, strAddress1, strAddress2, strAddress3, strPAN, strBankName, strBankAddress, strAccountNo, strBranch, strDesignation, intIsDeleted, strMobile, strTelephone, strEmailID, intApprove);
                if (msg == "1")
                {
                    lblResult.Visible = true;
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Employee Details are Added Successfully";
                }
                else
                {
                    lblResult.Visible = true;
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Employee Details are already Exists.";
                }
                setEmpCode();
             }

            ClearFields();

        }
        #endregion
        protected void ClearFields()
        {
            try
            {
                txtEmpNm.Text = "";
                txtAddressL1.Text = "";
                txtAddressL2.Text = "";
                txtAddressL3.Text = "";
                txtPanNo.Text = "";
                txtBnkNm.Text = "";
                txtBnkAddress.Text = "";
                txtAccNo.Text = "";
                txtBranch.Text = "";
                txtDesig.Text = "";
                txtMobEmp.Text = "";
                txtTelephn.Text = "";
                txtEmail.Text = "";
                rbYes.Checked = false;
                chkBxApprove.Checked = false;
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnClearAddEmp_Click(object sender, EventArgs e)
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

        protected void btnCancl_Click(object sender, EventArgs e)
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

    }
}
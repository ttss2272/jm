using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

//using Microsoft.SqlServer.Management.Smo;
//using Microsoft.SqlServer.Management.Common;

namespace Juris.Admin.Setting
{
    public partial class CreateBackup : System.Web.UI.Page
    {   



        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
            //DataTable dt = new DataTable();   
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string serverName = txtCBServerName.Text;
                string dataBaseName = txtCBDBName.Text;
                string driveName = txtCBDriveName.Text;
                string MyDataBaseName = txtCBDbNameAs.Text;

                con = new SqlConnection(@"Server=" + serverName + ";database=" + dataBaseName + ";Integrated Security=true;");
                //con = new SqlConnection("Data Source="+serverName+";Initial Catalog="+dataBaseName+";User Id=juris; password=Admin12!@");
                driveName +=":\\";
                
                if (!System.IO.Directory.Exists(driveName))
                {
                    lblCreateMsg.Text = "Drive does not exists";
                }
                else
                {
                    try
                    {
                        driveName += MyDataBaseName;
                        con.Open();
                        cmd = new SqlCommand("backup database "+dataBaseName+" to disk='" + driveName + ".Bak'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblCreateMsg.ForeColor = System.Drawing.Color.Green;
                        lblCreateMsg.Text = " Database Backup Created Successfully";

                        txtCBServerName.Text = "";
                        txtCBDBName.Text = "";
                        txtCBDriveName.Text = "";
                        txtCBDbNameAs.Text = "";
                     }
                    catch (Exception ex)
                    {
                        lblCreateMsg.Text = "Error Occured During DB backup process !<br>";
                    }
                }
            }
            catch (Exception ee)
            {
                Response.Write("Failed to back up");

            }
        }

        protected void btnSvSave_Click(object sender, EventArgs e)
        {
            try
            {
                string FilePath = "D:\\";
                con = new SqlConnection(@"Server=TT-1101-PC\SQLEXPRESS;Database=JurisMetricMain;Trusted_Connection=Yes");
                //con = new SqlConnection("Data Source=youjobsindia.com;Initial Catalog=Youjobsi_YouJobsDB;User Id=juris; password=Admin12!@");

                if (!System.IO.Directory.Exists(FilePath))
                {
                    lblSaveBk.Text = "Drive does not exists";
                }
                else
                {
                    try
                    {
                        FilePath += "JurisBackup.Bak";
                        con.Open();
                        cmd = new SqlCommand(@"RESTORE DATABASE JurisMetricMain FROM disk='D:\JuridBackUp.Bak'",con);// WITH MOVE 'JurisMetricMain' to 'd:\Temp\JurisMetricMain.mdf',MOVE 'JurisNew21_2' to 'd:\Temp\JurisNew21_2.ldf',REPLACE", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblSaveBackup.ForeColor = System.Drawing.Color.Green;
                        lblSaveBackup.Text = " Database Restored Successfully";

                        txtSaveBkDBName.Text = "";
                        txtSaveBkDBNameAs.Text = "";
                        txtSaveBkDriveName.Text = "";
                        txtSaveBkServerName.Text = "";
                    }
                    catch (Exception ex)
                    {
                        lblSaveBk.Text = "Error Occured During DB Restore process !<br>";
                    }
                }
            }
            catch (Exception eee)
            {
                lblSaveBk.Text = "Failed to restore";
            }
        }

        protected void btnCreateClear_Click(object sender, EventArgs e)
        {
            txtCBServerName.Text = "";
            txtCBDBName.Text = "";
            txtCBDriveName.Text = "";
            txtCBDbNameAs.Text = "";
            lblCreateMsg.Text = "";
        }

        protected void btnCreateCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/adminHome.aspx");
        }

        protected void btnSvCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/adminHome.aspx");
        }

        protected void btnSvClear_Click(object sender, EventArgs e)
        {
            txtSaveBkServerName.Text = "";
            txtSaveBkDriveName.Text = "";
            txtSaveBkDBName.Text = "";
            txtSaveBkDBNameAs.Text = "";
        }
           
    }
}
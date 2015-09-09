using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;


namespace Juris.Admin.Mail
{
    public partial class SendMail : System.Web.UI.Page
    {
        string sub, from, body, to, cc, bcc, attch;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                sub = Session["clientName"].ToString();
                sub += "-";
                sub += Session["caseName"].ToString();
                if (Session["Remarks"] != null)
                {
                    sub += "-";
                    sub += Session["Remarks"].ToString();
                }
                txtSubject.Text = sub;

                from = Session["Mail"].ToString();
                txtFrom.Text = from;

                body ="Client Name : "+ Session["clientName"].ToString();
                body += "\n";

                if (Session["caseName"]!=null)
                {
                body += "Case Name : " + Session["caseName"].ToString();
                body += "\n";
                }
                if (Session["LoanAcNo"] != null)
                {
                    body +="Loan A/c No. : "+ Session["LoanAcNo"].ToString();
                    body += "\n";
                }

                if (Session["Branch"] != null)
                {
                    body +="Branch Name : "+ Session["Branch"].ToString();
                    body += "\n";
                }

                if (Session["LoanAmmt"] != null)
                {
                    body +="Loan Ammount : "+ Session["LoanAmmt"].ToString();
                    body += "\n";
                }

                if (Session["Property"] != null)
                {
                    body +="Property : "+ Session["Property"].ToString();
                    body += "\n";
                }

                if (Session["Remarks"] != null)
                {
                    body +="Remarks : "+ Session["Remarks"].ToString();
                }

                body += "\n\n";
                body += "Best Regards,\n";
                body += Session["UserName"].ToString();

                txtBody.Text = body;

            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                to = txtTo.Text;
                cc = txtCc.Text;
                bcc = txtBcc.Text;

                if (Session["strFilePath"] != null)
                {
                    string file_name = Session["strFileNM"].ToString();
                    string file_path = Session["strFilePath"].ToString();
                    string filepathSpecificfile = "";
                    string[] values = file_path.Split(',');

                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = values[i].Trim();
                        file_path = values[i];
                        if (file_path.Contains(file_name))
                        {
                            filepathSpecificfile = file_path;
                        }
                    }
                    attch = filepathSpecificfile;
                }
                bool impstatus = false;
                impstatus = Mailer1.SendEmail2(from, to, cc, bcc, sub, body, attch);
                if (impstatus == true)
                {
                    lblMailStatus.Visible = true;
                    lblMailStatus.ForeColor = System.Drawing.Color.Green;
                    lblMailStatus.Text = "Mail Sent Successfully";
                    Session["strFileNM"] = null;
                    Session["strFilePath"] = null;
                    txtFrom.Text = "";
                    txtSubject.Text = "";
                    txtBody.Text = "";
                    txtCc.Text = "";
                    txtBcc.Text = "";
                    txtTo.Text = "";
                }
                else
                {
                    lblMailStatus.Visible = true;
                    lblMailStatus.ForeColor = System.Drawing.Color.Red;
                    lblMailStatus.Text = "Mail Sending Failed";
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnCancelMail_Click(object sender, EventArgs e)
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
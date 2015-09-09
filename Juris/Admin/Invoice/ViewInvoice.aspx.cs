using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using BusinessLayer;
using System.Diagnostics;
using System.IO;
using System.Text;
using iTextSharp.text;
using System.Drawing;
using iTextSharp.text.pdf;
using System.Configuration;
using System.Collections.Specialized;
using System.Net;
using iTextSharp.text.html.simpleparser;
using System.Reflection;
using System.Web.UI.WebControls;
using iTextSharp;
using Microsoft.Office;
using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using word = Microsoft.Office.Interop.Word;
using System.ComponentModel;
using System.Threading;
using System.Net;
using System.Net.Mail;

namespace Juris.Admin.Invoice
{
    public partial class ViewInvoice : System.Web.UI.Page
    {
        
        private string file_path;
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

                }
                else
                {
                    lblError.Text = "";
                    lblCatchError.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;

        /*
        Create By :- Kunal
        Created Date :- 13/3/2015
        Updated Date :- Rameshwar (Added Try Catch)
        Purpose :- View Invoice Dropdown Search
     */
        #region-----------drplstApp_SelectedIndexChanged------------
        protected void drplstApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drplstApp.SelectedItem.Text != "--Select--")
                {
                    string Clinm = txtClNm.Text;
                    string Invno = txtInNo.Text;
                    int app = int.Parse(drplstApp.SelectedItem.Value);
                    ViewInMethod(Clinm, Invno, app);
                }
                else
                {
                    lblError.Text="Records Not Available";
                    GdVwViewInvce.DataSource = null;
                    GdVwViewInvce.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        #endregion

        protected void btnAddNwInvce_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Admin/Invoice/AddInvoice.aspx");
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
        public void ViewInMethod(string ClientNm, string invoiceno, int app)
        {
            try
            {
                string ClNm = ""; string InNo = "";
                BLViewInvoice blViewIn = new BLViewInvoice();
                if (txtClNm.Text == "")
                {
                    ClNm = "NA";
                }
                else
                {
                    ClNm = txtClNm.Text;
                }
                if (txtInNo.Text == "")
                {
                    InNo = "NA";
                }
                else
                {
                    InNo = txtInNo.Text;
                }
                app = Convert.ToInt32(drplstApp.SelectedItem.Value);
                SqlDataReader dr = blViewIn.ViewInvoiceDet(ClNm, InNo, app);
                if (dr.HasRows)
                {
                    GdVwViewInvce.DataSource = dr;
                    GdVwViewInvce.DataBind();
                }
                else
                {
                    GdVwViewInvce.DataSource = null;
                    GdVwViewInvce.DataBind();
                    lblError.Text = "Records not Available";
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void GdVwViewInvce_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditProject")
                {
                    GridViewRow gvr = (GridViewRow)((System.Web.UI.Control)(e.CommandSource)).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    int invoiceid = int.Parse(GdVwViewInvce.Rows[rowIndex].Cells[1].Text);
                    Session["ClientName"] = GdVwViewInvce.Rows[rowIndex].Cells[3].Text;
                    string billno = GdVwViewInvce.Rows[rowIndex].Cells[4].Text;
                    Session["InvoiceNo"] = billno;
                    Response.Redirect("~/Admin/Invoice/AddInvoice.aspx?InvoiceId=" + invoiceid);
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnPrvInvce_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);

                SqlDataAdapter da = new SqlDataAdapter("select InvoiceId from Invoice where InvoiceNo ='" + txtInNo.Text + "'", con);
                DataSet ds = new DataSet();
                con.Open();
                da.Fill(ds);

                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", "Invoice.aspx?InvoiceID=" + ds.Tables[0].Rows[0]["Invoiceid"].ToString()));
               
                /*
                var file_path = Server.MapPath("~\\Document\\");
                if (txtInNo.Text == "")
                {
                    lblResult.Text = "Please Enter Invoice no";
                }
                else
                {
                    lblResult.Text = "";
                    SqlConnection con = new SqlConnection(constr);

                    SqlDataAdapter da = new SqlDataAdapter("select i.InvoiceNo,i.Date,p.ClientName,p.TotalAmount from Invoice i inner join Projects p on i.ClientId=p.ClientID where InvoiceNo ='" + txtInNo.Text + "'", con);
                    DataTable dt = new DataTable();
                    con.Open();

                    da.Fill(dt);
                    DataSet ds = new DataSet();
                    Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(file_path + txtInNo.Text + ".pdf", FileMode.Create));
                    doc.Open();
                    Paragraph p = new Paragraph("Recipt Form \n", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 18f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK));
                    doc.Add(p);
                    Paragraph p2 = new Paragraph(" \n\n");
                    doc.Add(p2);
                    PdfPTable table = new PdfPTable(2);
                    PdfPCell cell = new PdfPCell(new Phrase("Reciept", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 18f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GREEN)));
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 1;
                    table.AddCell(cell);
                    if (table != null)
                    {
                        table.AddCell("InvoiceNo");
                        table.AddCell(dt.Rows[0][0].ToString());
                        table.AddCell("Date");
                        table.AddCell(dt.Rows[0][1].ToString());

                        table.AddCell("Client Name");
                        table.AddCell(dt.Rows[0][2].ToString());
                        table.AddCell("TotalAmount");
                        table.AddCell(dt.Rows[0][3].ToString());
                    }
                    doc.Add(table);
                    Paragraph c_sign = new Paragraph("\nCustomer Signature: \n", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 18f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.MAGENTA));
                    doc.Add(c_sign);
                    Paragraph o_sign = new Paragraph("\nOwner Signature: \n", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 18f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.MAGENTA));
                    doc.Add(o_sign);
                    con.Close();
                    doc.Close();
                    lblmsg.Text = "PDF Created Success";
                    System.Diagnostics.Process.Start(file_path + txtInNo.Text + ".pdf");
                }
                 * */
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
            
        }

        protected void btnEmlInvce_Click(object sender, EventArgs e)
        {
            try
            {
                string sub = "IMP DOCUMENT";
                string attachmentfile = "";
                string value = "";
                string ddlCliNm = "Juris";
                string ddlTypWrk = "Invoice Details";
                string body = "PFA";
                string attch = attachmentfile;
                bool impstatus = false;
                var file_path = Server.MapPath("~\\Document\\");//temp comment
                //var file_path = Server.MapPath(@"~/Downloads/Abc.txt");
                var path = @"~/Downloads/Abc.txt";
                string Path = string.Empty;
                Path = HttpContext.Current.Server.MapPath("~/Downloads/");
                if (rbtnWord0.Checked == true)
                {
                    UIValues();
                    Response.Redirect("DownloadWord.aspx");
                    file_path = Session["file_Path"].ToString();
                    SendEmail(sub, body, file_path);
                }

                if (rbtnExcel0.Checked == true)
                {
                    UIValues();
                    Response.Redirect("DownloadExcel.aspx");
                    file_path = Session["file_Path"].ToString();
                    string file_Name = Session["file_Name"].ToString();
                    // //below code is developed  by raj 
                    sub = "IMP DOCUMENT";
                    attachmentfile = file_path + file_Name + ".xlsx";
                    value = file_path.ToString().Trim();
                    ddlCliNm = "Juris";
                    ddlTypWrk = "Invoice Details";
                    body = ddlCliNm + "\n" + ddlTypWrk + "\n";
                    attch = attachmentfile;
                    impstatus = false;

                    impstatus = Mailer1.SendEmail(sub, body, value);
                    if (impstatus == true)
                    {
                        lblmsg.Text = "Mail Send";
                    }
                    else
                    {
                        lblmsg.Text = "Error in sending mail";
                    }
                    // //code by raj
                    // Mail(file_path);
                }
                if (rbtnPDF0.Checked == true)
                {

                    UIValues();
                    var clientName = "";// = txtClNm.Text;
                    var getinno = "";// = txtInNo.Text;
                    var app = drplstApp.SelectedValue;
                    if (txtClNm.Text == "")
                    {
                        clientName = "NA";
                    }
                    else
                    {
                        clientName = txtClNm.Text;
                    }

                    if (txtInNo.Text == "")
                    {
                        getinno = "NA";
                    }
                    else
                    {
                        getinno = txtInNo.Text;
                    }
                    Session["sessionApp"] = drplstApp.SelectedValue;
                    SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("WordPdfExcel_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClientName", clientName);
                    cmd.Parameters.AddWithValue("@InvoiceNo", getinno);
                    cmd.Parameters.AddWithValue("@Approve", app);

                    cmd.ExecuteNonQuery();
                    SqlDataAdapter sda = new SqlDataAdapter();
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    DataTable dt = new DataTable();
                    // con.Open();

                    sda.Fill(dt);
                    DataSet ds = new DataSet();
                    Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(file_path + txtInNo.Text + ".pdf", FileMode.Create));
                    doc.Open();
                    Paragraph p = new Paragraph("Reciept Form \n", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 18f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK));
                    doc.Add(p);
                    Paragraph p2 = new Paragraph(" \n\n");
                    doc.Add(p2);
                    PdfPTable table = new PdfPTable(2);
                    PdfPCell cell = new PdfPCell(new Phrase("Reciept", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 18f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GREEN)));
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 1;
                    table.AddCell(cell);
                    // foreach(cell)

                    if (table != null)
                    {

                        table.AddCell("InvoiceNo");
                        table.AddCell(dt.Rows[0][0].ToString());
                        table.AddCell("Date");
                        table.AddCell(dt.Rows[0][1].ToString());

                        table.AddCell("Client Name");
                        table.AddCell(dt.Rows[0][2].ToString());
                        table.AddCell("TotalAmount");
                        table.AddCell(dt.Rows[0][3].ToString());

                    }

                    doc.Add(table);
                    Paragraph c_sign = new Paragraph("\nCustomer Signature: \n", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 18f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.MAGENTA));
                    doc.Add(c_sign);
                    Paragraph o_sign = new Paragraph("\nOwner Signature: \n", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 18f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.MAGENTA));
                    doc.Add(o_sign);
                    con.Close();
                    doc.Close();
                    lblmsg.Text = "PDF Created Success";
                    System.Diagnostics.Process.Start(file_path + txtInNo.Text + ".pdf");
                }

                //file_path = Session["file_Path"].ToString();

                // //code by raj 
                sub = "IMP DOCUMENT";
                attachmentfile = file_path + txtInNo.Text + ".pdf";
                value = attachmentfile.ToString().Trim();
                ddlCliNm = "Juris";
                ddlTypWrk = "Invoice Details";
                body = ddlCliNm + "\n" + ddlTypWrk + "\n";
                attch = attachmentfile;
                impstatus = false;

                impstatus = Mailer1.SendEmail(sub, body, value);
                if (impstatus == true)
                {
                    lblmsg.Text = "Mail Send";
                }
                else
                {
                    lblmsg.Text = "Error in sending mail";
                }
                // //code by raj
                //  Mail(file_path);

            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }


        public static bool SendEmail(string sub, string body, string attachfile)
        {
            try
            {
                MailMessage msg = new MailMessage();

                msg.CC.Add("tt.jalmart@gmail.com");
                msg.From = new MailAddress("dhammapal22@gmail.com");
                msg.Subject = sub; //"Hello and Welcome"; // write your subject here
                msg.Body += body;
                msg.Body += "Mail from Juries Web Application,\n";
                msg.Body += "Best Regards,\n";
                msg.Body += "Team Teratech";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(attachfile);
                msg.Attachments.Add(attachment);

                SmtpClient sc = new SmtpClient();
                sc.Host = "smtp.gmail.com";
                sc.Port = 587;
                sc.UseDefaultCredentials = false;

                NetworkCredential nc = new NetworkCredential();
                nc.UserName = "dhammapal22@gmail.com"; // write your username here
                nc.Password = "123456789"; // write your password here           

                sc.Credentials = nc;
                sc.EnableSsl = true;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.Send(msg);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }


        private void UIValues()
        {
            try
            {
                if (txtClNm.Text == "")
                {
                    Session["sessionClNm"] = "NA";
                }
                else
                {
                    Session["sessionClNm"] = txtClNm.Text;
                }

                if (txtInNo.Text == "")
                {
                    Session["sessionInNo"] = "NA";
                }
                else
                {
                    Session["sessionInNo"] = txtInNo.Text;
                }
                Session["sessionApp"] = drplstApp.SelectedValue;
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

        public string attachment { get; set; }
    }
}

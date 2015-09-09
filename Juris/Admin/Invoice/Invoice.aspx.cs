using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Juris.Admin.Invoice
{
    public partial class Invoice : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["InvoiceID"] != null)
                    {
                        ReportDocument reportDocument = new ReportDocument();
                        ParameterField paramField = new ParameterField();
                        ParameterFields paramFields = new ParameterFields();
                        ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
                        paramField.Name = "@InvoiceId";
                        paramDiscreteValue.Value = Convert.ToInt32(Request.QueryString["InvoiceID"]);

                        paramField.CurrentValues.Add(paramDiscreteValue);
                        paramFields.Add(paramField);
                        paramFields.Add(paramField);
                        CrystalReportViewer1.ParameterFieldInfo = paramFields;

                        string reportPath = Server.MapPath("~/Admin/Invoice/crInvoice.rpt");
                        reportDocument.Load(reportPath);
                        //reportDocument.SetParameterValue("@InvoiceId", 1770);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                        Session["ReportDocument"] = reportDocument;
                        int InvoiceId = Convert.ToInt32(Request.QueryString["InvoiceID"]);
                        ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", "Annexure.aspx?InvoiceID=" + InvoiceId));

                        //string strPopupAnnexure = "<script language='javascript' ID='script2'>"
                        //    // Passing intId to popup window.
                        //+ "window.open('Annexure.aspx?InvoiceID=" + HttpUtility.UrlEncode(InvoiceId.ToString())
                        //+ "','new window', 'top=90, left=200, width=768, height=1024, dependant=no, location=0, alwaysRaised=no, menubar=no, resizeable=no, scrollbars=n, toolbar=no, status=no, center=yes')"
                        //+ "</script>";
                        //ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "Script2", strPopupAnnexure, false);
                    }
                    else
                    {
                        string msg = "Session Expired.";
                    }
                }
                else
                {
                    if (Session["ReportDocument"] != null)
                    {
                        ReportDocument doc = (ReportDocument)Session["ReportDocument"];
                        CrystalReportViewer1.ReportSource = doc;
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
            }
        }
    }
}
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

namespace Juris.Admin.Invoice
{
    public partial class Annexure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["InvoiceID"] != null)
                    {
                        DataSet dsLoanNoCount = null;
                        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
                        SqlConnection con = new SqlConnection(constr);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("GetLoanNoCount_SP", con);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InvoiceId", Request.QueryString["InvoiceID"]);
                        SqlDataAdapter daLoanNoCount = new SqlDataAdapter(cmd);
                        dsLoanNoCount = new DataSet();
                        daLoanNoCount.Fill(dsLoanNoCount);
                        con.Close();
                        string reporturl = "";
                        if(dsLoanNoCount.Tables[0].Rows.Count != 0)
                        {
                            if (Convert.ToInt32(Session["InvoiceType"]) == 1)
                            {
                                reporturl = "~/Admin/Invoice/crAnnexure.rpt";
                            }
                            else
                            {
                                reporturl = "~/Admin/Invoice/crAnnexure1.rpt";
                            }
                        }
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

                        string reportPath = Server.MapPath(reporturl);
                        reportDocument.Load(reportPath);
                        CrystalReportViewer1.ReportSource = reportDocument;
                        CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                        Session["ReportDocument"] = reportDocument;
                        
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
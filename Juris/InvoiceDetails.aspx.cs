using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Juris.NewFolder1
{
   
   //Developed By : Raj
  // Created Date: 06-06-2015
    public partial class InvoiceDetails : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
               // int ProjectId;
                int projectid=0;
               // int totalamt;
                //temp code

                string totalamt = Request.QueryString[1];
                int BillNo = Convert.ToInt32(Request.QueryString[0]);
                string typeofwork = Session["Typeofwork"].ToString();
                string ClientName = Session["ClientName"].ToString();
               // string  TotalAmount = Session["TotalAmount"].ToString();
                //int totalamt = Convert.ToInt32(TotalAmount);
                SqlCommand cmd = new SqlCommand("getprojectid", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientName", ClientName);
                cmd.Parameters.AddWithValue("@Price", totalamt);
                cmd.Parameters.AddWithValue("@Typeofwork", typeofwork);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable ResultsTable = new DataTable();
                adapter.Fill(ResultsTable);
                DataTable dt = ResultsTable;
                if (dt.Rows.Count > 0)
                {
                     projectid =Convert.ToInt32(dt.Rows[0][0].ToString());
                }
                //end temp code
                
                SqlCommand cmmd = new SqlCommand("rpt_InvoiceDetails", conn);
                cmmd.CommandType = CommandType.StoredProcedure;
                cmmd.Parameters.AddWithValue("@ClientId", BillNo);
                cmmd.Parameters.AddWithValue("@ProjectId", projectid);
                SqlDataAdapter adpt = new SqlDataAdapter(cmmd);
                DataTable ResultsTable1 = new DataTable();
                adpt.Fill(ResultsTable1);
                DataTable dt1 = ResultsTable1;
                if (dt1.Rows.Count > 0)
                {
                   
                    lblClientName.Text = dt1.Rows[0]["ClientName"].ToString();
                    lblDate.Text = dt1.Rows[0]["Date"].ToString();
                    lblInvoiceNo.Text = dt1.Rows[0]["InvoiceNo"].ToString();
                    lbldate2.Text = dt1.Rows[0]["Date"].ToString();
                    lblpanno.Text = dt1.Rows[0]["PanNo"].ToString();
                    string sumamount = dt1.Rows[0]["TotalAmount"].ToString();
                    if (lblpanno.Text == "" && lblpanno.Text == null)
                    {
                        lblpan.Visible = false;
                    }
            
                    int sum = 0;
                    foreach (DataRow dr in dt1.Rows)
                    {
                        sum += Convert.ToInt32(dr["TotalAmount"]);
                    }
                  
                    string outwords = NumbersToWords(sum);
                    lblTotalAmount.Text = sumamount;
                    lblrupees.Text = outwords;
                    Repeater1.DataSource = dt1;
                    Repeater1.DataBind();
                    Repeater1.Visible = true;

                }
              
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record does not available')", true);
                    Response.Redirect("~/adminHome.aspx");
                }
            }
            //#EndRegin
        }



        private DataTable GetSPResult()
        {
            //#StartRegin
           
           
                DataTable ResultsTable = new DataTable();
                try
                {
                    string bill = BillNo;
                    // int bill = 172;

                    SqlCommand cmd = new SqlCommand("rptInvoiceDetails", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClientId", bill);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ResultsTable);
                }

                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }

                return ResultsTable;
                //#EndRegin
            }
        

        public string BillNo { get; set; }

        protected void GdVwViewInvce_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        public static string NumbersToWords(int inputNumber)
        {
            int inputNo = inputNumber;

            if (inputNo == 0)
                return "Zero";

            int[] numbers = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (inputNo < 0)
            {
                sb.Append("Minus ");
                inputNo = -inputNo;
            }

            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ",
            "Five " ,"Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ",
            "Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ",
            "Seventy ","Eighty ", "Ninety "};
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };

            numbers[0] = inputNo % 1000; // units
            numbers[1] = inputNo / 1000;
            numbers[2] = inputNo / 100000;
            numbers[1] = numbers[1] - 100 * numbers[2]; // thousands
            numbers[3] = inputNo / 10000000; // crores
            numbers[2] = numbers[2] - 100 * numbers[3]; // lakhs

            for (int i = 3; i > 0; i--)
            {
                if (numbers[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (numbers[i] == 0) continue;
                u = numbers[i] % 10; // ones
                t = numbers[i] / 10;
                h = numbers[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }

        public string pnl { get; set; }
    }
}

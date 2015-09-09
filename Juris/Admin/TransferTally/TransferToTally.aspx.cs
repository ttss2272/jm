using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
namespace Juris.Admin.TransferTally
{
    public partial class TransferToTally : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((HttpContext.Current.Session["LoginId"]) == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                BLTransferToTally blObjTrnTally = new BLTransferToTally();
                string fmdt = txtFrom.Text;
                string todt = txtTo.Text;
                if (rbtnlistInvRec.SelectedItem.Text == "Invoice")
                {
                    string msg = blObjTrnTally.transferTallyInv(fmdt, todt);
                    if (msg != "0")
                    {
                        lblMsg.Text = "Data Transfered Sucessfully";
                    }
                    else
                    {
                        lblError.Text = "Error in Transfer records";
                    }
                }
                else
                {
                    string msg = blObjTrnTally.transferTallyRec(fmdt, todt);
                    if (msg != "0")
                    {
                        lblMsg.Text = "Data Transfered Sucessfully";
                    }
                    else
                    {
                        lblError.Text = "Error in Transfer records";
                    }

                }
            }
            catch (Exception ex)
            {
                lblCatchError.Text = ex.Message.ToString();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
namespace BusinessLayer
{
    public class Mailer1
    {
        public static bool SendEmail(string sub,string body,string attachfile)
        {
            
           
            try
            {
                MailMessage msg = new MailMessage();

                msg.CC.Add("tt.jalmart@gmail.com");
                msg.From = new MailAddress("dhammapal22@gmail.com");
                msg.Subject = sub; //"Hello and Welcome"; // write your subject here
                msg.Body += body;
                msg.Body +="Mail from Juries Web Application,\n";
                msg.Body +="Best Regards,\n";
                msg.Body +="Team Teratech";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(attachfile);
                msg.Attachments.Add(attachment);

                SmtpClient sc = new SmtpClient();
                sc.Host ="smtp.gmail.com";
                sc.Port =587;
                sc.UseDefaultCredentials=false;

                NetworkCredential nc = new NetworkCredential();
                nc.UserName = "dhammapal22@gmail.com"; // write your username here
                nc.Password = "dhutrajD1"; // write your password here           

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


        public static bool SendEmail2(string from,string to,string cc,string bcc,string sub, string body, string attachfile)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(from);
                msg.To.Add(to);
                if (cc !="")
                {
                    msg.CC.Add(cc);
                }
                if (bcc != "")
                {
                    msg.Bcc.Add(bcc);
                    
                }
                msg.Subject = sub;
                msg.Body = body;

                if (attachfile != "")
                {
                    System.Net.Mail.Attachment attachment;
                    string[] attach = attachfile.Split(',');
                    foreach (string file in attach)
                    {
                        attachment = new System.Net.Mail.Attachment(file);
                        msg.Attachments.Add(attachment);
                    }
                }
                SmtpClient sc = new SmtpClient();
                sc.Host = "smtp.gmail.com";
                sc.Port = 587;
                sc.UseDefaultCredentials = false;

                NetworkCredential nc = new NetworkCredential();
                nc.UserName = "dhammapal22@gmail.com"; // write your username here
                nc.Password = "dhutrajD1"; // write your password here           

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

     
    }
}

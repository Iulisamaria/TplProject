using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using tplProject.Models.Repositories.SendMail;

namespace tplProject.Services
{
    public class Send:ISend
    {
        public void SendMail(string YourEmail,string YourSubject, String YourName, String Comments)
        {
            // Gmail Address from where you send the mail
            var fromAddress = "iulisa_maria@icloud.com";
            // any address where the email will be sending
            var toAddress = YourEmail;
            //Password of your gmail address
            const string fromPassword = "";
            // Passing the values and make a email formate to display
            string subject = YourSubject;
            string body = "From: " + YourName + "\n";
            body += "Email: " + YourEmail + "\n";
            body += "Subject: " + YourSubject + "\n";
            body += "Question: \n" + Comments + "\n";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
                smtp.EnableSsl = true;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //here on button click what will done 
        //        SendMail();
        //        DisplayMessage.Text = "Your Comments after sending the mail";
        //        DisplayMessage.Visible = true;
        //        YourSubject.Text = "";
        //        YourEmail.Text = "";
        //        YourName.Text = "";
        //        Comments.Text = "";
        //    }
        //    catch (Exception) { }
        //}
    }
}

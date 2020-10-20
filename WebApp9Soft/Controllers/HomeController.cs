using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace WebApp9Soft.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(string con_name, string con_email, string con_subject, string con_message)
        {

            if (con_name != null && con_name != "" && con_email != null && con_email != "" && con_subject != null && con_subject != "" && con_message != null && con_message != "")
            {
                
                    string RequestNumber = DateTime.Now.Day.ToString() +
                                       DateTime.Now.Month.ToString() +
                                       DateTime.Now.Year.ToString() +
                                       DateTime.Now.Hour.ToString() +
                                       DateTime.Now.Minute.ToString() +
                                       DateTime.Now.Second.ToString();


                    SendEmail("sastiService123@gmail.com",
                              "aribajawed163@gmail.com", //Email of customer support employee
                              con_email,
                              "Email Received by " + con_name,
                              con_message,
                              "smtp.gmail.com",
                              587,
                              "sastiService123456",
                              RequestNumber,
                              true);
                    
                }
            return View();
        }



        public void SendEmail(string emailFromAddress,
                                     string emailToAddress,
                                     string emailUser,
                                     string subject,
                                     string body,
                                     string smtpAddress,
                                     int portNumber,
                                     string password,
                                     string RequestNumber,
                                     bool enableSSL)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.CC.Add(emailUser);
                mail.Subject = subject;
                string strBody = "<html><head><Title> Sasti Service </Title></head><body bgcolor='#ccc'>  <h1>Email Notification from Customer</h1><br /> <p>The message has been received by $$$emailUser$$$</p><br /> <h3>Request Number: $$$RequestNumber$$$</h3><br />  <h3>Message: $$$body$$$</h3><br /></body></html>";
                strBody = strBody.Replace("$$$emailUser$$$", emailUser);
                strBody = strBody.Replace("$$$RequestNumber$$$", RequestNumber);
                strBody = strBody.Replace("$$$body$$$", body);
                mail.Body = strBody;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);

                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);



                }
            }
        }




        public ActionResult pvConactusSection()
        {
            return View();
        }
        public ActionResult pvTestimonialSection()
        {
            return View();
        }
        public ActionResult pvLetsTalkSection()
        {
            return View();
        }
    }
}
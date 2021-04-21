using Regele_Marius.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Regele_Marius.Resources;

namespace Regele_Marius.Controllers
{
    public class NotificareController : Controller
    {
        public ActionResult Index()
        {
            try
            {
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info.  
            return this.View();
        }

        /// <summary>  
        /// POST: /EmailNotify/Index  
        /// </summary>  
        /// <param name="model">Model parameter</param>  
        /// <returns>Return - Response information</returns>  
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(EmailNotificareViewModel model)
        {
            try
            {
                // Verification  
                if (ModelState.IsValid)
                {
                    // Initialization.  
                    string emailMsg = "Buna ziua, <br /><br /> Analizele efectuate au statusul: <b style='color: green'> Finalizat </b> <br /><br /> Acestea pot fi accesate prin link-ul urmator: <br /> <br />Multa sanatate, <br />Echipa Marius";
                    string emailSubject = Email.EMAIL_SUBJECT_DEFAULT + " Raport final analize";

                    // Sending Email.  
                    await this.SendEmailAsync(model.ToEmail, emailMsg, emailSubject);


                    // Info.  
                    return this.Json(new { EnableSuccess = true, SuccessTitle = "Success", SuccessMsg = "Notification has been sent successfully! to '" + model.ToEmail + "' Check your email." });
                }
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);

                // Info  
                return this.Json(new { EnableError = true, ErrorTitle = "Error", ErrorMsg = ex.Message });
            }

            // Info  
            return this.Json(new { EnableError = true, ErrorTitle = "Error", ErrorMsg = "Something goes wrong, please try again later" });
        }

        /// <summary>  
        ///  Send Email method.  
        /// </summary>  
        /// <param name="email">Email parameter</param>  
        /// <param name="msg">Message parameter</param>  
        /// <param name="subject">Subject parameter</param>  
        /// <returns>Return await task</returns>  
        public async Task<bool> SendEmailAsync(string email, string msg, string subject = "")
        {
            // Initialization.  
            bool isSend = false;

            try
            {
                // Initialization.  
                var body = msg;
                var message = new MailMessage();

                // Settings.  
                message.To.Add(new MailAddress(email));
                message.From = new MailAddress(Email.FROM_EMAIL_ACCOUNT);
                message.Subject = !string.IsNullOrEmpty(subject) ? subject : Email.EMAIL_SUBJECT_DEFAULT;
                message.Body = body;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    // Settings.  
                    var credential = new NetworkCredential
                    {
                        UserName = Email.FROM_EMAIL_ACCOUNT,
                        Password = Email.FROM_EMAIL_PASSWORD
                    };

                    // Settings.  
                    smtp.Credentials = credential;
                    smtp.Host = Email.SMTP_HOST_GMAIL;
                    smtp.Port = Convert.ToInt32(Email.SMTP_PORT_GMAIL);
                    smtp.EnableSsl = true;

                    // Sending  
                    await smtp.SendMailAsync(message);

                    // Settings.  
                    isSend = true;
                }
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }

            // info.  
            return isSend;
        }
    }
}
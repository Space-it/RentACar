using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class EmailController : Controller
    {
        // Post: Email
        [HttpPost]
        public ActionResult Index()
        {
            SmtpClient smtp = new SmtpClient(comboBoxServer.Text, (int)numericUpDownPort.Value);
            smtp.Credentials = new NetworkCredential(comboBoxFrom.Text, textBoxPass.Text);
            smtp.EnableSsl = true;

            MailMessage emailMes = new MailMessage(comboBoxFrom.Text, comboBoxTo.Text, textBoxTheme.Text, textBoxMessage.Text);

            try
            {
                smtp.Send(emailMes);
            }
            catch (SmtpException smtpEx)
            {

                return View();
            }
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace TeamSurvey
{
    class Mail
    {
        private MailAddress fromAddress = null;
        private MailAddress toAddress = null;
        private String sendPassword = "/*FromEmailPassword*/";

        public Mail(String fromMail)
        {
            this.fromAddress = new MailAddress(fromMail);
        }

        public void setToAddress(String toMail)
        {
            this.toAddress = new MailAddress(toMail);
        }

        public String sendMail(string subject, string body)
        {
            SmtpClient smtp = null;
            MailMessage message = null;

            try
            {
                smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, sendPassword),
                    UseDefaultCredentials = false
                };

                message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                };

                //smtp.Send(message);

                return "Send email to Summer Successfully!";
            }
            catch (Exception e)
            {
                return "Failed to send email to Summer!";
            }
            finally
            {
                if (smtp != null)
                {
                    smtp.Dispose();
                }
                if (message != null)
                {
                    message.Dispose();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Eben.Business.Models;

namespace Eben.Business.Services
{
    public class EmailService
    {
        public string SendEmail(ContactModel contact)
        {
           try
            {
                var message = new MailMessage
                {
                    From = new MailAddress(contact.Email, contact.Name)
                };

                message.To.Add("info@ebenproperty.co.za");
                message.Subject = contact.Service;
                message.Body = contact.Message;
                message.IsBodyHtml = true;
                var client = new SmtpClient
                {
                    Host = "mail.ebenproperty.co.za",
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = false,
                    Credentials = new System.Net.NetworkCredential("info@ebenproperty.co.za", "eben1234@1"),
                    UseDefaultCredentials = false,
                    Port = 25,
            };


                try
                {
                    message.IsBodyHtml = true;
                    client.Send(message);
                    message.Attachments.Dispose();
                    message.Dispose();
                    
                    return "True";
                }
                catch (SmtpException s)
                {
                    message.Attachments.Dispose();
                    message.Dispose();
                    return s.Message;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}

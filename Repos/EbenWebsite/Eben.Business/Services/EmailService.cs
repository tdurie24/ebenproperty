using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Eben.Business.Models;

namespace Eben.Business.Services
{
    public class EmailService
    {
        public bool SendEmail(ContactModel contact)
        {
          //  string Name, string email, string CCEmail, string Subject, string MessageText, List< Attachment > Attachments = null, string AttachmentNames = ""
            try
            {
                var message = new MailMessage
                {
                    From = new MailAddress(contact.Email, contact.Name)
                };

                message.To.Add("info@ebenproperty.co.za");
                //if (!string.IsNullOrWhiteSpace(c))
                //{
                //    message.CC.Add(CCEmail);
                //}

                message.Subject = contact.Service;
                message.IsBodyHtml = true;
                message.Body = contact.Message;
                var client = new SmtpClient
                {
#if DEBUG
                    Host = "mail.ebenproperty.co.za",
                    Port = 25,
                    Credentials = new System.Net.NetworkCredential("info@ebenproperty.co.za", "eben1234@1@")

#else
                    Host = "localhost",
                    Port = 25
#endif
                };

                //if (Attachments != null)
                //{
                //    foreach (Attachment attachment in Attachments)
                //    {
                //        attachment.Name = AttachmentNames;
                //        message.Attachments.Add(attachment);
                //    }
                //}

                try
                {
                    client.Send(message);
                    message.Attachments.Dispose();
                    message.Dispose();
                    return true;
                }
                catch (SmtpException s)
                {
                    message.Attachments.Dispose();
                    message.Dispose();
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}

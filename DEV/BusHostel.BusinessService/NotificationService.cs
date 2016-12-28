using BusHostel.Repository.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusHostel.BusinessService
{
    public class NotificationService : INotificationService
    {
        public void SendEmail(EmailArg emailArg)
        {
            string[] recievers = emailArg.Tos.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(emailArg.From),
                IsBodyHtml = true,
                Body = emailArg.Body,
                Subject = emailArg.Subject
            };

            foreach (string to in recievers)
                mailMessage.To.Add(new MailAddress(to));

            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = emailArg.Host;
                smtpClient.DeliveryMethod = emailArg.DeliveryMethod;
                smtpClient.Port = emailArg.Port;
                smtpClient.Send(mailMessage);
                smtpClient.EnableSsl = emailArg.EnableSsl;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace TercihRobotumBuSonOlsun.Models
{
    public class MailGonder
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public static void MailSender(string body, string gonderilecekAdres, string subject = "Tercih Robotum | Onay Kodu")
        {
            var fromAddress = new MailAddress("onlybrave3@gmail.com");
            var toAddress = new MailAddress(gonderilecekAdres);
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "a6y4m8e2")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }

    }

}
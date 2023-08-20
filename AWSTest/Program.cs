using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AWSTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String FROM = "info@test.com";
            String FROMNAME = "Name";

            String TO = "hellooo@gmail.com";

            String SMTP_USERNAME = "123456";

            String SMTP_PASSWORD = "BC/ddd/tAIL7TP+ttt";

            String CONFIGSET = "ConfigSet";

            String HOST = "email-smtp.eu-north-1.amazonaws.com";

            int PORT = 587;

            String SUBJECT =
                "Amazon SES test (SMTP interface accessed using C#)";

            String BODY =
                "<h1>Amazon SES Test</h1>" +
                "<p>This email was sent through the " +
                "<a href='https://aws.amazon.com/ses'>Amazon SES</a> SMTP interface " +
                "using the .NET System.Net.Mail library.</p>";

            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(FROM, FROMNAME);
            message.To.Add(new MailAddress(TO));
            message.Subject = SUBJECT;
            message.Body = BODY;
            //message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

            using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
            {
                client.Credentials =
                    new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                client.EnableSsl = true;

                try
                {
                    Console.WriteLine("Attempting to send email...");
                    client.Send(message);
                    Console.WriteLine("Email sent!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The email was not sent.");
                    Console.WriteLine("Error message: " + ex.Message);
                }
            }
        }
    }
}
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
namespace Khareedo.Models
{



    public class EmailService
    {
        public void SendEmail(string fname, string custemail, int orderID, string address, DateTime purchasedate)
        {
            try
            {
                // Ensure that SSL/TLS protocols are enabled
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                // SMTP configuration
                SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"])
                {
                    Port = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]), // SMTP port for secure connection
                    EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]), // Enable SSL for secure connection
                    Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SmtpUsername"], ConfigurationManager.AppSettings["SmtpPassword"]), // SMTP credentials
                };


                // Create a MailMessage
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"]), // Sender's email address
                    Subject = ConfigurationManager.AppSettings["Subject"], // Email subject
                    Body = "Dear " + fname + ", <br/><br/>" +
                            "Thank you for placing your order with us!<br/> We are pleased to confirm that your order has been successfully received and is being processed. <br/>" +
                            "Order Details:<br/>" +
                            "Order Number: " + orderID + "<br/>" +
                            "Date of Purchase: " + purchasedate.ToString("dd-MMM-yyyy") +
                            "<br/>You will receive another email with tracking details once your order has shipped. <br/><br/>" +
                            "If you have any questions or need assistance, feel free to reach out to our customer support team at " +
                            ConfigurationManager.AppSettings["SukhkartaAgarbattiEmail"] + " or " +
                            ConfigurationManager.AppSettings["MyPhone"] + ".<br/><br/>" +
                            "We truly appreciate your business and look forward to serving you again! <br/><br/>" +
                            "Best regards,<br/>Sukhkarta Agarbatti",
                    IsBodyHtml = Convert.ToBoolean(ConfigurationManager.AppSettings["IsBodyHtml"]), // Set to true if you want to send HTML content
                };

                // Add recipient email address
                mail.To.Add(custemail); // Replace with recipient email address
                mail.To.Add(ConfigurationManager.AppSettings["SukhkartaAgarbattiEmail"]); // Replace with recipient email address
                mail.To.Add(ConfigurationManager.AppSettings["MyPersonalEmail"]); // Replace with recipient email address

                // Send the email
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

}
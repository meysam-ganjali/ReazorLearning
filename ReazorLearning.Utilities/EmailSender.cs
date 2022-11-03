using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace ReazorLearning.Utilities;

public class EmailSender : IEmailSender
{
    //public string SendGridSecret { get; set; }
    //public EmailSender(IConfiguration _config)
    //{
    //    SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
    //}

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        //var emailToSend = new MimeMessage();
        //emailToSend.From.Add(MailboxAddress.Parse("hello@dotnetmastery.com"));
        //emailToSend.To.Add(MailboxAddress.Parse(email));
        //emailToSend.Subject = subject;
        //emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };


        ////send email
        //using (var emailClient = new SmtpClient())
        //         {
        //	emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        //	emailClient.Authenticate("dotnetmastery@gmail.com", "");
        //	emailClient.Send(emailToSend);
        //	emailClient.Disconnect(true);
        //         }

        //var client = new SendGridClient(SendGridSecret);
        //var from = new EmailAddress("hello@dotnetmastery.com", "Abby Food");
        //var to = new EmailAddress(email);
        //var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);

        return Task.CompletedTask;

        //return client.SendEmailAsync(msg);
    }
}
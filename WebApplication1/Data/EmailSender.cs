using System;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace WebApplication1.Data;
public class EmailSender
{
    public async Task SendEmail(string toEmail, string username, string subject, string messages)
    {
        var apiKey = "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";
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("ja5504424@gmail.com", "CodeAxis");
        var to = new EmailAddress(toEmail, username);
        var plainTextContent = messages;
        var htmlContent = "";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);
    }
}

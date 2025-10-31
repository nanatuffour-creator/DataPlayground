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
        var from = new EmailAddress("nyaw246@outlook.com", "CodeAxis");
        var to = new EmailAddress(toEmail, username);
        var plainTextContent = messages;
        var htmlContent = "";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);
    }
}

using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Models.Settings;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MailKit.Security;


using System.IO;
using System.Threading.Tasks;
using MimeKit;
using Batheer.Application.Common.Models;
using System;
using System.Security.Authentication;
using Microsoft.Extensions.Logging;

namespace Batheer.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        //https://github.com/iammukeshm/MailService.WebApi/blob/master/MailService.WebApi/Services/MailService.cs
        private readonly EmailConfiguration _emailConfiguration;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(EmailConfiguration mailSettings, ILogger<EmailSender> logger)
        {
            _emailConfiguration = mailSettings;
            _logger = logger;
        }
        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            _logger.LogInformation("SendEmailAsync", emailMessage);
            var _emailMessage = CreateEmailMessage(emailMessage);
            Send(_emailMessage);

            /*
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_emailConfiguration.From);
            email.To.Add(MailboxAddress.Parse(emailMessage.ToEmail));
            email.Subject = emailMessage.Subject;
            var builder = new BodyBuilder();
            if (emailMessage.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in emailMessage.Attachments)
                {
                    //if (file.Length > 0)
                    //{
                    //    using (var ms = new MemoryStream())
                    //    {
                    //        file.CopyTo(ms);
                    //        fileBytes = ms.ToArray();
                    //    }
                    //    builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    //}
                }
            }

            try
            {
                builder.HtmlBody = emailMessage.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailConfiguration.From, _emailConfiguration.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {

                throw;
            }
            */
           
        }



        private MimeMessage CreateEmailMessage(EmailMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfiguration.From));
            emailMessage.To.Add(new MailboxAddress(message.ToEmail));
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Body };

            _logger.LogInformation("CreateEmailMessage", emailMessage);

            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;

                    client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, _emailConfiguration.useSsl);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfiguration.UserName, _emailConfiguration.Password);
                    client.Send(mailMessage);
                }
                catch(Exception ex)
                {
                    _logger.LogInformation("Send_Exception", ex);

                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}

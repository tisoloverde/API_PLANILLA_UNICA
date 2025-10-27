using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using PlanillaUnicaApi.Models.Options;

namespace PlanillaUnicaApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpOptions _smtpOptions;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<SmtpOptions> smtpOptions, ILogger<EmailService> logger)
        {
            _smtpOptions = smtpOptions.Value;
            _logger = logger;
        }

        public async Task SendEmailWithAttachmentsAsync(string toEmail, string subject, string body, List<EmailAttachment> attachments)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_smtpOptions.FromName, _smtpOptions.FromEmail));
                message.To.Add(new MailboxAddress("", toEmail));
                message.Subject = subject;

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = body;

                // Agregar archivos adjuntos
                if (attachments != null && attachments.Count > 0)
                {
                    foreach (var attachment in attachments)
                    {
                        bodyBuilder.Attachments.Add(attachment.FileName, attachment.Content, ContentType.Parse(attachment.ContentType));
                    }
                }

                message.Body = bodyBuilder.ToMessageBody();

                using var client = new SmtpClient();
                client.Timeout = _smtpOptions.Timeout;
                
                // Para puerto 587, usar STARTTLS
                await client.ConnectAsync(_smtpOptions.Host, _smtpOptions.Port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_smtpOptions.User, _smtpOptions.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                _logger.LogInformation($"Email enviado exitosamente a {toEmail}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error enviando email a {toEmail}");
                throw;
            }
        }
    }
}
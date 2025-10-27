namespace PlanillaUnicaApi.Services
{
    public interface IEmailService
    {
        Task SendEmailWithAttachmentsAsync(string toEmail, string subject, string body, List<EmailAttachment> attachments);
    }

    public class EmailAttachment
    {
        public byte[] Content { get; set; } = Array.Empty<byte>();
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
    }
}
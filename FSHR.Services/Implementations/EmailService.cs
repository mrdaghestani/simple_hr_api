using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using FSHR.Services.DTOs;
using FSHR.Services.Repositories;
using FSHR.Services.Settings;

namespace FSHR.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private IEmailSettings _emailSettings;

        public EmailService(IEmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public async Task<EmailSendResultDto> Send(EmailSendDto dto)
        {
            var smtp = new SmtpClient();
            smtp.UseDefaultCredentials = _emailSettings.UseDefaultCredentials;
            smtp.EnableSsl = _emailSettings.EnableSsl;
            smtp.Host = _emailSettings.Host;
            smtp.Port = _emailSettings.Port;
            smtp.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);

            await smtp.SendMailAsync(_emailSettings.From, dto.EmailAddress, dto.Subject, dto.Body);

            return new EmailSendResultDto { };
        }
    }
}
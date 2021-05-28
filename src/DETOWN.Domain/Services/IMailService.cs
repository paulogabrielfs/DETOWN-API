using DETOWN.Domain.Services.Mail;

namespace DETOWN.Domain.Services
{
    public interface IMailService
    {
        void SendMail(MailMessage mailMessage);
    }
}

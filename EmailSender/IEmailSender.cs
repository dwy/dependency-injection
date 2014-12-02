using System.Net.Mail;

namespace EmailSender
{
    public interface IEmailSender
    {
        void Send(MailMessage message);
    }
}
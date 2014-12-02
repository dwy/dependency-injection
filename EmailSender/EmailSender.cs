using System;
using System.Net.Mail;

namespace EmailSender
{
    public class EmailSender : IEmailSender
    {

        private readonly SmtpClient _client;


        public EmailSender(SmtpClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }
            _client = client;
        }


        public void Send(MailMessage message)
        {
            _client.Send(message);
        }
    }
}

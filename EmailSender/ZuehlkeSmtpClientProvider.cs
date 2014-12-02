using System.Net;
using System.Net.Mail;
using Ninject.Activation;

namespace EmailSender
{
    public class ZuehlkeSmtpClientProvider: Provider<SmtpClient>
    {
        protected override SmtpClient CreateInstance(IContext context)
        {
            var client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Port = Resources.SmtpClientPortNumber;
            client.Host = Resources.SmtpHostAddress;
            client.EnableSsl = Resources.SmtpClientEnableSsl;
            client.Credentials = new NetworkCredential(Resources.EmailUserName, Resources.EmailUserPassword);
            return client;
        }
    }
}
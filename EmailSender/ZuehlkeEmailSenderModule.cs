using System.Net;
using System.Net.Mail;
using Ninject.Modules;

namespace EmailSender
{
    public class ZuehlkeEmailSenderModule: NinjectModule
    {
        public override void Load()
        {
            var client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Port = Resources.SmtpClientPortNumber;
            client.Host = Resources.SmtpHostAddress;
            client.EnableSsl = Resources.SmtpClientEnableSsl;
            client.Credentials = new NetworkCredential(Resources.EmailUserName, Resources.EmailUserPassword);

            Bind<SmtpClient>().ToConstant(client);
            Bind<IEmailSender>().To<EmailSender>();
        }
    }
}
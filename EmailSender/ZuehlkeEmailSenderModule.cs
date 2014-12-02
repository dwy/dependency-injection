using System.Net.Mail;
using Ninject.Modules;

namespace EmailSender
{
    public class ZuehlkeEmailSenderModule: NinjectModule
    {
        public override void Load()
        {
            Bind<SmtpClient>().ToProvider<ZuehlkeSmtpClientProvider>();
            Bind<IEmailSender>().To<EmailSender>();
        }
    }
}
using System.Net.Mail;
using Ninject;
using NUnit.Framework;

namespace EmailSender.Tests
{
    [TestFixture]
    public class EmailSenderTest
    {
        private readonly IKernel _kernel = new StandardKernel(new ZuehlkeEmailSenderModule());
        private IEmailSender _emailSender;

        [SetUp]
        public void Setup()
        {
            _emailSender = _kernel.Get<IEmailSender>();
        }

        [Test]
        public void EmailSender_SendMessage_MessageIsSent()
        {
            Assert.IsNotNull(_emailSender);

            var message = new MailMessage("dominic.wyler@gmail.com", "dominic.wyler@gmail.com");
            message.Subject = "hi from test";
            message.Body = "42";

            _emailSender.Send(message);
        }
    }
}
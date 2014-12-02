using System;
using System.Net.Mail;
using Ninject;

namespace EmailSender
{
    class Program
    {
        private const string DefaultEmailAddress = "dominic.wyler@gmail.com";

        private static void Main(string[] args)
        {
            var kernel = new StandardKernel(new ZuehlkeEmailSenderModule());
            var emailSender = kernel.Get<IEmailSender>();

            Console.Write(@"To [{0}]: ", DefaultEmailAddress);
            string @to = ReadFromConsoleOrDefault(DefaultEmailAddress);

            Console.Write(@"Subject [hi]: ");
            string subject = ReadFromConsoleOrDefault("hi");

            Console.Write(@"Body [turnip]: ");
            string body = ReadFromConsoleOrDefault("turnip");

            var message = new MailMessage(Resources.EmailUserName, @to);
            message.Subject = subject;
            message.Body = body;

            Console.Write(@"Sending e-mail... ");
            emailSender.Send(message);
            Console.Write(@"done");
            Console.ReadLine();
        }

        private static string ReadFromConsoleOrDefault(string defaultValue)
        {
            string value = Console.ReadLine();
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }
    }
}

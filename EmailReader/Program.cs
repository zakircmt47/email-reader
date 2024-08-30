using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pop3EmailReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MailRepository();
            client.Connect(hostname: "mail.gmail.com", username: "zakir@gmail.com", password: "###########", port: 995, isUseSsl: true);

            var allMail = client.GetMail();
            
            foreach (var mail in allMail)
            {
                var subject = mail.Message.Headers.Subject;
                var to = string.Join(",", mail.Message.Headers.To.Select(m => m.Address));
                var from = mail.Message.Headers.From.Address;

				var body = client.GetBodyText(mail.Message);

				Console.WriteLine("Email Subject: {0}", subject);
                Console.WriteLine("Sent To: {0}", to);
                Console.WriteLine("Sent From: {0}", from);
                Console.WriteLine("body: {0}", body);

            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}

using MimeKit;
using OpenPop.Mime;
using OpenPop.Pop3;
using Pop3EmailReader.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pop3EmailReader
{
    public class MailRepository : IMailRepository
    {
        public void Connect(string hostname, string username, string password, int port, bool isUseSsl)
        {
            this._client = new Pop3Client();
            this._client.Connect(hostname, port, isUseSsl);
            this._client.Authenticate(username, password);
        }
        public List<Pop3Mail> GetMail()
        {
            int messageCount = this._client.GetMessageCount();

            var allMessages = new List<Pop3Mail>(messageCount);

            for (int i = messageCount; i > 0; i--)
            {
                allMessages.Add(new Pop3Mail() { MessageNumber = i, Message = this._client.GetMessage(i) });
            }

            return allMessages;
        }
        private Pop3Client _client { get; set; }
		// Helper method to get the text from the email's body
		public string GetBodyText(Message message)
		{
			var plainTextPart = message.FindFirstPlainTextVersion();
			if (plainTextPart != null)
			{
				return plainTextPart.GetBodyAsText();
			}

			var htmlPart = message.FindFirstHtmlVersion();
			if (htmlPart != null)
			{
				return htmlPart.GetBodyAsText();
			}

			return string.Empty;
		}
	}
}

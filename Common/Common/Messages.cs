using System.Collections.Generic;
using System.Linq;

using Common.Enum;

namespace Common.Common
{
    public class Messages
    {
        private readonly IList<Message> messages;

        public Messages()
        {
            this.messages = new List<Message>();
        }

        public bool HasErrors
        {
            get
            {
                return this.messages.Any(x => x.Type == MessageTypeEnum.Error);
            }
        }

        public IEnumerable<string> GetErrors()
        {
            return this.messages.Where(x => x.Type == MessageTypeEnum.Error).Select(x => x.Content);
        }

        public void Add(MessageTypeEnum type, string message)
        {
            this.messages.Add(new Message(type, message));
        }

        public void Clear()
        {
            this.messages.Clear();
        }

        private class Message
        {
            public Message(MessageTypeEnum type, string content)
            {
                this.Content = content;
                this.Type = type;
            }

            public MessageTypeEnum Type { get; private set; }

            public string Content { get; private set; }
        }
    }
}
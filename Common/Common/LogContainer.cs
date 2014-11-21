using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Common
{
    using System;

    public class LogContainer
    {
        private readonly int maxLines;

        private readonly List<string> messages;

        private readonly object messagesLock = new object();

        public LogContainer(int maxLines)
        {
            this.maxLines = maxLines;
            this.messages = new List<string>();
        }

        public void AddMessage(string message)
        {
            lock (this.messagesLock)
            {
                this.messages.Add(message);

                if (this.messages.Count > this.maxLines)
                {
                    this.messages.Remove(this.messages.First());
                }
            }
        }

        public void Clear()
        {
            this.messages.Clear();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            lock (this.messagesLock)
            {
                var list = this.messages.ToList();
                list.Reverse();

                foreach (var message in list)
                {
                    sb.AppendLine(message);
                }
            }

            return sb.ToString();
        }
    }
}
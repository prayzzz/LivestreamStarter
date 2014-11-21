using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

using Common.Args;
using Common.Common;
using Common.Enum;

using Services.Interfaces;

namespace Services.Common
{
    public class Logger : ILogger
    {
        private readonly StringBuilder messages;

        public event LogMessageAdded LogMessageAdded;

        private readonly object messagesLock = new object();

        public Logger()
        {
            this.messages = new StringBuilder();
        }

        public string LoggedMessages
        {
            get
            {
                lock (this.messagesLock)
                {
                    return this.messages.ToString();
                }
            }
        }

        public void Log(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            message = BuildMessage(message);

            this.Append(message);
        }

        public void Log(string message, params object[] args)
        {
            Log(string.Format(message, args));
        }

        public void Log(LogTypeEnum logType, string message)
        {
            string typeIndicator;

            switch (logType)
            {
                case LogTypeEnum.Start:
                    typeIndicator = ">";
                    break;
                case LogTypeEnum.Work:
                    typeIndicator = "=";
                    break;
                case LogTypeEnum.Stop:
                    typeIndicator = "<";
                    break;
                case LogTypeEnum.None:
                    typeIndicator = string.Empty;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("logType");
            }

            this.Log(string.Format("{0} {1}", typeIndicator, message));
        }

        public void Log(LogTypeEnum logType, string message, params object[] args)
        {
            Log(logType, string.Format(message, args));
        }

        public void Log(Exception exception)
        {
            this.Log(string.Empty, exception);
        }

        public void Log(string message, Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            var builder = new StringBuilder();

            if (!string.IsNullOrEmpty(message))
            {
                builder.AppendLine(message);
            }

            builder.AppendLine(BuildMessage("An Exception occured:"));
            AddExceptionMessageRecursive(builder, exception);

            this.Append(builder.ToString());
        }

        private static void AddExceptionMessageRecursive(StringBuilder builder, Exception exception)
        {
            while (true)
            {
                builder.AppendLine(BuildMessage(string.Format("{0} {1}", "[E]", exception.Message)));

                if (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                    continue;
                }

                break;
            }
        }

        private static string BuildMessage(string message)
        {
            var id = string.Format("[{0}]", Thread.CurrentThread.ManagedThreadId).PadRight(4);

            return string.Format("{0} - {1} {2}", DateTime.Now.ToString("T"), id, message);
        }

        private void Append(string message)
        {
            lock (this.messagesLock)
            {
                this.messages.AppendLine(message);
            }

            Debug.WriteLine(message);

            if (this.LogMessageAdded != null)
            {
                this.LogMessageAdded(this, new LogMessageArgs(this.LoggedMessages));
            }
        }
    }
}
using System;

namespace Common.Args
{
    public class LogMessageArgs : EventArgs
    {
        public LogMessageArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; private set; }
    }
}
using System;

using Common.Common;
using Common.Enum;

namespace Services.Interfaces
{
    public interface ILogger
    {
        event LogMessageAdded LogMessageAdded;

        string LoggedMessages { get; }

        void Log(string message);

        void Log(string message, params object[] args);

        void Log(LogTypeEnum logType, string message);

        void Log(LogTypeEnum logType, string message, params object[] args);

        void Log(Exception exception);

        void Log(string message, Exception exception);
    }
}
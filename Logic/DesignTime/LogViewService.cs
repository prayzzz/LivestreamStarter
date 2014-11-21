using Common.Common;

using Logic.ViewServiceInterfaces;

namespace Logic.DesignTime
{
    public class LogViewService : ILogViewService
    {
        public void RegisterLogMessagesAddedEvent(LogMessageAdded action)
        {
        }

        public string GetLog()
        {
            return string.Empty;
        }
    }
}
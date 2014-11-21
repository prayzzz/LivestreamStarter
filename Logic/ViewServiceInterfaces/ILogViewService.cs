using Common.Common;

namespace Logic.ViewServiceInterfaces
{
    public interface ILogViewService
    {
        void RegisterLogMessagesAddedEvent(LogMessageAdded action);

        string GetLog();
    }
}
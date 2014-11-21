using Common.Common;

using Logic.ViewServiceInterfaces;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;

namespace Logic.ViewServices
{
    public class LogViewService : ILogViewService
    {
        private static ILogger Logger
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ILogger>();
            }
        }

        public void RegisterLogMessagesAddedEvent(LogMessageAdded action)
        {
            Logger.LogMessageAdded += action;
        }

        public string GetLog()
        {
            return Logger.LoggedMessages;
        }
    }
}
using Common.Common;
using Common.Enum;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;

namespace Logic.ViewServices
{
    public abstract class ViewServiceBase
    {
        private static ILogger Logger
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ILogger>();
            }
        }

        protected static IRepository Repository
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IRepository>();
            }
        }

        protected static void Log(LogTypeEnum logType, string message)
        {
            Logger.Log(logType, message);
        }

        protected static void Log(LogTypeEnum logType, string message, params object[] args)
        {
            Log(logType, string.Format(message, args));
        }
    }
}
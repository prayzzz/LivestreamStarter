using System.Collections.Generic;

namespace DailyMotionConnector.ServiceInterfaces
{
    internal interface IPathService
    {
        string GetApiMultipleStreamLink(IEnumerable<string> streamNames);

        string GetApiStreamLink(string streamName);
    }
}
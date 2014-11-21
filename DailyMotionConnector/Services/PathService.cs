using System.Collections.Generic;
using System.Linq;

using DailyMotionConnector.ServiceInterfaces;

namespace DailyMotionConnector.Services
{
    internal class PathService : IPathService
    {
        private const string ApiMultipleStreamLink = "https://api.dailymotion.com/videos?fields=audience,description,title,id&ids=";

        public string GetApiMultipleStreamLink(IEnumerable<string> streamNames)
        {
            return string.Format("{0}{1}", ApiMultipleStreamLink, streamNames.Aggregate((x, y) => x + "," + y));
        }

        public string GetApiStreamLink(string streamName)
        {
            return string.Format("{0}{1}", ApiMultipleStreamLink, streamName);
        }
    }
}
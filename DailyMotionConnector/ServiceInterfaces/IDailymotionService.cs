using System.Collections.Generic;

using DailyMotionConnector.Entities;

namespace DailyMotionConnector.ServiceInterfaces
{
    internal interface IDailymotionService
    {
        DailymotionVideos GetStreamInformations(IEnumerable<string> streamNames);

        DailymotionVideo GetStreamInformations(string streamName);
    }
}
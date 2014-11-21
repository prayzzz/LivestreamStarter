using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

using DailyMotionConnector.Entities;
using DailyMotionConnector.ServiceInterfaces;

using Microsoft.Practices.ServiceLocation;

using Newtonsoft.Json;

namespace DailyMotionConnector.Services
{
    internal class DailymotionService : IDailymotionService
    {
        private static IPathService PathService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IPathService>();
            }
        }

        public DailymotionVideos GetStreamInformations(IEnumerable<string> streamNames)
        {
            if (!streamNames.Any())
            {
                return null;
            }

            var url = PathService.GetApiMultipleStreamLink(streamNames);
            return GetStreamInformationFromUrl(url);
        }

        public DailymotionVideo GetStreamInformations(string streamName)
        {
            var dailymotionVideos = GetStream(streamName);

            if (dailymotionVideos != null && dailymotionVideos.list.Any())
            {
                return dailymotionVideos.list[0];
            }

            return null;
        }

        private static DailymotionVideos GetStream(string streamName)
        {
            var url = PathService.GetApiStreamLink(streamName);
            return GetStreamInformationFromUrl(url);
        }

        private static DailymotionVideos GetStreamInformationFromUrl(string url)
        {
            var webRequest = WebRequest.Create(url) as HttpWebRequest;

            if (webRequest == null)
            {
                return null;
            }

            using (var webResponse = webRequest.GetResponse())
            {
                using (var stream = new StreamReader(webResponse.GetResponseStream()))
                {
                    return JsonConvert.DeserializeObject<DailymotionVideos>(stream.ReadToEnd());
                }
            }
        }
    }
}
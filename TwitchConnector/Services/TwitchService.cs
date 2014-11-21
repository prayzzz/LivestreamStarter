using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

using Microsoft.Practices.ServiceLocation;

using Newtonsoft.Json;

using TwitchConnector.Entities;
using TwitchConnector.ServiceInterfaces;

namespace TwitchConnector.Services
{
    internal class TwitchService : ITwitchService
    {
        private static IPathService PathService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IPathService>();
            }
        }

        public bool IsStreamNameCorrect(string streamName)
        {
            var stream = GetStream(streamName);
            return stream != null && string.IsNullOrWhiteSpace(stream.error);
        }

        public TwitchStream GetStreamInformations(string streamName)
        {
            var twitchStreams = GetStream(streamName);

            if (twitchStreams != null && twitchStreams.stream != null)
            {
                return twitchStreams.stream;
            }

            return null;
        }

        public TwitchStreams GetStreamInformations(IEnumerable<string> streamNames)
        {
            if (!streamNames.Any())
            {
                return null;
            }

            var url = PathService.GetTwitchApiMultipleStreamLink(streamNames);
            return GetStreamInformationFromUrl(url);
        }

        private static TwitchStreams GetStream(string streamName)
        {
            var url = PathService.GetTwitchApiStreamLink(streamName);
            return GetStreamInformationFromUrl(url);
        }

        private static TwitchStreams GetStreamInformationFromUrl(string url)
        {
            var webRequest = WebRequest.Create(url) as HttpWebRequest;

            if (webRequest == null)
            {
                return null;
            }

            webRequest.UserAgent = "LivestreamStarter by prayzzz (prayzzz@outlook.com)";
            using (var webResponse = webRequest.GetResponse())
            {
                using (var stream = new StreamReader(webResponse.GetResponseStream()))
                {
                    return JsonConvert.DeserializeObject<TwitchStreams>(stream.ReadToEnd());
                }
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;

using TwitchConnector.ServiceInterfaces;

namespace TwitchConnector.Services
{
    internal class PathService : IPathService
    {
        private const string TwitchLink = "http://www.twitch.tv/";

        private const string TwitchApiStreamLink = "https://api.twitch.tv/kraken/streams/";

        private const string TwitchApiMultipleStreamLink = "https://api.twitch.tv/kraken/streams?channel=";

        public string GetTwitchLink(string channelName)
        {
            return string.Format("{0}{1}", TwitchLink, channelName);
        }

        public string GetTwitchApiStreamLink(string channelName)
        {
            return string.Format("{0}{1}", TwitchApiStreamLink, channelName);
        }

        public string GetTwitchApiMultipleStreamLink(IEnumerable<string> channelNames)
        {
            return string.Format("{0}{1}", TwitchApiMultipleStreamLink, channelNames.Aggregate((x, y) => x + "," + y));
        }
    }
}
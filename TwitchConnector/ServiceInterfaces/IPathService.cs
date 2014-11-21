using System.Collections.Generic;

namespace TwitchConnector.ServiceInterfaces
{
    internal interface IPathService
    {
        string GetTwitchLink(string channelName);
        
        string GetTwitchApiStreamLink(string channelName);
        
        string GetTwitchApiMultipleStreamLink(IEnumerable<string> channelNames);
    }
}
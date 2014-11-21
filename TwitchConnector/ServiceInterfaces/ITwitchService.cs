using System.Collections.Generic;

using TwitchConnector.Entities;

namespace TwitchConnector.ServiceInterfaces
{
    internal interface ITwitchService
    {
        TwitchStream GetStreamInformations(string streamName);

        TwitchStreams GetStreamInformations(IEnumerable<string> streamNames);

        bool IsStreamNameCorrect(string streamName);
    }
}
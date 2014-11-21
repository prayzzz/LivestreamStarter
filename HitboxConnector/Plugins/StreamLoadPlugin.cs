using BaseEntities;

using Services.Listener;

namespace HitboxConnector.Plugins
{
    public class StreamLoadPlugin : IStreamLoadListener
    {
        public void Load()
        {
        }

        public bool CheckStreamName(ChannelModel channel, string name)
        {
            return true;
        }
    }
}
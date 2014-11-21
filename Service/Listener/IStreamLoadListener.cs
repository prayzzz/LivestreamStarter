using BaseEntities;

namespace Services.Listener
{
    public interface IStreamLoadListener
    {
        void Load();

        bool CheckStreamName(ChannelModel channel, string name);
    }
}
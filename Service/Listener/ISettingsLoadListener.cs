namespace Services.Listener
{
    public interface ISettingsLoadListener
    {
        void ChannelsLoaded();

        void GamesLoaded();
    }
}
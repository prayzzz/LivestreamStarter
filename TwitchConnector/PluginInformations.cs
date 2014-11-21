using BaseEntities;

namespace TwitchConnector
{
    public static class PluginInformations
    {
        static PluginInformations()
        {
            CreateChannel();
        }

        public static ChannelModel Channel { get; set; }

        private static void CreateChannel()
        {
            Channel = new ChannelModel();
            Channel.Name = "Twitch";
            Channel.AliasName = "Justin";
            Channel.MainLink = "http://www.twitch.tv/";
            Channel.WeblinkPattern = "http://www.twitch.tv/{0}";
            Channel.ImagePath = "twitch.png";
            Channel.IsCustomChannel = false;
            Channel.IsDefault = false;
            Channel.IsAllowedAsFavorite = true;
            Channel.IsSupported = true;
        }
    }
}
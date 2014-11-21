using BaseEntities;

namespace DailyMotionConnector
{
    public static class PluginInformations
    {
        static PluginInformations()
        {
            CreateChannel();
        }

        private static void CreateChannel()
        {
            Channel = new ChannelModel();
            Channel.Name = "Dailymotion";
            Channel.MainLink = "http://www.dailymotion.com/";
            Channel.WeblinkPattern = "http://www.dailymotion.com/video/{0}";
            Channel.ImagePath = "dailymotion.png";
            Channel.IsCustomChannel = false;
            Channel.IsDefault = false;
            Channel.IsAllowedAsFavorite = true;
        }

        public static ChannelModel Channel { get; set; }
    }
}
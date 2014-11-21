using BaseEntities;

namespace HitboxConnector
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
            Channel.Name = "Hitbox";
            Channel.AliasName = "Hitbox";
            Channel.MainLink = "http://www.hitbox.tv/";
            Channel.WeblinkPattern = "http://www.hitbox.tv/{0}";
            Channel.ImagePath = "hitbox.png";
            Channel.IsCustomChannel = false;
            Channel.IsDefault = false;
            Channel.IsAllowedAsFavorite = true;
            Channel.IsSupported = true;
        }

        public static ChannelModel Channel { get; set; } 
    }
}
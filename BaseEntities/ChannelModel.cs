namespace BaseEntities
{
    public class ChannelModel : BaseModel
    {
        public string Name { get; set; }

        public string AliasName { get; set; }

        public string MainLink { get; set; }

        public string WeblinkPattern { get; set; }

        public string ImagePath { get; set; }

        public bool IsCustomChannel { get; set; }

        public bool IsDefault { get; set; }

        public bool IsAllowedAsFavorite { get; set; }

        /// <summary>
        /// Is Supported By Livestreamer
        /// </summary>
        public bool IsSupported { get; set; }
    }
}
using System;
using System.Xml.Serialization;

using BaseEntities.Enum;

namespace BaseEntities
{
    [Serializable]
    public class StreamModel : BaseModel
    {
        public GameModel Game { get; set; }

        public ChannelModel Channel { get; set; }

        public StatusEnum Status { get; set; }

        public string DisplayName { get; set; }

        public string Name { get; set; }

        public int Viewers { get; set; }

        public string StreamLink { get; set; }

        public string ChannelStatus { get; set; }

        public bool IsFavorite { get; set; }

        [XmlIgnore]
        public string PreviewImagePath { get; set; }
    }
}
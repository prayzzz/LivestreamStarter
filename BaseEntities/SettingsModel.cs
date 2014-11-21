using System.Collections.Generic;
using System.Xml.Serialization;

using BaseEntities.Enum;

namespace BaseEntities
{
    public class SettingsModel : BaseModel
    {
        public SettingsModel()
        {
            this.Channels = new List<ChannelModel>();
            this.Games = new List<GameModel>();
        }

        public string VlcPath { get; set; }

        public string LivestreamerPath { get; set; }

        public QualityEnum Quality { get; set; }

        public bool IsLogVisible { get; set; }

        public List<ChannelModel> Channels { get; set; }

        public List<GameModel> Games { get; set; }

        ////[XmlElement("GameFilter")]
        public List<GameFilterModel> GameFilter { get; set; }
    }
}
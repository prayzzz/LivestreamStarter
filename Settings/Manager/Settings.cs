using LivestreamStarter.Enum;

namespace LivestreamStarter.Settings
{
    public class Settings
    {
        public string VlcPath { get; set; }

        public string LivestreamerPath { get; set; }

        public QualityEnum Quality { get; set; }
    }
}
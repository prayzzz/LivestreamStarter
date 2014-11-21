using System;

namespace Settings.XmlEntities
{
    [Serializable]
    public class XmlStream
    {
        public string Channel { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Game { get; set; }

        public string StreamLink { get; set; }

        public bool IsFavorite { get; set; }
    }
}
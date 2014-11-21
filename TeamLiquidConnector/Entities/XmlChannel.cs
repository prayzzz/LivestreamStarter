using System;
using System.Xml.Serialization;

namespace TeamLiquidConnector.Entities
{
    [Serializable]
    public class    XmlChannel
    {
        [XmlAttribute("type")]
        public string Channel { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlText]
        public string Name { get; set; }
    }
}
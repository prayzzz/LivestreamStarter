using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using BaseEntities;
using BaseEntities.Enum;

namespace TeamLiquidConnector.Entities
{
    [Serializable]
    public class XmlStream
    {
        public XmlStream()
        {
            this.Links = new List<XmlLink>();
        }

        [XmlAttribute("type")]
        public string Game { get; set; }
        
        [XmlAttribute("status")]
        public StatusEnum Status { get; set; }

        [XmlAttribute("owner")]
        public string Owner { get; set; }

        [XmlAttribute("featured")]
        public bool Featured { get; set; }

        [XmlAttribute("viewers")]
        public int Viewers { get; set; }

        [XmlAttribute("race")]
        public RaceEnum Race { get; set; }

        [XmlAttribute("rating")]
        public RatingEnum Rating { get; set; }

        [XmlElement("channel")]
        public XmlChannel Channel { get; set; }

        [XmlElement("link")]
        public List<XmlLink> Links { get; set; }
    }
}
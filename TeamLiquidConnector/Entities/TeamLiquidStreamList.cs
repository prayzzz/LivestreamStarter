using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TeamLiquidConnector.Entities
{
    [Serializable]
    [XmlRoot("streamlist")]
    public class TeamLiquidStreamList
    {
        public TeamLiquidStreamList()
        {
            this.Streams = new List<XmlStream>();
        }

        [XmlElement("stream")]
        public List<XmlStream> Streams { get; set; } 
    }
}
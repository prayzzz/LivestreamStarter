using System;
using System.Xml.Serialization;

using BaseEntities;
using BaseEntities.Enum;

namespace TeamLiquidConnector.Entities
{
    [Serializable]
    public class XmlLink
    {
        [XmlAttribute("type")]
        public LinkTypeEnum LinkType { get; set; }

        [XmlText]
        public string Adress { get; set; }
    }
}
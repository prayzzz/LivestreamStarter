using System.Xml.Serialization;

namespace BaseEntities.Enum
{
    public enum StatusEnum
    {
        [XmlEnum("offline")]
        Offline,
        [XmlEnum("online")]
        Online
    }
}
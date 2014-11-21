using System.Xml.Serialization;

namespace BaseEntities.Enum
{
    public enum LinkTypeEnum
    {
        [XmlEnum("embed")]
        Embed,
        [XmlEnum("thread")]
        Thread
    }
}
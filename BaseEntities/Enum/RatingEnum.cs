using System.Xml.Serialization;

namespace BaseEntities.Enum
{
    public enum RatingEnum
    {
        [XmlEnum("Everyone")]
        Everyone,
        [XmlEnum("Mature")]
        Mature,
        [XmlEnum("Explicit")]
        Explicit
    }
}
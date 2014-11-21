using System;
using System.Xml.Serialization;

namespace BaseEntities.Enum
{
    [Serializable]
    public enum RaceEnum
    {
        [XmlEnum("None")]
        None,
        [XmlEnum("Z")]
        Zerg,
        [XmlEnum("T")]
        Terran,
        [XmlEnum("P")]
        Protoss,
        [XmlEnum("TP")]
        TerranProtoss,
        [XmlEnum("TZ")]
        TerranZerg,
        [XmlEnum("ZP")]
        ZergProtoss,
        [XmlEnum("TZP")]
        Random
    }
}
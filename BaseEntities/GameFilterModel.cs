using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using BaseEntities.Annotations;

namespace BaseEntities
{
    public class GameFilterModel : IXmlSerializable
    {
        [UsedImplicitly]
        public GameFilterModel()
        {
        }

        public GameFilterModel(GameModel game, bool isAllowed)
        {
            this.Game = game;
            this.IsAllowed = isAllowed;
        }

        public GameModel Game { get; set; }

        public bool IsAllowed { get; set; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            reader.ReadStartElement();

            this.Game = new GameModel();
            this.Game.Id = int.Parse(reader.ReadElementString("Id"));
            this.IsAllowed = bool.Parse(reader.ReadElementString("IsAllowed"));

            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Id", this.Game.Id.ToString());
            writer.WriteElementString("IsAllowed", this.IsAllowed.ToString());
        }
    }
}
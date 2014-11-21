using System.Xml.Serialization;

namespace BaseEntities
{
    public class BaseModel
    {
        protected BaseModel()
        {
            this.Id = -1;
        }

        [XmlIgnore]
        public int Id { get; set; }

        public bool IsStored
        {
            get
            {
                return this.Id != -1;
            }
        }
    }
}
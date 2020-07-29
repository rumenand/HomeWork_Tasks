using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class AllUsersExport
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("users")]
        public UsersExportDTO2[] Users { get; set; }
    }
}

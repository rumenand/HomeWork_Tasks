
namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;
    [XmlType("Supplier")]
    public class SupllierImportDTO
    {

        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("isImporter")]
        public bool isImporter { get; set; }
    }
}

namespace CarDealer
{   
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    using CarDealer.Data;
    using CarDealer.Dtos.Import;
    using CarDealer.Dtos.Export;
    using CarDealer.Models;

    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var db = new CarDealerContext();         
            string data = GetLocalSuppliers(db);
            File.WriteAllText("data.xml", data);

        }
        
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                                    .Where(x => !x.IsImporter)
                                    .Select(x=> new SupplierExportDTO
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        PartsCount = x.Parts.Count
                                    })
                                    .ToArray();
            return XmlSerialize(suppliers, "suppliers");
        }
        private static string XmlSerialize<T>(T[] list, string root)
        {
            var builder = new StringBuilder();
            var serializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(root));
            var writer = new StringWriter(builder);
            serializer.Serialize(writer, list, GetXMLNameSpaces());
            return builder.ToString();
        }
        private static string XmlSerialize<T>(T list, string root)
        {
            var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(root));
            var writer = new StringWriter();
            serializer.Serialize(writer, list, GetXMLNameSpaces());
            return writer.ToString();
        }
        private static XmlSerializerNamespaces GetXMLNameSpaces()
        {
            var xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);
            return xmlNamespaces;
        }
    }
}
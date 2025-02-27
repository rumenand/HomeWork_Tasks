﻿namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;
    [XmlType("car")]
    public class CarWithPartsExportDTO
    {
        [XmlAttribute("make")]
        public string Make { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
        [XmlArray("parts")]
        public CarPartsDTO[] Parts { get; set; }
    }
    [XmlType("part")]
    public class CarPartsDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}

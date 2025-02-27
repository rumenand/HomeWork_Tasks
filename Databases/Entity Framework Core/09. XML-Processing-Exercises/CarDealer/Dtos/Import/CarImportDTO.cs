﻿namespace CarDealer.Dtos.Import
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    [XmlType("Car")]
    public class CarImportDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("TraveledDistance")]
        public long TraveledDistance { get; set; }                    
        [XmlArray("parts")]
        public List<PartsIds> Parts { get; set; }
    }
    [XmlType("partId")]
    public class PartsIds
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
  }

namespace CarDealer
{

    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    using CarDealer.Data;
    using CarDealer.Dtos.Import;
    using CarDealer.Dtos.Export;
    using CarDealer.Models;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Text;
    using CarDealer.XMLHelper.CarDealer.XMLHelper;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            //Console.WriteLine(ImportSuppliers(db, File.ReadAllText("../../../Datasets/suppliers.xml")));
            //Console.WriteLine(ImportParts(db, File.ReadAllText("../../../Datasets/parts.xml")));
            // Console.WriteLine(ImportCars(db, File.ReadAllText("../../../Datasets/cars.xml")));
            // Console.WriteLine(ImportCustomers(db, File.ReadAllText("../../../Datasets/customers.xml")));            
            // Console.WriteLine(ImportSales(db, File.ReadAllText("../../../Datasets/sales.xml"))); 
            string data = GetSalesWithAppliedDiscount(db);
            File.WriteAllText("data.xml", data);

        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();
            var serializer = new XmlSerializer(typeof(SupllierImportDTO[]), new XmlRootAttribute("Suppliers"));
            var supliers = (SupllierImportDTO[])serializer.Deserialize(new StringReader(inputXml));
            foreach (var p in supliers)
            {
                var cSupplier = mapper.Map<SupllierImportDTO, Supplier>(p);
                context.Suppliers.Add(cSupplier);
            }
            context.SaveChanges();
            return $"Successfully imported {supliers.Count()}";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();
            var serializer = new XmlSerializer(typeof(PartImportDTO[]), new XmlRootAttribute("Parts"));
            var parts = (PartImportDTO[])serializer.Deserialize(new StringReader(inputXml));
            var supliersIds = context.Suppliers.Select(x => x.Id).ToList();
            var count = 0;
            foreach (var p in parts)
            {
                var cPart = mapper.Map<PartImportDTO, Part>(p);
                if (supliersIds.Any(x => x == cPart.SupplierId))
                {
                    context.Parts.Add(cPart);
                    count++;
                }
            }
            context.SaveChanges();
            return $"Successfully imported {count}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();
            var serializer = new XmlSerializer(typeof(CarImportDTO[]), new XmlRootAttribute("Cars"));
            var cars = (CarImportDTO[])serializer.Deserialize(new StringReader(inputXml));
            var partsIds = context.Parts.Select(x => x.Id).ToList();
            foreach (var car in cars)
            {
                var cCar = mapper.Map<CarImportDTO, Car>(car);
                context.Cars.Add(cCar);
                foreach (var part in car.Parts.Select(x => x.Id).ToHashSet())
                {
                    if (partsIds.Any(x => x == part))
                    {
                        var partCar = new PartCar
                        {
                            PartId = part,
                            Car = cCar
                        };
                        context.PartCars.Add(partCar);
                    }
                }
            }
            context.SaveChanges();
            return $"Successfully imported {cars.Count()}";
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();
            var serializer = new XmlSerializer(typeof(CustomerImportDTO[]), new XmlRootAttribute("Customers"));
            var customers = (CustomerImportDTO[])serializer.Deserialize(new StringReader(inputXml));
            foreach (var p in customers)
            {
                var cCustomer = mapper.Map<CustomerImportDTO, Customer>(p);
                context.Customers.Add(cCustomer);
            }
            context.SaveChanges();
            return $"Successfully imported {customers.Count()}";
        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();
            var serializer = new XmlSerializer(typeof(SaleImportDTO[]), new XmlRootAttribute("Sales"));
            var sales = (SaleImportDTO[])serializer.Deserialize(new StringReader(inputXml));
            int count = 0;
            var carsIds = context.Cars.Select(x => x.Id).ToList();
            foreach (var sale in sales)
            {
                if (carsIds.Any(x => x == sale.CarId))
                {
                    var cSale = mapper.Map<SaleImportDTO, Sale>(sale);
                    context.Sales.Add(cSale);
                    count++;
                }
            }
            context.SaveChanges();
            return $"Successfully imported {count}";
        }
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            var cars = context.Cars
                                    .Where(x => x.TravelledDistance > 2000000)
                                    .OrderBy(x => x.Make)
                                    .ThenBy(x => x.Model)
                                    .Take(10)
                                    .ProjectTo<CarExportDTO>(config)
                                    .ToArray();
            return XmlSerialize(cars, "cars");
        }
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            var cars = context.Cars
                                    .Where(x => x.Make == "BMW")
                                    .OrderBy(x => x.Model)
                                    .ThenByDescending(x => x.TravelledDistance)
                                    .ProjectTo<CarBMWExportDTO>(config)
                                    .ToArray();
            return XmlSerialize(cars, "cars");
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {           
            var suppliers = context.Suppliers
                                    .Where(x => x.IsImporter == false)                                    
                                    .Select(x => new SupplierExportDTO
                                     {
                                         Id = x.Id,
                                         Name = x.Name,
                                         PartsCount = x.Parts.Count
                                     })
                                    .ToArray();
            return XmlSerialize(suppliers, "suppliers");
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                                    .Select(x => new CarWithPartsExportDTO
                                    {
                                        Make = x.Make,
                                        Model = x.Model,
                                        TravelledDistance = x.TravelledDistance,
                                        Parts = x.PartCars.Select(y => new CarPartsDTO
                                        {
                                            Name = y.Part.Name,
                                            Price = y.Part.Price
                                        })
                                        .OrderByDescending(x => x.Price)
                                        .ToArray()
                                    })
                                    .OrderByDescending(x => x.TravelledDistance)
                                    .ThenBy(x => x.Model)
                                    .Take(5)
                                    .ToArray();                                    
            return  XmlConverter.Serialize(carsWithParts, "cars");
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersWithCars = context.Sales
                                   .Where(x => x.Customer.Sales.Any())
                                   .Select(x => new CustomerWithCarExportDTO
                                   {
                                       Name = x.Customer.Name,
                                       BoughtCars = x.Customer.Sales.Count,
                                       SpentMoney = x.Car.PartCars.Sum(x => x.Part.Price)
                                   })
                                   .OrderByDescending(x => x.SpentMoney)
                                   .ToArray();                                  
                                  
            return XmlConverter.Serialize(customersWithCars, "customers");
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context.Sales
                                 .Select(x => new SalesWithDiscountDTO
                                 {
                                    Car = new CarDetails
                                    {
                                        Make = x.Car.Make,
                                        Model = x.Car.Model,
                                        TravelledDistance = x.Car.TravelledDistance
                                    },
                                    Discount = x.Discount,
                                    CustomerName = x.Customer.Name,
                                    Price = x.Car.PartCars.Sum(y=>y.Part.Price)
                                 })
                                 .ToArray();
            foreach (var sale in salesWithDiscount)
            {
                sale.PriceWithDiscount = sale.Price - (sale.Price * sale.Discount / 100.0M);
            }
            return XmlConverter.Serialize(salesWithDiscount, "sales");
        }
        private static string XmlSerialize<T>(T[] list, string root)
        {
            var serializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(root));
            var writer = new StringWriter();
            serializer.Serialize(writer, list, GetXMLNameSpaces());
            return writer.ToString();
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
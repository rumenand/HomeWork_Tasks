using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using CarDealer.DTO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new CarDealerContext();
           // db.Database.EnsureDeleted();
           // db.Database.EnsureCreated();
            //var inputJSON = File.ReadAllText("../../../Datasets/sales.json");
            string data = GetSalesWithAppliedDiscount(db);
            File.WriteAllText("data.json", data);

            //File.WriteAllText("data.json", data);
        }
        //Problem 1
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count()}.";
        }
        //Problem 2
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson);
            var supliersId = context.Suppliers.Select(x => x.Id).ToList();
            int counter = 0;
            foreach (var part in parts)
            {
                if (supliersId.Any(x => x == part.SupplierId))
                {
                    context.Parts.Add(part);
                    counter++;
                }
            }
            context.SaveChanges();
            return $"Successfully imported {counter}.";
        }
        //Problem 3
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var config = new MapperConfiguration(cfg =>cfg.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();
            var carsData = JsonConvert.DeserializeObject<CarInsertModel[]>(inputJson);
            var cars = new List<Car>();
            var partsCar = new List<PartCar>();
            foreach (var carObj in carsData)
            {
                var car = mapper.Map<CarInsertModel, Car>(carObj);
                foreach (var part in carObj.PartsId.Distinct())
                {
                    var partCar = new PartCar();
                    partCar.PartId = part;
                    partCar.Car = car;
                    partsCar.Add(partCar);
                }
                cars.Add(car);
            }           
             
            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partsCar);
            context.SaveChanges();
            return $"Successfully imported {cars.Count()}.";
        }
        //Problem 4
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);
            context.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count()}.";
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);
            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count()}.";
        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                                     .OrderBy(x => x.BirthDate)
                                     .ThenBy(x => x.IsYoungDriver)
                                     .Select(x => new
                                     {
                                         Name = x.Name,
                                         BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                                         IsYoungDriver = x.IsYoungDriver
                                     })                                     
                                     .ToList();
            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                                    .Where(x => x.Make == "Toyota")
                                    .OrderBy(x => x.Model)
                                    .ThenByDescending(x=>x.TravelledDistance)
                                    .Select(x => new
                                    {
                                        Id = x.Id,
                                        Make = x.Make,
                                        Model = x.Model,
                                        TravelledDistance = x.TravelledDistance
                                    })
                                    .ToList();
            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                                    .Where(x => x.IsImporter == false)
                                    .Select(x => new
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        PartsCount = x.Parts.Count
                                    })
                                    .ToList();
            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                                    .Select(x => new
                                    {
                                        car = new
                                        {
                                            x.Make,
                                            x.Model,
                                            x.TravelledDistance
                                        },
                                        parts = x.PartCars.Select(y => new
                                        {
                                            Name = y.Part.Name,
                                            Price = string.Format("{0:0.00}",y.Part.Price)
                                        })
                                    })
                                    .ToList();
            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                                    .Where(x => x.Sales.Count >0)
                                    .Select(x => new
                                    {
                                        fullName = x.Name,
                                        boughtCars = x.Sales.Select(y=>y.CarId).Distinct().Count(),
                                        spentMoney = x.Sales.Sum(y=>y.Car.PartCars.Sum(z=>z.Part.Price))
                                    })
                                    .OrderByDescending(x=>x.spentMoney)
                                    .ThenByDescending(x=>x.boughtCars)
                                    .ToList();
            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                                    .Take(10)
                                    .Select(x => new
                                    {
                                        car = new
                                        {
                                            x.Car.Make,
                                            x.Car.Model,
                                            x.Car.TravelledDistance
                                        },
                                        customerName = x.Customer.Name,
                                        Discount = string.Format("{0:0.00}",x.Discount),
                                        price = string.Format("{0:0.00}",x.Car.PartCars.Sum(y=>y.Part.Price)),
                                        priceWithDiscount = string.Format("{0:0.00}",(1-x.Discount/100) * x.Car.PartCars.Sum(y=>y.Part.Price))
                                    })
                                    .ToList();
           
            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }
    }
}
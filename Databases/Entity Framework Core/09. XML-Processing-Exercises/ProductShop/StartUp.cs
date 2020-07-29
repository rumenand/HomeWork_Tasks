namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using ProductShop.Data;
    using ProductShop.Dtos.Import;
    using ProductShop.Dtos.Export;
    using ProductShop.Models;
    using AutoMapper;
    using System.Text;
    using AutoMapper.QueryableExtensions;

    public class StartUp
    {
        public static void Main()
        {
            var db = new ProductShopContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            //Console.WriteLine(ImportCategoryProducts(db, File.ReadAllText("../../../Datasets/categories-products.xml")));
            string data = GetUsersWithProducts(db);
            File.WriteAllText("data.xml", data);
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XDocument doc = XDocument.Parse(inputXml);
            var users = doc.Root.Elements();
            foreach (var user in users)
            {
                var cUser = new User()  { 
                    FirstName = user.Element("firstName").Value, 
                    LastName =  user.Element("lastName").Value, 
                    Age = int.Parse(user.Element("age").Value)} ;
                context.Users.Add(cUser);
            }
           
            context.SaveChanges();
            return $"Successfully imported {users.Count()}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());
            var mapper = config.CreateMapper();
            var serializer = new XmlSerializer(typeof(ProductImportDTO[]), new XmlRootAttribute("Products"));
            var products = (ProductImportDTO[])serializer.Deserialize(new StringReader(inputXml));
            var count = 0;
            foreach (var p in products)
            {
                var cProd = mapper.Map<ProductImportDTO, Product>(p);
                if (cProd.Name != null)
                {
                    context.Products.Add(cProd);
                    count++;
                }
            }
            context.SaveChanges();
            return $"Successfully imported {count}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XDocument doc = XDocument.Parse(inputXml);
            var categories = doc.Root.Elements();
            foreach (var c in categories)
            {
                var cCat = new Category()
                {
                    Name = c.Element("name").Value
                };
                context.Categories.Add(cCat);
            }
            context.SaveChanges();
            return $"Successfully imported {categories.Count()}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XDocument doc = XDocument.Parse(inputXml);
            var catProds = doc.Root.Elements();
            foreach (var cPr in catProds)
            {
                var cCatPr = new CategoryProduct()
                {
                    CategoryId = int.Parse(cPr.Element("CategoryId").Value),
                    ProductId = int.Parse(cPr.Element("ProductId").Value)
                };
                context.CategoryProducts.Add(cCatPr);
            }
            context.SaveChanges();
            return $"Successfully imported {catProds.Count()}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());
            var products = context.Products
                                    .Where(x => x.Price >= 500 && x.Price<=1000)                                    
                                    .ProjectTo<ProductExportDTO>(config)
                                    .OrderBy(x => x.Price)
                                    .Take(10)
                                    .ToArray();
            return XmlSerialize(products, "Products");
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());
            var users = context.Users
                                    .Where(x => x.ProductsSold.Count>1)
                                    .OrderBy(x => x.LastName)
                                    .ThenBy(x=>x.FirstName)
                                    .Take(5)
                                    .ProjectTo<UsersExportDTO>(config)                                    
                                    .ToArray();
            return XmlSerialize(users, "Users");
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                                   .Select(x => new CategoryExportDTO
                                   {
                                       Name = x.Name,
                                       Count = x.CategoryProducts.Count,
                                       AveragePrice = x.CategoryProducts.Average(p => p.Product.Price),
                                       TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price)
                                   })
                                   .OrderByDescending(x => x.Count)
                                   .ThenBy(x => x.TotalRevenue)
                                   .ToArray();
            return XmlSerialize(categories, "Categories");
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var allUSers = new AllUsersExport
            {
                Count = context.Users.Where(x => x.ProductsSold.Count > 0).Count(),
                Users = context.Users
                                    .ToArray()
                                    .Where(x => x.ProductsSold.Count > 0)                                    
                                    .Select(x => new UsersExportDTO2
                                    {
                                        FirstName = x.FirstName,
                                        LastName = x.LastName,
                                        Age = x.Age,
                                        SoldProducts = new SoldProducts
                                        {
                                            Count = x.ProductsSold.Count,
                                            products = x.ProductsSold.Select(y => new ProductDto
                                            {
                                                Name = y.Name,
                                                Price = y.Price
                                            })
                                            .OrderByDescending(z=>z.Price)
                                            .ToArray()
                                        }
                                    })
                                    .OrderByDescending(x => x.SoldProducts.Count)
                                    .Take(10)
                                    .ToArray()
            };
            return XmlSerialize(allUSers, "Users");
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
           var db = new ProductShopContext();
            // db.Database.EnsureDeleted();
            // db.Database.EnsureCreated();
            //Console.WriteLine(ImportCategoryProducts(db, File.ReadAllText("../../../Datasets/categories-products.json")));
            string data = GetUsersWithProducts(db);
            File.WriteAllText("data.json",data);
        }
        //Problem 1
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count()}";
        }
        //Problem 2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count()}";
        }
        //Problem 3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                               .Where(x=>x.Name != null)
                               .ToArray();
            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count()}";
        }
        //Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProduct = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            context.CategoryProducts.AddRange(categoryProduct);
            context.SaveChanges();
            return $"Successfully imported {categoryProduct.Count()}";
        }
        //Problem 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var prInRange = context.Products.Where(x => x.Price >= 500 && x.Price <= 1000)
                                            .Select(x => new {
                                                name = x.Name,
                                                price = x.Price,
                                                seller = x.Seller.FirstName +" " + x.Seller.LastName
                                            })
                                            .OrderBy(x => x.price)
                                            .ToList();
            return JsonConvert.SerializeObject(prInRange,Formatting.Indented);  
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldPr = context.Users.Where(x => x.ProductsSold.Any(y=>y.Buyer !=null))
                                                .OrderBy(x => x.LastName)
                                                .ThenBy(x => x.FirstName)
                                               .Select(x => new {
                                                   firstName = x.FirstName,
                                                   lastName = x.LastName,
                                                   soldProducts = x.ProductsSold.Where(z=>z.Buyer != null)
                                                                    .Select(y=> new { 
                                                                    name = y.Name,
                                                                    price = y.Price,
                                                                    buyerFirstName = y.Buyer.FirstName,
                                                                    buyerLastName = y.Buyer.LastName
                                                   }).ToArray()
                                               }).ToList();
            return JsonConvert.SerializeObject(soldPr,Formatting.Indented);
        }
        //Problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                                     .Select(x => new
                                     {
                                         category = x.Name,
                                         productsCount = x.CategoryProducts.Count,
                                         averagePrice = Math.Round(x.CategoryProducts.Average(y => y.Product.Price), 2).ToString(),
                                         totalRevenue = Math.Round(x.CategoryProducts.Sum(y => y.Product.Price), 2).ToString()
                                     })
                                     .OrderByDescending(x => x.productsCount);
            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }
        //Problem 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users.Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                                     .OrderByDescending(x => x.ProductsSold.Count(y => y.Buyer != null))
                                     .Select(x => new
                                     {
                                         firstName = x.FirstName,
                                         lastName = x.LastName,
                                         age = x.Age,
                                         soldProducts = new
                                         {   count = x.ProductsSold.Count(y=>y.Buyer != null),
                                             products = x.ProductsSold
                                                            .Select(y => new
                                                            {
                                                                name = y.Name,
                                                                price = y.Price
                                                            }).ToArray()
                                         }
                                     }).ToArray();
            var finalObj = new
            {
                usersCount = users.Count(),
                users
            };
            return JsonConvert.SerializeObject(finalObj, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }   
}
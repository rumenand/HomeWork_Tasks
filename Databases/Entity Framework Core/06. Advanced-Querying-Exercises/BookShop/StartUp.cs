namespace BookShop
{
    using Data;
    //using Initializer;
    using System.Text;
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using Models.Enums;
    using System.Collections.Generic;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            // var command = int.Parse(Console.ReadLine());
            var value = RemoveBooks(db);
            Console.WriteLine(value);

        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            command = command.ToLower();
            command = command.First().ToString().ToUpper() + command.Substring(1);
            AgeRestriction intType = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command);
            // FormattableString nativeSQLQuery = $"SELECT * FROM dbo.Books WHERE AgeRestriction = {intType} ORDER BY Title";

            // var books = context.Books.FromSqlInterpolated((FormattableString)nativeSQLQuery);      
            var books = context.Books.Where(x => x.AgeRestriction == intType)
                                       .OrderBy(x=>x.Title)
                                        .Select(x => x.Title);
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books.Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                                     .Select(x => new
                                     {
                                         Title = x.Title,
                                         Id = x.BookId
                                     })
                                     .OrderBy(x => x.Id);
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }
            return sb.ToString();
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books.Where(x => x.Price>40)
                                     .Select(x => new
                                     {
                                         Title = x.Title,
                                         Price = x.Price
                                     })
                                     .OrderByDescending(x => x.Price);
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }
            return sb.ToString();
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books.Where(x => x.ReleaseDate.Value.Year != year)
                                    .Select(x => new
                                    {
                                        Title = x.Title,
                                        Id = x.BookId
                                    })
                                    .OrderBy(x => x.Id);
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }
            return sb.ToString();
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var bookCat = input.ToLower()
                .Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var bookList = new List<string>();

            foreach (var c in bookCat)
            {
                var books = context.Books
                                .Where(x => x.BookCategories.Any(y => y.Category.Name.ToLower() == c))
                                .Select(x => x.Title)
                                .ToList();
                foreach (var book in books)
                {
                    bookList.Add(book);
                }
            }
           
            var sb = new StringBuilder();
            foreach (var book in bookList.OrderBy(x=>x))
            {
                sb.AppendLine($"{book}");
            }
           // Console.WriteLine(sb.ToString().Trim().Length);
            return sb.ToString().Trim();
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime chDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books.Where(x => x.ReleaseDate<chDate)
                                   .Select(x => new
                                   {
                                       Title = x.Title,
                                       Edition = x.EditionType,
                                       Price = x.Price,
                                       ReleaseDate = x.ReleaseDate
                                   })
                                   .OrderByDescending(x => x.ReleaseDate);
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.Edition} - ${book.Price:F2}");
            }
            return sb.ToString();
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {

            var authors = context.Authors.Where(x => x.FirstName.EndsWith(input))
                                   .Select(x => new
                                   {
                                       fullName = x.FirstName + " " + x.LastName
                                   })
                                   .OrderBy(x=>x.fullName)
                                   .ToList();
            var sb = new StringBuilder();
            foreach (var author in authors)
            {
                sb.AppendLine($"{author.fullName}");
            }
            return sb.ToString();
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            //var chString = "["+input.ToLower()+"]"+"%";
            var books = context.Books.Where(x => x.Title.ToLower().Contains(input.ToLower()))
                                  .Select(x => new
                                  {
                                     Title = x.Title
                                  })
                                  .OrderBy(x=>x.Title)
                                  .ToList();
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }
            return sb.ToString();
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books.Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                                  .OrderBy(x=>x.BookId)
                                  .Select(x => new
                                  {
                                      AuthorName = (x.Author.FirstName != null)
                                                    ?x.Author.FirstName+" "+x.Author.LastName
                                                    :x.Author.LastName,
                                      Title = x.Title
                                  })
                                  .ToList();
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            }
            return sb.ToString();
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books.Where(x => x.Title.Length > lengthCheck).ToList();
           
            return books.Count;
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors.Select(x => new
                                  {
                                      AuthorName = (x.FirstName != null)
                                                    ? x.FirstName + " " + x.LastName
                                                    : x.LastName,
                                      Copies = x.Books.Select(y=>y.Copies).Sum()
                                  })
                                  .OrderByDescending(x=>x.Copies)
                                  .ToList();
            var sb = new StringBuilder();
            foreach (var author in authors)
            {
                sb.AppendLine($"{author.AuthorName} - {author.Copies}");
            }
            return sb.ToString();
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var books = context.Categories.Select(x => new
            {
                Category = x.Name,
                Profit = x.CategoryBooks.Select(y=>y.Book.Price*y.Book.Copies).Sum()
            })
                                  .OrderByDescending(x => x.Profit)
                                  .ThenBy(x=>x.Category)
                                  .ToList();
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Category} ${book.Profit:F2}");
            }
            return sb.ToString();
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var books = context.Categories.Select(x => new
            {
                Category = x.Name,
                TopThree = x.CategoryBooks.Select(y=>y.Book)
                            .OrderByDescending(z=>z.ReleaseDate)
                            .Take(3)
                            .Select(a=>a.ReleaseDate == null
                                    ?$"{a.Title} ()"
                                    :$"{a.Title} ({a.ReleaseDate.Value.Year})")
            })
            .OrderBy(x=>x.Category)
            .ToList();
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"--{book.Category}");
                foreach (var title in book.TopThree)
                {
                    sb.AppendLine(title);
                }
            }
            return sb.ToString();
        }
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                               .Where(x => x.ReleaseDate.Value.Year<2010)
                               .ToList();
            foreach (var book in books)
            {
                book.Price +=5;
            }
            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var bookToRemove = context
            .Books
            .Where(b => b.Copies < 4200);
            foreach (var book in bookToRemove)
            {
                context.Remove(book);
                count++;
            }
            context.SaveChanges();
            return count;
        }
    }
}

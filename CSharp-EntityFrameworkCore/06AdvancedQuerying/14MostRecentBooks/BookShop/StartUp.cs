using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            //if the upper line is not commented it will print these unused lines :
            //    "BookShop database created successfully."
            //    "Sample data inserted successfully."

            Console.WriteLine(GetMostRecentBooks(db));
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var recentBooks = context
                .Categories
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Books = x.CategoryBooks
                        .OrderByDescending(c => c.Book.ReleaseDate)
                        .Select(c => new
                        {
                            BookTitle = c.Book.Title,
                            BookYear = c.Book.ReleaseDate.Value.Year
                        }).Take(3)
                }).ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var category in recentBooks)
            {
                sb.AppendLine($"--{category.CategoryName}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.BookYear})");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}



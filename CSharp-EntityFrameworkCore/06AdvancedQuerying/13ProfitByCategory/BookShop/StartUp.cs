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

            Console.WriteLine(GetTotalProfitByCategory(db));
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            string[] totalProfit = context
                .Categories
                .OrderByDescending(x => x.CategoryBooks.Sum(c => c.Book.Copies * c.Book.Price))
                .ThenBy(x => x.Name)
                .Select(x => $"{x.Name} ${x.CategoryBooks.Sum(c => c.Book.Copies * c.Book.Price):f2}")
                .ToArray();

            return string.Join(Environment.NewLine, totalProfit);
        }
    }
}



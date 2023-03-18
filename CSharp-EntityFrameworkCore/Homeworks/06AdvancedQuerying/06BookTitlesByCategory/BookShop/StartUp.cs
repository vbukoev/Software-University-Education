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
            
            string input = Console.ReadLine();
            Console.WriteLine(GetBooksByCategory(db, input));
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split().ToArray();

            string[] books = context
                .BooksCategories
                .Where(x=>categories.Contains(x.Category.Name.ToLower()))
                .Select(x=>x.Book.Title)
                .OrderBy(x=>x)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }
    }
}



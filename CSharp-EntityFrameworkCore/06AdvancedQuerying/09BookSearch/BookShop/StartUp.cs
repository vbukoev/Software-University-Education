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
            Console.WriteLine(GetBookTitlesContaining(db, input));
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string[] books = context
                .Books
                .Where(x=>x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x=>x)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }
    }
}



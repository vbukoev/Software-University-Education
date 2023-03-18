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

            Console.WriteLine(GetGoldenBooks(db));
        }


        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var value = Enum.Parse<AgeRestriction>(command, true);
            string[] bookTitles = context
                .Books
                .Where(x=>x.AgeRestriction == value)
                .Select(x=>x.Title)
                .OrderBy(x=>x)
                .ToArray();
            return string.Join(Environment.NewLine, bookTitles);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] books = context
                .Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }
    }
}



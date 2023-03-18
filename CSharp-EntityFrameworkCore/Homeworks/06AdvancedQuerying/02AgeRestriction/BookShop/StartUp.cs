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
            DbInitializer.ResetDatabase(db);
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
    }
}



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
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine(GetBooksNotReleasedIn(db, year));
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] books = context
                .Books
                .Where(x=>x.ReleaseDate.Value.Year != year)
                .OrderBy(x=>x.BookId)
                .Select(x=>x.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }
    }
}



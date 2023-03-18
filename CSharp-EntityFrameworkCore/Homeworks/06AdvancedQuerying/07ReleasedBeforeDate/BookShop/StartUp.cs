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
            
            string date = Console.ReadLine();
            Console.WriteLine(GetBooksReleasedBefore(db, date));
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            string[] books = context
                .Books
                .Where(x=>x.ReleaseDate < dateTime)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x=>$"{x.Title} - {x.EditionType.ToString()} - ${x.Price:f2}")
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }
    }
}



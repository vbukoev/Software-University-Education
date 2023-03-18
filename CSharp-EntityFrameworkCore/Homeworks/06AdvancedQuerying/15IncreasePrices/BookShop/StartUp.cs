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
            IncreasePrices(db);
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context
                .Books
                .Where(x => x.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
                book.Price += 5;

            context.SaveChanges();
        }
    }
}
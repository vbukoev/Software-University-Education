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
            
            
            Console.WriteLine(CountCopiesByAuthor(db));
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            string[] cntOfCopies = context
                .Authors
                .OrderByDescending(x => x.Books.Sum(x => x.Copies))
                .Select(x => $"{x.FirstName} {x.LastName} - {x.Books.Sum(x => x.Copies)}")
                .ToArray();

            return string.Join(Environment.NewLine, cntOfCopies);
        }
    }
}



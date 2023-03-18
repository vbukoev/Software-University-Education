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
            
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(CountBooks(db, input));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Count(x => x.Title.Length > lengthCheck);
        }
    }
}



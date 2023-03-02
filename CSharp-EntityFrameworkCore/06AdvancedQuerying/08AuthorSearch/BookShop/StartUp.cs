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
            Console.WriteLine(GetAuthorNamesEndingIn(db, input));
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string[] authors = context
                .Authors
                .Where(x=>x.FirstName.EndsWith(input))
                .Select(x => x.FirstName + " " + x.LastName)
                .OrderBy(x=>x)
                .ToArray();

            return string.Join(Environment.NewLine, authors);
        }
    }
}



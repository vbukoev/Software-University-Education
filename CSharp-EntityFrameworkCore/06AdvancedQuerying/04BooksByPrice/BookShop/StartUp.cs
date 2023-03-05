namespace BookShop
{
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            //if the upper line is not commented it will print these unused lines :
            //    "BookShop database created successfully."
            //    "Sample data inserted successfully."
            Console.WriteLine(GetBooksByPrice(db));
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            string[] books = context
                .Books
                .Where(x=>x.Price > 40)
                .OrderByDescending(x=>x.Price)
                .Select(x=>$"{x.Title} - ${x.Price:f2}")
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }
    }
}



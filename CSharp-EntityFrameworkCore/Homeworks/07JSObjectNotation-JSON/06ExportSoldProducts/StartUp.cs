using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            ImportData(context);

            string output = GetSoldProducts(context);

            Console.WriteLine(output);
        }

        public static void ImportData(ProductShopContext context)
        {
            string inputJsonUsers = File.ReadAllText(@"../../../Datasets/users.json");
            string inputJsonProducts = File.ReadAllText(@"../../../Datasets/products.json");
            string inputJsonCategories = File.ReadAllText(@"../../../Datasets/categories.json");
            string inputJsonCategoriesProducts = File.ReadAllText(@"../../../Datasets/categories-products.json");

            List<User>? users = JsonConvert.DeserializeObject<List<User>>(inputJsonUsers);
            context.Users.AddRange(users);
            context.SaveChanges();

            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJsonProducts);
            context.Products.AddRange(products);
            context.SaveChanges();

            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(inputJsonCategories)
                .Where(c => c.Name != null)
                .ToList();
            context.Categories.AddRange(categories);
            context.SaveChanges();

            List<CategoryProduct> categoriesProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJsonCategoriesProducts);
            context.CategoriesProducts.AddRange(categoriesProducts);
            context.SaveChanges();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(x => x.ProductsSold.Any(p=>p.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x=>x.FirstName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Select(p=>new
                    {
                        name = p.Name, 
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                })
                .ToArray();

            return JsonConvert.SerializeObject(soldProducts, Formatting.Indented);
        }
    }
}
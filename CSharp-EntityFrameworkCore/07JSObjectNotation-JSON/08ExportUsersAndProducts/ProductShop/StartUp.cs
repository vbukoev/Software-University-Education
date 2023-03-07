using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
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

            string output = GetUsersWithProducts(context);

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

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(x => x.ProductsSold
                    .Count(p => p.Buyer != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Count(p => p.Buyer != null),
                        products = x.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price
                            })
                    }
                }).ToArray();

            return 
                JsonConvert.SerializeObject(new
            {
                usersCount = usersWithProducts.Count(),
                users = usersWithProducts
            }, 
                new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            });
        }
    }
}
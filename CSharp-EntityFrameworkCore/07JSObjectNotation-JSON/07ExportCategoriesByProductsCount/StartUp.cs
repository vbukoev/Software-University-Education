using System.Reflection.Metadata;
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

            string output = GetCategoriesByProductsCount(context);

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

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProducts = context.Categories
                .OrderByDescending(x=>x.CategoriesProducts.Count)
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoriesProducts.Count,
                    averagePrice = Math.Round((double)x.CategoriesProducts.Average(p=>p.Product.Price),2),
                    totalRevenue = Math.Round((double)x.CategoriesProducts.Sum(p => p.Product.Price), 2),
                })
                .ToArray();

            return JsonConvert.SerializeObject(categoriesByProducts, Formatting.Indented);
        }
    }
}
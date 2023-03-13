using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.DTOs;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string userXmlPath = @"../../../Datasets/users.xml";
            string usersXmlString = File.ReadAllText(userXmlPath);
            ImportUsers(context, usersXmlString);

            string productXmlPath = @"../../../Datasets/products.xml";
            string productsXmlString = File.ReadAllText(productXmlPath);
            ImportProducts(context, productsXmlString);

            string categoryXmlPath = @"../../../Datasets/categories.xml";
            string categoriesXmlString = File.ReadAllText(categoryXmlPath);
            ImportCategories(context, categoriesXmlString);

            string categoriesProductsXmlPath = @"../../../Datasets/categories-products.xml";
            string categoriesProductsXmlString = File.ReadAllText(categoriesProductsXmlPath);
            string output = ImportCategoryProducts(context, categoriesProductsXmlString);

            Console.WriteLine(output);
        }

        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);
            using StringReader reader = new StringReader(inputXml);

            T dtos = (T)serializer.Deserialize(reader);
            return dtos;

        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var userDtos = Deserialize<ImportUserDto[]>(inputXml, "Users");
            User[] users = userDtos
                .Select(x => new User()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age
                })
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var productDto = Deserialize<ImportProductDto[]>(inputXml, "Products");

            Product[] products = productDto
                .Select(x => new Product()
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerId = x.BuyerId == 0 ? null : x.BuyerId,
                    SellerId = x.SellerId
                }).ToArray();
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categoriesDto = Deserialize<ImportCategoryDto[]>(inputXml, "Categories");
            Category[] categories = categoriesDto
                .Select(x => new Category()
                {
                    Name = x.Name
                }).ToArray();
            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categoriesProductsDto = Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");
            CategoryProduct[] categoryProducts = categoriesProductsDto
                .Select(x => new CategoryProduct()
                {
                    CategoryId = x.CategoryId,
                    ProductId = x.ProductId
                }).ToArray();
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count()}";
        }
    }
}
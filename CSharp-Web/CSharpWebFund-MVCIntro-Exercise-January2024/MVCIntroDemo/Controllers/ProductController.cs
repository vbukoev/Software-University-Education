using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCIntroDemo.ViewModels.Product;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Xml;
using static MVCIntroDemo.Seeding.ProductData;
namespace MVCIntroDemo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult All()
        {
            return View(products);
        }
        public IActionResult ById(string id)
        {
            ProductViewModel? product = products
                .FirstOrDefault(p => p.Id.ToString().Equals(id));

            if (product == null)
            {
                return RedirectToAction("All");
            }

            return View(product);
        }

        public IActionResult AllAsJson()
        {
            return Json(products, new JsonSerializerOptions()
            {
                WriteIndented = true,
            });
        }

        public IActionResult DownloadProductsInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                sb
                    .AppendLine($"Product with Id: {product.Id}")
                    .AppendLine($"## Product Name: {product.Name}")
                    .AppendLine($"## Price: {product.Price:f2}")
                    .AppendLine("-----------------------------");
            }
            Response.Headers.Add(HeaderNames.ContentDisposition, "attachment;filename=products.txt");
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/plain");
        }
    }
}

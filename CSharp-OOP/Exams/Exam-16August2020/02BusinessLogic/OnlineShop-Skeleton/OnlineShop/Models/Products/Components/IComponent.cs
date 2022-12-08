using OnlineShop.Models.Products.Components;
namespace OnlineShop.Models.Products.Components
{
    public interface IComponent : IProduct
    {
        int Generation { get; }
    }
}

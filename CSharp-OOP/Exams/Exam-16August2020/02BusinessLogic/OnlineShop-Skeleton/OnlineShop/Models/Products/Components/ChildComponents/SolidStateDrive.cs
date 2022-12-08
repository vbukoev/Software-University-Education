using OnlineShop.Models.Products.Components;
namespace OnlineShop.Models.Products.Components.ChildComponents
{
    public class SolidStateDrive : Component
    {
        public SolidStateDrive(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance * 1.20, generation)
        {
        }
    }
}

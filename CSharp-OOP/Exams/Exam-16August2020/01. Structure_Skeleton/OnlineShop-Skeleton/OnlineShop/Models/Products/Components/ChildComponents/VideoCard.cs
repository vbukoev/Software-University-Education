using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components.ChildComponents
{
    public class VideoCard : Component
    {
        public VideoCard(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance * 1.15, generation)
        {
        }
    }
}

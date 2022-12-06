using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components.ChildComponents
{
    public class CentralProcessingUnit : Component
    {
        public CentralProcessingUnit(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance * 1.25, generation)
        {
        }
    }
}

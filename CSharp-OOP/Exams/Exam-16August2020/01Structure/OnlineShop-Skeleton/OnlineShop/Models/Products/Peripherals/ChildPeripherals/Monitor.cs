﻿namespace OnlineShop.Models.Products.Peripherals.ChildPeripherals
{
    public class Monitor:Peripheral
    { 
        public Monitor(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
        }
    }
}

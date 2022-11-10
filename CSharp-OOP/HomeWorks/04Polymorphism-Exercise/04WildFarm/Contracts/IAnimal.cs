using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Contracts
{
    public interface IAnimal
    {
        //string Name, double Weight, int FoodEaten
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        void Eat(IFood food);
        string ProduceSound();
    }
}

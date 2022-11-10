namespace Restaurant
{
    public class Coffee : HotBeverage 
    {
        private const double COFFEE_MILILITTERS = 50;
        private const decimal COFFEE_PRICE = 3.5m;

        public Coffee(string name, double caffeine) : base(name, COFFEE_PRICE, COFFEE_MILILITTERS)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; private set; }
    }
}

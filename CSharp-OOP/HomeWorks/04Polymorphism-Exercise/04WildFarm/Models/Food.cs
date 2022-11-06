namespace WildFarm.Models
{
    using Contracts;

    public class Food : IFood
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }
        public int Quantity { get; private set; }
    }
}

namespace FishingNet
{
    public class Fish
    {
        public Fish(string fishType, double length, double weight)
        {
            FishType = fishType;
            Length = length;
            Weight = weight;
        }
        public string FishType { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public override string ToString()
        {
            return $"There is a {this.FishType}, {this.Length} cm. long, and {this.Weight} gr. in weight.";
        }
    }
}

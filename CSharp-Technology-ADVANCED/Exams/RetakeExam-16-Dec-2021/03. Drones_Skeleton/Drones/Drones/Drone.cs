using System.Text;

namespace Drones
{
    public class Drone
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Range { get; set; }
        public bool Available { get; set; }


        public Drone(string name, string brand, int range)
        {
            this.Available = true;
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drone: {this.Name}");
            sb.AppendLine($"Manufactured by: {Brand}");
            sb.AppendLine($"Range: {Range} kilometers");

            return sb.ToString().TrimEnd();
        }
    }
}

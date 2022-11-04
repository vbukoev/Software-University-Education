using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }
        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.Displacement = displacement;
        }
        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            this.Efficiency = efficiency;
        }
        public Engine(string model, int power, int displacement, string efficiency):this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }
        public override string ToString()
        {
            var res = new StringBuilder();
            res.AppendLine($" {this.Model}:");
            res.AppendLine($"    Power: {this.Power}");
            if (this.Displacement == 0) res.AppendLine($"    Displacement: n/a");
            else res.AppendLine($"    Displacement: {this.Displacement}");
            if (this.Efficiency == null) res.Append($"    Efficiency: n/a");
            else res.Append($"    Efficiency: {this.Efficiency}");
            return res.ToString();
        }
    }
}
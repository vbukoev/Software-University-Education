namespace BorderControl.Models
{
    using Contracts;
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
        public string Model { get; private set; }
        public string Id { get; private set; }
        public override string ToString()
        {
            return $"{Id}";
        }
    }
}

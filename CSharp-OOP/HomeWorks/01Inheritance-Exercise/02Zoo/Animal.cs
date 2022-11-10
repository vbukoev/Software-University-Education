namespace Zoo
{
    public class Animal
    {
        public Animal(string name)
        {
            Name = name;//"this" points to the current prop, but only in the current instance, it lives only in the Animal class
        }
        public virtual string Name { get; set; }
    }
}

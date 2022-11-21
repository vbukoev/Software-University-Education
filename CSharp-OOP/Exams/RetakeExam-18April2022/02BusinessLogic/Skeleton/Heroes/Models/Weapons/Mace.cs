namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private const int damage = 25;
        public Mace(string name, int durability) : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            Durability--;
            return Durability == 0 ? 0 : damage;
        }
    }
}

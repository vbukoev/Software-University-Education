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
            if (Durability > 0)
            {
                Durability--;
            }

            if (Durability == 0)
            {
                return 0;
            }

            return damage;
        }
    }
}

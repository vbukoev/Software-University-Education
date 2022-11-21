using System.Collections.Generic;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Repositories
{
    public class WeaponRepository :IRepository<IWeapon>
    {
        private List<IWeapon> weapons;
        public IReadOnlyCollection<IWeapon> Models => weapons.AsReadOnly();
        public void Add(IWeapon model)
        {
            weapons.Add(model);
        }

        public bool Remove(IWeapon model)
        => weapons.Remove(model);

        public IWeapon FindByName(string name)
            => weapons.Find(x => x.Name == name);
    }
}

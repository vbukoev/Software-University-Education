using System.Collections.Generic;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroesList;

        public HeroRepository()
        {
            heroesList = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => heroesList.AsReadOnly();
        public void Add(IHero model)
        {
            heroesList.Add(model);
        }

        public bool Remove(IHero model)
        => heroesList.Remove(model);


        public IHero FindByName(string name)
            => heroesList.Find(x => x.Name == name);
    }
}
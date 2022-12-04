using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;
        public IReadOnlyCollection<IPlanet> Models => planets;
        public void Add(IPlanet model)
        {
            planets.Add(model);
        }

        public bool Remove(IPlanet model)
        => planets.Remove(model);

        public IPlanet FindByName(string name)
            => planets.Find(x => x.Name == name);
    }
}

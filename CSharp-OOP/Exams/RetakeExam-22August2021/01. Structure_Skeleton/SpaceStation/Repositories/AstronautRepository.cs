using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> astronauts;

        public AstronautRepository()
        {
            astronauts = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => astronauts.AsReadOnly();
        public void Add(IAstronaut model)
        {
            astronauts.Add(model);
        }

        public bool Remove(IAstronaut model)
        => astronauts.Remove(model);

        public IAstronaut FindByName(string name)
            => astronauts.Find(x => x.Name == name);
    }
}

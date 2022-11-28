using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs;

        public EggRepository()
        {
            eggs = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => eggs.AsReadOnly();
        public void Add(IEgg model)
        {
            eggs.Add(model);
        }

        public bool Remove(IEgg model)
        => eggs.Remove(model);

        public IEgg FindByName(string name)
            => eggs.Find(x => x.Name == name);
    }
}

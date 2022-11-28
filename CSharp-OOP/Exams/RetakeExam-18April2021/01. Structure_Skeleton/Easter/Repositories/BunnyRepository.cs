using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> bunnies;

        public BunnyRepository()
        {
            bunnies = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => bunnies.AsReadOnly();
        public void Add(IBunny model)
        {
            bunnies.Add(model);
        }

        public bool Remove(IBunny model)
        => bunnies.Remove(model);

        public IBunny FindByName(string name)
            => bunnies.Find(x => x.Name==name);
    }
}

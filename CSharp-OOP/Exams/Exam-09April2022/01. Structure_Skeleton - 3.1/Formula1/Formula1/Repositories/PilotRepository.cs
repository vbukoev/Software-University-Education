using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> pilots;

        public PilotRepository()
        {
            pilots = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => pilots.AsReadOnly();
        public void Add(IPilot model)
        {
            pilots.Add(model);
        }

        public bool Remove(IPilot model)
            => pilots.Remove(model);

        public IPilot FindByName(string name)
            => pilots.Find(x => x.FullName == name);
    }
}

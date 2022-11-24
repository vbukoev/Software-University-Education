using System;
using System.Collections.Generic;
using System.Text;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> vessels;
        public IReadOnlyCollection<IVessel> Models => vessels.AsReadOnly();
        public void Add(IVessel model)
        {
            vessels.Add(model);
        }

        public bool Remove(IVessel model)
            => vessels.Remove(model);

        public IVessel FindByName(string name)
            => vessels.Find(x => x.Name == name);
    }
}

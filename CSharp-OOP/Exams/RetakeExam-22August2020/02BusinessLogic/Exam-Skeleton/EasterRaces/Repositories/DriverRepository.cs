using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Entities;

namespace EasterRaces.Repositories
{
    public class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name)
            => Models.FirstOrDefault(x => x.Name == name);
    }
}

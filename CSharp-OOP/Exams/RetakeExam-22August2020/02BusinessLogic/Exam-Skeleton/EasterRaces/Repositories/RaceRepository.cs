using System;
using System.Collections.Generic;
using System.Linq;

using EasterRaces.Models.Races.Contracts; 
using EasterRaces.Repositories.Entities;

namespace EasterRaces.Repositories
{
    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
            => Models.FirstOrDefault(x => x.Name == name);
    }
}

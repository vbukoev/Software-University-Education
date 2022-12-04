using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Entities;

namespace EasterRaces.Repositories
{
    public class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string name)
            => Models.FirstOrDefault(x => x.Model == name);
    }
}

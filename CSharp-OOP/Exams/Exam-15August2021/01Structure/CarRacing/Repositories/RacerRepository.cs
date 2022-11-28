using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> racers;

        public RacerRepository()
        {
            racers = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => racers.AsReadOnly();
        public void Add(IRacer model)
        {
            racers.Add(model);
        }

        public bool Remove(IRacer model)
         =>racers.Remove(model);


        public IRacer FindBy(string property)
            => racers.Find(x => x.Username == property);
    }
}

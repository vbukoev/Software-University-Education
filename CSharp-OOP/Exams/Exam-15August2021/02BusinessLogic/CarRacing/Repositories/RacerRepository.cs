using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

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
            if (model == null) throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            racers.Add(model);
        }

        public bool Remove(IRacer model)
         =>racers.Remove(model);


        public IRacer FindBy(string property)
            => racers.Find(x => x.Username == property);
    }
}

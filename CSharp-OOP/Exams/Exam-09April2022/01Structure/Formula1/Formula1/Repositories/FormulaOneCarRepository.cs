using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> cars;

        public FormulaOneCarRepository()
        {
            cars = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => cars.AsReadOnly();
        public void Add(IFormulaOneCar model)
        {
            cars.Add(model);
        }

        public bool Remove(IFormulaOneCar model)
            => cars.Remove(model);

        public IFormulaOneCar FindByName(string name)
            => cars.Find(x => x.Model == name);
    }
}

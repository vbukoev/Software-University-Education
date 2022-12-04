using System;
using System.Collections.Generic;
using System.Text;
using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;

namespace Gym.Repositories
{
    public class EquipmentRepository :IRepository<IEquipment>
    {
        private List<IEquipment> equipments;

        public EquipmentRepository()
        {
            equipments = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models => equipments.AsReadOnly();

        public void Add(IEquipment model)
        {
            equipments.Add(model);
        }

        public bool Remove(IEquipment model)
        => equipments.Remove(model);

        public IEquipment FindByType(string type)
            => equipments.Find(x => x.GetType().Name == type);
    }
}

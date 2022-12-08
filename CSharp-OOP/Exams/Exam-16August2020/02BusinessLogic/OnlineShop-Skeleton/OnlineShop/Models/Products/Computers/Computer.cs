using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public override decimal Price 
            => base.Price + components.Sum(x=>x.Price) + peripherals.Sum(x=>x.Price);

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();
        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public override double OverallPerformance
        {
            get
            {
                if (!components.Any()) return base.OverallPerformance;

                return base.OverallPerformance + components.Average(x=>x.OverallPerformance);
            }
        }

        public void AddComponent(IComponent component)
        {
            if (components.Any(x=>x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent, component.GetType().Name,
                    GetType().Name, Id));
            }
            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!components.Any(x=>x.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType,
                    GetType().Name, Id));
            }
            IComponent component = components.Find(x=>x.GetType().Name == componentType);
            components.Remove(component);

            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x=>x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, GetType().Name, Id));
            }
            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType,
                    GetType().Name, Id));
            }
            IPeripheral peripheral = peripherals.Find(x => x.GetType().Name == peripheralType);
            peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({components.Count}):");
            if (components.Any())
            {
                sb.AppendLine(string.Join(Environment.NewLine, components.Select(x => $"  {x}")));
            }

            sb.AppendLine(
                $" Peripherals ({peripherals.Count}); Average Overall Performance ({(peripherals.Count > 0 ? peripherals.Average(x => x.OverallPerformance) : 0):f2}):");

            if (peripherals.Any())
            {
                sb.Append(string.Join(Environment.NewLine, peripherals.Select(x => $"  {x}")));
            }

            return sb.ToString().TrimEnd();
        }
    }
}

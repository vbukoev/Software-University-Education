using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Components.ChildComponents;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Computers.ChildComputers;
using OnlineShop.Models.Products.Peripherals;
using OnlineShop.Models.Products.Peripherals.ChildPeripherals;
using IComponent = OnlineShop.Models.Products.Components.IComponent;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IPeripheral> peripherals;
        private List<IComponent> components;

        public Controller()
        {
            computers = new List<IComputer>(); 
            peripherals = new List<IPeripheral>();
            components = new List<IComponent>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x=>x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = null;

            if (computerType == "DesktopComputer") computer = new DesktopComputer(id, manufacturer, model, price); 

            else if (computerType == "Laptop") computer = new Laptop(id, manufacturer, model, price);
            
            else throw new ArgumentException(ExceptionMessages.InvalidComputerType);

            computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            IComputer computer = computers.Find(x=>x.Id== computerId);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            if (peripherals.Any(x=>x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = null;

            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);

            computer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);
            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = computers.Find(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);
            if (peripheral == null)
            {
                return string.Empty;
            }
            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            IComputer computer = computers.Find(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            if (components.Any(x=>x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = null;
            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            computer.AddComponent(component);
            components.Add(component);
            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = computers.Find(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComponent component = computer.RemoveComponent(componentType);
            components.Remove(component);
            if (component == null)
            {
                return string.Empty;
            }
            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string BuyComputer(int id)
        {
            IComputer computer = computers.Find(x => x.Id == id);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            computers.Remove(computer);
            if (computer == null)
            {
                return string.Empty;
            }
            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = computers.Where(x=>x.Price<=budget).OrderByDescending(x=>x.Price).FirstOrDefault();
            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = computers.Find(x => x.Id == id);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return computer.ToString();
        }
    }
}

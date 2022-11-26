using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronautRepository;
        private PlanetRepository planetRepository;
        private Mission mission;
        private HashSet<string> exploredPlanets;

        public Controller()
        {
            astronautRepository = new AstronautRepository();
            planetRepository = new PlanetRepository();
            mission = new Mission();
            exploredPlanets = new HashSet<string>();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == "Biologist") astronaut = new Biologist(astronautName);

            else if (type == "Geodesist") astronaut = new Geodesist(astronautName);

            else if (type == "Meteorologist") astronaut = new Meteorologist(astronautName);

            else throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);

            astronautRepository.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planetRepository.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronautRepository.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut,
                    astronautName));
            }
            astronautRepository.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planetRepository.FindByName(planetName);
            ICollection<IAstronaut> astronauts = astronautRepository.Models
                .Where(x=>x.Oxygen > 60)
                .ToArray();
            if (!astronauts.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            mission.Explore(planet, astronauts);
            exploredPlanets.Add(planetName);
            return string.Format(OutputMessages.PlanetExplored, planetName,
                astronauts.Where(x => !x.CanBreath).Count());
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets.Count} planets were explored!");
            sb.Append("Astronauts info:");
            foreach (IAstronaut astronaut in astronautRepository.Models)
            {
                sb.AppendLine();
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}"); 
                sb.Append($"Bag items: {(astronaut.Bag.Items.Any() ? string.Join(", ", astronaut.Bag.Items) : "none")}");
            }
            return  sb.ToString().TrimEnd();
        }
    }
}

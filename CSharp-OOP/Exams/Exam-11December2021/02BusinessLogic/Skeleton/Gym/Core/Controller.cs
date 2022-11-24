using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipmentRepository;
        private List<IGym> gyms;

        public Controller()
        {
            equipmentRepository = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddGym(string gymType, string gymName)//
        {
            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else throw new InvalidOperationException(ExceptionMessages.InvalidGymType);

            gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)//
        {
            IEquipment equipment1;
            if (equipmentType == "BoxingGloves")
            {
                equipment1 = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment1 = new Kettlebell();
            }
            else throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);

            equipmentRepository.Add(equipment1);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)//
        {
            IEquipment equipment = equipmentRepository.Models.FirstOrDefault(x => x.GetType().Name == equipmentType);
            IGym gym = gyms.Find(x => x.Name == gymName);
            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment,
                    equipmentType));
            }

            if (gym != null)
            {
                gym.AddEquipment(equipment);
                equipmentRepository.Remove(equipment);
            }

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)//
        {
            IAthlete athlete;
            IGym gym = gyms.Find(x => x.Name == gymName);

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
                if (gym.GetType().Name != "BoxingGym")
                {
                    return OutputMessages.InappropriateGym;
                }
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                if (gym.GetType().Name != "WeightliftingGym")
                {
                    return OutputMessages.InappropriateGym;
                }
            }
            else throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);

            gym.AddAthlete(athlete);
            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string TrainAthletes(string gymName)//
        {
            var gym = gyms.Find(x => x.Name == gymName);
            gym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.Find(x => x.Name == gymName);
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string Report()
            => string.Join(Environment.NewLine, gyms.Select(x => x.GymInfo()));
    }
}

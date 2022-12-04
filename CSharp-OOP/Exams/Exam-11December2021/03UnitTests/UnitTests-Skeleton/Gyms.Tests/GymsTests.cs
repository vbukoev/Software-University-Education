using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;

namespace Gyms.Tests
{
    public class GymsTests
    {
        private const string AthleteName = "Athlete";
        private const string GymName = "Gym";

        private const int GymSize = 2;
        private Athlete athlete;
        private Gym gym;

        [SetUp]
        public void SetUp()
        {
            athlete = new Athlete(AthleteName);
            gym = new Gym(GymName, GymSize);
            gym.AddAthlete(athlete);
        }

        [Test]
        public void AthleteConstructor()
        {
            Assert.True(athlete.FullName == AthleteName &&
                        !athlete.IsInjured);
        }

        [Test]
        public void GymConstructor()
        {
            gym = new Gym(GymName, GymSize);
            Assert.True(gym.Name == GymName &&
                        gym.Capacity == GymSize &&
                        gym.Count == 0);
        }

        [TestCase(null)]
        [TestCase("")]
        public void GymNameCannotBeNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => gym = new Gym(name, GymSize));
        }

        [Test]
        public void GymCapacityCannotBeNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() => gym = new Gym(GymName, -1));
        }

        [Test]
        public void AddAthleteCorrectlyIncreasesTheCount()
        {
            Assert.AreEqual( gym.Count, 1);
        }

        [Test]
        public void AddAthleteThrowsWhenThereIsANullGym()
        {
            var athlete = new Athlete("athlete");
            var athlete2 = new Athlete("athlete2");
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(()=>gym.AddAthlete(athlete2));
        }

        [Test]
        public void RemoveAthleteDecreasesCount()
        {
            gym.RemoveAthlete(AthleteName);
            Assert.AreEqual(gym.Count, 0);
        }

        [Test]
        public void RemoveAthleteThrowsWhenThereIsNotAAthlete()
        {
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("name"));
        }

        [Test]
        public void InjureAthleteThrowsWhenThereIsNoAthlete()
        {
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("name"));
        }

        [Test]
        public void InjureAthleteSetsTheBoolVariableInItToTrue()
        {
            Athlete athlete = gym.InjureAthlete(AthleteName);
            Assert.IsTrue(athlete.IsInjured && athlete.FullName == AthleteName);
        }

        [Test]
        public void ReportIsCorrect()
        {
            Athlete athlete2 = new Athlete("name");
            List<Athlete> athletes = new List<Athlete>();
            athletes.Add(this.athlete);
            athletes.Add(athlete2);
            gym.AddAthlete(athlete2);
            gym.InjureAthlete(athlete2.FullName);
            Assert.AreEqual($"Active athletes at {GymName}: {string.Join(", ", athletes.Where(x => !x.IsInjured).Select(x => x.FullName))}", gym.Report());
        }
    }
}

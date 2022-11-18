using System;
using System.Collections.Generic;
using System.Linq;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
        }
        [Test]
        public void TestConstructorInitializesEmptyCollectionOfWarrior()
        {
            Arena testArena = new Arena();
            List<Warrior> acList = testArena.Warriors.ToList();
            List<Warrior> exWarriors = new List<Warrior>();

            CollectionAssert.AreEqual(exWarriors, acList, "Arena ctor should initialize an empty collection for Warriors!");
        }

        [Test]
        public void TestCollectionGetter()
        {
            Warrior firstWarrior = new Warrior("Pesho", 30, 100);
            Warrior secondWarrior = new Warrior("Gosho", 35, 85);

            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            List<Warrior> acList = arena.Warriors.ToList();
            List<Warrior> expeList = new List<Warrior>()
            {
                firstWarrior, 
                secondWarrior
            };
            CollectionAssert.AreEqual(expeList, acList, "Warriors collection data should return correct data");
        }

        [Test]
        public void TestIfWarriorsCollectionIsEncapsulatedProperly()
        {
            string acType = typeof(Arena)
                .GetProperties()
                .First(x=>x.Name == "Warriors")
                .PropertyType
                .Name;
            string exType = typeof(IReadOnlyCollection<Warrior>).Name;

            Assert.AreEqual(exType, acType, "Property should be IReadOnlyCollection<Warrior>");
        }

        [Test]
        public void CountShouldReturnZeroOrEmpty()
        {
            int actCount = arena.Count;
            int exArenaCount = 0;

            Assert.AreEqual(exArenaCount, actCount, "Count should return zero when there are no enrolled Warriors!");
        }

        [Test]
        public void CountShouldReturnCorrectValueWhenThereAreEnrolledWarriors()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);

            arena.Enroll(warrior);
            int actualCount = arena.Count;
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, actualCount, "Count should return count of enrolled Warriors!");
        }

        [Test]
        public void EnrollShouldThrowAnExceptionWhenEnrollingTheExistingWarrior()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>
                {
                    arena.Enroll(warrior);
                }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void EnrollFightBetweenInExistingAttackerShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Invalid", "Pesho");
            }, "There is no fighter with name Invalid enrolled for the fights!");
        }
        [Test]
        public void EnrollFightBetweenInExistingDefenderShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Pesho", "Invalid");
            }, "There is no fighter with name Invalid enrolled for the fights!");
        }

        [Test]
        public void FightBetweenExistingWarriorsShouldSucceed()
        {
            Warrior warriorA = new Warrior("Pesho", 40, 100);
            Warrior warriorD = new Warrior("Gosho", 50, 100);

            arena.Enroll(warriorA);
            arena.Enroll(warriorD);

            arena.Fight("Pesho", "Gosho");


            int actualAttackerHp = warriorA.HP;
            int expectedAttackerHp = 100 - warriorD.Damage;

            int actualDefenderHp = warriorD.HP;
            int expectedDefenderHp = 100 - warriorA.Damage;

            Assert.AreEqual(expectedAttackerHp, actualAttackerHp, "Fight between existing warriors should decrease attacker HP!");

            Assert.AreEqual(expectedDefenderHp, actualDefenderHp, "Fight between existing warriors should decrease defender HP!");
        }
    }
}

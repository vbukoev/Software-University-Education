using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Weapon weapon;
            private Planet planet;

            [SetUp]
            public void SetUp()
            {
                weapon = new Weapon("Weapon", 250, 5);
                planet = new Planet("Name", 250);
            }

            [Test]
            public void ConstructorShouldSetTheCorrectNames()
            {
                Planet planet = new Planet("Name", 250);
                string expName = "Name";
                Assert.That(planet.Name, Is.EqualTo(expName));
            }

            [Test]
            public void ConstructorShouldThrowExceptionWhenInvalidName()
            {
                Assert.Throws<ArgumentException>(() => new Planet(null, 250));
            }

            [Test]
            public void ConstructorShouldThrowExceptionWhenInvalidBudget()
            {
                Assert.Throws<ArgumentException>(() => new Planet("Name", -1));
            }

            [Test]
            public void ConstructorShouldCreateCorrectCollectionOfWeapons()
            {
                Planet planet = new Planet("Name", 250);
                Assert.AreEqual(planet.Weapons.Count, 0);
            }

            [Test]
            public void ConstructorShouldCreateCorrectWeapons()
            {
                Weapon weapon = new Weapon("Weapon", 250, 5);
                Assert.AreEqual(weapon.Name, "Weapon");
                Assert.AreEqual(weapon.Price, 250);
                Assert.AreEqual(weapon.DestructionLevel, 5);
            }

            [Test]
            public void AddWeaponShouldAddWeaponToPlanetCollectionOfWeapons()
            {
                Planet planet = new Planet("Name", 250);
                Weapon weapon = new Weapon("Weapon", 250, 5);

                planet.AddWeapon(weapon);
                Assert.AreEqual(planet.Weapons.Count, 1);
            }

            [Test]
            public void AlreadyAddedAWeaponException()
            {
                Planet planet = new Planet("Name", 250);
                Weapon weapon = new Weapon("Weapon", 250, 5);

                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon));
            }

            [Test]
            public void DestructionLevelReturnsCorrectValue()
            {
                Planet planet = new Planet("Name", 80);
                Weapon weapon = new Weapon("Weapon", 30, 3);
                Weapon weapon2 = new Weapon("Weapon2", 20, 2);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(planet.MilitaryPowerRatio, 5);
            }

            [Test]
            public void ProfitIncreases()
            {
                Planet planet = new Planet("Name", 250);
                planet.Profit(22);

                Assert.AreEqual(planet.Budget, 272);
            }

            [Test]
            public void SpendBudgetDecreases()
            {
                Planet planet = new Planet("Name", 250);
                planet.SpendFunds(22);
                Assert.AreEqual(planet.Budget, 228);
            }

            [Test]
            public void BudgetCannotGoBelowZero()
            {
                Planet planet = new Planet("Name", 250);
                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(263));
            }

            [Test]
            public void WeaponIncreasesLevel()
            {
                Weapon weapon = new Weapon("Weapon", 15, 2);
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(weapon.DestructionLevel, 3);
            }

            [Test]
            public void NuclearWeaponWorksProperly()
            {
                Weapon weaponNuclear = new Weapon("Rocket", 1600, 11);
                Weapon gun = new Weapon("Gun", 20, 2);
                Assert.AreEqual(weaponNuclear.IsNuclear, true);
                Assert.AreEqual(gun.IsNuclear, false);
            }

            [Test]
            public void SellWeaponWorksProperly()
            {
                Planet planet = new Planet("Name", 1500);
                Weapon weapon = new Weapon("Weapon", 20, 2);
                Weapon weapon2 = new Weapon("Weapon2", 20, 3);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(planet.MilitaryPowerRatio, 5);

                planet.RemoveWeapon("Weapon");

                Assert.AreEqual(planet.MilitaryPowerRatio, 3);
                Assert.AreEqual(planet.Weapons.Count,1);
            }

            [Test]
            public void UpgradeWeapon()
            {
                Planet planet = new Planet("Name", 1500);
                Weapon weapon = new Weapon("Weapon", 20, 2);

                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Weapon");

                Assert.AreEqual(planet.MilitaryPowerRatio, 3);
            }

            [Test]
            public void WeaponDoesNotExist()
            {
                Planet planet = new Planet("Name", 1500);
                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("NotAddedWeapon"));
            }

            [Test]
            public void DestructOpponentThrowsExceptionIfTheOpponentIsSoStrong()
            {
                Planet planet = new Planet("Name", 1500);
                Planet planet2 = new Planet("Name2", 2000);
                Weapon weapon = new Weapon("Weapon", 20, 2);
                Weapon weapon2 = new Weapon("Weapon2", 30, 5);
                Weapon weapon3 = new Weapon("Weapon3", 20, 2);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon3);
                planet2.AddWeapon(weapon2);
                Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(planet2));
            }

            [Test]
            public void DestructOpponentWorksFine()
            {
                Planet planet = new Planet("Name", 1500);
                Planet planet2 = new Planet("Name2", 2000);
                Weapon weapon = new Weapon("Weapon", 20, 2);
                Weapon weapon2 = new Weapon("Weapon2", 30, 5);
                Weapon weapon3 = new Weapon("Weapon3", 20, 4);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                planet2.AddWeapon(weapon3);
                var expected = "Name2 is destructed!";

                Assert.AreEqual(planet.DestructOpponent(planet2), expected);
            }

            [Test]
            public void WeaponCannotHaveANegativePrice()
            {
                Assert.Throws<ArgumentException>(() => new Weapon("Weapon", -1, 2));
            }
        }
    }
}
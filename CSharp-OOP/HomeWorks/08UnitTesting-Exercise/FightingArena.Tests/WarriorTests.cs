namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDamage = 55;
            int expectedHp = 33;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHp);

           
            string actualName = warrior.Name;

            
            int actualDamage = warrior.Damage;

            
            int actualHp = warrior.HP;

            Assert.AreEqual(expectedName, actualName,
                "Constructor should initialize the Name of the Warrior!");
            Assert.AreEqual(expectedDamage, actualDamage,
                "Constructor should initialize the Damage of the Warrior!");
            Assert.AreEqual(expectedHp, actualHp,
                "Constructor should initialize the HP of the Warrior!");
        }

        [Test]
        public void TestNameGetter()
        {
            string expectedName = "Pesho";
            Warrior warrior = new Warrior(expectedName, 55, 33);

            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName,
                "Getter of the property Name should return the value of name!");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("           ")]
        public void TestNameSetterValidation(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 55, 55);
            }, "Name should not be empty or whitespace!");
        }

        [Test]
        public void TestDamageGetter()
        {
            int expectedDamage = 55;
            Warrior warrior = new Warrior("Pesho", expectedDamage, 33);

            int actualDamage = warrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage,
                "Getter of the property Damage should return the value of damage!");
        }

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestDamageSetterValidation(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", damage, 55);
            }, "Damage value should be positive!");
        }

        [Test]
        public void TestHPGetter()
        {
            int expectedHP = 55;
            Warrior warrior = new Warrior("Pesho", 33, expectedHP);

            int actualHP = warrior.HP;

            Assert.AreEqual(expectedHP, actualHP,
                "Getter of the property HP should return the value of hp!");
        }

        [TestCase(-5)]
        [TestCase(-1)]
        public void TestHPSetterValidation(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 55, hp);
            }, "HP should not be negative!");
        }

        [TestCase(0)] //edge case
        [TestCase(10)]
        [TestCase(25)]
        [TestCase(30)] //edge case
        public void AttackShouldThrowErrorWhenAttackingWarriorIsLow(int startHp)
        {
            Warrior warrior_a = new Warrior("Pesho", 70, startHp);

            Warrior warrior_d = new Warrior("Gosho", 55, 45);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior_a.Attack(warrior_d);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(0)] //edge case
        [TestCase(10)]
        [TestCase(25)]
        [TestCase(30)] //edge case
        public void AttackShouldThrowErrorWhenDefendingWarriorIsLow(int startHp)
        {
            Warrior warrior_a = new Warrior("Pesho", 45, 65);
            Warrior warrior_d = new Warrior("Gosho", 35, startHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior_a.Attack(warrior_d);
            }, "Enemy HP must be greater than 30 in order to attack him!");

        }

        [TestCase(50, 60)]
        [TestCase(50, 51)]
        public void AttackShouldThrowErrorWhenDefendingWarriorIsStronger(int attackerHp, int defenderDamage)
        {
            Warrior warrior_a = new Warrior("Pesho", 45, attackerHp);
            Warrior warrior_d = new Warrior("Gosho", defenderDamage, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior_a.Attack(warrior_d);
            }, "You are trying to attack too strong enemy");

        }

        [TestCase(70,50)]
        [TestCase(60, 55)]
        [TestCase(60, 60)]
        public void SuccessAttackShouldDecreaseAttackerHp(int attackerHp, int defenderDamage)
        {
            Warrior warriorA = new Warrior("Pesho", 50, attackerHp);
            Warrior warriorD = new Warrior("Gosho", defenderDamage, 55);

            warriorA.Attack(warriorD);

            int actualHp = warriorA.HP;
            int expectedHp = attackerHp - defenderDamage;

            Assert.AreEqual(expectedHp, actualHp, "Successful attack should decrease attacker HP!");
        }

        [TestCase(70, 40)]
        [TestCase(60, 55)]
        [TestCase(60, 59)]
        public void SuccessAttackShouldKillEnemyIfDamageIsOVerTheirHp(int attackerDamage, int defenderHp)
        {
            Warrior aWarrior = new Warrior("Pesho", attackerDamage, 100);
            Warrior dWarrior = new Warrior("Gosho", 40, defenderHp);

            aWarrior.Attack(dWarrior);

            int actualDefenderHp = dWarrior.HP;
            int expectedDefenderHp = 0;

            Assert.AreEqual(expectedDefenderHp, actualDefenderHp, "Attacking enemy with lower HP than attacker Damage should leave with zero HP");
        }

        [TestCase(50, 100)]
        [TestCase(50, 60)]
        [TestCase(50, 51)]
        [TestCase(50, 50)]
        public void SuccessAttackShoudDecreaseEnemyHPIfWeDoNotKillThem(int attackerDamage, int defenderHp)
        {
            //Arrange - the same
            Warrior aWarrior = new Warrior("Pesho", attackerDamage, 100);
            Warrior dWarrior = new Warrior("Gosho", 30, defenderHp);

            aWarrior.Attack(dWarrior);

            int actualDefenderHp = dWarrior.HP;
            int expectedDefenderHp = defenderHp - attackerDamage;

            Assert.AreEqual(expectedDefenderHp, actualDefenderHp, "Attacking enemy with lower HP than attacker Damage should leave with correct HP");
        }
    }
}
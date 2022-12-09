using System;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace Skeleton.Tests
{
    //                                 /
    //Dummy loses health if attacked \/
    //                                              / 
    //Dead Dummy throws an exception if attacked  \/ 
    //                         /
    //Dead Dummy can give XP \/
    //                            /   
    //Alive Dummy can't give XP \/
    [TestFixture]
    public class DummyTests
    {
        private const int INITIAL_AXE_ATTACK = 2;
        private const int INITIAL_AXE_DURABILITY = 10;

        private const int INITIAL_DUMMY_ALIVE_HEALTH = 10;
        private const int INITIAL_DUMMY_DEAD_HEALTH = 0;
        private const int INITIAL_DUMMY_EXPERIENCE = 5;
        private Axe axe;
        private Dummy dummy;
        private void Run_Setup(bool isAlive)
        {
            axe = new Axe(INITIAL_AXE_ATTACK, INITIAL_AXE_DURABILITY);
            if (isAlive)
                dummy = new Dummy(INITIAL_DUMMY_ALIVE_HEALTH, INITIAL_DUMMY_EXPERIENCE);
            else
                dummy = new Dummy(INITIAL_DUMMY_DEAD_HEALTH, INITIAL_DUMMY_EXPERIENCE);
        }

        [Test]
        public void Dummy_Looses_Health()
        {
            Run_Setup(isAlive: true);
            const int EXPECTED_DUMMY_HEALTH = INITIAL_DUMMY_ALIVE_HEALTH - INITIAL_AXE_ATTACK;
            axe.Attack(dummy);

            Assert.That(dummy.Health == EXPECTED_DUMMY_HEALTH, "Dummy doesn't loose health if attacked");
        }

        [Test]
        public void Dummy_Throws_An_Exception()
        {
            Run_Setup(isAlive:false);
            bool exception = false;
            try
            {
                axe.Attack(dummy);
            }
            catch (InvalidOperationException ioe)
            {
                exception = true;
            }
            Assert.IsTrue(exception, "Dead dummy doesn't throw an exception if attacked.");
        }

        [Test]
        public void Dead_Dummy_Can_Give_Xp()
        {
            Run_Setup(isAlive:false);
            int getXp = dummy.GiveExperience();
            Assert.That(getXp, Is.EqualTo(INITIAL_DUMMY_EXPERIENCE), "Dead dummy can't give experience.");
        }

        [Test]
        public void Alive_Dummy_Cannot_Give_Xp()
        {
            Run_Setup(isAlive: true);
            bool target = false;
            try
            {
                dummy.GiveExperience();
            }
            catch (InvalidOperationException)
            {
                target = true;
            }
            Assert.IsTrue(target,"Alive dummy able to give experience.");
        }

    }
}
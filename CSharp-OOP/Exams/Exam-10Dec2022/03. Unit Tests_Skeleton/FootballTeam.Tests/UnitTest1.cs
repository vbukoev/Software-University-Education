using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballPlayer player;
        private FootballPlayer player2;


        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer("name1", 10, "Midfielder");
            player2 = new FootballPlayer("name2", 11, "Midfielder");
        }

        [Test]
        public void TestTeamCtor()
        {
            var pl = new FootballTeam("Levksi", 22);

            Assert.That(pl.Name == "Levksi");
            Assert.That(pl.Capacity == 22);
        }

        [Test]
        public void TestTeamNamePropertyThrowsAE()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var team = new FootballTeam(null, 22);
            });
        }

        [Test]
        public void TestTeamNamePropertyEmptyThrowsAE()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var team = new FootballTeam("", 22);
            });
        }

        [Test]
        public void TestTeamCapacityPropertyThrowsAE()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var team = new FootballTeam("www", 4);
            });
        }

        [Test]
        public void TestTeamAddPlayerMethod()
        {
            var pl = new FootballTeam("Levksi", 22);

            var result = pl.AddNewPlayer(player);

            Assert.That(result == $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}");
        }

        [Test]
        public void NoMorePositionsAddMethodTest()
        {
            var pl = new FootballTeam("Levksi", 15);

            string result = null;

            for (int i = 0; i < 16; i++)
            {
                result = pl.AddNewPlayer(player);
            }

            Assert.That(result == $"No more positions available!");
        }

        [Test]
        public void TestTeamPickPlayerMethod()
        {
            var pl = new FootballTeam("Levksi", 22);

            pl.AddNewPlayer(player);
            pl.AddNewPlayer(player2);

            var result = pl.PickPlayer("name1");

            Assert.That(result == player);
        }

        [Test]
        public void TestTeamPickPlayerNotFoundMethod()
        {
            var pl = new FootballTeam("Levksi", 22);

            pl.AddNewPlayer(player);
            pl.AddNewPlayer(player2);

            var result = pl.PickPlayer("wwww");

            Assert.That(result == null);
        }

        [Test]
        public void TestTeamPlayerScore()
        {
            var pl = new FootballTeam("Levksi", 22);

            pl.AddNewPlayer(player);
            pl.AddNewPlayer(player2);

            var result = pl.PlayerScore(10);

            Assert.That(result == $"{player.Name} scored and now has {player.ScoredGoals} for this season!");
            Assert.That(player.ScoredGoals == 1);
        }

        [Test]
        public void TestTeamPlayers()
        {
            var pl = new FootballTeam("Levksi", 22);

            pl.AddNewPlayer(player);
            pl.AddNewPlayer(player2);

            Assert.That(pl.Players.Count == 2);
        }

        [Test]
        public void TestPlayerName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var pl = new FootballPlayer(null, 10, "Goalkeeper");
            });
        }

        [Test]
        public void TestPlayerNumber()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var pl = new FootballPlayer("nobody", 55, "Goalkeeper");
            });
        }

        [Test]
        public void TestPlayerPosition()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var pl = new FootballPlayer("nobody", 5, "noone");
            });
        }
    }
}
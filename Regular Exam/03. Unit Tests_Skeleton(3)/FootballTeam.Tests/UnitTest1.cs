using System;
using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class Tests
    {
        public FootballPlayer player;
        public FootballTeam team;

        private string name = "Ronaldo";
        private int playerNumber = 7;
        private string position = "Forward";

        private string teamName = "Man Utd";
        private int capacity = 15;

        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer(name, playerNumber, position);
            team = new FootballTeam(teamName, capacity);
        }

        [Test]
        public void Test_ConstructorName()
        {
            string expectedTeamName = "Man Utd";
            FootballTeam team = new FootballTeam(expectedTeamName, 16);

            string actualTeamName = team.Name;
            Assert.AreEqual(expectedTeamName, actualTeamName);
            //Assert.AreEqual(capacity, team.Capacity);
            //Assert.AreEqual(0, team.Players.Count);
        }

        [Test]
        public void Test_ConstructorCapacity()
        {
            int expectedCapacity = 16;
            FootballTeam team = new FootballTeam("Man Utd", expectedCapacity);

            int actualCapacity = team.Capacity;
            Assert.AreEqual(expectedCapacity, actualCapacity);
            //Assert.AreEqual(capacity, team.Capacity);
            //Assert.AreEqual(0, team.Players.Count);
        }

        [Test]
        public void Test_NameNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam(String.Empty, 16);
            });
        }
        [Test]
        public void Test_CapacityLowerThan15()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam("Barcelona", 4);
            });
        }

        [Test]
        public void Test_AddPlayer()
        {
            team.AddNewPlayer(player);
            Assert.AreEqual(1, team.Players.Count);
        }

        [Test]
        public void Test_AddPlayerWhenCapacityFull()
        {
            team = new FootballTeam("Man Utd", 15);
            team.AddNewPlayer(new FootballPlayer("Ronaldo", 7, "Forward"));
            team.AddNewPlayer(new FootballPlayer("Messi", 7, "Forward"));
            team.AddNewPlayer(new FootballPlayer("Di Maria", 7, "Forward"));
            team.AddNewPlayer(new FootballPlayer("Ronaldo", 7, "Forward"));
            team.AddNewPlayer(new FootballPlayer("Messi", 7, "Forward"));
            team.AddNewPlayer(new FootballPlayer("Di Maria", 7, "Forward"));
            team.AddNewPlayer(new FootballPlayer("Ronaldo", 7, "Forward"));
            team.AddNewPlayer(new FootballPlayer("Messi", 7, "Forward"));
            team.AddNewPlayer(new FootballPlayer("Di Maria", 7, "Forward"));
            team.AddNewPlayer(new FootballPlayer("Ronaldo", 7, "Forward"));
            team.AddNewPlayer(new FootballPlayer("Messi", 7, "Forward"));
            team.AddNewPlayer(new FootballPlayer("Di Maria", 7, "Forward"));
            team.AddNewPlayer(new FootballPlayer("Ronaldo", 7, "Forward"));
            team.AddNewPlayer(new FootballPlayer("Messi", 7, "Forward"));
            team.AddNewPlayer(new FootballPlayer("Di Maria", 7, "Forward"));

            string output = team.AddNewPlayer(new FootballPlayer("Ronaldo7", 7, "Forward"));
            string expected = "No more positions available!";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void Test_PickPlayer()
        {
            team.AddNewPlayer(player);
            string pickPlayer = "Ronaldo";
            team.PickPlayer(pickPlayer);
            Assert.AreEqual(player.Name, pickPlayer);
        }

        [Test]
        public void Test_PlayerScore()
        {
            team.AddNewPlayer(player);
            int sg = player.ScoredGoals;
            team.PlayerScore(7);
            Assert.AreEqual(sg+1, player.ScoredGoals);
        }

        [Test]
        public void Test_PlayerScoreOutput()
        {
           
            team.AddNewPlayer(new FootballPlayer("Ronaldo", 7, "Forward"));

            string expectedResult = $"{player.Name} scored and now has {player.ScoredGoals+1} for this season!";
            string actualResult = team.PlayerScore(7);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddingPlayerShouldIncreaseCount()
        {
            int expectedCount = 1;
            for (int i = 0; i < expectedCount; i++)
            {
                this.team.AddNewPlayer(new FootballPlayer("Ronaldo", 7, "Forward"));
            }

            int actualCount = team.Players.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }


        [Test]
        public void AddingPlayerShouldReturnCorrectTextWhenExisting()
        {
            
            team.AddNewPlayer(new FootballPlayer("Ronaldo", 7, "Forward"));

            string expectedResult = $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";
            string actualResult = team.AddNewPlayer(new FootballPlayer("Ronaldo", 7, "Forward"));

            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
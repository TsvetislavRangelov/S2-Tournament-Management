using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Business_Logic;

namespace Unit_Tests
{
    [TestClass]
   public class GameTest
    {
        [TestMethod]
        public void TestGetGames()
        {
            GameManager gm = new(new FakeGameData());

            Game[] games = gm.GetGames();

            Assert.AreEqual(4, games.Length);
        }
        [TestMethod]
        public void TestIsGameScored()
        {
            GameManager gm = new(new FakeGameData());

            bool result = gm.IsGameScored(gm.GetGames()[1].Id);

            Assert.AreEqual(false, result);
        }

        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void TestIsGameScoredInvalidId()
        {
            GameManager gm = new(new FakeGameData());

            bool result = gm.IsGameScored(55);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestFixByes()
        {
            //testing for only 1 game, but the same method applies to multiple games as well.
            GameManager gm = new(new FakeGameData());
            List<Game> games = gm.GetGames().ToList();

            games.Add(new Game(new User(0, "Bye", "123"), new User(8, "whatever", "123")));
            Game[] newGames = games.ToArray();
            gm.FixByes(newGames);
            Game fixedGame = newGames.Last();

            Assert.AreEqual(8, fixedGame.Winner.Id);
        }

        [TestMethod]
        public void TestFixByesEmptyArray()
        {
            GameManager gm = new(new FakeGameData());
            Game[] empty = Array.Empty<Game>();

            gm.FixByes(empty);

            Assert.AreEqual(0, empty.Length);
        }
    }
}

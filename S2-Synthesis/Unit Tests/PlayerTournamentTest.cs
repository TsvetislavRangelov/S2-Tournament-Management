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
   public class PlayerTournamentTest
    {
        [TestMethod]
        public void TestGetPlayersForTournament()
        {
            PlayerTournamentManager ptm = new(new FakePlayerTournamentData());

            List<User> players = ptm.GetPlayersForTournament(1).ToList();

            Assert.AreEqual(6, players.Count);
        }
        [TestMethod]
        public void TestExitTournament()
        {
            PlayerTournamentManager ptm = new(new FakePlayerTournamentData());

            ptm.ExitTournament(0, 2);

            Assert.AreEqual(2, ptm.GetPlayerCountForTournament(0)); 
        }

        [TestMethod]
        public void TestRegisterPlayerForTournament()
        {
            FakePlayerTournamentData src = new();
            PlayerTournamentManager ptm = new(src);
            User test = new(7, "whatever", "whatever");

            ptm.RegisterPlayerForTournament(0, test.Id);

            Assert.AreEqual(7, src.GetKeyValuePairs().Last().Value);
        }

        [TestMethod]
        public void TestGetPlayerCountForTournament()
        {
            FakePlayerTournamentData src = new();
            PlayerTournamentManager ptm = new(src);

            int count = ptm.GetPlayerCountForTournament(0);

            Assert.AreEqual(3, count);
        }
    }
}

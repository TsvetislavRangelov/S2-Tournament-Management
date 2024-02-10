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
   public class TournamentTest
    {
        [TestMethod]
        public void TestGetTournaments()
        {
            TournamentManager tm = new(new FakeTournamentData(), null);

            List <Tournament> list = tm.GetTournaments();

            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void TestCreateTournament()
        {
            TournamentManager tm = new(new FakeTournamentData(), null);

            Tournament test = new();
            tm.CreateTournament(test);

            Assert.AreEqual(3, tm.GetTournaments().Count);
        }

        [TestMethod]
        public void TestDeleteTournament()
        {
            TournamentManager tm = new(new FakeTournamentData(), null);

            tm.DeleteTournament(0);

            Assert.AreEqual(1, tm.GetTournaments()[0].Id);
        }

        [TestMethod]
        public void TestScheduleGamesForTournament() 
        {
            TournamentManager tm = new(new FakeTournamentData(), new FakePlayerTournamentData());
            Tournament test = tm.GetTournament(0);

            tm.ScheduleGamesForTournament(test.Id);

            // first 4 check the order, and the last 2 check rotation
            Assert.AreEqual(0, test.Games[0].Player1.Id);
            Assert.AreEqual(5, test.Games[0].Player2.Id);
            Assert.AreEqual(1, test.Games[1].Player1.Id);
            Assert.AreEqual(4, test.Games[1].Player2.Id);
            Assert.AreEqual(0, test.Games[3].Player1.Id);
            Assert.AreEqual(4, test.Games[3].Player2.Id);
        }
    }
}

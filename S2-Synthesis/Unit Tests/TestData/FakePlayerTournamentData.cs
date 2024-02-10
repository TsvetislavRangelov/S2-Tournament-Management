using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic;
using Interfaces;
using Models;

namespace Unit_Tests.TestData
{
    public class FakePlayerTournamentData : IPlayerTournamentData
    {
        //simulates many-to-many relationship of a mysql table
        //Can also be done by having 2 test classes which hold the arrays without key-value pairs
        private readonly User[] players;
        private readonly Tournament[] tournaments;
        private readonly List<KeyValuePair<int, int>> relationship;

        public FakePlayerTournamentData()
        {
            this.relationship = new()
            {
                new KeyValuePair<int, int>(0, 1),
                new KeyValuePair<int, int>(0, 2),
                new KeyValuePair<int, int>(0, 3)
            };
            this.players = new User[]
            {
                new User(0, "First", "123"),
                new User(1, "Second", "123"),
                new User(2, "Third", "123"),
                new User(3, "Fourth", "123"),
                new User(4, "Fifth", "123"),
                new User(5, "Sixth", "123")
            };
            this.tournaments = new Tournament[]
            {
                new Tournament(0, "Badminton", "whatever", DateTime.Now, DateTime.Now.AddDays(2), 5, 10, "here",
                Models.Enums.PlayingSystem.ROUND_ROBIN),
                new Tournament(1, "Badminton", "whatever", DateTime.Now, DateTime.Now.AddDays(2), 10, 20, "here",
                Models.Enums.PlayingSystem.ROUND_ROBIN)
            };
        }
        public List<KeyValuePair<int, int>> GetKeyValuePairs() => this.relationship;

        public User[] GetPlayersForTournament(int tID) => this.players;

        public void ExitTournament(int tID, int uID)
        {
            var pair = new KeyValuePair<int, int>(tID, uID);
            relationship.Remove(pair);
        }
        public void RegisterPlayerForTournament(int tID, int uID)
        {
            var pair = new KeyValuePair<int, int>(tID, uID);
            relationship.Add(pair);
        }
        public bool IsPlayerRegisteredForTournament(int tID, int uID)
        {
            foreach(var pair in this.relationship)
            {
                if (tID == pair.Key && uID == pair.Value) return true;
            }
            return false;
        }

        public int GetPlayerCountForTournament(int tID) => relationship.Count;

        public Tournament[] GetTournamentsForPlayer(int uID) => throw new NotImplementedException("method not implemented");
        
        

        
    }
}

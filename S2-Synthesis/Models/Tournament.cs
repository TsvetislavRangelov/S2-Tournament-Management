using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public string Location { get; set; }
        public PlayingSystem PlayingSystem { get; set; }
        public List<Game> Games { get; set; }
        public List<User> Players { get; set; }

        public Tournament()
        {

        }

        public Tournament(int id, string type, string description, DateTime startDate, DateTime endDate, int min, int max,
            string location, PlayingSystem playingSystem)
        {
            this.Id = id;
            this.Type = type;
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.MinPlayers = min;
            this.MaxPlayers = max;
            this.Location = location;
            this.PlayingSystem = playingSystem;
            this.Games = new();
            this.Players = new();
        }
    }
}

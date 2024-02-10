using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using MySql.Data.MySqlClient;
using Models.Enums;
using System.Data;
using Interfaces;

namespace Data_Access
{
    public class TournamentData : ITournamentData
    {
        private const string connString = "Server=studmysql01.fhict.local;Uid=dbi478554;Database=dbi478554;Pwd=12345;";

        public List<Tournament> GetTournaments()
        {
            List<Tournament> items = new List<Tournament>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "SELECT * FROM syn_tournaments;";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Tournament t = new Tournament();
                                t.Id = Int32.Parse(reader[0].ToString());
                                t.Type = reader[1].ToString();
                                t.Description = reader[2].ToString();
                                t.StartDate = DateTime.Parse(reader[3].ToString());
                                t.EndDate = DateTime.Parse(reader[4].ToString());
                                t.MinPlayers = Int32.Parse(reader[5].ToString());
                                t.MaxPlayers = Int32.Parse(reader[6].ToString());
                                t.Location = reader[7].ToString();
                                t.PlayingSystem = (PlayingSystem)Enum.Parse(typeof(PlayingSystem), reader[8].ToString());
                                items.Add(t);

                            }
                        }
                    }
                }
                catch(MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            return items;
        }

        public void CreateTournament(Tournament t)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "INSERT INTO syn_tournaments(Type, Description, StartDate, EndDate, MinPlayers, MaxPlayers, Location, PlayingSystem)" +
                        "VALUES(@Type, @Description, @StartDate, @EndDate, @MinPlayers, @MaxPlayers, @Location, @PlayingSystem);";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@Type", t.Type);
                        cmd.Parameters.AddWithValue("@Description", t.Description);
                        cmd.Parameters.AddWithValue("@StartDate", t.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", t.EndDate);
                        cmd.Parameters.AddWithValue("@MinPlayers", t.MinPlayers);
                        cmd.Parameters.AddWithValue("@MaxPlayers", t.MaxPlayers);
                        cmd.Parameters.AddWithValue("@Location", t.Location);
                        cmd.Parameters.AddWithValue("@PlayingSystem", t.PlayingSystem.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
                catch(MySqlException e)
                {
                    Console.WriteLine(e.Message);
                } 
            }
        }
        public int DeleteTournament(int tID)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "DELETE FROM syn_tournaments WHERE ID = @ID";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", tID);
                        if (cmd.ExecuteNonQuery() == 1) return 1;

                    }
                }
                catch(MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally { conn.Close(); }
               
            }
            return 0;
        }

        public void UpdateTournament(Tournament t)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "UPDATE syn_tournaments SET Type = @Type, Description = @Description, StartDate = @StartDate," +
                        " EndDate = @EndDate, MinPlayers = @MinPlayers, MaxPlayers = @MaxPlayers, Location = @Location, PlayingSystem = @PlayingSystem WHERE ID = @ID";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@Type", t.Type);
                        cmd.Parameters.AddWithValue("@Description", t.Description);
                        cmd.Parameters.AddWithValue("@StartDate", t.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", t.EndDate);
                        cmd.Parameters.AddWithValue("@MinPlayers", t.MinPlayers);
                        cmd.Parameters.AddWithValue("@MaxPlayers", t.MaxPlayers);
                        cmd.Parameters.AddWithValue("@Location", t.Location);
                        cmd.Parameters.AddWithValue("@PlayingSystem", t.PlayingSystem.ToString());
                        cmd.Parameters.AddWithValue("@ID", t.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch(MySqlException e)
                {
                    Console.WriteLine(e);
                }
                finally { conn.Close(); }
            }
        }

        public void ScheduleGamesForTournament(Game[] arr, int tID)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "INSERT INTO syn_games(TournamentID, Player1, Player2)" +
                        " VALUES(@TournamentID, @Player1, @Player2)";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {

                        cmd.Parameters.AddWithValue("@Player1", Int32.MinValue);
                        cmd.Parameters.AddWithValue("@Player2", Int32.MinValue);
                        cmd.Parameters.AddWithValue("@TournamentID", tID);
                        for (int i = 0; i < arr.Length; i++)
                        {
                            cmd.Parameters["@Player1"].Value = Int32.Parse(arr[i].Player1.Id.ToString());
                            cmd.Parameters["@Player2"].Value = Int32.Parse(arr[i].Player2.Id.ToString());

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch(MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally { conn.Close(); }
            }
        }
        public Game[] GetGamesForTournament(int tID)
        {
            List<Game> games = new();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "SELECT * FROM syn_games WHERE TournamentID = @TID";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@TID", tID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Game g = new Game();
                                g.Id = Int32.Parse(reader[0].ToString());
                                g.TournamentID = Int32.Parse(reader[1].ToString());
                                g.Player1.Id = Int32.Parse(reader[2].ToString());
                                g.Player2.Id = Int32.Parse(reader[3].ToString());
                                if (reader[4].GetType() != typeof(DBNull))
                                {
                                    g.Winner.Id = (int)reader[4];
                                }
                                if (reader[5].GetType() != typeof(DBNull))
                                {
                                    g.Player1Score = (int)reader[5];
                                }
                                if (reader[6].GetType() != typeof(DBNull))
                                {
                                    g.Player2Score = (int)reader[6];
                                }
                                games.Add(g);
                            }
                        }
                    }
                }
                catch(MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally { conn.Close(); }
            }
            return games.ToArray();
        }
    }
}

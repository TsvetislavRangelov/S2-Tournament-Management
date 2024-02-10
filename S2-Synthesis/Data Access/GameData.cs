using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using MySql.Data.MySqlClient;
using Interfaces;

namespace Data_Access
{
   public class GameData : IGameData
    {
        private readonly string connString = "Server=studmysql01.fhict.local;Uid=dbi478554;Database=dbi478554;Pwd=12345;";

        public void RegisterResultForGame(Game g)
        {
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "UPDATE syn_games SET Player1Score = @P1, Player2Score = @P2, Winner = @W WHERE ID = @ID; UPDATE syn_players SET Wins = @Wins WHERE ID = @PID;";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@P1", g.Player1Score);
                        cmd.Parameters.AddWithValue("@P2", g.Player2Score);
                        cmd.Parameters.AddWithValue("@W", g.Winner.Id);
                        cmd.Parameters.AddWithValue("@ID", g.Id);
                        cmd.Parameters.AddWithValue("@Wins", g.Winner.Wins);
                        cmd.Parameters.AddWithValue("@PID", g.Winner.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch(MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally { conn.Close(); }
            }
        }

        public Game[] GetGames()
        {
            List<Game> games = new();
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "SELECT * FROM syn_games";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Game g = new();
                                g.Id = Int32.Parse(reader[0].ToString());
                                g.TournamentID = Int32.Parse(reader[1].ToString());
                                g.Player1.Id = Int32.Parse(reader[2].ToString());
                                g.Player2.Id = Int32.Parse(reader[3].ToString());
                                if (reader[4] == typeof(DBNull)) g.Winner.Id = 0;
                                if (reader[5] == typeof(DBNull)) g.Player1Score = 0;
                                if (reader[6] == typeof(DBNull)) g.Player2Score = 0;
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

        public bool IsGameScored(int gID)
        {
            int scored;
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "SELECT Winner FROM syn_games " +
                        "WHERE ID = @ID";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", gID);
                        
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                scored = Int32.Parse(reader[0].ToString());
                                if (scored != 0) return true;
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
            return false;
        }

        public void FixByes(Game[] arr)
        {
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "UPDATE syn_games SET Winner = @Winner WHERE ID = @ID";
                    conn.Open();
                    using (MySqlCommand cmd = new(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@Winner", DBNull.Value);
                        cmd.Parameters.AddWithValue("@ID", Int32.MinValue);
                        for (int j = 0; j < arr.Length; j++)
                        {
                            if (arr[j].Winner != null)
                            {
                                cmd.Parameters["@Winner"].Value = Int32.Parse(arr[j].Winner.Id.ToString());
                            }
                            cmd.Parameters["@ID"].Value = Int32.Parse(arr[j].Id.ToString());
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

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Interfaces;
using Models.Enums;
using MySql.Data.MySqlClient;

namespace Data_Access
{
    public class PlayerTournamentData : IPlayerTournamentData
    {
        private string connString = "Server=studmysql01.fhict.local;Uid=dbi478554;Database=dbi478554;Pwd=12345;";

        public void RegisterPlayerForTournament(int tID, int uID)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "SET FOREIGN_KEY_CHECKS=0; INSERT INTO syn_tournaments_players(TournamentID, PlayerID) VALUES(@TID, @UID)";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@TID", tID);
                        cmd.Parameters.AddWithValue("@UID", uID);
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

        public void ExitTournament(int tID, int uID)
        {
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "DELETE FROM syn_tournaments_players WHERE TournamentID = @TID AND PlayerID = @UID";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@TID", tID);
                        cmd.Parameters.AddWithValue("@UID", uID);
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

        public bool IsPlayerRegisteredForTournament(int tID, int uID)
        {
            int count = 0;
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "SELECT COUNT(*) AS result FROM syn_tournaments_players WHERE PlayerID = @UID AND TournamentID = @TID";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@TID", tID);
                        cmd.Parameters.AddWithValue("@UID", uID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                count = Int32.Parse(reader["result"].ToString());

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
            return count is 1;
            
        }

        public User[] GetPlayersForTournament(int tID)
        {
            List<User> users = new();
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "SELECT p.* FROM syn_players AS p INNER JOIN syn_tournaments_players AS tp ON p.ID = tp.PlayerID" +
                        " INNER JOIN syn_tournaments AS t ON tp.TournamentID = t.ID WHERE t.ID = @tID";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@tID", tID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User p = new User();
                                p.Id = Int32.Parse(reader[0].ToString());
                                p.FirstName = reader[1].ToString();
                                p.LastName = reader[2].ToString();
                                p.Nationality = reader[3].ToString();
                                p.Password = reader[4].ToString();
                                p.Email = reader[5].ToString();
                                users.Add(p);

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
            return users.ToArray();
        }

        public int GetPlayerCountForTournament(int tID)
        {
            int count = 0;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "SELECT COUNT(p.ID) FROM syn_players AS p INNER JOIN syn_tournaments_players AS tp ON p.ID = tp.PlayerID" +
                        " INNER JOIN syn_tournaments AS t ON tp.TournamentID = t.ID WHERE t.ID = @tID";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@tID", tID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                count++;

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
            return count;
        }


        public Tournament[] GetTournamentsForPlayer(int uID)
        {
            List<Tournament> list = new();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "SELECT t.* FROM syn_tournaments AS t INNER JOIN syn_tournaments_players AS tp on t.ID = tp.TournamentID INNER JOIN syn_players AS u on tp.PlayerID = u.ID WHERE u.ID = @UID";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@UID", uID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Tournament t = new();
                                t.Id = Int32.Parse(reader[0].ToString());
                                t.Type = reader[1].ToString();
                                t.Description = reader[2].ToString();
                                t.StartDate = DateTime.Parse(reader[3].ToString());
                                t.EndDate = DateTime.Parse(reader[4].ToString());
                                t.MinPlayers = Int32.Parse(reader[5].ToString());
                                t.MaxPlayers = Int32.Parse(reader[6].ToString());
                                t.Location = reader[7].ToString();
                                t.PlayingSystem = (PlayingSystem)Enum.Parse(typeof(PlayingSystem), reader[8].ToString());
                                list.Add(t);
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
            return list.ToArray();
        }
    }
}

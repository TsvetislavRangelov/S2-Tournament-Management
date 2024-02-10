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
    public class UserData : IUserData
    {
        private readonly string connString = "Server=studmysql01.fhict.local;Uid=dbi478554;Database=dbi478554;Pwd=12345;";

        public void RegisterUser(User u)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "INSERT INTO syn_players (FirstName, LastName, Nationality, Password, Email) " +
                        "VALUES(@FirstName, @LastName, @Nationality, @Password, @Email)";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", u.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", u.LastName);
                        cmd.Parameters.AddWithValue("@Nationality", u.Nationality);
                        cmd.Parameters.AddWithValue("@Email", u.Email);
                        cmd.Parameters.AddWithValue("@Password", u.Password);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { conn.Close(); }
            }
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "SELECT * FROM syn_players;";
                    MySqlCommand cmd = new MySqlCommand(q, conn);
                    conn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            User u = new User();
                            u.Id = Convert.ToInt32(dr[0]);
                            u.FirstName = dr[1].ToString();
                            u.LastName = dr[2].ToString();
                            u.Nationality = dr[3].ToString();
                            u.Password = dr[4].ToString();
                            u.Email = dr[5].ToString();
                            u.Wins = Int32.Parse(dr[6].ToString());
                            users.Add(u);
                        }
                    }
                }
                catch (MySqlException e)
                {
                   Console.WriteLine(e.Message);
                }
                finally { conn.Close(); }
            }
            return users;
        }

    }
}

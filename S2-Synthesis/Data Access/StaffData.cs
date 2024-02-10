using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Interfaces;
using MySql.Data.MySqlClient;

namespace Data_Access
{
   public class StaffData : IStaffData
    {
        private readonly string connString = "Server=studmysql01.fhict.local;Uid=dbi478554;Database=dbi478554;Pwd=12345;";

        public Staff[] GetStaff()
        {
            List<Staff> items = new();
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    string q = "SELECT * FROM syn_staff";
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Staff s = new();
                                s.Id = Int32.Parse(reader[0].ToString());
                                s.Username = reader[1].ToString();
                                s.Password = reader[2].ToString();
                                items.Add(s);
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
            return items.ToArray();
        }
    }
}

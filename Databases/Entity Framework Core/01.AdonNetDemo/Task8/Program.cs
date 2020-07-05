using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Task8
{
    class Program
    {
        static void Main()
        {
            var miniIds = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            SqlConnection con = new SqlConnection(@"Server=localhost\SQLEXPRESS01;Database=MinionsDB;Trusted_Connection=True;");
            con.Open();
            using (con)
            {
                foreach (var Id in miniIds)
                {
                    var command1 = new SqlCommand(@"SELECT * FROM Minions WHERE Id=" + Id, con);
                    SqlDataReader reader1 = command1.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        string cName;
                        int cAge;
                        using (reader1)
                        {
                            reader1.Read();
                            cName = (string)reader1["Name"];
                            cAge = (int)reader1["Age"];                            
                        }
                        cAge++;
                        cName = cName.First().ToString().ToUpper() + cName.Substring(1);
                        command1 = new SqlCommand(@"UPDATE Minions SET Name='"+cName+"' , Age ="+cAge+" WHERE Id=" + Id, con);
                        command1.ExecuteNonQuery();
                    }
                }
                var command = new SqlCommand(@"SELECT * FROM Minions", con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            Console.Write((string)reader["Name"] + " ");
                            Console.WriteLine((int)reader["Age"]);
                        }
                    }
                }
            }
        }
    }
}

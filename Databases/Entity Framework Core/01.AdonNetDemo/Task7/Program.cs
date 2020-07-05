using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Task7
{
    class Program
    {
        static void Main()
        {
            SqlConnection con = new SqlConnection(@"Server=localhost\SQLEXPRESS01;Database=MinionsDB;Trusted_Connection=True;");
            con.Open();
            using (con)
            {
                var command = new SqlCommand("SELECT Name FROM Minions", con);
                var data = command.ExecuteReader();
                var miniNames = new List<string>();
                using (data)
                {
                    while (data.Read())
                    {
                        string name = (string)data["Name"];
                        miniNames.Add(name);
                    }
                }
                Console.WriteLine(string.Join(", ",miniNames));
                Console.WriteLine();

                while (miniNames.Count > 0)
                {
                    
                    Console.WriteLine(miniNames[0]);
                    miniNames.RemoveAt(0);
                    if (miniNames.Count > 0)
                    {
                        Console.WriteLine(miniNames[miniNames.Count-1]);
                        miniNames.RemoveAt(miniNames.Count - 1);
                    }
                }
            }
        }
    }
}

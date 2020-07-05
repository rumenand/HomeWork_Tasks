using System;
using Microsoft.Data.SqlClient;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            int villainId = int.Parse(Console.ReadLine());
            SqlConnection con = new SqlConnection(@"Server=localhost\SQLEXPRESS01;Database=MinionsDB;Trusted_Connection=True;");
            con.Open();
            using (con)
            {
                SqlCommand command = new SqlCommand(@"SELECT Name FROM Villains
                                                    WHERE Id = " + villainId, con);
                string vName =(string)command.ExecuteScalar();
                if (vName != null)
                {
                    Console.WriteLine("Villain {0}", vName);
                    command = new SqlCommand(@"SELECT m.Name,m.Age FROM Minions AS m
                                                    JOIN MinionsVillains AS mv ON m.Id = mv.MinionId
                                                    JOIN Villains AS v ON v.Id = mv.VillainId
                                                    WHERE v.Id = " + villainId, con);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        using (reader)
                        {
                            int counter = 1;
                            while (reader.Read())
                            {
                                string name = (string)reader["Name"];
                                int age = (int)reader["Age"];
                                Console.WriteLine("{0}. {1} - {2}", counter, name, age);
                                counter++;
                            }
                        }
                    }
                    else Console.WriteLine("no minions");
                }
                else
                {
                    Console.WriteLine("No villain with ID {0} exists in the database.", villainId);
                }
            }
        }
    }
}

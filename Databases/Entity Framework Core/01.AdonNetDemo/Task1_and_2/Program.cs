using System;
using Microsoft.Data.SqlClient;

namespace Task1_and_2
{
    class Program
    {
        static void Main()
        {
            SqlConnection con = new SqlConnection(@"Server=localhost\SQLEXPRESS01;Database=MinionsDB;Trusted_Connection=True;");
            con.Open();
            using (con)
            {
                SqlCommand command = new SqlCommand(@"SELECT * FROM(
                                            SELECT[Name], COUNT(*) AS[Count] FROM Villains AS v
                                            JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
                                            GROUP BY v.Name) AS z
                                            WHERE[Count] > 3
                                            ORDER BY[Count] DESC", con);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        int count = (int)reader["Count"];
                        Console.WriteLine("{0} - {1}", name, count);
                    }
                }
            }
        }
    }
}

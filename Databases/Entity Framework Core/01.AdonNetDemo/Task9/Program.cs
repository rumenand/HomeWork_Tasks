using System;
using Microsoft.Data.SqlClient;

namespace Task9
{
    class Program
    {
        static void Main()
        {
            var miniId = int.Parse(Console.ReadLine());
            SqlConnection con = new SqlConnection(@"Server=localhost\SQLEXPRESS01;Database=MinionsDB;Trusted_Connection=True;");
            con.Open();
            using (con)
            {
                var command = new SqlCommand(@"exec usp_GetOlder " + miniId, con);
                command.ExecuteNonQuery();
                command = new SqlCommand(@"SELECT * FROM Minions WHERE Id=" + miniId, con);
                SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                    reader.Read();
                    Console.WriteLine((string)reader["Name"]+" - "+(int)reader["Age"]+" years old");                        
                    }                
            }
        }
    }
}

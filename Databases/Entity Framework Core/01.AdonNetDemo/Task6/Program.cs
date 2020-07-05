using System;
using Microsoft.Data.SqlClient;

namespace Task6
{
    class Program
    {
        static void Main()
        {
            SqlConnection con = new SqlConnection(@"Server=localhost\SQLEXPRESS01;Database=MinionsDB;Trusted_Connection=True;");
            con.Open();
            using (con)
            {
                var vId = int.Parse(Console.ReadLine());
                var serMinions = GetCountOfServantMinions(vId,con);
                var villName = GetVNameFromId(vId, con);
                if (villName != null)
                {
                    DeleteVillFromTRTable(vId, con);
                    DeleteVillFromVTable(vId, con);
                    Console.WriteLine("{0} was deleted.",villName);
                    Console.WriteLine("{0} minions were released.",serMinions);
                }
                else Console.WriteLine("No such villain was found.");
            }
        }

        private static object GetVNameFromId(int vId, SqlConnection con)
        {
            SqlCommand command = new SqlCommand("SELECT Name FROM Villains WHERE Id=" + vId, con);
            var result = command.ExecuteScalar();
            return (result == null) ?null : (string)result;
        }

        private static void DeleteVillFromVTable(int vId, SqlConnection con)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Villains WHERE Id=" + vId, con);
            command.ExecuteNonQuery();
        }

        private static void DeleteVillFromTRTable(int vId, SqlConnection con)
        {
            SqlCommand command = new SqlCommand("DELETE FROM MinionsVillains WHERE VillainId=" + vId, con);
             command.ExecuteNonQuery();
        }

        private static int GetCountOfServantMinions(int vId, SqlConnection con)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM MinionsVillains WHERE VillainId="+vId, con);
            var result = command.ExecuteScalar();
            return (result == null) ? 0 : (int)result;
        }
    }
}

using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Task5
{
    class Program
    {
        static void Main()
        {

            var country = Console.ReadLine();
            SqlConnection con = new SqlConnection(@"Server=localhost\SQLEXPRESS01;Database=MinionsDB;Trusted_Connection=True;");
            con.Open();
            using (con)
            {
                int countryId = GetCountryIdFromName(country, con); 
                
                if (countryId !=0)
                {
                    var listTowns = GetTownsFromCountryId(countryId, con);                    
                    
                        foreach (var town in listTowns)
                        {
                            var command = new SqlCommand("UPDATE Towns SET Name = '" + town.Value.ToUpper() + "' WHERE Name = '" + town.Value + "' AND Id=" + town.Key, con);
                            command.ExecuteNonQuery();
                        }
                    listTowns = GetTownsFromCountryId(countryId, con);
                    Console.WriteLine("{0} town names were affected.",listTowns.Count);
                    Console.WriteLine("["+string.Join(", ",listTowns.Values)+"]");                    
                }
                else Console.WriteLine("No town names were affected.");
            }

            static Dictionary<int,string> GetTownsFromCountryId(int cId, SqlConnection con)
            { 
            
                var command = new SqlCommand("SELECT Id,Name FROM Towns WHERE Id = " + cId, con);
                var data = command.ExecuteReader();
                var listTowns = new Dictionary<int, string>();
                using (data)
                {
                    while (data.Read())
                    {
                        string name = (string)data["Name"];
                        int Id = (int)data["Id"];
                        listTowns.Add(Id, name);
                    }
                }
                return listTowns;
            }
        }

        private static int GetCountryIdFromName(string country, SqlConnection con)
        {
            SqlCommand command = new SqlCommand("SELECT Id FROM Countries WHERE Name = '" + country + "'", con);
            var result = command.ExecuteScalar();
            return (result == null) ?0:(int)result;
        }
    }
}

using System;
using Microsoft.Data.SqlClient;

namespace Task4
{
    class Program
    {
        static void Main()
        {
            var mInput = Console.ReadLine().Split("Minion: ");
            var mTokens = mInput[1].Split(" ");
            var mName = mTokens[0];
            var mAge = mTokens[1];
            var mTown = mTokens[2];

            var vInput = Console.ReadLine().Split("Villain: ");
            var vName = vInput[1];

            SqlConnection con = new SqlConnection(@"Server=localhost\SQLEXPRESS01;Database=MinionsDB;Trusted_Connection=True;");
            con.Open();
            using (con)
            {
                CreateIfNotExist(mTown,"Town", con);
                CreateIfNotExist(vName,"Villain", con);
                CreateMinion(mName, mAge, mTown,con);
                AddMinionToMaster(mName, vName,con);
            }
        }

        private static void AddMinionToMaster(string mName, string vName,SqlConnection con)
        {
            SqlCommand command = new SqlCommand(@"SELECT Id FROM Minions
                                                    WHERE Name = '" + mName + "'", con);
            int mId = (int)command.ExecuteScalar();
            command = new SqlCommand(@"SELECT Id FROM Villains 
                                                    WHERE Name = '" + vName + "'", con);
            int vId = (int)command.ExecuteScalar();
            command = new SqlCommand(@"INSERT INTO MinionsVillains(MinionId,VillainId) 
                                    VALUES('" + mId + "','" + vId + "')", con);
            command.ExecuteNonQuery();
            Console.WriteLine("Successfully added {0} to be minion of {1}.", mName, vName);
        }

        private static void CreateMinion(string mName, string mAge, string mTown,SqlConnection con)
        {
            SqlCommand command = new SqlCommand(@"SELECT Id FROM Towns
                                                    WHERE Name = '" + mTown + "'", con);
            int townId = (int)command.ExecuteScalar();
            command = new SqlCommand(@"INSERT INTO Minions(Name,Age,TownId) 
                                    VALUES('" + mName + "','"+mAge+"','"+townId+"')", con);
            command.ExecuteNonQuery();
        }
        static void CreateIfNotExist(string chValue, string type, SqlConnection con)
        {
            SqlCommand command = new SqlCommand("SELECT Name FROM "+type+"s WHERE Name = '" + chValue + "'", con);
            string check = (string)command.ExecuteScalar();
            if (check == null)
            {
                if (type == "Villain") command = new SqlCommand("INSERT INTO " + type + "s(Name,EvilnessFactor) VALUES('" + chValue + "','Evli')", con);
                else command = new SqlCommand("INSERT INTO "+type+"s(Name) VALUES('" + chValue + "')", con);
                command.ExecuteNonQuery();
                Console.WriteLine("{0} {1} was added to the database.", type, chValue);
            }
        }
    }
}

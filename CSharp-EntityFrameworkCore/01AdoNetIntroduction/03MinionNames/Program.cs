using System;
using System.Data.SqlClient;
using System.Text;
using _02VillianNames;

namespace _03MinionNames
{
    public class Program
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            sqlConnection.Open();
            string result = GetVillainNamesWithMinionsCount(sqlConnection);
            Console.WriteLine(result);
            sqlConnection.Close();
        }

        private static string GetVillainNamesWithMinionsCount(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();
            string query = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                            FROM Villains AS v 
                                            JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                        GROUP BY v.Id, v.Name 
                                          HAVING COUNT(mv.VillainId) > 3 
                                        ORDER BY COUNT(mv.VillainId)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                sb.AppendLine($"{reader["Name"]} - {reader["MinionsCount"]}");
            }

            return sb.ToString().TrimEnd();
        }

        private static string GetVillainWithMinions(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder output = new StringBuilder();
            string villainNameQuerry = @"SELECT [Name] FROM Villains WHERE Id = @VillainId";
            SqlCommand getVillainName = new SqlCommand(villainNameQuerry, sqlConnection);
            getVillainName.Parameters.AddWithValue("@VillainId", villainId);
            string villainName = (string)getVillainName.ExecuteScalar();
            if (villainName == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }

            output.AppendLine($"Villain: {villainName}");

            string minionsQuery = @"   SELECT [m].[Name],
                                              [m].[Age]
                                         FROM [Villains]
                                           AS [v]
                                    LEFT JOIN [MinionsVillains]
                                           AS [mv]
                                           ON [v].[Id] = [mv].VillainId
                                    LEFT JOIN [Minions]
                                           AS [m]
                                           ON [m].[Id] = [mv].[MinionId]
                                        WHERE [mv].[VillainId] = @VillainId
                                     ORDER BY [m].[Name]";
            SqlCommand getMinionsCommand = new SqlCommand(minionsQuery, sqlConnection);
            getMinionsCommand.Parameters.AddWithValue("@VillainId", villainId);

            using SqlDataReader minionsReader = getMinionsCommand.ExecuteReader();
            if (!minionsReader.HasRows)
            {
                output.AppendLine($"(no minions)");
            }
            else
            {
                int rowNum = 1;
                while (minionsReader.Read())
                {
                    output.AppendLine($"{rowNum}. {minionsReader["Name"]} {minionsReader["Age"]}");
                    rowNum++;
                }
            }

            return output.ToString().TrimEnd();
        }
    }
}

namespace _02VillianNames
{
    using System.Data.SqlClient;
    using System.Text;

    public class StartUp
    {
        /// Problem 02
        private static string GetVillainNamesWithMinionsCount(SqlConnection sqlConnection)
        {
            StringBuilder output = new StringBuilder();

            string query = @"    SELECT [v].[Name],
                                        COUNT([mv].[MinionId])
                                     AS [MinionsCount]
                                   FROM [Villains]
                                     AS [v]
                              LEFT JOIN [MinionsVillains]
                                     AS [mv]
                                     ON [v].[Id] = [mv].[VillainId]
                               GROUP BY [v].[Name]
                                 HAVING COUNT([mv].[MinionId]) > 3
                               ORDER BY [MinionsCount]";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                output
                    .AppendLine($"{reader["Name"]} - {reader["MinionsCount"]}");
            }

            return output.ToString().TrimEnd();
        }

        
    }
}

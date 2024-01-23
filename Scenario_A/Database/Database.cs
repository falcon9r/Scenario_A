using MySql.Data.MySqlClient;

namespace Scenario_A.Database
{
    public class Database
    {
        private readonly string queryString = "server=localhost;User ID=root;database=krautundrueben;password=";

        public bool ExecuteNonQuery(string query)
        {
            using(MySqlConnection connection = new MySqlConnection(queryString))
            {
                connection.Open();
                
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            return true;   
        }
    }
}

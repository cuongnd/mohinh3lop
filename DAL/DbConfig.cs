using System;
using MySql.Data.MySqlClient;
namespace DAL
{
    public class DbConfig
    {
        public static MySqlConnection connection = new MySqlConnection();

        public static MySqlConnection GetConnection()
        {
            try
            {
                string conString;
                using (System.IO.FileStream fileStream = System.IO.File.OpenRead("../DAL/DbConfig.txt"))
                {
                    
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                    {
                        conString = reader.ReadLine();
                    }
                }
                return GetConnection(conString);
            }
            catch(Exception error)
            {
                Console.WriteLine(error.Message);
                return null;
            }
        }
        public static MySqlConnection GetConnection(string connectionString)
        {
            connection.ConnectionString = connectionString;
            return connection;
        }

    }
}
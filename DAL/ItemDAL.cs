using System;
using Persistence;
using MySql.Data.MySqlClient;
namespace DAL
{
    public class ItemDAL
    {
        private static MySqlConnection connection = DbConfig.GetConnection();

        private string query = "";
        public Item GetItemById(int ItemdId)
        {
            if (connection == null)
            {
                Console.WriteLine("cannot connection db");
                return null;
            }
            Item item = null;
            try
            {
                connection.Open();
                query = @"select item_id,item_name,unit_price,amout,item_status,ifnull(item_description,'') as item_description from Items where item_id=@Itemid";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@itemId", ItemdId);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    item = GetItem(reader);
                }
                reader.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error:"+error.Message);
            }
            finally { connection.Close(); };
            return item;

        }

        internal Item GetItem(MySqlDataReader reader)
        {
            Item item = new Item();
            item.ItemId = reader.GetInt32("item_id");
            item.ItemName = reader.GetString("item_name");
            item.ItemPrice = reader.GetDecimal("unit_price");
            item.Amout = reader.GetInt32("amout");
            item.Status = reader.GetInt32("item_status");
            item.Description = reader.GetString("item_description");
            return item;
        }
    }
}
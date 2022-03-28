using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mimimetrrr
{
    public class DataBaseHelper
    {
        
        SQLiteConnection connection;
        public DataBaseHelper()
        {
            connection = new SQLiteConnection("Data Source='Catts.db'");
            connection.Open();
        }
        public List<Cat> GetsAllCats()
        {
            string sql = "SELECT ID, name, votes, filename FROM Catts";
            List<Cat> cats = new List<Cat>();

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Cat cat = new Cat((long)reader["ID"], (string)reader["name"], (int)reader["votes"], (string)reader["filename"]);
                        cats.Add(cat);
                    }
                }
            }
            return cats;
        }
        public void UpdateCat(Cat cat)
        {
            string sql = $"UPDATE Catts SET votes={cat.votes} WHERE ID={cat.ID}";
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }

        }
        public void Close()
        {
            connection.Close();
        }
    }
}

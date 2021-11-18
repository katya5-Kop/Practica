using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Практика
{
    class Global
    {
        string stringConnection = "server=localhost;user id=root;password=root;database=database_book";
        public string CheckConnection()
        {
            string answer = "";
            using (MySqlConnection connection = new MySqlConnection(stringConnection))
            {
                connection.Open();
                string SQL = "SELECT * FROM database_book.books;";
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                answer = cmd.ExecuteNonQuery().ToString();
            }
            return answer;
        }
    }
}

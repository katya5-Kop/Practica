using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace IPFunc
{
    class DataClass
    {
        MySqlConnectionStringBuilder ConnectrionStr;
        MySqlConnection connection;
        public void CreateStrConnection()
        {
            ConnectrionStr = new MySqlConnectionStringBuilder();
            ConnectrionStr.Server = "localhost";
            ConnectrionStr.Port = 3306;
            ConnectrionStr.UserID = "root";
            ConnectrionStr.Password = "root";
            ConnectrionStr.Database = "database_book";
            connection = new MySqlConnection(ConnectrionStr.ToString());
        }
        public void AddBook(string Title, string Author, string Genre, int Date, string Description)
        {
            string CommandText = $"INSERT INTO books (Title,Genre,Author,DateCreate,Description) VALUES ('{Title}','{Genre}','{Author}','{Date}','{Description}');";

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(CommandText, connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
            connection.Close();

        }

        public List<Book> ReadBook()
        {
            List<Book> books = new List<Book>();
            string cmdtxt = $"SELECT * FROM books;";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(cmdtxt, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        books.Add(new Book()
                        {
                            idbooks = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Genre = reader.GetString(2),
                            Author = reader.GetString(3),
                            DateCreate = reader.GetInt32(4),
                            Description = (reader.GetValue(5) == null) ? "Отсутствует " : reader.GetValue(5).ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            connection.Close();
            return books;

        }

        public void UpdBook(int Id, string newTitle, string newAuthor, string newGenre, int newDate, string newDescription)
        {
            string CommandText = $"UPDATE books SET Title = '{newTitle}', " +
                $"Genre = '{newGenre}', " +
                $"Author = '{newAuthor}', " +
                $"DateCreate = {newDate}, " +
                $"Description = '{newDescription}' WHERE idbooks = {Id};";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(CommandText, connection);
                command.ExecuteNonQuery();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            connection.Close();
        }

        public void DeldBook(int id)
        {
            string cmdtxt = $"DELETE FROM books WHERE idbooks = {id}";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(cmdtxt, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        public int Authorize(string login, string password)
        {
            string cmdtxt = $"SELECT * FROM user WHERE login='{login}' AND password='{password}'";
            int codeAuth = -1;
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(cmdtxt, connection);
                codeAuth = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            connection.Close();
            return codeAuth;
        }

        public List<Us> ReadUser()
        {
            List<Us> user = new List<Us>();
            string cmdtxt = $"SELECT * FROM user;";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(cmdtxt, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.Add(new Us()
                        {
                            idUser = reader.GetInt32(0),
                            login = reader.GetString(1),
                            password = reader.GetString(2),
                            FirstName = reader.GetString(3),

                        });
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            connection.Close();
            return user;

        }

        public void AddUser(string UserLogin, string UserPassword, string LastName, string FirstName)
        {
            string CommandText = $"INSERT INTO user (login,password,LastName,FirstName) VALUES ('{UserLogin}','{UserPassword}','{LastName}','{FirstName}');";

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(CommandText, connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            connection.Close();

        }

        public void UpdUser(int Id, string newLogin, string newPassword, string newLastName, string newFirstName)
        {
            string CommandText = $"UPDATE user SET login = '{newLogin}', " +
                $"password = '{newPassword}', " +
                $"LastName = '{newLastName}', " +
                $"FirstName = '{newFirstName}'  WHERE idUser = {Id};";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(CommandText, connection);
                command.ExecuteNonQuery();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            connection.Close();
        }

        public void DelUser(int id)
        {
            string cmdtxt = $"DELETE FROM user WHERE idUser = {id}";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(cmdtxt, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }
    }
}
    

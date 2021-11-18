using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data;
namespace Практика
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*     string StringConnection = "server=localhost;user id=root;password=root;database=database_book";
           
            MySqlConnection connection = new MySqlConnection(StringConnection);
            try
            {
               
                connection.Open();
                MessageBox.Show($"Произошла ошибка подключения к БД - {connection.State}");
            }
            catch (Exception error)
            {
                MessageBox.Show($"Произошла ошибка подключения к БД - {error.Message}");
                connection.Close();
            }*/
            Global global1 = new Global();

             if (!String.IsNullOrEmpty(global1.CheckConnection()))
             {
                 MessageBox.Show("Подключение прошло успешно");
             }
             else
             {
                 MessageBox.Show("Произошла ошибка подключения");

             }
        }
    }
}

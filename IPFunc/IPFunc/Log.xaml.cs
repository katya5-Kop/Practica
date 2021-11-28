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
using System.Windows.Shapes;

namespace IPFunc
{
    /// <summary>
    /// Логика взаимодействия для Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        DataClass db = new DataClass();
        public Log()
        {
            InitializeComponent();
            db.CreateStrConnection();
        }

        private void btnLoginUs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int answer = db.Authorize(tbLogin.Text, tbPass.Text);
                if (answer > 0)
                {
                    MessageBox.Show("Авторизация прошла успешно!");
                    MainWindow Main = new MainWindow();
                    Main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Авторизация не удалась");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoginGuest_Click_1(object sender, RoutedEventArgs e)
        {
            WindowGuest windowGuest = new WindowGuest();
            windowGuest.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User User = new User();
            User.Show();
        }

       
    }
}


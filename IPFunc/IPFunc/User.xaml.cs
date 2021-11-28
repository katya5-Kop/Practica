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
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        DataClass db = new DataClass();
        Us user = new Us();
        int idUser;
        public User()
        {
            InitializeComponent();
            db.CreateStrConnection();
            dgUser.ItemsSource = db.ReadUser();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            db.AddUser(tbUserLogin.Text, tbUserPass.Text, tbLastName.Text, tbFirstName.Text);
            dgUser.ItemsSource = db.ReadUser();
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            db.UpdUser(idUser, tbUserLogin.Text, tbUserPass.Text, tbLastName.Text, tbFirstName.Text);
            dgUser.ItemsSource = db.ReadUser();
        }

        private void btnDelate_Click_1(object sender, RoutedEventArgs e)
        {
            db.DelUser(idUser);
            dgUser.ItemsSource = db.ReadUser();
        }

        private void dgUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Us use = new Us();
            use = dgUser.SelectedItem as Us;
            if (use != null)
            {
                tbUserLogin.Text = use.login;
                tbUserPass.Text = use.password;
                tbLastName.Text = use.LastName;
                tbFirstName.Text = use.FirstName;
                idUser = use.idUser;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

       
    
    }
}

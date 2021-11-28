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

namespace IPFunc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataClass db = new DataClass();
        Book book = new Book();
        int idBook;

        public MainWindow()
        {
            InitializeComponent();
            db.CreateStrConnection();
            dgdbBook.ItemsSource = db.ReadBook();
        }

        private void btnAddBook_Click_1(object sender, RoutedEventArgs e)
        {
            db.AddBook(tbTitle.Text, tbAuthor.Text, tbGenre.Text, Convert.ToInt32(tbDateCreate.Text), tbDes.Text);
            dgdbBook.ItemsSource = db.ReadBook();
        }

        private void dgdbBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book book = new Book();
            book = dgdbBook.SelectedItem as Book;
            if (book != null)
            {
                tbTitle.Text = book.Title;
                tbAuthor.Text = book.Author;
                tbGenre.Text = book.Genre;
                tbDateCreate.Text = book.DateCreate.ToString();
                idBook = book.idbooks;
                tbDes.Text = book.Description;

            }
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            db.UpdBook(idBook, tbTitle.Text, tbGenre.Text, tbAuthor.Text, Convert.ToInt32(tbDateCreate.Text), tbDes.Text);
            dgdbBook.ItemsSource = db.ReadBook();
        }

        private void btnDelate_Click_1(object sender, RoutedEventArgs e)
        {
            db.DeldBook(idBook);
            dgdbBook.ItemsSource = db.ReadBook();

        }

      
    }
}

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
    /// Логика взаимодействия для WindowGuest.xaml
    /// </summary>
    public partial class WindowGuest : Window
    {
        DataClass db = new DataClass();
        public WindowGuest()
        {
            InitializeComponent();
            DataContext = db;
            db.CreateStrConnection();
            listBook.ItemsSource = db.ReadBook();
        }

        private void listBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book book = new Book();
            book = listBook.SelectedItem as Book;
            if (book != null)
            {
                lblTitle.Content = $"Название: {book.Title}";
                lblAuthor.Content = $"Автор: {book.Author}";
                lblDate.Content = $"Дата издания: { book.DateCreate}";
                rhDes.AppendText(book.Description);
            }
        }
    }
}
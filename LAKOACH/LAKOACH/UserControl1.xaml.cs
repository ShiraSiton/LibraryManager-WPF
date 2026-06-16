using LAKOACH.SHARAT;
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

namespace LAKOACH
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        PageUS pus;
        BooksList book;
        public UserControl1(BooksList book, PageUS pus)
        {
            InitializeComponent();
            this.pus = pus;
            this.book = book;
            this.DataContext = book;
            this.NameBook.Text = book.NameBook;
            this.CodeBook.Text = book.CodeBook.ToString();
            this.pic.Source = Images.GetImage(book.Imagb);
        }
    }
   
}

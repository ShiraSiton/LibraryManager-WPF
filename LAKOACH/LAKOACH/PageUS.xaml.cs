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
    /// Interaction logic for PageUS.xaml
    /// </summary>
    public partial class PageUS : Page
    {
        public PageUS()
        {
            InitializeComponent();
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<BooksList> booksLists = (await Global.proxy.GetListBooksListAsync()).ToList();//.Where(x=> x.NameBook.StartsWith(txtname.text));
            foreach (var p in booksLists)
            {
                sp1.Children.Add(new UserControl1(p, this));
            }

        }

      
    }
}

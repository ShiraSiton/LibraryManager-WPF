using SAFRANIT.SHARAT;
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

namespace SAFRANIT
{
    /// <summary>
    /// Interaction logic for Types2.xaml
    /// </summary>
    public partial class Types2 : Page
    {
        public Types2()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lstvTypesFORbook.ItemsSource = await Global.proxy.GetListTypesFORbookAsync();
            CodeBook.ItemsSource = await Global.proxy.GetListBooksListAsync();
            CodeBook.DisplayMemberPath = "NameBook";
            CodeBook.SelectedValuePath = "CodeBook";
            CodeKindOfBook.ItemsSource = await Global.proxy.GetListKindsOfBookAsync();
            CodeKindOfBook.DisplayMemberPath = "NameKindOfBook";
            CodeKindOfBook.SelectedValuePath = "CodeKindOfBook";

        }

        private void newCodeBook_Click(object sender, RoutedEventArgs e)
        {
            CodeBook.SelectedItem = null;
            CodeKindOfBook.SelectedItem = null;
        }

        private async void addCodeBook_Click(object sender, RoutedEventArgs e)
        {
            Global.currentTypesFORbook = new SHARAT.TypesFORbook() { CodeBook = (BooksList)CodeBook.SelectedItem, CodeKindOfBook = (KindsOfBook)CodeKindOfBook.SelectedItem };
            await Global.proxy.AddTypesFORbookAsync(Global.currentTypesFORbook);
            lstvTypesFORbook.ItemsSource = await Global.proxy.GetListTypesFORbookAsync();
        }
  
    }
}

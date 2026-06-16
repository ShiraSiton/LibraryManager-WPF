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
    /// Interaction logic for Kof2.xaml
    /// </summary>
    public partial class Kof2 : Page
    {
        public Kof2()
        {
            InitializeComponent();
        }

        private async void addKindOfBook_Click(object sender, RoutedEventArgs e)
        {
           Global.currentKindsOfBook = new SHARAT.KindsOfBook() { CodeKindOfBook= Convert.ToInt32(CodeKindOfBook.Text) , NameKindOfBook = NameKindOfBook.Text};
           await Global.proxy.AddKindsOfBookAsync(Global.currentKindsOfBook);
           lstvkindsof.ItemsSource = await Global.proxy.GetListKindsOfBookAsync();
        }
       

        private async void newKindOfBook_Click(object sender, RoutedEventArgs e)
        {
            int x = await Global.proxy.GetNextKeyKindsOfBookAsync();
            CodeKindOfBook.Text = x.ToString();
            NameKindOfBook.Text = "";
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lstvkindsof.ItemsSource = await Global.proxy.GetListKindsOfBookAsync() ;
        }
    }
}

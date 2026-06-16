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
using static System.Net.Mime.MediaTypeNames;

namespace SAFRANIT
{
    /// <summary>
    /// Interaction logic for BTB.xaml
    /// </summary>
    public partial class BTB : Page
    {
        public BTB()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CodeBook.ItemsSource = await Global.proxy.GetBooksListBySelectAsync("StatusBook", true.ToString());
            CodeBook.DisplayMemberPath = "NameBook";
            CodeBook.SelectedValuePath = "CodeBook";
            Copies.Text = "";
            lstvBTB.ItemsSource = await Global.proxy.GetBookToBorrowBySelectAsync("StatusToBorrow", true.ToString());
        }

        private async void b1_Click(object sender, RoutedEventArgs e)
        {
            BooksList b1= (BooksList)CodeBook.SelectedItem;
            List<BookToBorrow> lst =(await Global.proxy.GetBookToBorrowBySelectAsync("CodeBook",b1.CodeBook.ToString())).ToList();
            int num = lst.Count+1;
             
            for(int i=num; i<Convert.ToInt32(Copies.Text)+num;i++)
            {
                Global.currentBookToBorrow = new SHARAT.BookToBorrow() {CodeBook= ((BooksList)CodeBook.SelectedItem), CodeSidoory=i, StatusToBorrow=true };
                await Global.proxy.AddBookToBorrowAsync(Global.currentBookToBorrow);
                lstvBTB.ItemsSource = await Global.proxy.GetListBookToBorrowAsync();
            }
            Copies.Text = "";
        }
     
    }
}

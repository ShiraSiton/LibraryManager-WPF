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
    /// Interaction logic for BOR2.xaml
    /// </summary>
    public partial class BOR2 : Page
    {
        public BOR2()
        {
            InitializeComponent();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Global.currentClients = await Global.proxy.GetClientsByCodeAsync(IdClient.Text);
            wellcome.Text = " ברוכ.ה הבא.ה " + Global.currentClients.Fname;

            int amount = (await Global.proxy.GetListBorrowingExplaningAsync()).Where(x => x.CodeBorrow.IdClient.IdClient == Global.currentClients.IdClient && x.ReturningTime.Year == 2001).Count();//חישוב כמה ספרים יש כרגע אצל הלקוח הנוכחי
            Global.countbooks = (Global.currentClients.Children / 3 + 2) - amount;//חישוב כמה ספרים הלקוח יכול להשאיל לפי מספר הילדים


            Global.currentBorrowing = new SHARAT.Borrowing() { CodeBorrow = await Global.proxy.GetNextKeyBorrowingAsync(), IdClient = Global.currentClients, DateBorrow = DateTime.Today };
            await Global.proxy.AddBorrowimgAsync(Global.currentBorrowing);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<BookToBorrow> lst = (await Global.proxy.GetListBookToBorrowAsync()).ToList();
            List<BookToBorrow> btblist = lst.Where(x => x.StatusToBorrow == true).ToList();
            foreach (var p in btblist)
            {
                sp1.Children.Add(new UserControl2bor(p, this));
            }
        }
        public async void refresh()
        {
            sp1.Children.Clear();
            List<BookToBorrow> lst = (await Global.proxy.GetListBookToBorrowAsync()).ToList();
            List<BookToBorrow> btblist = lst.Where(x => x.StatusToBorrow == true).ToList();
            foreach (var p in btblist)
            {
                sp1.Children.Add(new UserControl2bor(p, this));
            }
        }
        private async void CodeBook_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CodeBook.Text != "")
            {
                List<BookToBorrow> lst = (await Global.proxy.GetListBookToBorrowAsync()).ToList();
                if (CodeSidoory.Text == "")
                {
                    List<BookToBorrow> btblist = lst.Where(x => x.StatusToBorrow == true && x.CodeBook.CodeBook == Convert.ToInt32(CodeBook.Text)).ToList();
                    sp1.Children.Clear();
                    foreach (var p in btblist)
                    {
                        sp1.Children.Add(new UserControl2bor(p, this));
                    }
                }
                else
                {
                    List<BookToBorrow> btblist = lst.Where(x => x.StatusToBorrow == true && x.CodeBook.CodeBook == Convert.ToInt32(CodeBook.Text) && x.CodeSidoory == Convert.ToInt32(CodeSidoory.Text)).ToList();
                    sp1.Children.Clear();
                    foreach (var p in btblist)
                    {
                        sp1.Children.Add(new UserControl2bor(p, this));
                    }
                }
            }
        }

        private async void CodeSidoory_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CodeSidoory.Text != "")
            {
                List<BookToBorrow> lst = (await Global.proxy.GetListBookToBorrowAsync()).ToList();
                if (CodeBook.Text == "")
                {
                    List<BookToBorrow> btblist = lst.Where(x => x.StatusToBorrow == true && x.CodeSidoory == Convert.ToInt32(CodeSidoory.Text)).ToList();
                    sp1.Children.Clear();
                    foreach (var p in btblist)
                    {
                        sp1.Children.Add(new UserControl2bor(p, this));
                    }
                }
                else
                {
                    List<BookToBorrow> btblist = lst.Where(x => x.StatusToBorrow == true && x.CodeSidoory == Convert.ToInt32(CodeSidoory.Text) && x.CodeBook.CodeBook == Convert.ToInt32(CodeBook.Text)).ToList();
                    sp1.Children.Clear();
                    foreach (var p in btblist)
                    {
                        sp1.Children.Add(new UserControl2bor(p, this));
                    }
                }
            }
          
        }
    }
}

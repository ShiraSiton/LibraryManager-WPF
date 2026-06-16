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
    /// Interaction logic for UserControl3ret.xaml
    /// </summary>
    public partial class UserControl3ret : UserControl
    {
        RET2 ret2;
        BorrowingExplaning be;
        public UserControl3ret(BorrowingExplaning be, RET2 ret2)
        {
            InitializeComponent();
            this.be = be;
            this.ret2 = ret2;
            this.DataContext = be;
            this.NameBook.Text = be.BookToBorrow1.CodeBook.NameBook;
            this.pic.Source = Images.GetImage(be.BookToBorrow1.CodeBook.Imagb);
        }

        private async void toret_Click(object sender, RoutedEventArgs e)
        {
            Global.currentBookToBorrow = be.BookToBorrow1;
            Global.currentBookToBorrow.StatusToBorrow = true;
            await Global.proxy.UpdateBookToBorrowAsync(Global.currentBookToBorrow);
            List<BorrowingExplaning> lst = (await Global.proxy.GetListBorrowingExplaningAsync()).ToList();
            List<BorrowingExplaning> belst = lst.Where(x => x.BookToBorrow1.CodeBook.CodeBook == Global.currentBookToBorrow.CodeBook.CodeBook && x.BookToBorrow1.CodeSidoory == Global.currentBookToBorrow.CodeSidoory && x.ReturningTime.Year == 2001).ToList();
            Global.currentBorrowingExplaning = belst.FirstOrDefault();
            Global.currentBorrowingExplaning.ReturningTime = DateTime.Today;
            await Global.proxy.UpdateBorrowingExplaningAsync(Global.currentBorrowingExplaning);
            MessageBoxResult result = MessageBox.Show("הספר הוחזר בהצלחה!", "שימו לב", MessageBoxButton.OK, MessageBoxImage.Information);
            ret2.refresh();
        }
    }
}

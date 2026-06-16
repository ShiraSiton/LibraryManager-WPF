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
    /// Interaction logic for UserControl2bor.xaml
    /// </summary>
    public partial class UserControl2bor : UserControl
    {
        BOR2 bor;
        BookToBorrow btb;
        public UserControl2bor(BookToBorrow btb, BOR2 bor)
        {
            InitializeComponent();
            this.btb = btb;
            this.bor = bor;
            this.DataContext = btb;
            this.NameBook.Text = btb.CodeBook.NameBook;
            this.CodeBook.Text = btb.CodeBook.CodeBook.ToString();
            this.pic.Source = Images.GetImage(btb.CodeBook.Imagb);
            this.CodeSidoory.Text = btb.CodeSidoory.ToString();
        }

        private async void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Global.currentBookToBorrow = btb;
            if (Global.countbooks > 0)
            {
                Global.countbooks--;
                Global.currentBookToBorrow.StatusToBorrow = false;
                await Global.proxy.UpdateBookToBorrowAsync(Global.currentBookToBorrow);
                Global.currentBorrowingExplaning = new SHARAT.BorrowingExplaning() { CodeBorrow = Global.currentBorrowing, BookToBorrow1 = Global.currentBookToBorrow, ReturningTime = DateTime.MinValue };
                await Global.proxy.AddBorrowingExplaningAsync(Global.currentBorrowingExplaning);
                MessageBoxResult result = MessageBox.Show("הספר הושאל בהצלחה!", "שימו לב", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("אליך להחזיר את ספרי הספריה שברשותך כדי להשאיל ספרים נוספים", "שימו לב", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void toborrow_Click(object sender, RoutedEventArgs e)
        {
            Global.currentBookToBorrow = btb;
            if (Global.countbooks > 0)
            {
                Global.countbooks--;
                Global.currentBookToBorrow.StatusToBorrow = false;
                await Global.proxy.UpdateBookToBorrowAsync(Global.currentBookToBorrow);
                Global.currentBorrowingExplaning = new SHARAT.BorrowingExplaning() { CodeBorrow = Global.currentBorrowing, BookToBorrow1 = Global.currentBookToBorrow, ReturningTime = DateTime.MinValue };
                await Global.proxy.AddBorrowingExplaningAsync(Global.currentBorrowingExplaning);
                MessageBoxResult result = MessageBox.Show("הספר הושאל בהצלחה!", "שימו לב", MessageBoxButton.OK, MessageBoxImage.Information);
                bor.refresh();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("אליך להחזיר את ספרי הספריה שברשותך כדי להשאיל ספרים נוספים", "שימו לב", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

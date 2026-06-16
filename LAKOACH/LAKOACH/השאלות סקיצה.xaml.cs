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
    /// Interaction logic for BOR.xaml
    /// </summary>
    public partial class BOR : Page
    {
        public BOR()
        {
            InitializeComponent();
        }

        private async void yes_Click(object sender, RoutedEventArgs e)
        {
            Global.currentClients = await Global.proxy.GetClientsByCodeAsync(IdClient.Text);
            wellcome.Text = Global.currentClients.Fname + " ברוכ.ה הבא.ה ";
        }

        private async void ok_Click(object sender, RoutedEventArgs e)
        {
            Global.currentBookToBorrow = await Global.proxy.GetBookToBorrowByCodeAsync(Convert.ToInt32(CodeBook.Text), Convert.ToInt32(CodeSidoory.Text));
            pic.Source = Images.GetImage(Global.currentBookToBorrow.CodeBook.Imagb);
        }

        private async void toborrow_Click(object sender, RoutedEventArgs e)
        {
            Global.currentBorrowing = new SHARAT.Borrowing() { CodeBorrow= await Global.proxy.GetNextKeyBorrowingAsync(),IdClient=Global.currentClients, DateBorrow= DateTime.Today };
            await Global.proxy.AddBorrowimgAsync(Global.currentBorrowing);
            Global.currentBorrowingExplaning = new SHARAT.BorrowingExplaning() { CodeBorrow = Global.currentBorrowing, BookToBorrow1 = Global.currentBookToBorrow, ReturningTime=DateTime.MinValue };
            await Global.proxy.AddBorrowingExplaningAsync(Global.currentBorrowingExplaning);
            welldone.Text = "הספר הושאל בהצלחה";
        }

        private void more_Click(object sender, RoutedEventArgs e)
        {
            CodeBook.Text = "";
            CodeSidoory.Text = "";
            welldone.Text = "";
            pic.Source = null;
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            CodeBook.Text = "";
            CodeSidoory.Text = "";
            welldone.Text = "";
            pic.Source = null;
            wellcome.Text = "";
            IdClient.Text = "";
        }
    }
}

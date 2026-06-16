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
    /// Interaction logic for RET.xaml
    /// </summary>
    public partial class RET : Page
    {
        public RET()
        {
            InitializeComponent();
            returnbook.IsEnabled=false;
        }
        private async void returnbook_Click(object sender, RoutedEventArgs e)
        {
            Global.currentBookToBorrow.StatusToBorrow = true;
            await Global.proxy.UpdateBookToBorrowAsync(Global.currentBookToBorrow);
            List<BorrowingExplaning> lst = (await Global.proxy.GetListBorrowingExplaningAsync()).ToList();
            List<BorrowingExplaning> belst = lst.Where(x => x.BookToBorrow1.CodeBook.CodeBook == Global.currentBookToBorrow.CodeBook.CodeBook && x.BookToBorrow1.CodeSidoory == Global.currentBookToBorrow.CodeSidoory && x.ReturningTime.Year == 2001).ToList();
            Global.currentBorrowingExplaning = belst.FirstOrDefault();
            Global.currentBorrowingExplaning.ReturningTime = DateTime.Today;
            await Global.proxy.UpdateBorrowingExplaningAsync(Global.currentBorrowingExplaning);
            welldone.Text = "הספר הוחזר בהצלחה";
        }

        private void more_Click(object sender, RoutedEventArgs e)
        {
            CodeSidoory.Text = "";
            CodeBook.Text = "";
            returnbook.IsEnabled = false;
            pic.Source = null;
        }

        private async void fine_Click(object sender, RoutedEventArgs e)
        {
            Global.currentBookToBorrow = await Global.proxy.GetBookToBorrowByCodeAsync(Convert.ToInt32(CodeBook.Text), Convert.ToInt32(CodeSidoory.Text));
            if (Global.currentBookToBorrow == null)
            {
                MessageBoxResult result = MessageBox.Show("הספר  הנל לא נמצא, בדוק אם הקלדת נכון", "שימו לב", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Global.currentBookToBorrow.StatusToBorrow == true)//כלומר הספר לא הושאל
                {
                    MessageBoxResult result = MessageBox.Show("הספר  הנל לא מושאל, בדוק אם הקלדת נכון", "שימו לב", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    pic.Source = Images.GetImage(Global.currentBookToBorrow.CodeBook.Imagb);
                    returnbook.IsEnabled = true;

                }
            }
          
        }
    }
}

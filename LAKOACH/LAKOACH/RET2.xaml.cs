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
    /// Interaction logic for RET2.xaml
    /// </summary>
    public partial class RET2 : Page
    {
        public RET2()
        {
            InitializeComponent();
        }

        private async void ok_Click(object sender, RoutedEventArgs e)
        {
          Global.currentClients = await Global.proxy.GetClientsByCodeAsync(IdClient.Text);
          wellcome.Text = " ברוכ.ה הבא.ה " + Global.currentClients.Fname ;
          List<BorrowingExplaning> lst =(await Global.proxy.GetListBorrowingExplaningAsync()).ToList();
          List<BorrowingExplaning> belst = lst.Where(x=> x.CodeBorrow.IdClient.IdClient == Global.currentClients.IdClient && x.ReturningTime.Year<2010).ToList();
            foreach (var p in belst)
            {
                sp1.Children.Add(new UserControl3ret(p, this));
            }
        }
        public async void refresh ()
        {
            sp1.Children.Clear();
            List<BorrowingExplaning> lst = (await Global.proxy.GetListBorrowingExplaningAsync()).ToList();
            List<BorrowingExplaning> belst = lst.Where(x => x.CodeBorrow.IdClient.IdClient == Global.currentClients.IdClient && x.ReturningTime.Year<2010).ToList();
            foreach (var p in belst)
            {
                sp1.Children.Add(new UserControl3ret(p, this));
            }
        }


       
    }
}

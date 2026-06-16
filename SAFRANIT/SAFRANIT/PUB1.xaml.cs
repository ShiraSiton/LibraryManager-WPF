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
    /// Interaction logic for PUB2.xaml
    /// </summary>
    public partial class PUB2 : Page
    {
        public PUB2()
        {
            InitializeComponent();
        }

        private async void newpublish_Click(object sender, RoutedEventArgs e)
        {
            int x = await Global.proxy.GetNextKeyPublishAsync();
            CodePublish.Text = x.ToString();
            NamePublish.Text = "";
        }

        private async void addpublish_Click(object sender, RoutedEventArgs e)
        {
            Global.currentPublish = new SHARAT.Publish() { CodePublish = Convert.ToInt32(CodePublish.Text), NamePublish = NamePublish.Text };
            await Global.proxy.AddPublishAsync(Global.currentPublish);
            lstvpublish.ItemsSource = await Global.proxy.GetListPublishAsync();
        }
    
    }
}

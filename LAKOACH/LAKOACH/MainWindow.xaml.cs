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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void us1_Click(object sender, RoutedEventArgs e)
        {
            myframe.Navigate(new PageUS());
        }

        private void ret_Click(object sender, RoutedEventArgs e)
        {
            myframe.Navigate(new RET());
        }

        private void bor_Click(object sender, RoutedEventArgs e)
        {
            myframe.Navigate(new BOR2());
        }

        private void ret2_Click(object sender, RoutedEventArgs e)
        {
            myframe.Navigate(new RET2());   
        }
    }
}

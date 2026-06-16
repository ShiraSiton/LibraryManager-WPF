using System;
using System.Collections;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void b1_Click(object sender, RoutedEventArgs e)
        {
            myframe.Navigate(new BOR());
        }
        private void s1_Click(object sender, RoutedEventArgs e)
        {
            myframe.Navigate(new S1());
        }
        private void t1_Click(object sender, RoutedEventArgs e)
        {
            myframe.Navigate(new BTB());
        }

        private void kindsof2_Click(object sender, RoutedEventArgs e)
        {
            myframe.Navigate(new Kof2());
        }

        private void pub2_Click(object sender, RoutedEventArgs e)
        {
            myframe.Navigate(new PUB2());
        }

        private void typesfor2_Click(object sender, RoutedEventArgs e)
        {
            myframe.Navigate(new Types2());
        }

        private void booklist2_Click(object sender, RoutedEventArgs e)
        {
            myframe.Navigate(new Blist2());
        }

        private void us1_Click(object sender, RoutedEventArgs e)
        {
            myframe.Navigate(new PageUS());
        }

        private void ret_Click(object sender, RoutedEventArgs e)
        {
            myframe.Navigate(new RET());
        }

        private void ret2_Click(object sender, RoutedEventArgs e)
        {
            myframe.Navigate(new RET2());
        }
    }
}

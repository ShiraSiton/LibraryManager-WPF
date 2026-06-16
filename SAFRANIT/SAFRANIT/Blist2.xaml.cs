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
using System.Xml.Linq;

namespace SAFRANIT
{
   
    public partial class Blist2 : Page
    {
        private string fileImg;
        public Blist2()
        {
            InitializeComponent();
        }

        private async void newbk_Click(object sender, RoutedEventArgs e)
        {
            int x = await Global.proxy.GetNextKeyBooksListAsync();
            CodeBook.Text = x.ToString();
            NameBook.Text = "";
            StatusBook.IsChecked = false;
            CodePublish.SelectedItem = null;
            pic.Source = null;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lstvblist.ItemsSource= await Global.proxy.GetListBooksListAsync();
            CodePublish.ItemsSource = await Global.proxy.GetListPublishAsync();
            CodePublish.SelectedValuePath = "CodePublish";
            CodePublish.DisplayMemberPath = "NamePublish";
        }

        private async void addbk_Click(object sender, RoutedEventArgs e)
        {                                                                                                                                                                           
            Global.currentBooksList = new SHARAT.BooksList() { CodeBook = Convert.ToInt32(CodeBook.Text), NameBook = NameBook.Text, Copies=0, CodePublish = (Publish) CodePublish.SelectedItem, StatusBook = StatusBook.IsChecked==true, Imagb = fileImg };
            Images.SendImage(Global.currentBooksList.Imagb);
            await Global.proxy.AddBooksListAsync (Global.currentBooksList);   
            lstvblist.ItemsSource = await Global.proxy.GetListBooksListAsync();
        }
     
        private async void upbk_Click(object sender, RoutedEventArgs e)
        {
            Global.currentBooksList = new SHARAT.BooksList() { CodeBook = Convert.ToInt32(CodeBook.Text), NameBook = NameBook.Text, Copies = 0, CodePublish = (Publish)CodePublish.SelectedItem, StatusBook = StatusBook.IsChecked==true, Imagb = fileImg };
            await Global.proxy.UpdateBooksListAsync(Global.currentBooksList);
            lstvblist.ItemsSource = await Global.proxy.GetListBooksListAsync();
        }
      
        private async void destalbk_Click(object sender, RoutedEventArgs e)
        {
            await Global.proxy.DeleteStatusBooksListAsync(Global.currentBooksList);
            lstvblist.ItemsSource = await Global.proxy.GetListBooksListAsync();
            StatusBook.IsChecked = false;
        }
  
      private void Fill(SHARAT.BooksList books)
        {
            CodeBook.Text = books.CodeBook.ToString();
            NameBook.Text = books.NameBook.ToString();
            CodePublish.SelectedValue = books.CodePublish.CodePublish;
            StatusBook.IsChecked = books.StatusBook;
            pic.Source = Images.GetImage(books.Imagb);


        }

        private void lstvblist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstvblist.SelectedIndex != -1) 
            {
                Global.currentBooksList = lstvblist.SelectedItem as SHARAT.BooksList;
                Fill(Global.currentBooksList);
            }
        }

        private void choosepicture_Click(object sender, RoutedEventArgs e)
        {
            fileImg = Images.UploadImage_Dlg();
            pic.Source = Images.GetImage(fileImg);
        }
       
    }
}

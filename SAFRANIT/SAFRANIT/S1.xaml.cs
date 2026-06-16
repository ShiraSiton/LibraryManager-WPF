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
    /// Interaction logic for S1.xaml
    /// </summary>
    public partial class S1 : Page
    {
        BDIKA bdika = new BDIKA();
        public S1()
        {
            InitializeComponent();
        }

        private void newclients_Click(object sender, RoutedEventArgs e)
        {
            IdClient.Text = "";
            Children.Text = "";
            Fone.Text = "";
            Fname.Text = "";
            Lname.Text = "";
        }

        private async void addclients_Click(object sender, RoutedEventArgs e)
        { if (Validation.GetHasError(IdClient) || Validation.GetHasError(Fname) || Validation.GetHasError(Lname) || Validation.GetHasError(Fone))
            {
                MessageBoxResult result = MessageBox.Show("שדה חובה", "שימו לב", MessageBoxButton.OK, MessageBoxImage.Error);
            }
               // MessageBox.Show("שדה חובה");
                
            else
            {
               Global.currentClients = new SHARAT.Clients() {IdClient=IdClient.Text, Children=Convert.ToInt32(Children.Text), Fone=Fone.Text, Fname=Fname.Text, Lname=Lname.Text};
               await Global.proxy.AddClientsAsync(Global.currentClients);
               lstvclients.ItemsSource = await Global.proxy.GetListClientsAsync(); 
            }
        }

        private async void upclients_Click(object sender, RoutedEventArgs e)
        {
            Global.currentClients = new SHARAT.Clients() { IdClient = IdClient.Text, Children = Convert.ToInt32(Children.Text), Fone = Fone.Text, Fname = Fname.Text, Lname = Lname.Text };
            await Global.proxy.UpdateClientsAsync(Global.currentClients);
            lstvclients.ItemsSource = await Global.proxy.GetListClientsAsync();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = bdika;
            lstvclients.ItemsSource = await Global.proxy.GetListClientsAsync();
            lstvsignup.ItemsSource = await Global.proxy.GetListSignUpAsync();
        }
        private void Fill (Clients cli)
        {
          IdClient.Text = cli.IdClient.ToString();
          Children.Text = cli.Children.ToString();
          Fone.Text = cli.Fone.ToString(); 
          Fname.Text = cli.Fname.ToString();
          Lname.Text = cli.Lname.ToString();  
        }

        private void lstvclients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstvclients.SelectedIndex != -1) 
            {
                Global.currentClients = lstvclients.SelectedItem as SHARAT.Clients;
                Fill(Global.currentClients);
            }
        }

        private async void addsignup_Click(object sender, RoutedEventArgs e)
        {
            Global.currentSignUp = new SHARAT.SignUp() { IdClient= Global.currentClients, SignDate= Convert.ToDateTime(SignDate.SelectedDate), EndSignTime = Convert.ToDateTime(EndSignTime.SelectedDate)};
            await Global.proxy.AddSignUpAsync(Global.currentSignUp);
            lstvsignup.ItemsSource = await Global.proxy.GetListSignUpAsync();
        }

         private void newsignup_Click(object sender, RoutedEventArgs e)
         {
         SignDate.SelectedDate   = DateTime.Today;
         EndSignTime.SelectedDate  = DateTime.Today.AddYears(1);
         }

        private async void upsignup_Click(object sender, RoutedEventArgs e)
        {if (Global.currentClients != null)
            {
                Global.currentSignUp = new SHARAT.SignUp() { IdClient = Global.currentClients, SignDate = Convert.ToDateTime(SignDate.SelectedDate), EndSignTime = Convert.ToDateTime(EndSignTime.SelectedDate) };
                await Global.proxy.UpdateSignUpAsync(Global.currentSignUp);
                lstvsignup.ItemsSource = await Global.proxy.GetListSignUpAsync();
            }
        }
        private void fill (SignUp su) 
        {
          SignDate.SelectedDate = su.SignDate;
          EndSignTime.SelectedDate = su.EndSignTime;  
        }

        private async void lstvsignup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstvsignup.SelectedIndex != -1)
            {
                Global.currentSignUp = lstvsignup.SelectedItem as SHARAT.SignUp;
                fill(Global.currentSignUp);
                Global.currentClients = await Global.proxy.GetClientsByCodeAsync(Convert.ToString(Global.currentSignUp.IdClient.IdClient));
                Fill(Global.currentClients);
            }
        }
    }
}


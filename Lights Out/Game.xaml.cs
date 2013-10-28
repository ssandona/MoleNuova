using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Lights_Out.ViewModel;

namespace Lights_Out
{
    ///CLASS: classe parziale che viene fusa con lo xaml parsato
    public partial class Game : PhoneApplicationPage
    {
        /// COSTRUTTORE
        public Game()
        {
            InitializeComponent();
        }

        /// METODO: durante il passaggio alla pagina con id x caricami i dati del livello con id x e setta il DataContext
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string liv = string.Empty;
            
            /// IF: riesco a prendere il livello sul quale sto navigando
            if (NavigationContext.QueryString.TryGetValue("id", out liv))
            {
                /// converti la stringa dell id del livello in intero
                int a = Convert.ToInt32(liv);

                /// crea un nuovo DataContext con il LivelloVM(id) per il binding
                this.DataContext = new LivelloVM(a);
            }

            /*if (e.NavigationMode == NavigationMode.Back)
                {
                    MessageBox.Show("Te piasaria");
            NavigationService.Navigate(new Uri("/PagLivelli.xaml?Refresh=true", UriKind.Relative));
              }*/
        }

        //Al click del back button chiedo se si è sicuri di uscire. Se si torno alla pagina dei livelli a cui applico un refresh
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (vittoria.IsOpen) { }
            else torna.IsOpen = true;
                
            
            /*MessageBoxResult m=MessageBox.Show("Sei sicuro?", "Esci dal livello", MessageBoxButton.OKCancel);
            if(m==MessageBoxResult.OK)
            {
                NavigationService.Navigate(new Uri("/PagLivelli.xaml?Refresh=true", UriKind.Relative));
            }
            else*/ 
            e.Cancel = true;
            
        }

        private void continua(object sender, RoutedEventArgs e)
        {
            torna.IsOpen = false;
        }


        /// METODO: invoca il movimento sul bottone selezionato
        private void Go(object sender, RoutedEventArgs e)
        {
            string c = ((Button)sender).Tag.ToString();
            int n = Convert.ToInt32(c);
            bool vitt=((LivelloVM)this.DataContext).Move(n);
            mole_sound.Play();
            if (vitt)
            {
                win_sound.Play();
                vittoria.IsOpen = true;
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PagLivelli.xaml?Refresh=true", UriKind.Relative));
        }

        private void next_level(object sender, RoutedEventArgs e)
        {
            string liv = id.Text;
            int next = Convert.ToInt32(liv) + 1;
            string uri;
            if(next<=20)
             uri = "/Game.xaml?id=" + next;
            else uri = "/MainPage.xaml";

            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }


    }
}
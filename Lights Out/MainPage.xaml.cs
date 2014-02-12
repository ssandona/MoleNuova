using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;
using System.Runtime.Serialization;
using PhoneApp1;
using Lights_Out.ViewModel;
using System.IO.IsolatedStorage;


namespace Lights_Out
{
    /// CLASS: classe parziale di inizio merged con il file xaml parsato
    public partial class MainPage : PhoneApplicationPage
    {
        private bool audio = false;
        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

        /// COSTRUTTORE
        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            bool ischecked = false;
            if (appSettings.Contains("audio"))ischecked = (bool)appSettings["audio"];
            AudioCheckBox.IsChecked = ischecked;
        }

        /// METODO: richiamato dal bottone inizia
        private void Inizia_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PagLivelli.xaml", UriKind.Relative));
        }

        /// METODO: richiamato dall bottone informazoni
        private void Informazioni_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/info.xaml", UriKind.Relative));
        }

        //Premendo il Back button chiedo se si è sicuri di uscire. Se si non torno alla pagina di prima ma esco dall'applicazione (cancello la storia delle pagine navigate)
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            while (NavigationService.CanGoBack)
            {
                NavigationService.RemoveBackEntry();
            }

        }

        private void Altro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/altro.xaml", UriKind.Relative));
        }

        private void Audio(object sender, RoutedEventArgs e)
        {
            if (!audio)
            {
                audio = true;
                if (appSettings.Contains("audio"))
                    {
                        appSettings.Remove("audio");
                        appSettings.Add("audio", true);
                    }
                else appSettings.Add("audio", true);
            }
            else {
                throw new Exception("Audio settato male");
            }
        }

        private void NoAudio(object sender, RoutedEventArgs e)
        {
            if (audio)
            {
                audio = false;
                if (appSettings.Contains("audio"))
                {
                    appSettings.Remove("audio");
                    appSettings.Add("audio", false);
                }
                else appSettings.Add("audio", false);
            }
            else
            {
                throw new Exception("Audio settato male");
            }
        }

       
    }

}
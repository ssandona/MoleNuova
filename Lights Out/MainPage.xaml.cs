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


namespace Lights_Out
{
    /// CLASS: classe parziale di inizio merged con il file xaml parsato
    public partial class MainPage : PhoneApplicationPage
    {
        /// COSTRUTTORE
        public MainPage()
        {
            InitializeComponent();
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
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
<<<<<<< HEAD
=======
using Lights_Out.ViewModel;
>>>>>>> Button game.xaml

namespace Lights_Out
{
    public partial class PagLivelli : PhoneApplicationPage
    {
        public PagLivelli()
        {
            InitializeComponent();
<<<<<<< HEAD
        }

        private void Inizia_livello(object sender, RoutedEventArgs e)
        {
            string liv = (string)((Button)sender).Content;
            string uri = "/Game.xaml?id=" + liv;
=======
            this.DataContext = new LivelliVM();
        }

        private void GoToGame(object sender, RoutedEventArgs e)
        {
            int liv = (int)((Button)sender).Content;
            string uri = "/Game.xaml?id=" + liv.ToString();
>>>>>>> Button game.xaml
            //Livelli.setActual(liv);
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
            //tutto sostituibile con ICommand
        }
    }
}
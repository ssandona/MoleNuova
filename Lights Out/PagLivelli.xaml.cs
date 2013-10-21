using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Lights_Out.ViewModel;

namespace Lights_Out
{
    public partial class PagLivelli : PhoneApplicationPage
    {
        public PagLivelli()
        {
            InitializeComponent();
            this.DataContext = new LivelliVM();
        }

        private void GoToGame(object sender, RoutedEventArgs e)
        {
            //string liv = (string)((Button)sender).Content;
            string uri = "/Game.xaml?id=" + ((LivelliVM)(this.DataContext)).Cod;
            //Livelli.setActual(liv);
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
            //tutto sostituibile con ICommand
        }
    }
}
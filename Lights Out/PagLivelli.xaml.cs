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
    /// CLASS classe parziale merged con il file xaml parsato
    public partial class PagLivelli : PhoneApplicationPage
    {

        /// COSTRUTTORE: setta il datacontext (dove è il this.datacontext?)
        public PagLivelli()
        {
            InitializeComponent();
            this.DataContext = App.livelliVM();
        }


        //Premendo il Back button voglio tornare alla main page e non nella pagina prima
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml?Refresh=true", UriKind.Relative));
        }

        


    }
}
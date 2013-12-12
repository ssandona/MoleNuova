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
                LivelloVM vm = (LivelloVM)this.DataContext;

                ///associo all'evento PlaySounds il play dei vari media elements
                vm.PlayMoleSound += (sender, ev) =>
                {
                    this.mole_sound.Play();
                };

                vm.PlayVittoriaSound += (sender, ev) =>
                {
                    this.win_sound.Play();
                };
            }

        }

        //Al click del back button chiedo se si è sicuri di uscire. Se si torno alla pagina dei livelli a cui applico un refresh
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (vittoria.IsOpen) { }
            else if (torna.IsOpen) { }
                else torna.IsOpen = true;

            e.Cancel = true;
            
        }

        private void continua(object sender, RoutedEventArgs e)
        {
            torna.IsOpen = false;
        }



        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PagLivelli.xaml?Refresh=true", UriKind.Relative));
        }



    }
}
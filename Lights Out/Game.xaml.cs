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
        }

        /// METODO: invoca il movimento sul bottone selezionato
        private void Go(object sender, RoutedEventArgs e)
        {
            string c = ((Button)sender).Tag.ToString();
            int n = Convert.ToInt32(c);
            ((LivelloVM)this.DataContext).Move(n);
        }
    }
}
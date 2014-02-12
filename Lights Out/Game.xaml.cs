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
using System.IO.IsolatedStorage;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;


namespace Lights_Out
{
    //CLASS: classe parziale che viene fusa con lo xaml parsato
    public partial class Game : PhoneApplicationPage
    {

        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

        // COSTRUTTORE
        public Game()
        {
            InitializeComponent();
        }



    private void PlaySound(string path)
    {
        if (!string.IsNullOrEmpty(path))
        {
            using (var stream = TitleContainer.OpenStream(path))
            {
                if (stream != null)
                {
                var effect = SoundEffect.FromStream(stream);
                FrameworkDispatcher.Update();
                effect.Play();
                }
            }
        }
    }

    static Stream popstream = TitleContainer.OpenStream("Sounds/pop.wav");
    static Stream winstream = TitleContainer.OpenStream("Sounds/win.wav");
    static SoundEffect pop = SoundEffect.FromStream(popstream);
    static SoundEffect win = SoundEffect.FromStream(winstream);
    static SoundEffectInstance popSound = pop.CreateInstance();
    static SoundEffectInstance winSound = win.CreateInstance();

        // METODO: durante il passaggio alla pagina con id x caricami i dati del livello con id x e setta il DataContext
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string liv = string.Empty;
            
            // IF: riesco a prendere il livello sul quale sto navigando
            if (NavigationContext.QueryString.TryGetValue("id", out liv))
            {
                // converti la stringa dell id del livello in intero
                int a = Convert.ToInt32(liv);

                // crea un nuovo DataContext con il LivelloVM(id) per il binding
                this.DataContext = new LivelloVM(a);
                LivelloVM vm = (LivelloVM)this.DataContext;
                bool audio = false;

                if (appSettings.Contains("audio"))
                {
                    audio = (bool)appSettings["audio"];
                }
                else
                {
                    appSettings.Add("audio", false);
                }

                //associo all'evento PlaySounds il play dei vari media elements
                vm.PlayMoleSound += (sender, ev) =>
                {
                    if (audio)
                    {
                        FrameworkDispatcher.Update();
                        popSound.Play();
                    }
                };

                vm.PlayVittoriaSound += (sender, ev) =>
                {
                    if (audio)
                    {
                        FrameworkDispatcher.Update();
                        winSound.Play();
                    }
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
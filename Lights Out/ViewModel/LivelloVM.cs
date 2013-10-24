using Lights_Out.Model;
using PhoneApp1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows;

namespace Lights_Out.ViewModel
{

    /// <summary>
    /// CLASS: classe ViewModel che gestisce il livello attuale, e le mosse effettuate
    /// </summary>
    public class LivelloVM: INotifyPropertyChanged{

        /// VAR: Lista delle celle del gioco
        private ObservableCollection<Cella> celle;
    
        /// VAR: Isolate storage per salvare/caricare
        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        
        /// VAR: Livello di riferimento
        private Livello livAttuale;

        /// VAR: Numero di mosse
        private int mosse;

        /*private Livello successivo;*/

        /// COSTRUTTORE: Prende il numero del livello
        public LivelloVM(int i)
        {


            celle = new ObservableCollection<Cella>();

            livAttuale = new Livello(i);

            /*successivo = new Livello(i+1);*/

            /// assegno alla lista, la lista del livello tramite getter
            celle = livAttuale.Scacchiera;

            /// mosse iniziali a 0
            mosse = 0;
        }

        /// GETTER: var celle
        public ObservableCollection<Cella> Celle {
            get {
                return celle;
            }
        }

        /// GETTER: var mosse
        public int Mosse
        {
            get
            {
                return mosse;
            }
        }

        /// GETTER: livelloattuale
        public Livello LivAttuale
        {
            get
            {
                return livAttuale;
            }
        }

        /// METODO: Aumenta il numero di mosse     
        public void addMossa(){

            /// aumenta la variabile mosse
            mosse++;

            /// avverte la grafica che mosse è cambiato
            RaisePropertyChanged("Mosse");
        }

        /// METODO: Chiama la Mossa(cellaselezionata) sulla cella && Controlla se il livello è completo && Salva best score
        public void Move(int CodCella)
        {
            /// muovo sulla cella selezionata
            this.livAttuale.Mossa(CodCella);
            
            /// aumenta il numero di mosse
            this.addMossa();

            /// se il livello attuale è completo
            if (livAttuale.Completo())
            {
                /// trasforma il best score corrente in stringa
                livAttuale.Best_Score = mosse.ToString();

                /// Aggiungo alle settings bestscore+id
                if (appSettings.Contains("bestscore" + livAttuale.Id))
                {
                    /// Rimuovi vecchio best score
                    appSettings.Remove("bestscore" + livAttuale.Id);
                }
                /// Aggiungi nuovo best score
                appSettings.Add("bestscore" + livAttuale.Id, livAttuale.Best_Score);

                /// Avverto vittoria DA MIGLIORARE
                MessageBox.Show("Ti ga vinto more!");
                

            }



        }

        /// METODO: Implementa interfaccia Notify    
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropName));
        }

    }

}
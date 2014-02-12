using Lights_Out.Model;
using PhoneApp1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;


namespace Lights_Out.ViewModel
{

    /// <summary>
    /// CLASS: classe ViewModel che gestisce la lista di livelli
    /// </summary>
    public class LivelliVM: INotifyPropertyChanged
    {
        /// VAR: lista di livelli
        private ObservableCollection<Livello> listaLiv;

        private ICommand goToGame;
        public ICommand GoToGame {
            get {
                return goToGame;
            }
        }

        /// COSTRUTTORE: carica dallo xml una lista di id e crea i livelli in base all'id
        public LivelliVM() {
           
            listaLiv = new ObservableCollection<Livello>();
            
            /// assegna una lista di id di livelli
            List<int> livelli = caricaLivelli();

            /// oer ogni id nella lista caricata, crea un livello nuovo ed assegnalo al campo 
            foreach (int id in livelli)
            {
                listaLiv.Add(new Livello(id));
            }
            goToGame = new DelegateCommand(_goToGame);
        }

        /// GETTER: listaLiv
        public ObservableCollection<Livello> ListaLiv {
            get {
                return listaLiv;
            }
        }

        public Livello getLivello(int id)
        {
            return listaLiv[id - 1];
        }

        public bool Avaiable(int num) {
            if (listaLiv[num - 1].isAvaiable())
                return true;
            else return false;
        }

        /// METODO: Carica i livelli dentro la lista
        public List<int> caricaLivelli()
        {
            /// apertura file livelli.xml
            XDocument doc = XDocument.Load("livelli.xml");

            /// creazione lista di interi
            List<int> lista = new List<int>();

            /// configurazione dei livelli
            string conf = ritornaLivelli(doc);

            /// togli tutti i spazi vuoti
            conf = conf.Trim();

            /// converti la configurazione da string in intero
            int c = Convert.ToInt32(conf);
            /// per ogni aggiungi l'id alla lista
            for (int i = 1; i < c+1; i++)
            {
                    lista.Add(i);
            }
            return lista;

        }

        public void _goToGame(object o) { 
            int liv=((Livello)o).Id;
            bool ris=this.Avaiable(liv);
            string uri;
            if (ris)
            {
                uri = "/Game.xaml?id=" + liv.ToString();

                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri(uri, UriKind.Relative));
            }
        
        }

        /// METODO: Per i figli di ogni tag livello dammi la proprieta id
        private string ritornaLivelli(XDocument doc)
        {
            var pos = from query in doc.Descendants("livello")
                      select query.Element("id").Value;
            return pos.Last();
        }

        /// METODO: Implementa interfaccia
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropName));
        }


    }

}
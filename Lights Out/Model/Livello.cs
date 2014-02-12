using Lights_Out.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;
using System.Xml.Linq;


namespace PhoneApp1
{

    /// CLASS: classe Model gestisce il modello di un livello 
    public class Livello: INotifyPropertyChanged
    {
        /// VAR: Collezione di celle AKA Scacchiera
        private ObservableCollection<Cella> celle;

        /// VAR: Isolated storage per caricare/salvare
        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

        /// VAR: variabile per il best score inizializzato a - se nuovo livello
        private string best_score;

        /// VAR: variabile per l'id del livello
        private int id;

        /// COSTRUTTORE: Prende il cod che è l'id del livello
        public Livello(int cod)
        {
            this.celle = new ObservableCollection<Cella>();

            this.id = cod;

            Loader loader = new Loader();

            List<bool> ce= loader.caricaLivello(cod);

            int i = 0;
            foreach (bool b in ce) { 
            celle.Add(new Cella(i,b));
            i++;   
            }
         if(appSettings.Contains("bestscore"+id))
                {
                    string content = appSettings["bestscore" + id].ToString();
                    best_score = content;
                }
                else best_score="-";
        }

        public void reset() {
            foreach (Cella c in celle)
                c.reset();
        }

        /// GETTER: ritorna celle (?)
        public ObservableCollection<Cella> Scacchiera{
            get {
                return celle;
            }
        }

        /// GETTER: ritorna id
        public int Id
        {
            get
            {
                return id;
            }
        }

        /// GETTER: ritorna best_score
        /// SETTER: setta il nuovo best score del livello
        public string Best_Score
        {
            get
            {
                return best_score;
            }
            set {
                /// se esiste già un best score imposta il piu grande tra l attuale e il vecchio
                if (!best_score.Equals("-"))
                {
                    int val = Convert.ToInt32(value);
                    int val2 = Convert.ToInt32(best_score);
                    if (val < val2)
                    {
                        best_score = value;
                        RaisePropertyChanged("Best_Score");
                    }
                }
                    /// altrimenti se si gioca per la prima volta viene assegnato il valore corrente 
                else { best_score = value;
                RaisePropertyChanged("Best_Score");
                }
            }

        }

        /// METODO: ritorna se un livello è sbloccato o bloccato guardando il precedente (?)
        public bool isAvaiable() {

            /// Controlla se il livello precedente è stato vinto
            int livelloprecedente = (Convert.ToInt32(id))-1;
                    
            /// Il primo livello e sempre accessibile   
            if (livelloprecedente == 0) { return true; }

            /// IF: il best score del livello precedente è settato (QUESTO è SEMPRE VERO O NO ?)
            if (appSettings.Contains("bestscore" + livelloprecedente))
              {
                    /// prendo il best score del livello precedente
                     string content = appSettings["bestscore" + livelloprecedente].ToString();
                
                    /// IF: non si è vinto il livello precedento ritorno bloccato
                     if (content == "-") 
                          return false; 
                    
                    /// ELSE: torno sbloccato
                     else 
                           return true;
                          }
            /// ELSE: ritorno bloccato
            else 
                return false;
                }

        /// METODO: ritorna la stringa del path del background in base se il livello è sbloccato o meno
        public string Avaiable {
            get {
                if (isAvaiable())
                    return "Images/unlocked_"+id+".png";
                else return "Images/locked_"+id+".png";
            }
        }


        /// METODO: che cambia stato alla scacchiera a seconda della selezione
        public void Mossa(int id) {
            
            ///PRIMA COLONNA
            if (id%5 == 0) 
            {
                /// ANGOLO ALTO SX
                if (id ==0)
                {
                    celle[1].changeState();                
                    celle[5].changeState();
                

                }
                   
                /// ANGOLO BASSO SX
                else if (id==20)
                {
                    celle[15].changeState();                 
                    celle[21].changeState();
                 
                }
                
                /// BORDO SX
                else
                {
                    celle[id + 1].changeState();                  
                    celle[id - 5].changeState();                 
                    celle[id + 5].changeState();
                
                }
            }
            /// ULTIMA COLONNA
            else if (id % 5 == 4) 
            {
                /// ANGOLO ALTO DX
                if (id==4)
                {
                    celle[3].changeState();               
                    celle[9].changeState();
                  
                }

                /// ANGOLO BASSO DX
                else if (id==24)
                {
                    celle[23].changeState();                
                    celle[19].changeState();
                 
                }
                /// BORDO DX
                else
                {
                    celle[id - 1].changeState();               
                    celle[id - 5].changeState();                 
                    celle[id + 5].changeState();
                   
                }
            }
            /// BORDO ALTO
            else if (id < 5)
            {
                celle[id - 1].changeState();              
                celle[id + 1].changeState();              
                celle[id + 5].changeState();
              
            }
            /// BORDO BASSO
            else if(id>19){
                celle[id - 1].changeState();              
                celle[id + 1].changeState();         
                celle[id - 5].changeState();
              
            }
            /// CASO GENERICO CENTRALE
            else {
                celle[id - 1].changeState(); 
                celle[id + 1].changeState();            
                celle[id - 5].changeState();            
                celle[id + 5].changeState();
           
            }
            /// Cambio stato cella selezionata
            celle[id].changeState();
                     
        }

        /// METODO: controlla le celle AKA scacchiera per la vittoria ritorna bool a seconda della vittoria
        public bool Completo() {
            foreach (Cella c in celle) {
                if (c.Stato)
                    return false;
            }
            return true;
        }

<<<<<<< HEAD
        /// METODO: carica il livello con id corrispondente e ritorna una lista di configurazione booleana
        public List<bool> caricaLivello(int id)
        {
            /// id compreso tra 1 e 20
            if (id < 0 || id > 20) 
                throw new Exception("Livello Inesistente!");
            
            /// apertura file livelli.xml
            XDocument doc = XDocument.Load("livelli.xml");
            
            /// lista di booleani per la scacchiera
            List<bool> lista = new List<bool>();

            /// creazione della stringa id da cercare
            string livello = "" + id;

            /// prendo la configurazione del livello
            string conf = ritornaConf(livello, doc);
            
            /// pulisco il risultato
            conf = conf.Trim();

            /// PARSING della configurazione da stringa di 1001011 a lista di booleani
            for (int i = 0; i < conf.Length; i++)
            {
                if (conf[i] == '1')
                    lista.Add(true);
                else lista.Add(false);
            }
            return lista;
            
        }

        /// METODO: ritorna la configurazione del livello come una stringa di 110110 
        private string ritornaConf(string livello, XDocument doc)
        {
            /// prendi dal livello con id tale la configurazione
            var pos = from query in doc.Descendants("livello")
                      where query.Element("id").Value == livello
                      select query.Element("configurazione").Value;

            return pos.First();
        }
=======
>>>>>>> 1006c035a4ab032033847300e31c8f34d655ec3b

        /// METODO : implementazione interfaccia Nofity
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropName));
        }



    }
}
using Lights_Out.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;


namespace PhoneApp1
{
    [DataContract] 
    public class Livello: INotifyPropertyChanged
    {
      private ObservableCollection<Cella> celle;


        //variabile per il best score del livello, se diverso da 0 significa che il livello è passato 
        private string best_score;
        private int id;
        private bool avaiable;


        /// <summary>
        /// Costruisce una scacchiera 5x5. Se una luce è accesa allora è true, false altrimenti.
        ///Si vince quando tutte le luci sono spente.
        /// </summary>
        /// <param name="livello">numero del livello, va da 0 a 25</param>
        
        
        public Livello(int cod)
        {
            celle = new ObservableCollection<Cella>();
            best_score = "-";
            id = cod;
            if (cod != 1)
                avaiable = false;
            else avaiable = true;
            //mosse = 0; all'inizio
            //best_score = serializzazione in base a come era prima 
            //scacchiera = new bool[5, 5];
            //Inizializzo tutte le luci come accese
            List<bool> ce = caricaLivello(cod);
            int i = 0;
            foreach (bool b in ce) { 
            celle.Add(new Cella(i,b));
            i++;
            }
         

        }


        public ObservableCollection<Cella> Scacchiera{
            get {
                return celle;
            }
        }



        public string Best_Score
        {
            get
            {
                return best_score;
            }
            set {
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
                else { best_score = value;
                RaisePropertyChanged("Best_Score");
                }
            }

        }

        public bool Avaiable {
            get {
                return (avaiable);
            }
            set {
                if (value != avaiable)
                    avaiable = value;
            }
        }

       
        public int Id
        {
            get
            {
                return id;
            }
        }

        public List<int> Mossa(int id) {
            List<int> modify = new List<int>();
            if (id%5 == 0) //prima colonna
            {
                if (id ==0)
                {
                    celle[1].Stato = true;
                    modify.Add(1);
                    celle[5].Stato = true;
                    modify.Add(5);

                }
                else if (id==20)
                {
                    celle[15].Stato = true;
                    modify.Add(15);
                    celle[21].Stato = true;
                    modify.Add(21);
                }
                else
                {
                    celle[id+1].Stato = true;
                    modify.Add(id+1);
                    celle[id-5].Stato = true;
                    modify.Add(id-5);
                    celle[id+5].Stato = true;
                    modify.Add(id+5);
                }
            }
            else if (id % 5 == 4) //ultima colonna
            {
                if (id==4)
                {
                    celle[3].Stato = true;
                    modify.Add(3);
                    celle[9].Stato = true;
                    modify.Add(9);
                }
                else if (id==24)
                {
                    celle[23].Stato = true;
                    modify.Add(23);
                    celle[19].Stato = true;
                    modify.Add(19);
                }
                else
                {
                    celle[id-1].Stato = true;
                    modify.Add(id-1);
                    celle[id-5].Stato = true;
                    modify.Add(id-5);
                    celle[id+5].Stato = true;
                    modify.Add(id+5);
                }
            }
            else if (id < 5)
            {
                celle[id-1].Stato = true;
                modify.Add(id-1);
                celle[id+1].Stato = true;
                modify.Add(id+1);
                celle[id+5].Stato = true;
                modify.Add(id+5);
            }
            else if(id>19){ 
                celle[id-1].Stato = true;
                modify.Add(id - 1);
                celle[id+1].Stato = true;
                modify.Add(id + 1);
                celle[id-5].Stato = true;
                modify.Add(id - 5);
            }
            else {
                celle[id - 1].Stato = true;
                modify.Add(id-1);
                celle[id + 1].Stato = true;
                modify.Add(id+1);
                celle[id - 5].Stato = true;
                modify.Add(id-5);
                celle[id+5].Stato = true;
                modify.Add(id+5);
            
            }
            celle[id].Stato = true;
            modify.Add(id);
            return modify;                
        }

        public bool Completo() {
            foreach (Cella c in celle) {
                if (c.Stato == true)
                    return false;
            }
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropName));
        }

        public List<bool> caricaLivello(int id)
        {
            if (id < 0 || id > 24) throw new Exception("Livello Inesistente!");
            XDocument doc = XDocument.Load("livelli.xml");
            List<bool> lista = new List<bool>();
            string livello = "" + id;
            string conf = ritornaConf(livello, doc);
            conf = conf.Trim();

            for (int i = 0; i < conf.Length; i++)
            {
                if (conf[i] == '1')
                    lista.Add(true);
                else lista.Add(false);
            }
            return lista;

        }

        private string ritornaConf(string livello, XDocument doc)
        {
            var pos = from query in doc.Descendants("livello")
                      where query.Element("id").Value == livello
                      select query.Element("configurazione").Value;
            return pos.First();
        }/*Fine del codice da usare*/





        /// <summary>
        /// Metodo che invoca una mossa sulla scacchiera e decreta la vittoria o meno controllando se tutta la scacchiera è settata a false
        /// pre: passo due parametri interi da 0 a 4
        /// post: cambia la scacchiera secondo la mossa data
        /// </summary>
        /// <param name="x">Ascissa della mossa fatta, da 0 a 4</param>
        /// <param name="y">Ordinata  della mossa fatta, da 0 a 4</param>
        /// <returns>Un booleano che decreta se hai vinto o meno</returns>
        /*
        public bool Mossa(int x, int y)
        {
            //aumenta il contatore delle mosse effettuate
            mosse++;


            //sistema le tre caselle orizzontali
            switch (x)
            {
                case 0:
                    {
                        scacchiera[1, y] = !scacchiera[1, y];
                        scacchiera[0, y] = !scacchiera[0, y];
                        scacchiera[4, y] = !scacchiera[4, y];
                        break;
                    }//end of case x==0
                case 4:
                    {
                        scacchiera[0, y] = !scacchiera[0, y];
                        scacchiera[4, y] = !scacchiera[4, y];
                        scacchiera[3, y] = !scacchiera[3, y];
                        break;
                    }//end of case x==5
                default:
                    {
                        scacchiera[x + 1, y] = !scacchiera[x + 1, y];
                        scacchiera[x, y] = !scacchiera[x, y];
                        scacchiera[x - 1, y] = !scacchiera[x - 1, y];
                        break;
                    }//end of case 1<x<5
            }//end of switch

            switch (y)
            {
                case 0:
                    {
                        scacchiera[x, 1] = !scacchiera[x, 1];
                        scacchiera[x, 4] = !scacchiera[x, 4];
                        break;
                    }//end of case y==0
                case 4:
                    {
                        scacchiera[x, 3] = !scacchiera[x, 3];
                        scacchiera[x, 0] = !scacchiera[x, 0];
                        break;
                    }//end of case y==5
                default:
                    {
                        scacchiera[x, y + 1] = !scacchiera[x, y + 1];
                        scacchiera[x, y - 1] = !scacchiera[x, y - 1];
                        break;
                    }//end of case 1<y<5
            }//end of switch
        
            //Controlla se esiste almeno una luce accesa e in tal caso dì che non hai ancora vinto (false) 
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (scacchiera[i, j] == true) return false;
                }
            }//end of nested for



            Altrimenti ritorna che hai vinto (true!) 
            return true;
        }
*/

        /// <summary>
        /// metodo che aggiorna il best_score del livello
        /// </summary>
        /// <returns>the void</returns>


    }
}
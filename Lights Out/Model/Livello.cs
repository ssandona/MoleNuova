using Lights_Out.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace PhoneApp1
{
    [DataContract] 
    public class Livello: INotifyPropertyChanged
    {
      private ObservableCollection<Cella> celle;


        //variabile per il best score del livello, se diverso da 0 significa che il livello è passato 
        private int best_score;
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
            best_score = -1;
            id = cod;
            if (cod != 1)
                avaiable = false;
            else avaiable = true;
            //mosse = 0; all'inizio
            //best_score = serializzazione in base a come era prima 
            //scacchiera = new bool[5, 5];
            //Inizializzo tutte le luci come accese
            for (int i = 0; i < 25; i++)
            {
                if (i % 2 == 0)
                    celle.Add(new Cella(i,true));
                else celle.Add(new Cella(i,false));
            } 

        }


        public ObservableCollection<Cella> Scacchiera{
            get {
                return celle;
            }
        }



        [DataMember] 
        public int Best_Score
        {
            get
            {
                return best_score;
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

        [DataMember] 
        public int Id
        {
            get
            {
                return id;
            }
        }

        public void Mossa(Cella a) {

            int id = a.Id;
            if (id % 5 == 0)
            {
                if (id < 5)
                {
                    celle[id + 1].Stato = true;
                    celle[id + 5].Stato = true;
                }
                else if (id > 19)
                {
                    celle[id - 5].Stato = true;
                    celle[id + 1].Stato = true;
                }
                else
                {
                    celle[id + 1].Stato = true;
                    celle[id - 5].Stato = true;
                    celle[id + 5].Stato = true;
                }
            }
            else if (id % 5 == 4)
            {
                if (id < 5)
                {
                    celle[id - 1].Stato = true;
                    celle[id + 5].Stato = true;
                }
                else if (id > 19)
                {
                    celle[id - 1].Stato = true;
                    celle[id - 5].Stato = true;
                }
                else
                {
                    celle[id - 1].Stato = true;
                    celle[id - 5].Stato = true;
                    celle[id + 5].Stato = true;
                }
            }
            else {
                celle[id - 1].Stato = true;
                celle[id + 1].Stato = true;
                celle[id - 5].Stato = true;
                celle[id + 5].Stato = true;
            }
                          
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropName));
        }





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
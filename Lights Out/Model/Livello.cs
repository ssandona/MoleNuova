<<<<<<< HEAD
﻿using Lights_Out;
=======
﻿using Lights_Out.Model;
>>>>>>> Button game.xaml
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace PhoneApp1
{
<<<<<<< HEAD
    
    public class Livello/*: INotifyPropertyChanged*/
    {
        //private bool[,] scacchiera;


      private ObservableCollection<Boolean> scacchiera;
        /*
        for(qualcosa)
            scacchiera.add(new Cella(indice_x, indice_y));
         * /*
        ...
        scacchiera[0][0].setState("talpa fuori");

        ecc...
       
       la cella avrà un get sfondo per il binding....questa è l'idea che vorremo fare*/


        //variabile per le mosse effettuate fino ad ora
        private int mosse=0;
=======
    [DataContract] 
    public class Livello: INotifyPropertyChanged
    {
      private ObservableCollection<Cella> celle;

>>>>>>> Button game.xaml

        //variabile per il best score del livello, se diverso da 0 significa che il livello è passato 
        private int best_score;
        private int id;
        private bool avaiable;


<<<<<<< HEAD
        public Livello(int id)
        {
            scacchiera = new ObservableCollection<Boolean>();
            //best_score = serializzazione in base a come era prima 
            //Inizializzo tutte le luci come accese
            for (int i = 0; i < 25; i++)
            {
                if (i % 2 == 0)
                    scacchiera.Add(true);
                else scacchiera.Add(false);
            }

            /*
             * //Costrutto di deserializzazione
            try
            {
                MemoryStream ms = new MemoryStream();
                DataContractSerializationHelper.Serialize(ms, new Livello(id));
                ms.Position = 0;
                var sampleData = DataContractSerializationHelper.Deserialize(ms, typeof(Livello));
                ms.Close();
            }
            catch
            {
                throw new Exception("Livello inesistente");
            }
            */

        }//end of Scacchiera(livello) Constructor
        /*
        public event PropertyChangedEventHandler PropertyChange;
        private void NotifyPropertyChanged(string PropName) { 
        
        if(PropertyChange!=null)
            
        }
        */
=======
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

       
        public int Id
        {
            get
            {
                return id;
            }
        }

        public void Mossa(Cella a) {

            int id = a.Id;
            if (id%5 == 0) //prima colonna
            {
                if (id ==0)
                {
                    celle[1].Stato = true;
                    celle[5].Stato = true;
                }
                else if (id==20)
                {
                    celle[15].Stato = true;
                    celle[21].Stato = true;
                }
                else
                {
                    celle[id+1].Stato = true;
                    celle[id-5].Stato = true;
                    celle[id+5].Stato = true;
                }
            }
            else if (id % 5 == 4) //ultima colonna
            {
                if (id==4)
                {
                    celle[3].Stato = true;
                    celle[9].Stato = true;
                }
                else if (id==24)
                {
                    celle[23].Stato = true;
                    celle[19].Stato = true;
                }
                else
                {
                    celle[id-1].Stato = true;
                    celle[id-5].Stato = true;
                    celle[id+5].Stato = true;
                }
            }
            else if (id < 5)
            {
                celle[id-1].Stato = true;
                celle[id+1].Stato = true;
                celle[id+5].Stato = true;
            }
            else if(id>19){ 
                celle[id - 1].Stato = true;
                celle[id + 1].Stato = true;
                celle[id - 5].Stato = true;
            }
            else {
            celle[id - 1].Stato = true;
                celle[id + 1].Stato = true;
                celle[id - 5].Stato = true;
                celle[id+5].Stato = true;
            
            }
            celle[id].Stato = true;
                          
        }
>>>>>>> Button game.xaml


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropName));
        }


<<<<<<< HEAD
=======



        /// <summary>
        /// Metodo che invoca una mossa sulla scacchiera e decreta la vittoria o meno controllando se tutta la scacchiera è settata a false
        /// pre: passo due parametri interi da 0 a 4
        /// post: cambia la scacchiera secondo la mossa data
        /// </summary>
        /// <param name="x">Ascissa della mossa fatta, da 0 a 4</param>
        /// <param name="y">Ordinata  della mossa fatta, da 0 a 4</param>
        /// <returns>Un booleano che decreta se hai vinto o meno</returns>
        /*
>>>>>>> Button game.xaml
        public bool Mossa(int x, int y)
        {
            //aumenta il contatore delle mosse effettuate
            mosse++;


            //sistema le tre caselle orizzontali
            /*
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
<<<<<<< HEAD
            */
            /* Controlla se esiste almeno una luce accesa e in tal caso dì che non hai ancora vinto (false) */
            for (int i = 0; i < 25; i++)
=======
        
            //Controlla se esiste almeno una luce accesa e in tal caso dì che non hai ancora vinto (false) 
            for (int i = 0; i < 5; i++)
>>>>>>> Button game.xaml
            {
                    if (scacchiera[i] == true) return false;
               
            }//end of nested for



<<<<<<< HEAD
            /* Altrimenti ritorna che hai vinto (true!) */
            salva_score();
=======
            Altrimenti ritorna che hai vinto (true!) 
>>>>>>> Button game.xaml
            return true;
        }
*/

        /// <summary>
        /// metodo che aggiorna il best_score del livello
        /// </summary>
        /// <returns>the void</returns>


    }
}
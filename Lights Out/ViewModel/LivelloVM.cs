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
    public class LivelloVM: INotifyPropertyChanged{
    private ObservableCollection<Cella> celle;
    private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        private Livello livAttuale;
       /*private Livello successivo;*/
        private int mosse;
        /*private string MoleIn = "Images/mole_in.png";
        private string MoleOut = "Images/mole_out.png";*/


        public void Move(int CodCella) {
            
            List<int> a = livAttuale.Mossa(CodCella);
            /*MessageBox.Show(""+celle[CodCella].Stato);*/
            /*string stato = "";
            foreach (int el in a)
            {
                string stat = "Stato" + el;
                
                RaisePropertyChanged(stat);
            }*/
            /*string stato = "Stato" + CodCella.ToString();
            RaisePropertyChanged(stato);*/
            this.addMossa();
            /*for(int i=0;i<25;i++)
            stato = stato + celle[i].Stato;
            MessageBox.Show(stato);*/
           // MessageBox.Show("" + celle[CodCella].Stato);
            if (livAttuale.Completo())
            {
                livAttuale.Best_Score = mosse.ToString();
                /*Aggiungo alle settings bestscore+id*/
                if (appSettings.Contains("bestscore"+livAttuale.Id))
                    {
                        /* Rimuovi per poi aggiungere*/
                        appSettings.Remove("bestscore"+livAttuale.Id);
                    }
                appSettings.Add("bestscore" + livAttuale.Id, livAttuale.Best_Score);
                
                MessageBox.Show("Ti ga vinto more!");
                //NavigationService.Navigate(new Uri("/LivelloCompletato.xaml", UriKind.Relative));

            }


            
        }


        /*public string Stato0
        {
            get
            {
                if (celle[0].Stato==true)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato1
        {
            get
            {
                if (celle[1].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato2
        {
            get
            {
                if (celle[2].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato3
        {
            get
            {
                if (celle[3].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato4
        {
            get
            {
                if (celle[4].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato5
        {
            get
            {
                if (celle[5].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato6
        {
            get
            {
                if (celle[6].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato7
        {
            get
            {
                if (celle[7].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato8
        {
            get
            {
                if (celle[8].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato9
        {
            get
            {
                if (celle[9].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato10
        {
            get
            {
                if (celle[10].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato11
        {
            get
            {
                if (celle[11].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato12
        {
            get
            {
                if (celle[12].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato13
        {
            get
            {
                if (celle[13].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato14
        {
            get
            {
                if (celle[14].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato15
        {
            get
            {
                if (celle[15].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato16
        {
            get
            {
                if (celle[16].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato17
        {
            get
            {
                if (celle[17].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato18
        {
            get
            {
                if (celle[18].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato19
        {
            get
            {
                if (celle[19].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato20
        {
            get
            {
                if (celle[20].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato21
        {
            get
            {
                if (celle[21].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato22
        {
            get
            {
                if (celle[22].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato23
        {
            get
            {
                if (celle[23].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }

        public string Stato24
        {
            get
            {
                if (celle[24].Stato)
                    return MoleOut;
                else return MoleIn;
            }
        }*/

           


        public LivelloVM(int i) {
            celle = new ObservableCollection<Cella>();
            livAttuale=new Livello(i);
            //successivo = new Livello(i+1);
            celle=livAttuale.Scacchiera;
            mosse = 0;
        }

        public ObservableCollection<Cella> Celle {
            get {
                return celle;
            }
        }

        /*public Cella CellaAttuale {
            get {
                return cellaAttuale;
            }
            set {
                cellaAttuale = value;
                livAttuale.Mossa(cellaAttuale);
                this.Mosse = 1;
            }
        }*/

        public int Mosse
        {
            get
            {
                return mosse;
            }
        }

        public void addMossa(){
            mosse++;
            RaisePropertyChanged("Mosse");
        }
           

        public Livello LivAttuale {
            get {
                return livAttuale;
            }
        }


        
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropName));
        }

    }

}
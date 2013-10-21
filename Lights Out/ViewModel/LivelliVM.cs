using Lights_Out.Model;
using PhoneApp1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Lights_Out.ViewModel
{
    public class LivelliVM: INotifyPropertyChanged
    {
        private ObservableCollection<Livello> listaLiv;
        private Livello attuale;
        private ObservableCollection<Cella> listaCelleAttuale;
        private int mosse;
        private int best_score;
        private int cod;


        public LivelliVM() {
            listaLiv = new ObservableCollection<Livello>();
            listaCelleAttuale = new ObservableCollection<Cella>();
            listaLiv.Add(new Livello(1));
            listaLiv.Add(new Livello(2));
            listaLiv.Add(new Livello(3));
            cod = -1;
            mosse = -1;
            best_score = -1;
        }

        public LivelliVM(int i)
        {
            listaLiv = new ObservableCollection<Livello>();
            listaCelleAttuale = new ObservableCollection<Cella>();
            listaLiv.Add(new Livello(1));
            listaLiv.Add(new Livello(2));
            listaLiv.Add(new Livello(3));
            this.Attuale = listaLiv[i-1];
        }

        

        public ObservableCollection<Livello> ListaLiv {
            get {
                return listaLiv;
            }
        }

        public int Cod {
            get {
                return cod;
            }
            set {
                if (cod != value) {
                    cod = value;
                    RaisePropertyChanged("Cod");
                }
            }
        }

        public ObservableCollection<Cella> ListaCelleAttuale
        {
            get
            {
                return listaCelleAttuale;
            }
            set {
                if (listaCelleAttuale != value) {
                    listaCelleAttuale = value;
                }
            }
        }

        public int Mosse{
            get {
                return mosse;
            }
        }

        public int BestScore
        {
            get
            {
                return best_score;
            }
        }

        //seleziona/ritorna il livello attuale
        public Livello Attuale
        {
            get
            {
                return attuale;
            }
            set
            {
                if (attuale != value)
                {
                    attuale = value;
                    this.ListaCelleAttuale = attuale.Scacchiera;
                    best_score = attuale.Best_Score;
                    this.Cod = attuale.Id;
                }

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
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
    class LivelloVM: INotifyPropertyChanged{
    private ObservableCollection<Cella> celle;
        private Livello livAttuale;
        private Livello successivo;
        private Cella cellaAttuale;
        private int mosse;



        public LivelloVM(int i) {
            celle = new ObservableCollection<Cella>();
            livAttuale=new Livello(i);
            successivo = new Livello(i+1);
            celle=livAttuale.Scacchiera;
            mosse = 0;
        }

        public ObservableCollection<Cella> Celle {
            get {
                return celle;
            }
        }

        public Cella CellaAttuale {
            get {
                return cellaAttuale;
            }
            set {
                this.cellaAttuale = value;
                this.livAttuale.Mossa(cellaAttuale);
                this.Mosse = 1;
            }
        }

        public int Mosse
        {
            get
            {
                return mosse;
            }
            set
            {
                if (value == 1)
                {
                    mosse++;
                    RaisePropertyChanged("Mosse");
                }
            }
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
using Lights_Out.Model;
using PhoneApp1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace Lights_Out.ViewModel
{
    public class LivelliVM: INotifyPropertyChanged
    {
        private ObservableCollection<Livello> listaLiv;


        public LivelliVM() {
            listaLiv = new ObservableCollection<Livello>();
            Livello uno = new Livello(1);
            Livello due = new Livello(2);
            Livello tre = new Livello(3);

            if (uno.isAvaiable()) { listaLiv.Add(uno); }
            if (due.isAvaiable()) { listaLiv.Add(due); }
            if (tre.isAvaiable()) { listaLiv.Add(tre); }
        }


        

        public ObservableCollection<Livello> ListaLiv {
            get {
                return listaLiv;
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
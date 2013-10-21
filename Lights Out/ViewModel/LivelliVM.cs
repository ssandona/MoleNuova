
﻿using PhoneApp1;

﻿using Lights_Out.Model;
using PhoneApp1;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Lights_Out.ViewModel
{

    /*
    class LivelliVM: INotifyPropertyChanged
    {
        ObservableCollection<Livello> livelli=new ObservableCollection<Livello>();

        public LivelliVM() { 
            for(int i=1; i<5 ;i++){

       
        }
    }
    }*/

    public class LivelliVM: INotifyPropertyChanged
    {
        private ObservableCollection<Livello> listaLiv;


        public LivelliVM() {
            listaLiv = new ObservableCollection<Livello>();
            listaLiv.Add(new Livello(1));
            listaLiv.Add(new Livello(2));
            listaLiv.Add(new Livello(3));
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Lights_Out.Model
{

    public class Cella: INotifyPropertyChanged
    {
        private int id;
        private bool stato;

        public Cella(int cod, bool st) {
            stato = st;
            id = cod;
        }


        public int Id {
            get{
                return id;
            }
        }

        public string Sfondo
        {
            get
            {
                if (stato)
                    return "Images/mole_out.png";
                else return "Images/mole_in.png";

            }
        }

        public bool Stato
        {
            get
            {
                return stato;
                
            }
        }

        public void changeState(){
            if (stato == false){
                stato = true;
                RaisePropertyChanged("Stato");
                RaisePropertyChanged("Sfondo");
            }
            else{
                stato = false;
                RaisePropertyChanged("Stato");
                RaisePropertyChanged("Sfondo");
                    }
        }
           
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropName){
            if(PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(PropName));
        }
        }

        }


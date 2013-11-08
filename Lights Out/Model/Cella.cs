using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Lights_Out.Model
{
    /// CLASS: classe Model cella gestisce la proprieta stato ed id
    public class Cella: INotifyPropertyChanged
    {
        /// VAR: id della cella
        private int id;

        /// VAR: stato della cella
        private bool stato;
        private bool initial_state;

        /// COSTRUTTORE: prende un id ed uno stato
        public Cella(int cod, bool st) {
            this.stato = st;
            this.initial_state = st;
            this.id = cod;
        }

        public void reset() {
            stato = initial_state;
            RaisePropertyChanged("Sfondo");
        }

        /// GETTER: return id
        public int Id {
            get{
                return id;
            }
        }

        /// GETTER: ritorna il path del background a seconda dello stato
        public string Sfondo
        {
            get
            {
                if (stato)
                    return "Images/mole_out.png";
                else return "Images/mole_in.png";

            }
        }

        /// GETTER: return stato
        public bool Stato
        {
            get
            {
                return stato;
                
            }
        }

        /// METODO: cambia lo stato della cella ed avverte gli Observer del cambiamento sia della variabile stato che sfondo (?)
        public void changeState(){
            if (stato == false){
                stato = true;
                /// (non basta avvertire che cambia sfondo? a qualcuno interessa lo stato?)
                RaisePropertyChanged("Stato");
                RaisePropertyChanged("Sfondo");
            }
            else{
                stato = false;
                RaisePropertyChanged("Stato");
                RaisePropertyChanged("Sfondo");
                    }
        }
           
        /// METODO: implementa interfaccia Notify
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropName){
            if(PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(PropName));
        }
        }

        }


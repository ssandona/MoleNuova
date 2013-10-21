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
        public string sfondo;

        public Cella(int cod, bool st) {
            stato = st;
            if (st == true)
                sfondo = "Images/mole_in.jpg";
            else
                sfondo = "Images/mole_out.jpg";

            id = cod;
        }

        public string Sfondo {

            get { return this.sfondo; }

            
        }



        public int Id {
            get{
                return id;
            }
        }


        public bool Stato
        {
            get
            {
                return stato;
            }
            set
            {
                if (value == true)
                {
                    if (stato == false)
                    {
                        stato = true;
                        sfondo = "Images/mole_in.jpg";
                        RaisePropertyChanged("Stato");
                        RaisePropertyChanged("Sfondo");

                    }
                    else
                    {
                        stato = false;
                        sfondo = "Images/mole_out.jpg";
                        RaisePropertyChanged("Stato");
                        RaisePropertyChanged("Sfondo");

                    }
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropName){
            if(PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(PropName));
        }
        }

        }


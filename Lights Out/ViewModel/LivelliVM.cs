using Lights_Out.Model;
using PhoneApp1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
<<<<<<< HEAD
<<<<<<< HEAD
=======
using System.Xml.Linq;
>>>>>>> fc156e4d9600ff845348bc48b2e3f1bd2adda86b
=======
using System.Xml.Linq;
>>>>>>> fc156e4d9600ff845348bc48b2e3f1bd2adda86b

namespace Lights_Out.ViewModel
{
    public class LivelliVM: INotifyPropertyChanged
    {
        private ObservableCollection<Livello> listaLiv;


        public LivelliVM() {
            listaLiv = new ObservableCollection<Livello>();
<<<<<<< HEAD
<<<<<<< HEAD
            Livello uno = new Livello(1);
            Livello due = new Livello(2);
            Livello tre = new Livello(3);

            if (uno.isAvaiable()) { listaLiv.Add(uno); }
            if (due.isAvaiable()) { listaLiv.Add(due); }
            if (tre.isAvaiable()) { listaLiv.Add(tre); }
=======
=======
>>>>>>> fc156e4d9600ff845348bc48b2e3f1bd2adda86b
            List<int> livelli = caricaLivelli();
            foreach (int id in livelli)
            {
                listaLiv.Add(new Livello(id));
            }
            /*listaLiv.Add(new Livello(1));
            listaLiv.Add(new Livello(2));
            listaLiv.Add(new Livello(3));*/
<<<<<<< HEAD
>>>>>>> fc156e4d9600ff845348bc48b2e3f1bd2adda86b
=======
>>>>>>> fc156e4d9600ff845348bc48b2e3f1bd2adda86b
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

        public List<int> caricaLivelli()
        {
            XDocument doc = XDocument.Load("livelli.xml");
            List<int> lista = new List<int>();
            string conf = ritornaLivelli(doc);
            conf = conf.Trim();
            int c = Convert.ToInt32(conf);
            
            for (int i = 1; i < c+1; i++)
            {
                    lista.Add(i);
            }
            return lista;

        }

        private string ritornaLivelli(XDocument doc)
        {
            var pos = from query in doc.Descendants("livello")
                      select query.Element("id").Value;
            return pos.Last();
        }/*Fine del codice da usare*/

    }

}
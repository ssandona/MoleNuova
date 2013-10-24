using Lights_Out.Model;
using PhoneApp1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml.Linq;


namespace Lights_Out.ViewModel
{
    public class LivelliVM: INotifyPropertyChanged
    {
        private ObservableCollection<Livello> listaLiv;


        public LivelliVM() {
            listaLiv = new ObservableCollection<Livello>();
            List<int> livelli = caricaLivelli();
            foreach (int id in livelli)
            {
                listaLiv.Add(new Livello(id));
            }
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
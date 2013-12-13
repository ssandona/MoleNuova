using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Lights_Out.Model
{
    public class Loader
    {



        /// METODO: carica il livello con id corrispondente e ritorna una lista di configurazione booleana
        public List<bool> caricaLivello(int id)
        {
            /// id compreso tra 1 e 20
            if (id < 0 || id > 20)
                throw new Exception("Livello Inesistente!");

            /// apertura file livelli.xml
            XDocument doc = XDocument.Load("livelli.xml");

            /// lista di booleani per la scacchiera
            List<bool> lista = new List<bool>();

            /// creazione della stringa id da cercare
            string livello = "" + id;

            /// prendo la configurazione del livello
            string conf = ritornaConf(livello, doc);

            /// pulisco il risultato
            conf = conf.Trim();

            /// PARSING della configurazione da stringa di 1001011 a lista di booleani
            for (int i = 0; i < conf.Length; i++)
            {
                if (conf[i] == '1')
                    lista.Add(true);
                else lista.Add(false);
            }
            return lista;

        }

        /// METODO: ritorna la configurazione del livello come una stringa di 110110 
        private string ritornaConf(string livello, XDocument doc)
        {
            /// prendi dal livello con id tale la configurazione
            var pos = from query in doc.Descendants("livello")
                      where query.Element("id").Value == livello
                      select query.Element("configurazione").Value;

            return pos.First();
        }


    }
}

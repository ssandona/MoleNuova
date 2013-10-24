using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PhoneApp1;


namespace Lights_Out.Model
{
    public class Livelli 
    {
       public List<Livello> lista;
        public Livelli() {
            lista = new List<Livello>();
            lista.Add(new Livello(1));
        }
    }
}


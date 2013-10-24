using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PhoneApp1;


namespace Lights_Out.Model
{
    /// CLASS: classe Model contiene una lista di livelli
    public class Livelli 
    {
       /// VAR: lista di livelli
       public List<Livello> lista;

       /// COSTRUTTORE: aggiunge solo il primo livello disponibile (?)
       public Livelli() {
            lista = new List<Livello>();
            lista.Add(new Livello(1));
        }
    }
}


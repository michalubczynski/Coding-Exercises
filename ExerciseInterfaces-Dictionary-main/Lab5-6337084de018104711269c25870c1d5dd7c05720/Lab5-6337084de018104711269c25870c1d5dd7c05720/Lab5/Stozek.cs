using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{

    public class Stozek
    {
        public delegate void ObslugaBledu(string opis);
        public event ObslugaBledu InfoOBledzie;
        private double r, h;
        public double Promien { get { return r; } set { if (value < 0) { InfoOBledzie($"Zla wartosc promienia{value}"); } else r = value; } }
        public double Wysokosc { get { return h; } set { if (value < 0) { InfoOBledzie($"Zla wartosc wysokosci{value}"); } else h = value; } }
        public Stozek(double r, double h) {
            Promien = r;
            Wysokosc = h;        
        }
        public Stozek() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    public class Stozek: Bryla
    {
   
        double Wysokosc { get; set; }
        double Promien { get; set; }

        public Stozek(string nazwa, double gestosc, decimal cenaZaKilo, double wysokosc, double promien):base (nazwa,gestosc,cenaZaKilo) { 
        Wysokosc=wysokosc;
        Promien=promien;
        }
        //public override double ObliczObjetosc() {return 1.0 / 3.0 * Math.PI*Wysokosc*Promien*Promien;}
        public override double ObliczonaObjetosc { get => 1.0 / 3.0 * Math.PI * Wysokosc * Promien * Promien;}
        public override string PobierzIdentyfikator() { return base.PobierzIdentyfikator() +" r:"+ Promien +" h:"+ Wysokosc; }
    }
}
    
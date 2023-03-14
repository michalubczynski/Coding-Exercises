using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    public class Kula: Bryla
    {
        public double Promien { get; set; }
        //public override double ObliczObjetosc(){return Math.PI*(4.00/3.00)*Math.Pow(Promien,3);}
        public override double ObliczonaObjetosc => Math.PI * (4.00 / 3.00) * Math.Pow(Promien, 3);
        public override double ObliczonaMasa => ObliczonaObjetosc*Gestosc;
        public Kula(string nazwa, double gestosc, decimal cenaZaKilo, double promien) : base(nazwa, gestosc, cenaZaKilo)
        {
            Promien = promien;
        }
        public override string PobierzIdentyfikator() { return base.PobierzIdentyfikator()+Promien; }

        public static Kula operator +(Kula a, Kula b) {
            double sumaobj = a.ObliczonaObjetosc + b.ObliczonaObjetosc;
            double r_dopasowaneDo_V = Math.Pow((3*sumaobj)/(4*Math.PI),1.0/3.0);
            Kula zwrotna = new Kula("Sumowana Kula",100 ,5, r_dopasowaneDo_V);
            return zwrotna;
        }
        public static Kula operator -(Kula a, Kula b)
        {
            double sumaobj = a.ObliczonaObjetosc - b.ObliczonaObjetosc;
            double r_dopasowaneDo_V = Math.Pow((3 * sumaobj) / (4 * Math.PI), 1.0 / 3.0);
            Kula zwrotna = new Kula("Sumowana Kula", 100, 5, r_dopasowaneDo_V);
            return zwrotna;
        }
        public static Kula operator ++(Kula a) {
            double sumaobj = a.ObliczonaObjetosc + 1;
            double r_dopasowaneDo_V = Math.Pow((3 * sumaobj) / (4 * Math.PI), 1.0 / 3.0);
            Kula zwrotna = new Kula(a.Nazwa,a.Gestosc, a.CenaZaKg, r_dopasowaneDo_V);
            return zwrotna;
        }

    }
}

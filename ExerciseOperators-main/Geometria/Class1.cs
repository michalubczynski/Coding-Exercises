using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Geometria
{
    public interface IWyswietl: IComparable
    {
        string PobierzIdentyfikator();
    }
    public abstract class Bryla : IWyswietl
    {
        public static Bryla[] bryly;
        private string nazwa;
        private double gestosc;
        private decimal cenaZaKg;
        static int identyfikator = 0;
        public string Nazwa { get { return nazwa; } private set { nazwa = value; } }
        public double Gestosc { get { return gestosc; } private set { gestosc = value; } }
        public decimal CenaZaKg { get { return cenaZaKg; } private set { cenaZaKg = value; } }
        public virtual double ObliczonaMasa { get => ObliczonaObjetosc * Gestosc; }
        public virtual decimal FinalnaCena { get { return (decimal)this.ObliczonaMasa * this.CenaZaKg; } }
        public abstract double ObliczonaObjetosc { get; }
        //public abstract double ObliczObjetosc();
        //public virtual double ObliczMase(){return 0.0;   }
        //public decimal ObliczCene() {return (decimal)ObliczMase() * CenaZaKg;}
        public Bryla(string n, double g, decimal c)
        {
            Nazwa = n;
            Gestosc = g;
            CenaZaKg = c;
            ++identyfikator;
        }

        public int CompareTo(object other) {

            if (other is Student){ return 1; }
            Bryla figura = other as Bryla;
            if (other is Bryla && this.ObliczonaObjetosc > figura.ObliczonaObjetosc ) return 1;
            else if (other is Bryla && this.ObliczonaObjetosc < figura.ObliczonaObjetosc) return -1;
            else { return 0; }
        }

        public virtual string PobierzIdentyfikator() { return identyfikator.ToString() + Nazwa ; }
        public override string ToString()
        {
            return $"ID: {PobierzIdentyfikator()} {Nazwa}: Gestosc:{Gestosc}, Cena/Kg:{CenaZaKg} m:{ObliczonaMasa} Cena:{FinalnaCena} V:{ObliczonaObjetosc}";
        }
    }
}

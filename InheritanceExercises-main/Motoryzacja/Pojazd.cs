using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Motoryzacja
{
    struct RejestrNazw
    {
        DateTime datamodyfikacji { get; set; }
        string Nazwa { get; set; }
        public RejestrNazw(string nazwa, DateTime data)
        {
            this.Nazwa = nazwa;
            this.datamodyfikacji = data;
        }
        public override string ToString() {
            return this.Nazwa + this.datamodyfikacji;
        }
    }
    public class Pojazd
    {
        private string nazwa;
        public string Nazwa { get { return this.nazwa; } set { this.nazwa = value; historiaNazw.Add(new RejestrNazw(this.nazwa, DateTime.Now));  } }
        private int liczbaKół;
        public int LiczbaKół { get { return liczbaKół; } set { if (value < 1 ) { throw new ArgumentException(); } else liczbaKół = value; } }
        private double prędkość;
        public double Prędkość { get { return prędkość; } set { if (value < 0) { throw new ArgumentException(); } else prędkość = value; } }
        public int Lp { get; private set; }
        static private int liczbaPojazdow;
        private List<RejestrNazw> historiaNazw = new List<RejestrNazw>();

         public void WyswietlHistorie(ref ListBox l) { //Dodać do klasy Pojazd metodę WyświetlHistorię przyjmującą jako parametr referencję do listy ListBox, na której chcemy zobaczyć historię zmian nazwy
            foreach (RejestrNazw rejestrNazw in this.historiaNazw) { 
            l.Items.Add(rejestrNazw);
            }
         }


        static Pojazd() {
            liczbaPojazdow = 0;
        }
        
        public Pojazd (string nazwa, int kola, double predkosc):this()
        {
            Nazwa = nazwa;
            LiczbaKół= kola;
            Prędkość= predkosc;
        }
        public Pojazd(string nazwa, double predkosc) : this(nazwa, 4, predkosc)
        {
            Nazwa= nazwa;
            Prędkość = predkosc;
        }
        public Pojazd() {
            ++liczbaPojazdow;
            this.Lp = liczbaPojazdow;
        }
 
        
        public override string ToString() {
            return "Lp."+this.Lp+"/"+Pojazd.liczbaPojazdow+". "+this.Nazwa + ", Kół:" + this.LiczbaKół + " Prędkość:" + this.Prędkość;
        }

    }
    public class PojazdMechaniczny : Pojazd
    {
        public int MocSilnika { get { return this.mocSilnika; } set { if (value > 0) mocSilnika = value; else throw new ArgumentException(); } }
        public int mocSilnika;
        public PojazdMechaniczny(string nazwa, int ilKol, double predkosc, int mocSilnika) : base(nazwa, ilKol, predkosc)
        {
            MocSilnika = mocSilnika;
        }
        public override string ToString()
        {
            return base.ToString() + ", moc silnika:" + this.mocSilnika;
        }
    }
    public sealed class Samochod : PojazdMechaniczny
    {
        public string Marka { get; set; }
        public int liczbaPasazerow;
        public int LiczbaPasazerow { get { return liczbaPasazerow; } set { if (value < 1) { throw new ArgumentException(); } else liczbaPasazerow = value; } }
        public Samochod(string m_nazwa, double predkosc, int moc, string marka, int pasazery) : base(m_nazwa, 4, predkosc, moc)
        {
            LiczbaPasazerow = pasazery;
            Marka = marka;
        }
        public override string ToString()
        {
            return base.ToString() + ", Marka:" + Marka + ", Pasażerów:" + LiczbaPasazerow;
        }
    }
}

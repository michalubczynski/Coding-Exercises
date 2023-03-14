using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Obliczenia;
using Sprzedaz;
namespace Lab6
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        List<Towary> towaryList;
        decimal sredniaCena = 0;
        decimal najwyzszaCena = 0;
        public MainWindow()
        {
            InitializeComponent();
            towaryList = new List<Towary>();
            towaryList.Add(new Towary() { Cena=4.20M, Nazwa="Zielone", KategoryOfProduct = Kategoria.Spozywka,Ilosc=5 });
            towaryList.Add(new Towary() { Cena = 50M, Nazwa = "Bluza", KategoryOfProduct = Kategoria.Odziez, Ilosc=4 });
            towaryList.Add(new Towary() { Cena = 2M, Nazwa = "Banan", KategoryOfProduct = Kategoria.Spozywka, Ilosc=10 });
            towaryList.Add(new Towary() { Cena = 30M, Nazwa = "Szklo", KategoryOfProduct = Kategoria.Spozywka, Ilosc=1 });
            towaryList.Add(new Towary() { Cena = 40M, Nazwa = "Picka", KategoryOfProduct = Kategoria.Spozywka, Ilosc=4 });
            towaryList.Add(new Towary() { Cena = 12.55M, Nazwa = "Czapa", KategoryOfProduct = Kategoria.Odziez, Ilosc=4 });
            towaryList.Add(new Towary() { Cena = 40M, Nazwa = "Toster", KategoryOfProduct = Kategoria.Spozywka, Ilosc=1 });
            towaryList.Add(new Towary() { Cena = 69M, Nazwa = "Soksy", KategoryOfProduct = Kategoria.Odziez, Ilosc=8 });
            towaryList.Add(new Towary() { Cena = 69M, Nazwa = "Posejdon", KategoryOfProduct = Kategoria.Chemia, Ilosc=1 });
            towaryList.Add(new Towary() { Cena = 21.37M, Nazwa = "Domestos", KategoryOfProduct = Kategoria.Chemia, Ilosc=2 });
            
            lstBoxKategorie.Items.Add(Kategoria.Odziez);
            lstBoxKategorie.Items.Add(Kategoria.Chemia);
            lstBoxKategorie.Items.Add(Kategoria.Spozywka);

            var towary = from s in towaryList select s.Cena;
            foreach (var t in towary)
            {
                sredniaCena += t;
                var pomocniczaCena = t;
                if (pomocniczaCena>najwyzszaCena)najwyzszaCena = pomocniczaCena;
            }
            sredniaCena /= towaryList.Count();
            lbl3.Content += sredniaCena.ToString()+"zl";


        }
        public double FunkcjaRosenbrocka(double x, double y) {
            
            return (1-x)*(1-x)+100*(y-x*x)*(y-x*x);
        }

        private void btnF3_Click(object sender, RoutedEventArgs e)
        {
            (double?, double?, double?) wynik;
            wynik = Funkcje.ZnajdzMinimumFunkcji2D(-100, -50, 50, 100, 1000, (x, y) =>
            {
                if (x > -1 && x < 1 && y > -2 && y < 2){
                    return (x * x) + (y * y); 
                }
                else { return 30; } 
            
            });
            MessageBox.Show("x:" + wynik.Item1 + " y:" + wynik.Item2.ToString() + " Wynik:" + wynik.Item3.ToString());
        }

        private void btnF2_Click(object sender, RoutedEventArgs e)
        {
            (double?, double?, double?) wynik;
            wynik = Funkcje.ZnajdzMinimumFunkcji2D(-100, -100, 100, 100, 1000, (x,y)=>((x-4)*(x-4))+((y+2)*(y+2)));
            MessageBox.Show("x:"+wynik.Item1 +" y:"+ wynik.Item2.ToString() + " Wynik:" + wynik.Item3.ToString());
        }

        private void btnRosenbrocka_Click(object sender, RoutedEventArgs e)
        {
            (double?, double?, double?) wynik;
            wynik = Funkcje.ZnajdzMinimumFunkcji2D(0, 0, 1, 1, 1000, FunkcjaRosenbrocka);
            MessageBox.Show("x:" + wynik.Item1 + " y:" + wynik.Item2.ToString() + " Wynik:" + wynik.Item3.ToString());
        }
    
        public (double,double) ObliczKolo(double r)
        {
            double pole = Math.PI * r * r;
            double obwod = 2 * Math.PI * r;
            return (pole, obwod);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            lst1.Items.Clear();
            //var towary = from s in towaryList where s.Ilosc > 5 orderby s.Ilosc descending select s; // Poprawny sposób bez wykorzystania LINQ
            var towarety = (from s in towaryList where s.Ilosc > 5 select s).OrderByDescending(s => s.Ilosc);
            foreach ( var t in towarety)
            lst1.Items.Add(t);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            lst2.Items.Clear();
            var towary = from s in towaryList where s.KategoryOfProduct == (Kategoria)lstBoxKategorie.SelectedIndex select s.Ilosc;
            int suma = 0;
            foreach (var t in towary) { 
            suma += t;
            }
            lst2.Items.Add(suma);

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            lst3.Items.Clear();
            var towaryDoWyswielenia = from s in towaryList where s.Cena > sredniaCena select s.Nazwa +" kosztuje:"+ s.Cena+"zl";//BEZ LINQ
            var towarety = from s in towaryList where s.Cena > (from s2 in towaryList select s2.Cena).Average() select s.Nazwa + " kosztuje:" + s.Cena + "zl"; //Z LINQ
            foreach (var t in towaryDoWyswielenia)
            {
                lst3.Items.Add(t);
            }
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {

            var towar = from s in towaryList where s.Cena == najwyzszaCena select s.Nazwa + " kosztuje:" + s.Cena + "zl";
            int pomocnicza = 0;
            var towarety = (from s in towaryList select s.Cena).Max();//Wykorzystanie LINQ
            MessageBox.Show("Najdroższy towar znaleziony dzieki LINQ kosztuje:"+towarety.ToString()+"zl");
            foreach (var t in towar)
            { 
                    lbl5.Content += " "+t.ToString();
                    if (pomocnicza+1 != towar.Count())
                    {
                        lbl5.Content += "\n lub: ";
                    }
                    pomocnicza++;
            }
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            lst4.Items.Clear();
            for (int i = 0; i < 3; i++)
            {
                decimal sredniaCenaKategorii = 0;
                var towary = from s in towaryList where s.KategoryOfProduct == (Kategoria)i select s.Cena;
                var towaryIl = from s in towaryList where s.KategoryOfProduct == (Kategoria)i select s.Ilosc;
                int ileTowarowWKategorii = 0, iloscTowarowWKategorii = 0;
                foreach (var t in towary)
                {
                    sredniaCenaKategorii += t;
                    var pomocniczaCena = t;
                    if (pomocniczaCena > najwyzszaCena) najwyzszaCena = pomocniczaCena;
                    ileTowarowWKategorii++;

                }
                foreach (var t in towaryIl)
                {
                    iloscTowarowWKategorii += t;
                }
                sredniaCena /= ileTowarowWKategorii;


                lst4.Items.Add((Kategoria)i+", towarow jest:"+ ileTowarowWKategorii+", srednia cena:"+sredniaCena);
            }
            
        }

    }
    public static class LINQMINMAX
    {
        public static (J a, J b) MinMax<I, J>(this IEnumerable<I> Obiekt, Func<I, J> lambda)
        {
            var lista = Obiekt.OrderBy(x => lambda.Invoke(x)).Select(x => lambda.Invoke(x));
            return (lista.First(), lista.Last());
            }
    }

}

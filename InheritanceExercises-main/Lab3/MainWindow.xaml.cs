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
using Motoryzacja;
using System.Threading;

namespace Lab3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        void WyswietlPojazdy(Pojazd[] l)
        {
            foreach (var item in l)
            {
                lstBoxZadA.Items.Add(item);
            }
        }

        private async void btnZadanieA_Click(object sender, RoutedEventArgs e)
        {
            btnZadanieA.IsEnabled = false;
            try
            {

                lstBoxZadA.Items.Clear();
                Pojazd[] p = new Pojazd[5];
                p[0] = new Pojazd("Skuter", 2, 50);
                p[1] = new Pojazd("Quad", 20);
                p[2] = new Pojazd() { Nazwa = "Tesla", Prędkość = 100, LiczbaKół = 2 };
                p[3] = new PojazdMechaniczny("Ciagnik", 4, 15, 60);
                p[4] = new Samochod("Alfina", 140, 140, "Alfa Romero", 4);
                //p[5] = new Samochod("Alfina", 140, 140, "Alfa Romero", 0); // Example of exceptions 
                WyswietlPojazdy(p);
                await Task.Delay(2000);
                this.lstBoxZadA.Items.Add("History of changes:");
                p[0].Nazwa = "NowaNazwa";
                p[0].WyswietlHistorie(ref lstBoxZadA);
            }
            catch (ArgumentException) {
                MessageBox.Show("Incorrect value in vehicle argument");
            }
            
            
        }
    }

}
//Dodajemy bibliotekę klas aplikacji WPF .net framework 
//Dodajemy w LAB3 odwołanie do Motoryzacji
//Dyrektywa Using Motoryzacja

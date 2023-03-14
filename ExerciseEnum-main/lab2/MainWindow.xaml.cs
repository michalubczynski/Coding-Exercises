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

namespace lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        enum rodzaj{
            Sum,
            Min,
            Max
        }
        int oblicz(rodzaj coLiczymy,params int[] liczba) {
            lstboxKontrolka.Items.Clear();
            int wynik=0;
            foreach (int i in liczba) {
                lstboxKontrolka.Items.Add(i); 
            }
            if (coLiczymy == rodzaj.Sum){
                foreach (int i in liczba)
                {
                    wynik += i;
                }
            }
            else if (coLiczymy == rodzaj.Min) {
                int pomocnicza;
                wynik = +999999999;
                foreach (int i in liczba)
                {
                    pomocnicza = i;
                    wynik = Math.Min(wynik, pomocnicza);
                    if(wynik < pomocnicza) pomocnicza=wynik;
                }
            }
            else
            {
                int pomocnicza;
                wynik = -999999999;
                foreach (int i in liczba)
                {
                    pomocnicza = i;
                    wynik = Math.Max(wynik, pomocnicza);
                    if (wynik > pomocnicza) pomocnicza = wynik;
                }
            }
            return wynik;
        }

        private void btnlicz_Click(object sender, RoutedEventArgs e)
        {
            int a=1,b=2,c=3,d=4;
            rodzaj operacja;
            if (rdioMaks.IsChecked == true) operacja = rodzaj.Max;
            else if (rdioMin.IsChecked == true) operacja = rodzaj.Min;
            else operacja = rodzaj.Sum;
            int wynik = oblicz(operacja, a, b, c, d);
            MessageBox.Show(wynik.ToString());
        }
    }
}

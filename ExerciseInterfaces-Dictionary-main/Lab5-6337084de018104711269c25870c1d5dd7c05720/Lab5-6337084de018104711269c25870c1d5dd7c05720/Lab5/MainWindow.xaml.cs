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
using Generyki;
namespace Lab5
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dictionary<string, Student> slownik = new Dictionary<string, Student>();

        public MainWindow()
        {
            InitializeComponent();
            Student s = new Student("Majk1", 5);
            Student s2 = new Student("Wajk2", 4);
            Student s3 = new Student("Majk3", 3);
            Student s4 = new Student("Zajk4", 2);

            slownik.Add("123", s);
            slownik.Add("234", s2);
            slownik.Add("456", s3);
            slownik.Add("789", s4);

            double w1 = KlasaStatyczna.ZnajdzWiekszy<double>(2.00, 3.00);
            Student w3 = KlasaStatyczna.ZnajdzWiekszy<Student>(s4, s2);
            //MessageBox.Show(w3.ToString());

        }

        private void btnStozek_Click(object sender, RoutedEventArgs e)
        {
            Stozek stog = new Stozek();
            stog.InfoOBledzie += action1;
            stog.InfoOBledzie += action2;
            stog.Promien = double.Parse(txtPromien.Text);
            stog.Wysokosc= double.Parse(txtWysokosc.Text);
        }
        public void action1(string s) {
            MessageBox.Show(s);
        }
        public void action2(string s)
        {
            lblbledy.Content = s;
        }

        private void btnSzukajPoAlbumie_Click(object sender, RoutedEventArgs e)
        {
            Student s= new Student();
            if (slownik.TryGetValue(txtNrAlbumu.Text, out s))
            {
                MessageBox.Show($"{s}");
            }
            else MessageBox.Show("Nie znaleziono");

        }

        private void btnInterface_Click(object sender, RoutedEventArgs e)
        {

            Samochod lambo = new Samochod(15);
            MessageBox.Show(lambo.ToString());
            lambo.PobierzLepszWersje();
            MessageBox.Show(lambo.ToString());
            ((IZwiekszany)lambo).Zmien();
            MessageBox.Show("Zwiekszono?"+lambo.ToString());
            ((IZmniejszany)lambo).Zmien();
            MessageBox.Show("Zwiekszono?" + lambo.ToString());
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            DodawanieZadan oknoDodaj = new DodawanieZadan();
            oknoDodaj.ShowDialog();
        }

        private void btnPobierz_Click(object sender, RoutedEventArgs e)
        {
            PobierzZadanie oknoPobierz = new PobierzZadanie();
            oknoPobierz.ShowDialog();
        }
    }
}

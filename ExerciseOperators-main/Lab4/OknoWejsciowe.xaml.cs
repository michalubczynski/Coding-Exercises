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
using System.Windows.Shapes;
using Geometria;
namespace Lab4
{

    public partial class OknoWejsciowe : Window
    {
        public OknoWejsciowe()
        {
            InitializeComponent();
        }
        double Szerokosc { 
            get { 
            return Convert.ToDouble(this.txtSzer.Text);
            }
        }
        double Wysokosc { 
            get
            {
                return Convert.ToDouble(this.txtWysokosc.Text);
            } }

        private void btnKoniec_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student("Majkel","Dzordan");
            Student student2 = new Student("Majkel", "Ezordan");
            List<object> l= new List<object>();
            Kula kula = new Kula("Kuleczka",10,20,30);
            Kula kula2 = new Kula("Kuleczka2", 10, 20, 30);
            Stozek st2 = new Stozek("St",21,31,41,51);
            l.Add(kula+kula2);
            l.Add(st2);
            l.Add(student);
            l.Add(student2);

            l.Sort();
                var Okno = new OknoWyjsciowe(l);
                Okno.ShowDialog();
            
        }

        private void btnStozek_Click(object sender, RoutedEventArgs e)
        {
            if (double.Parse(txtPromien.Text) < 0) { MessageBox.Show("Bledna wartosc promienia stozka"); }
            else if (double.Parse(txtWysokosc.Text) < 0) { MessageBox.Show("Bledna wartosc wysokosci stozka"); }
            else
            {
                Stozek s = new Stozek("Stozek1", 100, 100, double.Parse(txtWysokosc.Text), double.Parse(txtPromien.Text));
                var Okno = new OknoWyjsciowe(s.ToString());
                Okno.lblPole.Visibility = Visibility.Hidden;
                Okno.ShowDialog();
            }

        }

        private void btnKula_Click(object sender, RoutedEventArgs e)
        {
            if (double.Parse(txtPromien.Text) < 0) { MessageBox.Show("Bledna wartosc promienia kuli"); }
            else
            {
                Kula k = new Kula("Kula1", 100, 100, double.Parse(txtPromien.Text));
                var Okno = new OknoWyjsciowe(k.ToString());
                Okno.lblPole.Visibility = Visibility.Hidden;
                Okno.ShowDialog();
            }
        }
    }
}

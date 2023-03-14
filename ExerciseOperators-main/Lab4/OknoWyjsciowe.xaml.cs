using System;
using System.Collections;
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

    public partial class OknoWyjsciowe : Window
    {
        public OknoWyjsciowe(double szerokosc, double wysokosc)
        {
            InitializeComponent();
            this.lblObwod.Content = szerokosc*2+wysokosc*2;
            this.lblPole.Content = szerokosc*wysokosc;

        }
        public OknoWyjsciowe(string s)
        {
            InitializeComponent();
            this.lblObwod.Content = s;
        }
        public OknoWyjsciowe(List<object> b)
        {
            InitializeComponent();
            foreach (var o in b) { lstBox.DodajDoListy(o);  }

        }
         
        private void btnZamyka_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

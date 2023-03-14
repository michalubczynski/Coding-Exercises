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
using Geometria;
namespace Lab4
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOblicz_Click(object sender, RoutedEventArgs e)
        {
            var okno = new OknoWejsciowe();
            okno.ShowDialog();
        }

        private void btnStozek_Click(object sender, RoutedEventArgs e)
        {
            var okno = new OknoWejsciowe();
            okno.txtSzer.Visibility = Visibility.Collapsed;
            okno.txtWysokosc.Visibility = Visibility.Visible;
            okno.txtPromien.Visibility = Visibility.Visible;
            okno.btnKoniec.Visibility = Visibility.Hidden;
            okno.btnKula.Visibility = Visibility.Hidden;
            okno.ShowDialog();

        }

        private void btnKula_Click(object sender, RoutedEventArgs e)
        {
            var okno = new OknoWejsciowe();
            okno.txtSzer.Visibility = Visibility.Collapsed;
            okno.txtWysokosc.Visibility = Visibility.Hidden;
            okno.txtPromien.Visibility = Visibility.Visible;
            okno.btnKoniec.Visibility = Visibility.Hidden;
            okno.btnStozek.Visibility = Visibility.Hidden; 
            okno.ShowDialog();
        }
    }
}

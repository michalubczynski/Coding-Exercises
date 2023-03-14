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
using Generyki;
namespace Lab5
{
    /// <summary>
    /// Logika interakcji dla klasy PobierzZadanie.xaml
    /// </summary>
    public partial class PobierzZadanie : Window
    {
        public PobierzZadanie()
        {
            InitializeComponent();
            Queue<Zadanie> queue = Zadanie.getQue();
            if (queue.Count >= 1)
            {
                this.txtZadanieDoWypisania.Content = queue.Dequeue().ToString();
            }
            else this.txtZadanieDoWypisania.Content = "Brak zadan do wykonania";
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

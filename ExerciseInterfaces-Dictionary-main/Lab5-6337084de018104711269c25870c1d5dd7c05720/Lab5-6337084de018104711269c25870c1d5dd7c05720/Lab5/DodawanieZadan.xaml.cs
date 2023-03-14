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
    /// Logika interakcji dla klasy DodawanieZadan.xaml
    /// </summary>
    public partial class DodawanieZadan : Window
    {
        public DodawanieZadan()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Zadanie zlecone = new Zadanie(txtZadanieInsert.Text);
            this.Close();
        }
    }
}

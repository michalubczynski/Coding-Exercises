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

namespace lab2HOMEWORK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            gwiazda(250,200,150,3,3);
            int a = 5;
            int b = 10;
            Zamien(ref a,ref b);
            MessageBox.Show($"a:{a}, b:{b}");
        }
        void gwiazda(double x_sr,double y_sr, double ramie, int gr_linii, int ilePowtorzen) {
           
            RysujLinie(x_sr - ramie, x_sr + ramie, y_sr, y_sr, Brushes.Beige, gr_linii);
            RysujLinie(x_sr - ramie * 0.66, x_sr + ramie * 0.66, y_sr - ramie * 0.66, y_sr + ramie *0.66, Brushes.Beige, gr_linii);
            RysujLinie(x_sr - ramie * 0.66, x_sr + ramie * 0.66, y_sr + ramie * 0.66, y_sr - ramie * 0.66, Brushes.Beige, gr_linii);
            
            if(ilePowtorzen > 0)
            {
 
                gwiazda(x_sr + ramie, y_sr , ramie / 3, gr_linii, ilePowtorzen-1);//rgt
                gwiazda(x_sr - ramie, y_sr, ramie / 3, gr_linii, ilePowtorzen-1);//lft

                gwiazda(x_sr + ramie * 0.66, y_sr - ramie * 0.66, ramie / 3, gr_linii, ilePowtorzen-1);//rgt bot
                gwiazda(x_sr - ramie * 0.66, y_sr - ramie * 0.66, ramie / 3, gr_linii, ilePowtorzen-1);//lft bot

                gwiazda(x_sr - ramie * 0.66, y_sr + 0.66 * ramie, ramie / 3, gr_linii, ilePowtorzen-1);//lft top
                gwiazda(x_sr + ramie * 0.66, y_sr + 0.66 * ramie, ramie / 3, gr_linii, ilePowtorzen-1);//rgt top
            }

        }
        void RysujLinie(double p_liniiX, double k_liniiX, double p_liniiY, double k_liniiY, Brush kolor_linii = default, int gr_linii = 1)
        {
            if (kolor_linii == null)
            {
                kolor_linii = Brushes.Black;
            }
            var line = new Line();
            line.Stroke = kolor_linii;
            line.StrokeThickness = gr_linii;

            line.X1 = p_liniiX;
            line.X2 = k_liniiX;
            line.Y1 = p_liniiY;
            line.Y2 = k_liniiY;

            cnvPlotno.Children.Add(line);
        }

        void Zamien(ref int A, ref int B) {
            (A, B) = (B, A);
        }

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            lstBox.Items.Clear();
            double[,] tablica_2D = new double[5, 3]
            {
                {1.00,2.34,3.3213},
                {5,6,7},
                {7,8.123,9},
                {9,10,11.123},
                {10.123,11,12}
            };
            string temporary="";
            double sumaw = 0;
            double SumaK1=0,SumaK2=0,SumaK3=0;
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 3; j++) {
                    temporary += tablica_2D[i, j].ToString("#.# , ");
                    sumaw += tablica_2D[i, j];
                }
                SumaK1 += tablica_2D[i, 0];
                SumaK2 += tablica_2D[i, 1];
                SumaK3 += tablica_2D[i, 2];

                temporary += sumaw.ToString("[#.##]");
                lstBox.Items.Add(temporary);
                sumaw = 0;
                temporary = "";
            }
            temporary = SumaK1.ToString("[#.#] ") + SumaK2.ToString("[#.#] ") + SumaK3.ToString("[#.#]");
            lstBox.Items.Add(temporary);



        }

        private void btnJagged_Click(object sender, RoutedEventArgs e)
        {
            lstBox.Items.Clear();
            int[][] tablicaJagged = new int[3][];

            int z = 6, pomocnicza = 2 ;
            string temporary = "";

            for (int i = 0; i < 3; i++) {
                tablicaJagged[i] = new int[z];
                for (int j = z-1; j > 0; j--) {
                    tablicaJagged[i][j] = pomocnicza;
                    temporary += tablicaJagged[i][j].ToString("#.# , ");
                    pomocnicza++;
                }
                lstBox.Items.Add(temporary);
                temporary = "";
                pomocnicza = 2;
                z--;
            }
        }
    }
}

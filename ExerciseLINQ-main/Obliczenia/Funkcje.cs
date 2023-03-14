using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obliczenia
{
    public static class Funkcje
    {
        public static (double?, double?, double?) ZnajdzMinimumFunkcji2D(int minX, int maxX, int minY, int maxY, int liczbaIteracji, Func<double, double, double> d)
        {
            Random rnd = new Random();
            double? najx = null, najy = null, najWynik = null;

            for (int i = 0; i <= liczbaIteracji; i++) {
                double x = rnd.NextDouble() - (maxX - minX) + minX;
                double y = rnd.NextDouble() - (maxY - minY) + minY;
                double wynik  = d(x, y);
                if (najWynik == null || wynik < najWynik) { 
                najWynik=wynik;
                najx=x;
                najy=y;
                }
            }
            (double?, double?, double?) Fwynik;
            Fwynik.Item1= najx;
            Fwynik.Item2= najy;
            Fwynik.Item3= najWynik;
            return Fwynik;
        }
    }
}

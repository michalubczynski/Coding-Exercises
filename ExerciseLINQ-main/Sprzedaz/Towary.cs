using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprzedaz
{
    public enum Kategoria
    {
        Odziez,
        Chemia,
        Spozywka
    }
    public class Towary
    {
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }
        public Kategoria KategoryOfProduct { get; set; }



        public override string ToString()
        {
            return KategoryOfProduct.ToString()+" "+Ilosc+"*"+Nazwa+" za:"+Cena+"zl";
        }
    }
}

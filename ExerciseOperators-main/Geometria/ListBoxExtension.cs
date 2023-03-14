using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Geometria
{
    public static  class ListBoxExtension
    {
        public static void DodajDoListy(this ListBox l, object iw) {
            if (iw is IWyswietl) {
                l.Items.Add((IWyswietl)iw);
            }
        }
    }
}

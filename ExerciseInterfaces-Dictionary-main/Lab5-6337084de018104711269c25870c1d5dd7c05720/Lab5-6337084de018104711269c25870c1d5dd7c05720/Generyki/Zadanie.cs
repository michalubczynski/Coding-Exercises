using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generyki
{
    public class Zadanie
    {
        private static Queue<Zadanie> queue = new Queue<Zadanie>();
        private string Opis { get; set; }
        private DateTime Czas { get; set; }
        public Zadanie(string opis)
        {
            Opis = opis;
            Czas = DateTime.Now;
            queue.Enqueue(this);
        }
        public static Queue<Zadanie> getQue() {
            return queue;
        }
        public static void setQueue(string s) {
            Zadanie zlecone = new Zadanie(s);
        }
        public override string ToString()
        {
            return "Zlecone:"+this.Czas.ToString("M") +". Musisz:"+this.Opis;
        }
    }
}

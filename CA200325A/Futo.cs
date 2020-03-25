using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA200325A
{
    class Futo
    {
        public string Nev { get; set; }
        public int Rajtszam { get; set; }
        public bool Kategoria { get; set; }
        public TimeSpan Versenyido { get; set; }
        public int Szazalek { get; set; }

        public string VersenyidoString =>

            string.Format("{0:00}:{1:00}:{2:00}",
                Versenyido.Days * 24 + Versenyido.Hours,
                Versenyido.Minutes,
                Versenyido.Seconds);

        public Futo(string s)
        {
            var t = s.Split(';');

            Nev = t[0];
            Rajtszam = int.Parse(t[1]);
            Kategoria = t[2] == "Ferfi";

            var ido = t[3].Split(':');

            Versenyido = new TimeSpan(int.Parse(ido[0]), int.Parse(ido[1]), int.Parse(ido[2]));
            Szazalek = int.Parse(t[4]);

        }
    }
}

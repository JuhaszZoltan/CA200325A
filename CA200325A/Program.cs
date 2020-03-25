using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA200325A
{
    class Program
    {
        static List<Futo> versenyzok;
        static void Main()
        {
            Beolvas();
            F03();
            //FTeszt();
            F04();
            Console.ReadKey();
        }

        private static void F04()
        {
            var c = versenyzok.Count(f => !f.Kategoria && f.Szazalek == 100);
            Console.WriteLine($"f04: {c}");
        }

        private static void FTeszt()
        {
            foreach (var f in versenyzok)
            {
                Console.WriteLine(f.VersenyidoString);
            }
        }
        private static void F03()
        {
            Console.WriteLine($"f03: {versenyzok.Count}");
        }
        private static void Beolvas()
        {
            versenyzok = new List<Futo>();
            var sr = new StreamReader(@"..\..\Res\ub2017egyeni.txt", Encoding.UTF8);

            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                versenyzok.Add(new Futo(sr.ReadLine()));
            }
            sr.Close();
        }
    }
}

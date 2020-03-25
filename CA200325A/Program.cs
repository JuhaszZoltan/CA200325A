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
            F05();
            F07();
            F08("no");
            F08("ferfi");
            
            Console.ReadKey();
        }

        private static void F08(string sex)
        {

            Futo r = versenyzok
                .Where(f => f.Kategoria == (sex == "ferfi") && f.Szazalek == 100)
                .OrderBy(f => f.Versenyido)
                .First();

            Console.WriteLine($"f08: {sex}: {r.Nev} ({r.Rajtszam}.) - {r.VersenyidoString}");
        }

        private static void F07()
        {
            double r = versenyzok
                .Where(f => f.Kategoria && f.Szazalek == 100)
                .Average(f => f.IdoOraban);

            Console.WriteLine($"f07: {r}");
        }

        private static void F05()
        {
            Console.Write("f05 input: ");
            string nev = Console.ReadLine();
            
            int r = versenyzok
                .Where(f => f.Nev == nev)
                .Select(f => f.Szazalek)
                .FirstOrDefault();

            if(r != 0)
            {
                Console.WriteLine($"f05: {nev} indult a versenyen\n" +
                    $"{(r == 100 ? "\t" : "\tnem ")}teljesítette a teljes távolt");
            }
            else Console.WriteLine($"f05: nem indult {nev} nevű");

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

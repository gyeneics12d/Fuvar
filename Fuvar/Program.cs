using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fuvar
{
    class Fuvar
    {
        public int taxi_id { get; set; }
        public string indulas { get; set; }
        public int idotartam { get; set; }
        public double tavolsag { get; set; }
        public double viteldij { get; set; }
        public double borravalo { get; set; }
        public string fizetesmod { get; set; }
        public Fuvar(string sor)
        {
            string[] t = sor.Split(';');
            taxi_id = int.Parse(t[0]);
            indulas = t[1];
            idotartam = int.Parse(t[2]);
            tavolsag = double.Parse(t[3]);
            viteldij = double.Parse(t[4]);
            borravalo = double.Parse(t[5]);
            fizetesmod = t[6];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Fuvar> fuvarok = new List<Fuvar>();
            foreach (var sor in File.ReadAllLines("fuvar.csv").Skip(1))
            {
                fuvarok.Add(new Fuvar(sor));
            }

            Console.WriteLine($"3. feladat: {fuvarok.Count}");

            //4.
            double bevetel = 0;
            int db = 0;
            foreach (var f in fuvarok)
            {
                if (f.taxi_id == 6185)
                {
                    bevetel += f.viteldij + f.borravalo;
                    db++;
                }

            }
            Console.WriteLine($"4. feladat: {db} fuvar alatt: {bevetel}$");

            //5.
            int bankkártyás = 0;
            int készpénz = 0;
            foreach (var h in fuvarok)
            {
                if (h.fizetesmod == "bankkártyás")
                {
                    bankkártyás++;
                }
                if (h.fizetesmod == "készpénz")
                {
                    készpénz++;
                }
            }
            //5. b
            /*
            Dictionary<string, int> stat = new Dictionary<string, int>();
            foreach (var f in fuvarok)
            {
                if (stat.ContainsKey(f.fizetesmod))
                {
                    stat[f.fizetesmod]++;
                }
                else
                {
                    stat.Add(f.fizetesmod, 1);
                }
            }
            Console.WriteLine("5. feladat:");
            foreach (var s in stat)
            {
                Console.WriteLine($"\t {s.Key}: {s.Value} fuvar");
            }
            */
            //5.c
            Console.WriteLine("5. feladat:");
            fuvarok
                .GroupBy(x => x.fizetesmod)
                .Select(g => new { fizetésmód = g.Key, db = g.Count() })
                .ToList()
                .ForEach(x => Console.WriteLine($"\t {x.fizetésmód}: {x.db} fuvar"));


            Console.ReadKey();
        }
    }
}

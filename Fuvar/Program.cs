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
                Console.WriteLine($"4.feladat: {db} fuvar alatt: {bevetel}");

                Console.ReadKey();
            }
        }
    }
}

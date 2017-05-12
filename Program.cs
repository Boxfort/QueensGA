using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueensGA
{
    class Program
    {
        static void Main(string[] args)
        {
            Solver sv = new Solver();

            for (int i = 0; i < 1000; i++)
            {
                sv.EvolvePopulation();
            }

            sv.DrawFittest();
            Console.ReadKey();
        }
    }
}

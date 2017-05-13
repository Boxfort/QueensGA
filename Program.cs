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

            for (int i = 0; i < 100; i++)
            {
                sv.EvolvePopulation();

               // Console.WriteLine("Iteration " + i + " of 100");
            }

            sv.DrawFittest();
            Console.ReadKey();
        }
    }
}

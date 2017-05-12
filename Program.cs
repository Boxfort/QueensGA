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

            sv.EvolvePopulation();
            Console.ReadKey();
        }
    }
}

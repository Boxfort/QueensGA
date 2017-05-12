using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueensGA
{
    class Solver
    {
        private const int POPULATION_SIZE = 100;
        private const double MUTATION_RATE = 0.015;
        private const int TOURNAMENT_SIZE = 5;
        private const bool ELITISM = true;

        Population population;

        public Solver()
        {
            population = new Population(POPULATION_SIZE, true);
        }

        public void EvolvePopulation()
        {
            Population newPopulation = new Population(POPULATION_SIZE, false);

            int elitismOffset = 0;
            if (ELITISM)
            {
                newPopulation.SaveSolution(0, population.GetFittest());
                elitismOffset = 1;
            }

            for (int i = elitismOffset; i < POPULATION_SIZE; i++)
            {
               //Select parents
               //Create child
               //Add child to population
            }

            //Mutate Population
        }

        
    }
}

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

        private Population _population;

        public Solver()
        {
            _population = new Population(POPULATION_SIZE, true);
        }

        public void EvolvePopulation()
        {
            Population newPopulation = new Population(POPULATION_SIZE, false);

            int elitismOffset = 0;
            if (ELITISM)
            {
                newPopulation.SaveSolution(0, _population.GetFittest());
                elitismOffset = 1;
            }

            for (int i = elitismOffset; i < POPULATION_SIZE; i++)
            {
                Solution parent1 = TournamentSelect(_population);
                Solution parent2 = TournamentSelect(_population);
                Solution child = new Solution(parent1, parent2);

                newPopulation.SaveSolution(i, child);
            }

            //Mutate Population

            _population = newPopulation;
        }

        private Solution TournamentSelect(Population population)
        {
            // Create a tournament population
            Population tournament = new Population(TOURNAMENT_SIZE, false);
            // For each place in the tournament get a random candidate tour and
            // add it
            for (int i = 0; i < TOURNAMENT_SIZE; i++)
            {
                Random rand = new Random();
                tournament.SaveSolution(i, population.GetSolution(rand.Next(POPULATION_SIZE)));
            }
            // Get the fittest tour
            Solution fittest = tournament.GetFittest();
            return fittest;
        }
    }
}

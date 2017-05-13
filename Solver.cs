using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueensGA
{
    class Solver
    {
        private const int POPULATION_SIZE = 500;
        private const double MUTATION_RATE = 0.1;
        private const int TOURNAMENT_SIZE = 30;
        private const bool ELITISM = true;

        private Population _population;
        Random rand = new Random();

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
                Solution child2 = new Solution(parent2, parent1);

                Console.WriteLine("parent1 " + parent1.ToString());
                Console.WriteLine("parent2 " + parent2.ToString());
                Console.WriteLine("child   " + child.ToString());

                newPopulation.SaveSolution(i, child);

                if(++i < POPULATION_SIZE)
                    newPopulation.SaveSolution(i, child2);
            }

            MutatePopulation(newPopulation);

            _population = newPopulation;

            //Console.WriteLine("Fittest = " + _population.GetFittest().EvaluateFitness());
        }

        private void MutatePopulation(Population population)
        {
            for(int i = 0; i < POPULATION_SIZE; i++)
            {
                if(rand.NextDouble() < MUTATION_RATE)
                {
                    population.GetSolution(i).Mutate();
                }
            }
        }

        private Solution TournamentSelect(Population population)
        {
            // Create a tournament population
            Population tournament = new Population(TOURNAMENT_SIZE, false);
            // For each place in the tournament get a random candidate tour and
            // add it
            for (int i = 0; i < TOURNAMENT_SIZE; i++)
            { 
                tournament.SaveSolution(i, population.GetSolution(rand.Next(POPULATION_SIZE)));
            }
            // Get the fittest tour
            Solution fittest = tournament.GetFittest();
            return fittest;
        }

        public void DrawFittest()
        {
            Solution fittest = _population.GetFittest();
            Console.WriteLine("Fittest = " + fittest.EvaluateFitness());

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    bool queen = false;

                    for (int i = 0; i < 8; i++)
                    {
                        if (fittest.GetQueen(i).x == x && fittest.GetQueen(i).y == y)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;

                            Console.Write("X ");
                            queen = true;
                            break;
                        }
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (!queen)
                        Console.Write(0+" ");
                }
                Console.WriteLine("");
            }
        }
    }
}

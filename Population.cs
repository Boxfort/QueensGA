using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueensGA
{
    class Population
    {
        Solution[] solutions;

        public Population(int populationSize)
        {
            solutions = new Solution[populationSize];
        }

        /// <summary>
        /// Evaluate the population and return the fittest solution.
        /// </summary>
        /// <returns>Solution with the lowest fitness.</returns>
        public Solution GetFittest()
        {
            Solution fittest = solutions[0];
            int fittestFitness = fittest.EvaluateFitness();

            for(int i = 0; i < solutions.Length; i++)
            {
                int fitness = solutions[i].EvaluateFitness();
                if(fitness > fittestFitness)
                {
                    fittest = solutions[i];
                    fittestFitness = fitness;
                }
            }

            return fittest;
        }
    }
}

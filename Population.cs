﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueensGA
{
    class Population
    {
        Solution[] solutions;

        public Population(int populationSize, bool initialise)
        {
            solutions = new Solution[populationSize];

            if (initialise)
            {
                Random rand = new Random();

                for (int i = 0; i < solutions.Length; i++)
                {  
                    Solution solution = new Solution();
                    solution.Generate(rand.Next(Int32.MaxValue));
                    solutions[i] = solution;
                }
                
            }
        }

        public void SaveSolution(int index, Solution solution)
        {
            solutions[index] = solution;
        }

        public Solution GetSolution(int index)
        {
            return solutions[index];
        }

        /// <summary>
        /// Evaluate the population and return the fittest solution. Lower is Better.
        /// </summary>
        /// <returns>Solution with the lowest fitness.</returns>
        public Solution GetFittest()
        {
            Solution fittest = solutions[0];
            int fittestFitness = fittest.EvaluateFitness();

            for(int i = 0; i < solutions.Length; i++)
            {
                if (solutions[i] == null)
                    continue;

                int fitness = solutions[i].EvaluateFitness();
                if(fitness < fittestFitness)
                {
                    fittest = solutions[i];
                    fittestFitness = fitness;
                }
            }

            return fittest;
        }
    }
}

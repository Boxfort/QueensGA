using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueensGA
{
    class Solution
    {
        const int NUM_QUEENS = 8;
        const int BOARD_SIZE = 64;

        bool[] board;

        /// <summary>
        /// Initialise a blank soltution.
        /// </summary>
        public Solution()
        {
            board = new bool[BOARD_SIZE];
        }

        /// <summary>
        /// Initialise a new solution which is the child of two parent solutions.
        /// </summary>
        /// <param name="parent1">The first parent solution.</param>
        /// <param name="parent2">The second parent solution.</param>
        public Solution(Solution parent1, Solution parent2)
        {
            //Create a child using both parents.
        }

        /// <summary>
        /// Generate a new random layout of 8 queens.
        /// </summary>
        public void Generate()
        {
            Random rand = new Random();
            int queens = 0;

            while (queens < NUM_QUEENS)
            {
                int position = rand.Next(64);
                if (!board[position])
                {
                    board[position] = true;
                    queens++;
                }
            }
        }

        /// <summary>
        /// Mutate the solution.
        /// </summary>
        public void Mutate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Evaluate the fitness of the solution and return it.
        /// </summary>
        /// <returns>Fitness value of the solution</returns>
        public int EvaluateFitness()
        {
            throw new NotImplementedException();
        }
    }
}

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
        const int ROW_LENGTH = 8;

        //Directions on the board relative to the current position.
        int[] offsets = { -9, -8, -7, 7, 8, 9 };
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
        /// Evaluate the fitness of the solution and return it. Lower is better.
        /// </summary>
        /// <returns>Fitness value of the solution</returns>
        public int EvaluateFitness()
        {
            int fitness = 0;

            for(int i = 0; i < BOARD_SIZE; i++)
            {
                if(board[i])
                {
                    int position = i;

                    //Check in every diagonal, up, and down for presence of queen.
                    foreach(int offset in offsets)
                    {
                        int offsetPos = position;
                        offsetPos += offset;

                        while(offsetPos > 0 && offsetPos < (BOARD_SIZE - 1))
                        {
                            if (board[offsetPos])
                                fitness++;

                            offsetPos += offset;
                        }
                    }

                    //If queen is not at the beginning of a row.
                    if (position % ROW_LENGTH != 0 && position != 0)
                    {
                        //Check to start of row to presence of queens.
                        int leftOffset = position - 1;
                        while (leftOffset % ROW_LENGTH != 0 && leftOffset > 0)
                        {
                            //If a queen is found add 1 to fitness.
                            if (board[leftOffset])
                                fitness++;
                            leftOffset -= 1;
                        }
                    }

                    //If queen is not at the end of a row.
                    if (position % ( ROW_LENGTH - 1 ) != 0 && position != (BOARD_SIZE - 1))
                    {
                        //Check to end of row for presence of queens.
                        int rightOffset = position + 1;
                        while (rightOffset % (ROW_LENGTH - 1) != 0 && rightOffset < (BOARD_SIZE - 1))
                        {
                            //If a queen is found add 1 to fitness.
                            if (board[rightOffset])
                                fitness++;
                            rightOffset -= 1;
                        }
                    }
                }
            }

            return fitness;
        }
    }
}

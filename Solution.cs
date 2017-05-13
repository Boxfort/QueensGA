using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueensGA
{
    struct Queen
    {
        public int x;
        public int y;
    }

    class Solution
    {
        Random rand = new Random();

        const int NUM_QUEENS = 8;
        const int BOARD_SIZE = 64;
        const int ROW_LENGTH = 8;

        //Directions on the board relative to the current position.
        int[] offsets = { -9, -8, -7, 7, 8, 9 };
        Queen[] queens;

        /// <summary>
        /// Initialise a blank soltution.
        /// </summary>
        public Solution()
        {
            queens = new Queen[NUM_QUEENS];
        }

        /// <summary>
        /// Initialise a new solution which is the child of two parent solutions.
        /// </summary>
        /// <param name="parent1">The first parent solution.</param>
        /// <param name="parent2">The second parent solution.</param>
        public Solution(Solution parent1, Solution parent2)
        {
            queens = new Queen[NUM_QUEENS];

            //Create a child using both parents.
            
            int crossover = rand.Next(NUM_QUEENS);

            for(int i = 0; i < crossover; i++)
            {
                queens[i] = parent1.GetQueen(i);
            }

            for (int i = 0; i < NUM_QUEENS; i++)
            {
                if (crossover == NUM_QUEENS - 1)
                    break;

                Queen q = parent2.GetQueen(i);
                if (!QueenExists(q))
                {
                    queens[crossover] = q;
                    crossover++;
                }
            }
        }

        public Queen GetQueen(int index)
        {
            return queens[index];
        }

        /// <summary>
        /// Generate a new random layout of 8 queens.
        /// </summary>
        public void Generate(int seed)
        { 
            //THIS IS SO HACKY FIX THIS
            Random rand = new Random(seed);
            int count = 0;

            while (count < NUM_QUEENS)
            {
                int x = rand.Next(8);
                int y = rand.Next(8);

                Queen q = new Queen();

                q.x = x;
                q.y = y;

                if (!QueenExists(q))
                {
                    queens[count] = q;
                    count++;
                }
            }
        }

        private bool QueenExists(Queen queen)
        {
            foreach(Queen q in queens)
            {
                if (q.x == queen.x && q.y == queen.y)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Mutate the solution by randomising the position of one queen.
        /// </summary>
        public void Mutate()
        {
            Queen q = new Queen();

            do
            {
                int x = rand.Next(8);
                int y = rand.Next(8);

                q.x = x;
                q.y = y;
            }
            while (QueenExists(q));

            int index = rand.Next(NUM_QUEENS);
            queens[index] = q;
        }

        /// <summary>
        /// Evaluate the fitness of the solution and return it. Lower is better.
        /// </summary>
        /// <returns>Fitness value of the solution</returns>
        public int EvaluateFitness()
        {
            int fitness = 0;
            bool[] badqueen = new bool[8];

            for(int i = 0; i < queens.Length; i++)
            {
                for(int j = 0; j < queens.Length; j++)
                {


                    //If horizontal or vertical
                    if ((queens[i].x == queens[j].x || queens[i].y == queens[j].y))
                    {
                        fitness++;
                        badqueen[i] = true;
                        badqueen[j] = true;
                    }

                    //If diagonal
                    int d1 = Math.Abs((queens[i].y+1) - (queens[i].x+1));
                    int d2 = Math.Abs((queens[j].y+1) - (queens[j].x+1));
                    if (d1 == d2)
                    {
                        fitness++;
                        badqueen[i] = true;
                        badqueen[j] = true;
                    }
                }
            }

            return fitness;
        }
    
        public String ToString()
        {
            string output = "";

            for(int i = 0; i < NUM_QUEENS; i++)
            {
                output += "(" + queens[i].x + "," + queens[i].y + ")";
            }

            return output;
        }
    }
}

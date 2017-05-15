using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_4_ai.Model
{
    class RandomAlgoritmicPlayer : AlgoritmicPlayer
    {
        private double randomChance;

        public StupidAlgoritmicPlayer(int maxDepth, string resultsPath, double randomChance) : base(maxDepth, resultsPath)
        {
            this.randomChance = (randomChance > 1 ? 1 : (randomChance < 0 ? 0 : randomChance));
        }

        public override int getSelectedCol(Board board)
        {
            Random random = new Random();
            if (randomChance > random.NextDouble())
            {
                List<int> colsWithSpace = new List<int>();
                for (int col=0; col<board.columns; col++)
                {
                    if (board.colHasSpace(col))
                    {
                        colsWithSpace.Add(col);
                    }
                }
                return colsWithSpace[random.Next(0, colsWithSpace.Count)];
            }
            else
            {
                return base.getSelectedCol(board);
            }
        }

    }
}
